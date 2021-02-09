using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.UI.Notifications;
using Newtonsoft.Json;
using Shotr.Core.Controls.Theme;
using Shotr.Core.Entities;
using Shotr.Core.Entities.Hotkeys;
using Shotr.Core.Model;
using Shotr.Core.Pipes;
using Shotr.Core.Services;
using Shotr.Core.Settings;
using Shotr.Core.UpdateFramework;
using Shotr.Core.Uploader;
using Shotr.Core.Utils;
using Shotr.Ui.Forms;
using Shotr.Ui.Properties;

namespace Shotr.Ui
{
    static class Program
    {
        public static ServiceProvider ServiceProvider;
        private static Mutex _mutex;
        
#if DEBUG
        private static bool _debug = true;
#else
        private static bool _debug = false;
#endif
        
        /// <summary>
        /// Configure services with DI
        /// </summary>
        /// <param name="services"></param>
        static void ConfigureServices(ServiceCollection services)
        {
            // Forms
            services.AddSingleton<MainForm>();
            services.AddSingleton<FfMpegDownload>();
            services.AddSingleton<UpdateForm>();
            
            //services.AddSingleton<CustomUploader>();
            //services.AddTransient<CustomUploaderPrompt>();

            // Settings
            var settings = SettingsService.Load();
            services.AddSingleton(settings);
            services.AddTransient<SettingsService>();
            
            // Plugins
            PluginService.Initialize(services);
            
            // etc
            services.AddSingleton(_ => new dcrypt(Resources.a));
            services.AddSingleton<Uploader>();
            services.AddSingleton<MusicPlayerService>();
            services.AddSingleton<HotKeyService>();
            services.AddSingleton<PipeServer>();
            services.AddSingleton<SingleInstance>();
            services.AddSingleton<KeyboardHook>();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Theme.LoadFonts();
            CreateDirectories();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if THEMEDEBUGGER
            TryEnableDpiAware();
            Application.Run(new ThemeShowcase());
            return;
#endif

#if WINDOWSNOTIFICATION
            var stuff = new ToastContentBuilder()
                .AddText("Shotr")
                .AddText("Image Saved to Clipboard!")
                .AddAppLogoOverride(new Uri(@"C:\Users\zac\Desktop\New Color Logos\Shotr App Icon - full square new color.png"), ToastGenericAppLogoCrop.Circle)
                .AddHeroImage(new Uri(@"C:\Users\Zac\Downloads\_images_2021_02_01_20_gVph8F.mp4.thumbnail.png"))
                .GetToastContent();

            var things = stuff.GetContent();

            XmlDocument x = new XmlDocument();
            x.LoadXml(things);

            ToastNotification toast = new ToastNotification(x);

            ToastNotificationManager.CreateToastNotifier("Shotr").Show(toast);
            Thread.Sleep(10000);
            return;
#endif

            if (args.Length > 0)
            {
                foreach (var arg in args)
                {
                    switch (arg)
                    {
                        case "--debug":
                            _debug = true;
                            break;
                        case "--region":
                        case "--record":
                            PipeClient.SendCommand(args[0]);
                            Environment.Exit(0);
                            break;
                    }
                }
            }

            if (_debug)
            {
                if (!WinApi.AttachConsole(-1)) 
                { 
                    WinApi.AllocConsole();
                }
            }

            Console.SetOut(new ConsoleWriter(_debug));

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            
            _mutex = new Mutex(true, "ShotrMutexHotKeyHook", out var mutex);
            if (!mutex)
            {
                PipeClient.SendCommand("--launch");
                Environment.Exit(0);
                return;
            }

            Console.WriteLine($"Starting Shotr v{Assembly.GetExecutingAssembly().GetName().Version}...");

            var services = new ServiceCollection();

            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            ConfigureApplication();

            TryEnableDpiAware();

            var form = ServiceProvider.GetService<MainForm>();
            var settings = ServiceProvider.GetService<BaseSettings>();
            var hotkeys = ServiceProvider.GetService<HotKeyService>();
            
            hotkeys.LoadHotKeys();
            
            form.SetUpForm(!settings.StartMinimized, !settings.StartMinimized);

            Updater.BaseSettings = settings;
            Updater.OnUpdateCheck += Updater_OnUpdateCheck;
            Updater.CheckForUpdates();
            
            // Do not require mandatory login
            if (settings.Login.Enabled == true)
            {
                try
                {
                    var successfulLogin = false;
                    if (settings.Login.Token is {})
                    {
                        var httpClient = new HttpClient();
                        httpClient.DefaultRequestHeaders.Add("token", settings.Login.Token);
                        // Api call, and make sure token is valid.
                        var response = httpClient.GetAsync("https://shotr.dev/api").Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var content = response.Content.ReadAsStringAsync().Result;
                            var user = JsonConvert.DeserializeObject<LoginResponse>(content);
                            if (user.Token == settings.Login.Token)
                            {
                                settings.Login.Email = user.Email;
                                settings.Login.Token = user.Token;
                                settings.Uploads = user.Uploads;
                                successfulLogin = true;
                            }
                        }
                    }
                
                    if (!successfulLogin)
                    {
                        var loginForm = new LoginForm(settings);
                        if (loginForm.ShowDialog() != DialogResult.OK)
                        {
                            settings.Login.Enabled = false;
                            settings.Login.Token = null;
                            settings.Login.Email = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    File.WriteAllText(Path.Combine(SettingsService.FolderPath, "error.log"), ex.ToString());
                }
            }
            
            DesktopNotificationManagerCompat.RegisterAumidAndComServer<Toast>("Shotr");
            DesktopNotificationManagerCompat.RegisterActivator<Toast>();

            Application.Run(form);
            GC.KeepAlive(_mutex);
            _mutex.ReleaseMutex();
        }

        static void CreateDirectories()
        {
            //Create application directory.
            if (!Directory.Exists(SettingsService.FolderPath))
            {
                Directory.CreateDirectory(SettingsService.FolderPath);
            }
            if (!Directory.Exists(SettingsService.CachePath))
            {
                Directory.CreateDirectory(SettingsService.CachePath);
            }
        }

        static void ConfigureApplication()
        {   
            //check if audio shit is installed, if not then register it.
            var audioSnifferPath = Path.Combine(SettingsService.FolderPath, "audio-sniffer.dll");
            if (!File.Exists(audioSnifferPath))
            {
                //decrypt it and output it
                var dcrypt = ServiceProvider.GetService<dcrypt>();
                File.WriteAllBytes(audioSnifferPath, dcrypt.Decrypt(Resources.audio_sniffer));
                //register it
                var ps = new ProcessStartInfo
                {
                    FileName = "regsvr32.exe",
                    Arguments = "/s audio-sniffer.dll",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    WorkingDirectory = SettingsService.FolderPath
                };
                //ps.Verb = "runas";
                var m = Process.Start(ps);
                m.OutputDataReceived += (_, e) =>
                {
                    Console.WriteLine(e.Data);
                };
                m.WaitForExit();
                m.Close();
            }
            
            //clear out all remaining mp4 files.
            foreach (var file in Directory.GetFiles(SettingsService.CachePath))
            {
                try
                {
                    File.Delete(file);
                }
                catch { }
            }

            // Copy notification image to cache folder.
            if (!File.Exists(Path.Combine(SettingsService.CachePath, "shotr.png")))
            {
                Resources.shotr.Save(Path.Combine(SettingsService.CachePath, "shotr.png"));
            }

            ServicePointManager.DefaultConnectionLimit = 100;
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.UseNagleAlgorithm = false;
            ServicePointManager.ServerCertificateValidationCallback += (_, _, _, _) => true;
        }

        static void Updater_OnUpdateCheck(object sender, UpdaterInfoArgs e)
        {
            var serverVersion = new Version(e.UpdateInfo.Version);
            var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
            var displayVersion = $"{assemblyVersion.Major}.{assemblyVersion.Minor}.{assemblyVersion.Build}";

            var alphaBetaTag = e.UpdateInfo switch
            {
                { ChannelTypeId: 20 } => "a",
                { ChannelTypeId: 30 } => "b",
                _ => string.Empty
            };

            if (serverVersion > assemblyVersion)
            {
                //check if it's an alpha or beta update.
                if (e.UpdateInfo.ChannelTypeId == 20 || e.UpdateInfo.ChannelTypeId == 30)
                {
                    //check if the user has subscribed to them or not.
                    if (!e.Settings.SubscribeToAlphaBeta)
                    {
                        return;
                    }
                }
                //show update form.
                Console.WriteLine($"There is an update available to Shotr - v{serverVersion}{alphaBetaTag}.");
            }
            else
            {
                Console.WriteLine($"You are running Shotr - v{displayVersion}{alphaBetaTag}.");

                return;
            }

            while (Utils.GetForegroundProcess() != null)
            {
                Thread.Sleep(5000);
            }

            if (!WineDetectionService.IsWine())
            {
                Toast.SendUpdateNotifications($"An update to v{serverVersion}{alphaBetaTag} is available!", e.UpdateInfo.Changes, e.UpdateInfo.ChannelTypeId == 20 || e.UpdateInfo.ChannelTypeId == 30);
            }
            else
            {
                var updateForm = new UpdateForm(e.UpdateInfo.Changes, e.Settings.SubscribeToAlphaBeta, false);
                updateForm.ShowDialog();
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            File.WriteAllText(SettingsService.ErrorPath, e.ExceptionObject.ToString());

            var uploader = ServiceProvider.GetService<Uploader>();
            uploader.RemoveHandlers();
            uploader.OnUploaded += (fileShell, result, saveResult, fileType, extension, uploader) =>
            {
                try
                {
                    var m = new WebClient { Proxy = null };
                    m.Headers.Add("User-Agent: Shotr_Error_Reporter");
                    m.UploadValues("https://shotr.io/report_error", new NameValueCollection { { "error", result.PageUrl } });
                }
                catch { }
                MessageBox.Show("Shotr has encountered an error and must close.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            };
            uploader.OnError += (fileShell, allowReupload, fileType, uploader, errorMessage) =>
            {
                MessageBox.Show("Shotr has encountered an error and must close.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            };
            
            uploader.AddToQueue(new FileShell(Encoding.ASCII.GetBytes(e.ExceptionObject.ToString())));
        }

        [DllImport("SHCore.dll")]
        private static extern bool SetProcessDpiAwareness(ProcessDpiAwareness awareness);

        private enum ProcessDpiAwareness
        {
            ProcessDpiUnaware = 0,
            ProcessSystemDpiAware = 1,
            ProcessPerMonitorDpiAware = 2
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetProcessDPIAware();

        public static float MeanDpIprimary = 96f;

        internal static void TryEnableDpiAware()
        {
            try
            {
                SetProcessDpiAwareness(ProcessDpiAwareness.ProcessPerMonitorDpiAware);
            }
            catch
            {
                try
                { // fallback, use (simpler) internal function
                    SetProcessDPIAware();
                }
                catch { }
            }
        }
    }
}

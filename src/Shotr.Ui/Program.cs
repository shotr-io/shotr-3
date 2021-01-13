using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CustomEnvironmentConfig;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Shotr.Core.Model;
using Shotr.Core.Plugin;
using Shotr.Core.Settings;
using Shotr.Core.UpdateFramework;
using Shotr.Core.Uploader;
using Shotr.Core.Utils;
using Shotr.Ui.Forms;
using Shotr.Ui.Forms.Settings;
using Shotr.Ui.Properties;
using ShotrUploaderPlugin;

namespace Shotr.Ui
{
    static class Program
    {
        private static ServiceProvider _serviceProvider;

        private static Form _form;
        /// <summary>
        /// Configure services with DI
        /// </summary>
        /// <param name="services"></param>
        static void ConfigureServices(ServiceCollection services)
        {
            // Forms
            services.AddSingleton<MainForm>();
            services.AddSingleton<AboutForm>();
            services.AddSingleton<FfMpegDownload>();
            services.AddSingleton<LoginForm>();
            services.AddSingleton<UpdateForm>();
            services.AddSingleton<SettingsForm>();
            //services.AddSingleton<CustomUploader>();

            services.AddTransient<ColorPickerForm>();
            services.AddTransient<ErrorNotification>();
            services.AddTransient<GifRecorderForm>();
            services.AddTransient<Notification>();
            services.AddTransient<NoUploadNotification>();
            services.AddTransient<RecordingNotice>();
            services.AddTransient<ScreenshotForm>();
            services.AddTransient<CustomUploaderPrompt>();

            // Settings
            
            // etc
            services.AddSingleton<PluginCore>();
            services.AddSingleton(_ => new dcrypt(Resources.a));
            
        }
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Start(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            TryEnableDpiAware();

            var services = new ServiceCollection();

            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();

            ConfigureApplication();

            var form = _serviceProvider.GetService<MainForm>();

            Application.Run(form);
            GC.KeepAlive(PreRun.Mut);
            PreRun.Mut.ReleaseMutex();
            // End

            PluginCore.Initialize();
            try
            {
                Settings.Instance = new Settings();
                PluginCore.InitCustoms();

                object[] min = Settings.Instance.GetValue("start_minimized");
                var minimized = false;
                if (min != null) minimized = (bool)min[0];
                form = new MainForm
                {
                    ShowInTaskbar = !minimized,
                    Visible = !minimized,
                };

                object[] mini = Settings.Instance.GetValue("program_subscribe_to_alpha_beta_releases");
                Updater.OnUpdateCheck += Updater_OnUpdateCheck;
                Updater.CheckForUpdates((bool?) mini?[0] ?? false);

                if (!File.Exists(SettingsHelper.FolderPath + "\\ffmpeg.exe") || Utils.MD5File(SettingsHelper.FolderPath + "\\ffmpeg.exe") != "76b4131c0464beef626eb445587e69fe")
                {
                    var mpg = new FfMpegDownload();
                    if (mpg.ShowDialog() == DialogResult.Cancel)
                    {
                        Application.Restart();
                        return;
                    }
                }

                var successfulLogin = false;
                var tokenSettings = Settings.Instance.GetValue("shotr.token");
                if (tokenSettings != null && tokenSettings.Length > 0)
                {
                    var token = (string)tokenSettings[0];
                    if (!string.IsNullOrEmpty(token))
                    {
                        var httpClient = new HttpClient();
                        httpClient.DefaultRequestHeaders.Add("token", token);
                        // Api call, and make sure token is valid.
                        var response = httpClient.GetAsync("https://shotr.dev/api").Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var content = response.Content.ReadAsStringAsync().Result;
                            var user = JsonConvert.DeserializeObject<LoginResponse>(content);
                            if (user.Token == token)
                            {
                                Settings.Instance.login = true;
                                Settings.Instance.token = user.Token;
                                Settings.Instance.email = user.Email;
                                successfulLogin = true;
                            }
                        }
                    }
                }
                
                if (!successfulLogin)
                {
                    var loginForm = new LoginForm();
                    if (loginForm.ShowDialog() != DialogResult.OK)
                    {
                        Environment.Exit(0);
                    }
                }
                
            }
            catch(Exception ex) 
            { 
                //write to err.log
                File.WriteAllText(SettingsHelper.FolderPath + "error.log", ex.ToString());
            }
        }

        static void ConfigureApplication()
        {
            //Create application directory.
            if (!Directory.Exists(SettingsHelper.FolderPath))
            {
                Directory.CreateDirectory(SettingsHelper.FolderPath);
            }
            if (!Directory.Exists(SettingsHelper.CachePath))
            {
                Directory.CreateDirectory(SettingsHelper.CachePath);
            }
            
            //check if audio shit is installed, if not then register it.
            var audioSnifferPath = Path.Combine(SettingsHelper.FolderPath, "audio-sniffer.dll");
            if (!File.Exists(audioSnifferPath))
            {
                //decrypt it and output it
                var dcrypt = _serviceProvider.GetService<dcrypt>();
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
                    WorkingDirectory = SettingsHelper.FolderPath
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
            foreach (var file in Directory.GetFiles(SettingsHelper.CachePath))
            {
                try
                {
                    File.Delete(file);
                }
                catch { }
            }

            ServicePointManager.DefaultConnectionLimit = 100;
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.UseNagleAlgorithm = false;
            ServicePointManager.ServerCertificateValidationCallback += (_, _, _, _) => true;
        }
        

        static void Updater_OnUpdateCheck(object sender, UpdaterInfoArgs e)
        {
            if (e.updateInfo == null || e.error)
            {
                return;
            }
            //check version.
            var m = new Version(e.updateInfo.version);
            var curr = Assembly.GetExecutingAssembly().GetName().Version;
            if (m > curr)
            {
                //check if it's an alpha or beta update.
                if (e.updateInfo.alpha || e.updateInfo.beta)
                {
                    //check if the user has subscribed to them or not.
                    if (!(bool)Settings.Instance.GetValue("program_subscribe_to_alpha_beta_releases")[0])
                    {
                        //updat
                        return;
                    }
                }
                //show update form.
                Console.WriteLine("There is an update available to Shotr - v{0}{1}.", m, (e.updateInfo.alpha ? "a" : e.updateInfo.beta ? "b" : ""));               
                if (_form == null)
                {
                    var upd = new UpdateForm(e.updateInfo, e.updateInfo.alpha || e.updateInfo.beta);
                    upd.ShowDialog();
                }
                else
                {
                    //if fullscreen application is running, wait for fullscreen application to stop.
                    while (Utils.GetForegroundProcess() != null)
                    {
                        Thread.Sleep(5000);
                    }
                    _form.Invoke((MethodInvoker)(() =>
                    {
                        _form.Show();
                        var upd = new UpdateForm(e.updateInfo, e.updateInfo.alpha || e.updateInfo.beta);
                        upd.ShowDialog();
                    }));
                }
                Updater.Check = false;
            }
            else if (m == curr)
            {
                //current version.
                if (e.updateInfo.alpha)
                {
                    Console.WriteLine("You are running Shotr - v{0}a.", curr);
                }
                else if(e.updateInfo.beta)
                {
                    Console.WriteLine("You are running Shotr - v{0}b.", curr);
                }
                else
                {
                    Console.WriteLine("You are running Shotr - v{0}.", curr);
                }
            }
            else
            {
                if ((bool)Settings.Instance.GetValue("program_subscribe_to_alpha_beta_releases")[0])
                {
                    //updat
                    return;
                }
                // Downgrade?
                Console.WriteLine("There is an update (downgrade) available to Shotr - v{0}{1}.", m, (e.updateInfo.alpha ? "a" : e.updateInfo.beta ? "b" : ""));
                if (_form == null)
                {
                    var upd = new UpdateForm(e.updateInfo, true);
                    upd.ShowDialog();
                }
                else
                {
                    //if fullscreen application is running, wait for fullscreen application to stop.
                    while (Utils.GetForegroundProcess() != null)
                    {
                        Thread.Sleep(5000);
                    }
                    _form.Invoke((MethodInvoker)(() =>
                    {
                        _form.Show();
                        var upd = new UpdateForm(e.updateInfo, true);
                        upd.ShowDialog();
                    }));
                }
                Updater.Check = false;
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            File.WriteAllText(SettingsHelper.ErrorPath, e.ExceptionObject.ToString());
            Uploader.RemoveHandlers();
            Uploader.OnUploaded += (_, e) =>
            {
                try
                {
                    var m = new WebClient { Proxy = null };
                    m.Headers.Add("User-Agent: Shotr_Error_Reporter");
                    m.UploadValues("https://shotr.io/report_error", new NameValueCollection { { "error", e.PageURL } });
                }
                catch { }
                MessageBox.Show("Shotr has encountered an error and must close.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            };
            Uploader.OnError += (_, e) =>
            {
                MessageBox.Show("Shotr has encountered an error and must close.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            };
            
            Uploader.AddToQueue(new ImageShell(Encoding.ASCII.GetBytes(e.ExceptionObject.ToString()), FileExtensions.txt));
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

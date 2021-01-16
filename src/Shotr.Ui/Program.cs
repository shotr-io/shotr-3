﻿using System;
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
using Newtonsoft.Json;
using Shotr.Core;
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
using Shotr.Ui.Forms.Settings;
using Shotr.Ui.Properties;
using ShotrUploaderPlugin;

namespace Shotr.Ui
{
    static class Program
    {
        private static ServiceProvider _serviceProvider;
        private static Mutex _mutex;
        
#if DEBUG
        private static bool _debug = true;
#else
        private static bool DEBUG = false;
#endif
        
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
            //services.AddTransient<CustomUploaderPrompt>();

            // Settings
            var settings = SettingsService.Load();
            services.AddSingleton(settings);
            services.AddTransient<SettingsService>();
            
            // Plugins
            PluginService.Initialize(services);
            
            // etc
            services.AddSingleton(_ => new dcrypt(Resources.a));
            services.AddTransient<Uploader>();
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            if (args.Length > 0)
            {
                foreach (var arg in args)
                {
                    switch (arg)
                    {
                        case "--debug":
                            if (!WinApi.AttachConsole(-1))
                                WinApi.AllocConsole();
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
            
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            
            _mutex = new Mutex(true, "ShotrMutexHotKeyHook", out var mutex);
            if (!mutex)
            {
                PipeClient.SendCommand("--launch");
                Environment.Exit(0);
                return;
            }

            Console.SetOut(new ConsoleWriter(_debug));

            Console.WriteLine($"Starting Shotr v{Assembly.GetExecutingAssembly().GetName().Version}...");
            
            TryEnableDpiAware();

            var services = new ServiceCollection();

            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();

            ConfigureApplication();

            var form = _serviceProvider.GetService<MainForm>();
            var settings = _serviceProvider.GetService<BaseSettings>();
            var hotkeys = _serviceProvider.GetService<HotKeyService>();
            
            hotkeys.LoadHotKeys();
            
            form.SetUpForm(!settings.StartMinimized, !settings.StartMinimized);
            
            Updater.OnUpdateCheck += Updater_OnUpdateCheck;
            Updater.CheckForUpdates(settings);
            
            if (!File.Exists(SettingsService.FolderPath + "\\ffmpeg.exe") || Utils.MD5File(SettingsService.FolderPath + "\\ffmpeg.exe") != "76b4131c0464beef626eb445587e69fe")
            {
                var mpg = new FfMpegDownload();
                if (mpg.ShowDialog() == DialogResult.Cancel)
                {
                    Application.Restart();
                    return;
                }
            }

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
                            successfulLogin = true;
                        }
                    }
                }
                
                if (!successfulLogin)
                {
                    var loginForm = _serviceProvider.GetService<LoginForm>();
                    if (loginForm.ShowDialog() != DialogResult.OK)
                    {
                        Environment.Exit(0);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                File.WriteAllText(SettingsService.FolderPath + "error.log", ex.ToString());
            }

            Application.Run(form);
            GC.KeepAlive(_mutex);
            _mutex.ReleaseMutex();
        }

        static void ConfigureApplication()
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
            
            //check if audio shit is installed, if not then register it.
            var audioSnifferPath = Path.Combine(SettingsService.FolderPath, "audio-sniffer.dll");
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

            ServicePointManager.DefaultConnectionLimit = 100;
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.UseNagleAlgorithm = false;
            ServicePointManager.ServerCertificateValidationCallback += (_, _, _, _) => true;
        }
        

        static void Updater_OnUpdateCheck(object sender, UpdaterInfoArgs e)
        {
            if (e.UpdateInfo == null || e.Error)
            {
                return;
            }
            //check version.
            var m = new Version(e.UpdateInfo.version);
            var curr = Assembly.GetExecutingAssembly().GetName().Version;
            if (m > curr)
            {
                //check if it's an alpha or beta update.
                if (e.UpdateInfo.alpha || e.UpdateInfo.beta)
                {
                    //check if the user has subscribed to them or not.
                    if (!e.Settings.SubscribeToAlphaBeta)
                    {
                        return;
                    }
                }
                //show update form.
                Console.WriteLine("There is an update available to Shotr - v{0}{1}.", m, e.UpdateInfo.alpha ? "a" : e.UpdateInfo.beta ? "b" : "");

                while (Utils.GetForegroundProcess() != null)
                {
                    Thread.Sleep(5000);
                }
                
                var updateForm = _serviceProvider.GetService<UpdateForm>();
                updateForm.SetUpForm(e.UpdateInfo, e.UpdateInfo.alpha || e.UpdateInfo.beta);
                updateForm.ShowDialog();
                
                Updater.Check = false;
            }
            else if (m == curr)
            {
                //current version.
                if (e.UpdateInfo.alpha)
                {
                    Console.WriteLine("You are running Shotr - v{0}a.", curr);
                }
                else if(e.UpdateInfo.beta)
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
                if (e.Settings.SubscribeToAlphaBeta)
                {
                    return;
                }
                // Downgrade?
                Console.WriteLine("There is an update (downgrade) available to Shotr - v{0}{1}.", m, (e.UpdateInfo.alpha ? "a" : e.UpdateInfo.beta ? "b" : ""));
                while (Utils.GetForegroundProcess() != null)
                {
                    Thread.Sleep(5000);
                }
                
                var updateForm = _serviceProvider.GetService<UpdateForm>();
                updateForm.SetUpForm(e.UpdateInfo, e.UpdateInfo.alpha || e.UpdateInfo.beta);
                updateForm.ShowDialog();
                
                Updater.Check = false;
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            File.WriteAllText(SettingsService.ErrorPath, e.ExceptionObject.ToString());

            var uploader = _serviceProvider.GetService<Uploader>();
            uploader.RemoveHandlers();
            uploader.OnUploaded += (_, e) =>
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
            uploader.OnError += (_, e) =>
            {
                MessageBox.Show("Shotr has encountered an error and must close.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            };
            
            uploader.AddToQueue(new ImageShell(Encoding.ASCII.GetBytes(e.ExceptionObject.ToString()), FileExtensions.txt));
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

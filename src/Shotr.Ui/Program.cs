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
using Newtonsoft.Json;
using Shotr.Core.Model;
using Shotr.Core.Plugin;
using Shotr.Core.UpdateFramework;
using Shotr.Core.Uploader;
using Shotr.Core.Utils;
using Shotr.Ui.Forms;
using Shotr.Ui.Properties;
using ShotrUploaderPlugin;

namespace Shotr.Ui
{
    static class Program
    {
        public static MainForm form;

        private static bool CertCheck(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors policyErrors)
        {
            return true;
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Start(string[] args)
        {
            
            PluginCore.Initialize();
            try
            {
                //resolver.
                //LoadAssemblies();
                //AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                //Create application directory.
                if (!Directory.Exists(Settings.FolderPath))
                {
                    Directory.CreateDirectory(Settings.FolderPath);
                }
                if (!Directory.Exists($"{Settings.FolderPath}\\Cache"))
                {
                    Directory.CreateDirectory($"{Settings.FolderPath}\\Cache");
                }
                //check if audio shit is installed, if not then register it.
                if (!File.Exists(Path.Combine(Settings.FolderPath, "audio-sniffer.dll")))
                {
                    //decrypt it and output it
                    File.WriteAllBytes(Path.Combine(Settings.FolderPath, "audio-sniffer.dll"), Settings.dc.Decrypt(Resources.audio_sniffer));
                    //register it
                    ProcessStartInfo ps = new ProcessStartInfo
                    {
                        FileName = "regsvr32.exe",
                        Arguments = "/s audio-sniffer.dll",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        WorkingDirectory = Settings.FolderPath
                    };
                    //ps.Verb = "runas";
                    Process m = Process.Start(ps);
                    m.OutputDataReceived += m_OutputDataReceived;
                    m.WaitForExit();
                    m.Close();
                }
                //clear out all remaining mp4 files.
                foreach (string file in Directory.GetFiles($"{Settings.FolderPath}\\Cache"))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch { }
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                ServicePointManager.DefaultConnectionLimit = 100;
                ServicePointManager.Expect100Continue = false;
                ServicePointManager.UseNagleAlgorithm = false;
                ServicePointManager.ServerCertificateValidationCallback += CertCheck;

                Settings.Instance = new Settings();
                PluginCore.InitCustoms();
                TryEnableDPIAware();

                /*while (CheckForInternetConnection() == false)
                {
                    MessageBox.Show("No internet connection was detected! Please press 'Ok' to retry.",
                        "Shotr could not connect to the internet!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/

                object[] min = Settings.Instance.GetValue("start_minimized");
                bool minimized = false;
                if (min != null) minimized = (bool)min[0];
                form = new MainForm
                {
                    ShowInTaskbar = !minimized,
                    Visible = !minimized,
                };

                object[] mini = Settings.Instance.GetValue("program_subscribe_to_alpha_beta_releases");
                Updater.OnUpdateCheck += Updater_OnUpdateCheck;
                Updater.CheckForUpdates((bool?) mini?[0] ?? false);

                if (!File.Exists(Settings.FolderPath + "\\ffmpeg.exe") || Utils.MD5File(Settings.FolderPath + "\\ffmpeg.exe") != "76b4131c0464beef626eb445587e69fe")
                {
                    FFMpegDownload mpg = new FFMpegDownload();
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
                
                Application.Run(form);
                GC.KeepAlive(PreRun.mut);
                PreRun.mut.ReleaseMutex();
            }
            catch(Exception ex) 
            { 
                //write to err.log
                File.WriteAllText(Settings.FolderPath + "error.log", ex.ToString());
            }
        }
        
        static void m_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }

        static void Updater_OnUpdateCheck(object sender, UpdaterInfoArgs e)
        {
            if (e.updateInfo == null || e.error)
            {
                return;
            }
            //check version.
            Version m = new Version(e.updateInfo.version);
            Version curr = Assembly.GetExecutingAssembly().GetName().Version;
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
                if (form == null)
                {
                    UpdateForm upd = new UpdateForm(e.updateInfo, e.updateInfo.alpha || e.updateInfo.beta);
                    upd.ShowDialog();
                }
                else
                {
                    //if fullscreen application is running, wait for fullscreen application to stop.
                    while (Utils.GetForegroundProcess() != null)
                    {
                        Thread.Sleep(5000);
                    }
                    form.Invoke((MethodInvoker)(() =>
                    {
                        form.Show();
                        UpdateForm upd = new UpdateForm(e.updateInfo, e.updateInfo.alpha || e.updateInfo.beta);
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
                if (form == null)
                {
                    UpdateForm upd = new UpdateForm(e.updateInfo, true);
                    upd.ShowDialog();
                }
                else
                {
                    //if fullscreen application is running, wait for fullscreen application to stop.
                    while (Utils.GetForegroundProcess() != null)
                    {
                        Thread.Sleep(5000);
                    }
                    form.Invoke((MethodInvoker)(() =>
                    {
                        form.Show();
                        UpdateForm upd = new UpdateForm(e.updateInfo, true);
                        upd.ShowDialog();
                    }));
                }
                Updater.Check = false;
            }
        }

        public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            File.WriteAllText(string.Format("{0}{1}", Settings.FolderPath, "error.log"), e.ExceptionObject.ToString());
            Uploader.RemoveHandlers();
            Uploader.OnUploaded += Uploader_OnUploaded;
            Uploader.OnError += Uploader_OnError;
            Uploader.AddToQueue(new ImageShell(Encoding.ASCII.GetBytes(e.ExceptionObject.ToString()), FileExtensions.txt));
        }

        static void Uploader_OnError(object sender, ImageShell e)
        {
            MessageBox.Show("Shotr has encountered an error and must close.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }

        static void Uploader_OnUploaded(object sender, UploadResult e)
        {
            try
            {
                WebClient m = new WebClient { Proxy = null };
                m.Headers.Add("User-Agent: Shotr_Error_Reporter");
                m.UploadValues("https://shotr.io/report_error", new NameValueCollection { { "error", e.PageURL } });
            }
            catch { }
            MessageBox.Show("Shotr has encountered an error and must close.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }

        [DllImport("SHCore.dll")]
        private static extern bool SetProcessDpiAwareness(PROCESS_DPI_AWARENESS awareness);

        private enum PROCESS_DPI_AWARENESS
        {
            Process_DPI_Unaware = 0,
            Process_System_DPI_Aware = 1,
            Process_Per_Monitor_DPI_Aware = 2
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetProcessDPIAware();

        public static float MeanDPIprimary = 96f;

        internal static void TryEnableDPIAware()
        {
            try
            {
                SetProcessDpiAwareness(PROCESS_DPI_AWARENESS.Process_Per_Monitor_DPI_Aware);
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

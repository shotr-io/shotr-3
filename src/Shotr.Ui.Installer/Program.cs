using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Newtonsoft.Json;
using Shotr.Core.Controls.Theme;
using Shotr.Core.UpdateFramework;
using Shotr.Ui.Installer.Utils;

namespace Shotr.Ui.Installer
{
    static class Program
    {
        public static bool Alpha = false;
        public static bool Silent = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Theme.LoadFonts();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            TryEnableDpiAware();

            //check parent process.
            try
            {
                if (Process.GetCurrentProcess().ParentProcess().ProcessName.ToLower() == "shotr")
                {
                    Silent = true;
                }
            }
            catch
            {

            }

            string? version = null;
            
            foreach (var m in args)
            {
                if (m == "--install-beta")
                {
                    Alpha = true;
                }

                if (m.StartsWith("--version="))
                {
                    version = m.Split("=")[1];
                }

                if (m == "--silent")
                {
                    Silent = true;
                }
            }
            
            UpdaterResponse? response = null;

            try
            {

                var wc = new WebClient();
                var str = wc.DownloadString("https://shotr.dev/api/updates");
                var versions = JsonConvert.DeserializeObject<List<Core.UpdateFramework.UpdaterResponse>>(str);
                if (version is { })
                {
                    response = versions.FirstOrDefault(p => p.Version == version) ?? versions.First();
                }
                else if (Alpha)
                {
                    response = versions.FirstOrDefault(p => p.ChannelTypeId == 20 || p.ChannelTypeId == 30) ??
                               versions.First();
                }
                else
                {
                    response = versions.FirstOrDefault(p => p.ChannelTypeId == 10) ?? versions.First();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The installer could not connect to the internet. Please connect and try again!",
                    "Shotr Installer", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }


            //we're elevated.
            try
            {
                var store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadWrite);
                store.Add(new X509Certificate2(
                    X509Certificate.CreateFromSignedFile(Assembly.GetExecutingAssembly().Location)));
                store.Close();
            }
            catch
            {
            }

            if (Application.ExecutablePath.Contains("uninstall.exe"))
            {
                Application.Run(new UninstallerForm());
                return;
            }

            Application.Run(new InstallerForm(response));
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

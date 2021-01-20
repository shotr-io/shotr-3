using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
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

            foreach (var m in args)
            {
                if (m == "--install-beta")
                {
                    Alpha = true;
                }
                if (m == "--silent")
                {
                    Silent = true;
                }
            }

            //we're elevated.
            try
            {
                var store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadWrite);
                store.Add(new X509Certificate2(X509Certificate.CreateFromSignedFile(Assembly.GetExecutingAssembly().Location)));
                store.Close();
            }
            catch { }

            TryEnableDpiAware();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Application.ExecutablePath.Contains("uninstall.exe"))
            {
                Application.Run(new UninstallerForm());
                return;
            }

            Application.Run(new InstallerForm());
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

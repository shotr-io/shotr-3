using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Shotr.Ui.Pipes;
using Shotr.Ui.Properties;
using Shotr.Ui.Utils;

namespace Shotr.Ui
{
    static class PreRun
    {
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        static dcrypt dc = new(Resources.a);
#if DEBUG
        private static bool DEBUG = true;
#else
        private static bool DEBUG = false;
#endif
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "--debug":
                        if (!AttachConsole(-1))
                        AllocConsole();
                        DEBUG = true;
                    break;
                    case "--region":
                    case "--record":
                        PipeClient.SendCommand(args[0]);
                        Environment.Exit(0);
                        break;
                    case "--dump-settings":
                        LoadAssemblies();
                        AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
                        var settings = new Settings();
                        settings.DumpSettings();
                        Environment.Exit(0);
                        break;
                }
            }

            Console.SetOut(new ConsoleWriter(DEBUG));

            Console.WriteLine("Starting Shotr v{0}...", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            LoadAssemblies();
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            
            Program.Start(args);
        }

        private static Dictionary<string, byte[]> _loadedAssemblies;

        private static void LoadAssemblies()
        {
            /*_loadedAssemblies = new Dictionary<string, byte[]>()
            {
                { "ShotrUploaderPlugin", Resources.ShotrUploaderPlugin },
                { "Newtonsoft.Json", Resources.Newtonsoft },
                { "MetroFramework", Resources.MetroFramework5 },
                { "Shotr.Core.Quantizer", Resources.Shotr_Core_Quantizer },
                { "Shotr.Core", Resources.Shotr_Core },
            };*/
        }
        
        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            /*try
            {
                foreach (KeyValuePair<string, byte[]> assm in _loadedAssemblies)
                {
                    if (args.Name.Contains(assm.Key))
                    {
                        //_loadedAssemblies.Remove(assm.Key);
                        return Assembly.Load(dc.Decrypt(assm.Value));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The executable seems to be corrupted...Please re-download a new copy. Attempted to load assembly: " +args.Name + " - " + ex.ToString());
            }*/
            return null;
        }
        
    }
}

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Shotr.Core;
using Shotr.Core.Pipes;
using Shotr.Core.Utils;

namespace Shotr.Ui
{
    static class PreRun
    {
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
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
                        var settings = new Settings();
                        settings.DumpSettings();
                        Environment.Exit(0);
                        break;
                }
            }

            Console.SetOut(new ConsoleWriter(DEBUG));

            Console.WriteLine("Starting Shotr v{0}...", Assembly.GetExecutingAssembly().GetName().Version);

            Program.Start(args);
        }
    }
}

using System;
using System.Diagnostics;
using System.IO.Pipes;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Shotr.Core.Pipes
{
    public class PipeClient
    {
        public static void SendCommand(string arg)
        {
            try
            {
                NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", "ShotrInputHandler", PipeDirection.InOut, PipeOptions.None);
                Console.WriteLine("[PIPE CLIENT] Connecting to pipe server.\n");

                pipeClient.Connect(2000);

                Console.WriteLine("[PIPE CLIENT] Sending request to pipe server.");
                StreamString ss = new StreamString(pipeClient);

                ss.WriteString(arg);
                Console.WriteLine("[PIPE CLIENT] Sent request to pipe server!");

                pipeClient.Close();
            }
            catch
            {
                //Shotr isn't running. Re-run it?
                MessageBox.Show("Shotr wasn't previously running. Starting Shotr.", "Shotr wasn't running.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.Start(Assembly.GetExecutingAssembly().Location);
                Thread.Sleep(5000);
                SendCommand(arg);
            }
        }
    }
}

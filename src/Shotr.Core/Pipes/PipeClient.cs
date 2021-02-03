using System;
using System.IO.Pipes;
using System.Windows.Forms;

namespace Shotr.Core.Pipes
{
    public class PipeClient
    {
        public static void SendCommand(string arg)
        {
            try
            {
                var pipeClient = new NamedPipeClientStream(".", "ShotrInputHandler", PipeDirection.InOut, PipeOptions.None);
                Console.WriteLine("[PIPE CLIENT] Connecting to pipe server.\n");

                pipeClient.Connect(2000);

                Console.WriteLine("[PIPE CLIENT] Sending request to pipe server.");
                var ss = new StreamString(pipeClient);

                ss.WriteString(arg);
                Console.WriteLine("[PIPE CLIENT] Sent request to pipe server!");

                pipeClient.Close();
            }
            catch (Exception ex)
            {
                //Shotr isn't running. Re-run it?
                Console.WriteLine("[PIPE CLIENT] Sent request to pipe server!");
                MessageBox.Show($"Error when trying to show other instance of Shotr: {ex}", "Can't show Shotr!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Process.Start(Assembly.GetExecutingAssembly().Location);
                //Thread.Sleep(5000);
                //SendCommand(arg);
            }
        }
    }
}

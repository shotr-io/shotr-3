using System;
using System.IO;
using System.IO.Pipes;
using System.Security.AccessControl;
using System.Threading;

namespace Shotr.Core.Pipes
{
    public class PipeServer
    {
        public event EventHandler<PipeServerEventArgs> PipeServerReceivedClient = delegate { };

        public void StartServer()
        {
            Console.WriteLine("[PIPE SERVER] Starting pipe server.");
            new Thread(delegate()
            {
                PipeSecurity ps = new PipeSecurity();
                ps.AddAccessRule(new PipeAccessRule("Everyone", PipeAccessRights.FullControl, AccessControlType.Allow));
                while (true)
                {
                    var pipeServer = new NamedPipeServerStream("ShotrInputHandler", PipeDirection.InOut, 1,
                        PipeTransmissionMode.Message, PipeOptions.WriteThrough, 1024, 1024);
                    //pipeServer.SetAccessControl(ps);
                    try
                    {
                        Console.WriteLine("[PIPE SERVER] Waiting for client...");
                        pipeServer.WaitForConnection();
                        Console.WriteLine("[PIPE SERVER] Got client through pipe server.");
                        try
                        {
                            StreamString ss = new StreamString(pipeServer);
                            string data = ss.ReadString();
                            PipeServerReceivedClient.Invoke(this, new PipeServerEventArgs(data));
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("[PIPE SERVER] ERROR: Pipe client had an error. Code: {0}", e.Message);
                        }
                        pipeServer.Close();
                    }
                    catch
                    {

                    }
                }
            }).Start();
        }
    }

    public class PipeServerEventArgs : EventArgs
    {
        public PipeServerEventArgs(string p)
        {
            _data = p;
        }
        private string _data;
        public string Data { get { return _data; } }
    }
}
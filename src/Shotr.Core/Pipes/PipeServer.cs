using System;
using System.IO;
using System.IO.Pipes;
using System.Security.AccessControl;
using System.Security.Principal;
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
                var ps = new PipeSecurity();
                ps.AddAccessRule(new PipeAccessRule(new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null), PipeAccessRights.ReadWrite, AccessControlType.Allow));
                while (true)
                {
                    var pipeServer = NamedPipeServerStreamConstructors.New("ShotrInputHandler", PipeDirection.InOut, 1,
                        PipeTransmissionMode.Message, PipeOptions.WriteThrough, 1024, 1024, ps);
                    try
                    {
                        Console.WriteLine("[PIPE SERVER] Waiting for client...");
                        pipeServer.WaitForConnection();
                        Console.WriteLine("[PIPE SERVER] Got client through pipe server.");
                        try
                        {
                            var ss = new StreamString(pipeServer);
                            var data = ss.ReadString();
                            Console.WriteLine($"[PIPE SERVER] Received the message: {data}.");
                            PipeServerReceivedClient.Invoke(this, new PipeServerEventArgs(data));
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("[PIPE SERVER] ERROR: Pipe client had an error. Code: {0}", e.Message);
                        }
                    }
                    catch
                    {
                        pipeServer.Close();
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
        public string Data => _data;
    }
}
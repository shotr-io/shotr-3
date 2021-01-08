using System;
using System.IO;
using System.Text;

namespace Shotr.Core
{
    public class ConsoleWriter : TextWriter
    {
        private TextWriter originalOut;
        private bool Debug;

        public ConsoleWriter(bool debug)
        {
            Debug = debug;
            originalOut = Console.Out;
        }

        public override Encoding Encoding
        {
            get { return new ASCIIEncoding(); }
        }
        public override void WriteLine(string message)
        {
            if (Debug)
            {
                originalOut.WriteLine(String.Format("[{0}] -> {1}", DateTime.Now, message));
            }
                
        }
        public override void Write(string message)
        {
            if (Debug)
            {
                originalOut.Write(String.Format("[{0}] -> {1}", DateTime.Now, message));
            }
        }
    }
}

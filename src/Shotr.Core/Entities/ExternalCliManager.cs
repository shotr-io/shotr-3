using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Shotr.Core.Entities
{
    public abstract class ExternalCliManager : IDisposable
    {
        public event DataReceivedEventHandler OutputDataReceived;
        public event DataReceivedEventHandler ErrorDataReceived;

        private Process process;

        public virtual int Open(string path, string args = null)
        {
            if (File.Exists(path))
            {
                var psi = new ProcessStartInfo(path);
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.Arguments = args;
                psi.WorkingDirectory = Path.GetDirectoryName(path);
                psi.StandardOutputEncoding = Encoding.UTF8;
                psi.StandardErrorEncoding = Encoding.UTF8;

                process = new Process();
                process.EnableRaisingEvents = true;
                if (psi.RedirectStandardOutput) process.OutputDataReceived += cli_OutputDataReceived;
                if (psi.RedirectStandardError) process.ErrorDataReceived += cli_ErrorDataReceived;
                process.StartInfo = psi;
                process.Start();
                if (psi.RedirectStandardOutput) process.BeginOutputReadLine();
                if (psi.RedirectStandardError) process.BeginErrorReadLine();
                process.WaitForExit();
                return process.ExitCode;
            }

            return -1;
        }

        public virtual int OpenNoOutput(string path, string args = null)
        {
            if (File.Exists(path))
            {
                var psi = new ProcessStartInfo(path);
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.RedirectStandardInput = true;
                //psi.RedirectStandardOutput = true;
                //psi.RedirectStandardError = true;
                psi.Arguments = args;
                psi.WorkingDirectory = Path.GetDirectoryName(path);
                //psi.StandardOutputEncoding = Encoding.UTF8;
                //psi.StandardErrorEncoding = Encoding.UTF8;

                process = new Process();
                process.EnableRaisingEvents = true;
                //if (psi.RedirectStandardOutput) process.OutputDataReceived += cli_OutputDataReceived;
                //if (psi.RedirectStandardError) process.ErrorDataReceived += cli_ErrorDataReceived;
                process.StartInfo = psi;
                process.Start();
                //if (psi.RedirectStandardOutput) process.BeginOutputReadLine();
                //if (psi.RedirectStandardError) process.BeginErrorReadLine();
                process.WaitForExit();
                return process.ExitCode;
            }

            return -1;
        }

        private void cli_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                if (OutputDataReceived != null)
                {
                    OutputDataReceived(sender, e);
                }
            }
        }

        private void cli_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                if (ErrorDataReceived != null)
                {
                    ErrorDataReceived(sender, e);
                }
            }
        }

        public void WriteInput(string input)
        {
            if (process != null && process.StartInfo != null && process.StartInfo.RedirectStandardInput)
            {
                process.StandardInput.WriteLine(input);
            }
        }

        public virtual void ForceClose()
        {
            if (process != null)
            {
                if(!process.HasExited)
                    process.Kill();
            }
        }

        public virtual void Close()
        {
            if (process != null)
            {
                process.CloseMainWindow();
            }
        }

        public bool Closed
        {
            get
            {
                if (process != null)
                {
                    return process.HasExited;
                }

                return true;
            }
        }

        public void Dispose()
        {
            if (process != null)
            {
                process.Dispose();
            }
        }
    }
}

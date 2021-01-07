using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using Shotr.Ui.DpiScaling;
using Shotr.Ui.UpdateFramework;

namespace Shotr.Ui.Forms
{
    public partial class UpdateForm : DpiScaledForm
    {
        private bool _allowClose = false;

        UpdaterJsonClass upd;
        public UpdateForm(UpdaterJsonClass p, bool allowClose = false)
        {
            InitializeComponent();
            ManualDpiScale();
            ScaleForm = false;
            metroTextBox1.Text = p.changelog;
            TopMost = false;
            if (p.stable)
            {
                metroButton2.Visible = false;
                metroButton1.Location = metroButton2.Location;
                metroLabel2.Text = " An update is ready for download.";

                FormClosing += UpdateForm_FormClosing;
            }
            upd = p;
            _allowClose = allowClose;
        }

        void UpdateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_allowClose)
            {
                e.Cancel = true;
            }
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //start the updating.
            Size = new Size(265, 70);
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - (Size.Width / 2), Screen.PrimaryScreen.WorkingArea.Height / 2 - (Size.Height / 2));
            metroTextBox1.Visible = false;
            metroLabel1.Visible = false;
            metroLabel2.Visible = false;
            metroButton1.Visible = false;
            metroButton2.Visible = false;
            metroProgressSpinner1.Visible = true;
            FormClosing += UpdateForm_FormClosing;
            Text = "Shotr - Updating";
            Movable = true;
            //update shit.
            UpdateFromURL(upd.update_url);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            _allowClose = true;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void metroProgressSpinner1_Click(object sender, EventArgs e)
        {

        }

        private void UpdateFromURL(string url)
        {
            /*CSharpCodeProvider c = new CSharpCodeProvider();
            ICodeCompiler comp = c.CreateCompiler();
            CompilerParameters param = new CompilerParameters();
            param.CompilerOptions = "/t:winexe";
            param.GenerateExecutable = true;
            param.OutputAssembly = Program.FolderPath + "shotr-updater.exe";
            param.ReferencedAssemblies.Add("System.dll");
            string source = "using System; public class Program{public static void Main(){";
            source += "new System.Net.WebClient().DownloadFile(\"" + url + "\", @\"" + Application.ExecutablePath + ".tmp\");";
            source += "foreach(System.Diagnostics.Process p in System.Diagnostics.Process.GetProcessesByName(\"" + Process.GetCurrentProcess().ProcessName + "\")) p.Kill();";
            source += "System.Threading.Thread.Sleep(1000);";
            //source += "foreach(System.Diagnostics.Process p in System.Diagnostics.Process.GetProcessesByName(\"WerFault\")) p.Kill();";
            source += "try { System.IO.File.Delete(@\"" + Application.ExecutablePath + "\"); } catch { } ";
            source += "try { System.IO.File.Move(@\""+ Application.ExecutablePath + ".tmp\", @\"" + Application.ExecutablePath + "\"); } catch { } ";
            source += "System.Diagnostics.Process.Start(@\"" + Application.ExecutablePath + "\");";
            source += "System.Diagnostics.Process.GetCurrentProcess().Kill();";
            source += "}}";
            CompilerResults results = comp.CompileAssemblyFromSource(param, source);
            bool errored = false;
            foreach (CompilerError a in results.Errors)
            {
                try
                {
                    Console.WriteLine(a.ToString());
                }
                catch { }
                errored = true;
            }
            if (!errored)
            {*/
            //download file.
            WebClient m = new WebClient() { Proxy = null };
            try
            {
                m.DownloadFile("https://shotr.io/latest", Program.FolderPath + "Shotr-Installer.exe");
                Process p = new Process();
                p.StartInfo.Verb = "runas";
                p.StartInfo.FileName = Program.FolderPath + "Shotr-Installer.exe";
                p.StartInfo.Arguments = "--run-installer "+((bool)Program.Settings.GetValue("program_subscribe_to_alpha_beta_releases")[0] ? "--install-beta " : "")+"--silent";
                p.Start();
                Environment.Exit(0);
            }
            catch(Exception ex)
            {
                MessageBox.Show("There was an error while updating. Error message: " + ex.ToString());
                _allowClose = true;
                Close();
            }
            //}
        }
    }
}

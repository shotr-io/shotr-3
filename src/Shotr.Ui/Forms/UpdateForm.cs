using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;
using Shotr.Core.Services;
using Shotr.Core.Settings;
using Shotr.Core.UpdateFramework;

namespace Shotr.Ui.Forms
{
    public partial class UpdateForm : DpiScaledForm
    {
        private readonly BaseSettings _settings;
        private bool _allowClose;

        UpdaterResponse _upd;
        public UpdateForm(BaseSettings settings)
        {
            _settings = settings;
            
            InitializeComponent();
            ManualDpiScale();
            ScaleForm = false;
        }

        public void SetUpForm(UpdaterResponse p)
        {
            metroTextBox1.Text = p.Changelog;
            TopMost = false;
            if (p.Stable)
            {
                metroButton2.Visible = false;
                metroButton1.Location = metroButton2.Location;
                metroLabel2.Text = " A new update is available.";
            }
            _upd = p;
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
            Text = "Shotr - Updating";
            Movable = true;
            //update shit.
            UpdateFromUrl(_upd.UpdateUrl);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            _allowClose = true;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void UpdateFromUrl(string url)
        {
            new Thread(delegate()
            {
                //download file.
                var m = new WebClient { Proxy = null };
                try
                {
                    m.DownloadFile("https://shotr.io/latest", Path.Combine(SettingsService.FolderPath, "Shotr-Installer.exe"));
                    var p = new Process();
                    p.StartInfo.Verb = "runas";
                    p.StartInfo.UseShellExecute = true;
                    p.StartInfo.FileName = Path.Combine(SettingsService.FolderPath, "Shotr-Installer.exe");
                    p.StartInfo.Arguments = "--run-installer --silent" + (_settings.SubscribeToAlphaBeta ? " --install-beta " : "");
                    p.Start();
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    Invoke((MethodInvoker)delegate () 
                    {
                        MessageBox.Show("There was an error while updating. Error message: " + ex);
                        _allowClose = true;
                        Close();
                    });
                }
                //}
            }).Start();
        }
    }
}

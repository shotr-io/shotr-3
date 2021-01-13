using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using Shotr.Core.DpiScaling;
using Shotr.Core.Settings;
using Shotr.Core.UpdateFramework;

namespace Shotr.Ui.Forms
{
    public partial class UpdateForm : DpiScaledForm
    {
        private readonly BaseSettings _settings;
        private bool _allowClose;

        UpdaterJsonClass _upd;
        public UpdateForm(BaseSettings settings)
        {
            _settings = settings;
            
            InitializeComponent();
            ManualDpiScale();
            ScaleForm = false;
        }

        public void SetUpForm(UpdaterJsonClass p, bool allowClose = false)
        {
            metroTextBox1.Text = p.changelog;
            TopMost = false;
            if (p.stable)
            {
                metroButton2.Visible = false;
                metroButton1.Location = metroButton2.Location;
                metroLabel2.Text = " An update is ready for download.";

                FormClosing += UpdateForm_FormClosing;
            }
            _upd = p;
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
            UpdateFromUrl(_upd.update_url);
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

        private void UpdateFromUrl(string url)
        {
            //download file.
            var m = new WebClient { Proxy = null };
            try
            {
                m.DownloadFile("https://shotr.io/latest", SettingsHelper.FolderPath + "Shotr-Installer.exe");
                var p = new Process();
                p.StartInfo.Verb = "runas";
                p.StartInfo.FileName = SettingsHelper.FolderPath + "Shotr-Installer.exe";
                p.StartInfo.Arguments = "--run-installer --silent"+(_settings.SubscribeToAlphaBeta ? " --install-beta " : "");
                p.Start();
                Environment.Exit(0);
            }
            catch(Exception ex)
            {
                MessageBox.Show("There was an error while updating. Error message: " + ex);
                _allowClose = true;
                Close();
            }
            //}
        }
    }
}

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;
using Shotr.Core.Controls.Theme;
using Shotr.Core.Services;
using Shotr.Core.Settings;
using Shotr.Core.UpdateFramework;

namespace Shotr.Ui.Forms
{
    public partial class UpdateForm : ThemedForm
    {
        private readonly BaseSettings _settings;

        UpdaterResponse _upd;
        public UpdateForm(BaseSettings settings)
        {
            _settings = settings;
            
            InitializeComponent();
        }

        public void SetUpForm(UpdaterResponse p)
        {
            metroTextBox1.Text = p.Changes;
            TopMost = false;
            metroLabel2.Text = " A new update is available.";
            _upd = p;
            metroTextBox1.DeselectAll();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            var scalingFactor = DpiScaler.GetScalingFactor(this);
            //start the updating.
            ClientSize = new Size((int)(373 * scalingFactor), (int)(71 * scalingFactor));
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - (Size.Width / 2), Screen.PrimaryScreen.WorkingArea.Height / 2 - (Size.Height / 2));
            metroTextBox1.Visible = false;
            metroLabel1.Visible = false;
            metroLabel2.Visible = false;
            metroButton1.Visible = false;
            metroButton2.Visible = false;
            themedProgressBar1.Visible = true;
            Text = "Shotr - Updating";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            //update shit.
            UpdateFromUrl();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void UpdateFromUrl()
        {
            new Thread(delegate()
            {
                //download file.
                var m = new WebClient { Proxy = null };
                try
                {
                    m.DownloadProgressChanged += (s, e) =>
                    {
                        Invoke((MethodInvoker) delegate() { themedProgressBar1.Value = e.ProgressPercentage; });
                    };
                    m.DownloadFileCompleted += (sender, args) =>
                    {
                        using (var fs = File.OpenRead(Path.Combine(SettingsService.FolderPath, "Shotr-Installer.zip")))
                        {
                            using (var zip = new ZipArchive(fs))
                            {
                                foreach (var zipEntry in zip.Entries)
                                {
                                    var fileName = Path.Combine(SettingsService.FolderPath, zipEntry.Name);
                                    zipEntry.ExtractToFile(fileName, true);
                                }
                            }
                        }

                        File.Delete(Path.Combine(SettingsService.FolderPath, "Shotr-Installer.zip"));

                        var p = new Process();
                        p.StartInfo.Verb = "runas";
                        p.StartInfo.UseShellExecute = true;
                        p.StartInfo.FileName = Path.Combine(SettingsService.FolderPath, "Shotr-Installer.exe");
                        p.StartInfo.Arguments = "--run-installer" + (_settings.SubscribeToAlphaBeta ? " --install-beta " : ""); // temp remove silent to show progress
                        p.Start();

                        Environment.Exit(0);
                    };

                    m.DownloadFileAsync(new Uri("https://shotr.dev/downloads/Shotr-Installer.zip"), Path.Combine(SettingsService.FolderPath, "Shotr-Installer.zip"));
                    
                }
                catch (Exception ex)
                {
                    Invoke((MethodInvoker)delegate () 
                    {
                        MessageBox.Show("There was an error while updating. Error message: " + ex);
                        Close();
                    });
                }
            }).Start();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            metroTextBox1.DeselectAll();
        }
    }
}

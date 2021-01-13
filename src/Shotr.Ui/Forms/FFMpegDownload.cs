using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Shotr.Core.DpiScaling;
using Shotr.Core.Settings;
using Shotr.Core.Utils;

namespace Shotr.Ui.Forms
{
    public partial class FfMpegDownload : DpiScaledForm
    {
        public FfMpegDownload()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //ok
            metroButton1.Visible = false;
            metroProgressBar1.Visible = true;
            metroProgressBar1.Maximum = 100;
            var f = new WebClient();
            f.Proxy = null;
            f.DownloadFileCompleted += f_DownloadFileCompleted;
            f.DownloadProgressChanged += f_DownloadProgressChanged;
            f.DownloadFileAsync(new Uri("http://shotr.io/ffmpeg.compr"), SettingsHelper.FolderPath + "ffmpeg.compressed");
        }

        void f_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            metroProgressBar1.Value = e.ProgressPercentage;
        }

        void f_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            new Thread(delegate()
            {
                try
                {
                    Utils.Decompress(SettingsHelper.FolderPath + "ffmpeg.compressed", SettingsHelper.FolderPath + "ffmpeg.exe");
                    File.Delete(SettingsHelper.FolderPath + "ffmpeg.compressed");
                    //d76946e2b54773afd1c0e202dd14e73e
                    if (Utils.MD5File(SettingsHelper.FolderPath + "ffmpeg.exe") != "76b4131c0464beef626eb445587e69fe")
                    {
                        throw new Exception();
                    }
                    Invoke((MethodInvoker)(() =>
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }));
                }
                catch
                {
                    //download was corrupted.
                    Process.Start("http://shotr.io/ffmpeg.exe");
                    Process.Start(SettingsHelper.FolderPath);
                    MessageBox.Show("The download was corrupted. The program is now opening a link in your web browser and a folder on your computer. Please place the downloaded file in the folder that pops up, then press OK.");
                    Invoke((MethodInvoker)(() =>
                    {
                        DialogResult = DialogResult.Cancel;
                        Close();
                    }));
                }
            }).Start();
        }
    }
}

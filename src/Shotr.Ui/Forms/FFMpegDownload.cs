﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Shotr.Core;
using Shotr.Core.Controls.DpiScaling;
using Shotr.Core.Controls.Theme;
using Shotr.Core.Services;
using Shotr.Core.Utils;

namespace Shotr.Ui.Forms
{
    public partial class FfMpegDownload : ThemedForm
    {
        public FfMpegDownload()
        {
            InitializeComponent();
            DpiScaler.ScaleLocation(this, Size, Location);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //ok
            metroButton1.Visible = false;
            metroProgressBar1.Visible = true;
            metroProgressBar1.MaxValue = 100;
            var f = new WebClient();
            f.Proxy = null;
            f.DownloadFileCompleted += f_DownloadFileCompleted;
            f.DownloadProgressChanged += f_DownloadProgressChanged;
            f.DownloadFileAsync(new Uri("https://shotr.dev/downloads/ffmpeg.gz"), Path.Combine(SettingsService.FolderPath, "ffmpeg.compressed"));
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
                    Utils.Decompress(Path.Combine(SettingsService.FolderPath, "ffmpeg.compressed"), Path.Combine(SettingsService.FolderPath, "ffmpeg.exe"));
                    File.Delete(Path.Combine(SettingsService.FolderPath, "ffmpeg.compressed"));
                    //d76946e2b54773afd1c0e202dd14e73e
                    if (Utils.MD5File(Path.Combine(SettingsService.FolderPath, "ffmpeg.exe")) != "05a894305c9bd146dad4cc3ff0e21e83")
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
                    "http://shotr.dev/downloads/ffmpeg.exe".OpenUrl();
                    Process.Start("explorer.exe", SettingsService.FolderPath);
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

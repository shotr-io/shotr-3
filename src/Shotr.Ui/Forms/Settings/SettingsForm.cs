using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Shotr.Core.Capture;
using Shotr.Core.DpiScaling;
using Shotr.Core.Utils;
using ShotrUploaderPlugin;

namespace Shotr.Ui.Forms.Settings
{
    public partial class SettingsForm : DpiScaledForm
    {
        /*
         { "region_hotkey", new object[] { Keys.Control | Keys.Shift | Keys.D4 } },
         { "region_fullscreen", new object[] { Keys.Control | Keys.Shift | Keys.D3 } },
         { "region_activewindow", new object[] { Keys.Control | Keys.Shift | Keys.D2 } },
         { "region_record_screen", new object[] {Keys.Control | Keys.Shift | Keys.D1} },
         { "region_clipboard", new object[] { Keys.Control | Keys.Shift | Keys.D5 } },
         { "start_with_windows", new object[] { true } },
         { "start_minimized", new object[] { false } },
         { "image_history", new object[] { } },
         { "image_uploader", new object[] { "Shotr" } },
         { "image_uploader_direct_url", new object[] { false } },
         { "program_subscribe_to_alpha_beta_releases", new object[] { false } },
         { "program_stitch_fullscreen", new object[] { true } },
         { "program_custom_uploaders", new object[] { new List<CustomUploaderInstance>() } },
         { "region_capture_information", new object[] { true } },
         { "region_capture_zoom", new object[] { true } },
         { "region_capture_color", new object[] { true } },
         { "play_sounds", new object[] { true } },
         { "program_show_notifications", new object[] { true } },
         this.ChangeKey("settings.screen_recording", new object[] { 60, 4, true, false, "" });
         this.ChangeKey("settings.screenshot", new object[] { FileExtensions.png, CompressionLevel.High, true });
         this.ChangeKey("region_clipboard", new object[] { Keys.Control | Keys.Shift | Keys.D5 });
        */
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            ScreencastOptions k = new ScreencastOptions();
            FFmpegHelper fmp = new FFmpegHelper(k);
            fmp.Options.FFmpeg.CLIPath = Path.Combine(Core.Utils.Settings.FolderPath, "ffmpeg.exe");
            DirectShowDevices p = fmp.GetDirectShowDevices();
            if (p.AudioDevices.Count < 0)
            {
                recordAudioToggle.Checked = false;
                recordAudioToggle.Enabled = false;
                audioDeviceCombo.Enabled = false;
            }
            else
            {
                //add to combobox
                for (int i = 0; i < p.AudioDevices.Count; i++)
                {
                    audioDeviceCombo.Items.Add(p.AudioDevices[i]);
                }
                //check settings first.
                if ((string)Core.Utils.Settings.Instance.GetValue("settings.screen_recording")[1].ToString() == "")
                {
                    audioDeviceCombo.Text = p.AudioDevices[0];
                }
                else
                {
                    if (p.AudioDevices.Contains((string)Core.Utils.Settings.Instance.GetValue("settings.screen_recording")[4].ToString()))
                    {
                        audioDeviceCombo.Text = (string)Core.Utils.Settings.Instance.GetValue("settings.screen_recording")[4].ToString();
                    }
                    else
                    {
                        audioDeviceCombo.Text = p.AudioDevices[0];
                    }
                }
            }
            //load all settings here.
            if (GetOptions("general.savetodirectory").Length > 1)
            {
                metroTextBox1.Text = (string)GetOptions("general.savetodirectory")[1];
            }
            saveToDirectoryToggle.Checked = (bool)GetOptions("general.savetodirectory")[0];
            showNotificationsToggle.Checked = (bool)GetOptions("program_show_notifications")[0];
            startupToggle.Checked = (bool)GetOptions("start_with_windows")[0];
            minimizedToggle.Checked = (bool)GetOptions("start_minimized")[0];
            alphaToggle.Checked = (bool)GetOptions("program_subscribe_to_alpha_beta_releases")[0];
            soundToggle.Checked = (bool)GetOptions("play_sounds")[0];
            imageCodecCombo.Text = (string)GetOptions("settings.screenshot")[0].ToString();
            imageQualityCombo.Text = (string)GetOptions("settings.screenshot")[1].ToString();
            imageCompressionToggle.Checked = (bool)GetOptions("settings.screenshot")[2];
            stitchFullscreenToggle.Checked = (bool)GetOptions("program_stitch_fullscreen")[0];
            framerateCombo.Text = (string)GetOptions("settings.screen_recording")[0].ToString();
            encodingCombo.Text = (string)GetOptions("settings.screen_recording")[1].ToString();
            recordCursorToggle.Checked = (bool)GetOptions("settings.screen_recording")[2];
            recordAudioToggle.Checked = (bool)GetOptions("settings.screen_recording")[3];
            audioDeviceCombo.Text = (string)GetOptions("settings.screen_recording")[4].ToString();
            useresizablecanvas.Checked = (bool)GetOptions("screenshot.use_resizable_canvas")[0];

            saveToDirectoryToggle.CheckedChanged += saveToDirectoryToggle_CheckedChanged;
            showNotificationsToggle.CheckedChanged += showNotificationsToggle_CheckedChanged;
            startupToggle.CheckedChanged += startupToggle_CheckedChanged;
            minimizedToggle.CheckedChanged += minimizedToggle_CheckedChanged;
            alphaToggle.CheckedChanged += alphaToggle_CheckedChanged;
            soundToggle.CheckedChanged += soundToggle_CheckedChanged;
            imageCodecCombo.SelectedIndexChanged += imageCodecCombo_SelectedIndexChanged;
            imageQualityCombo.SelectedIndexChanged += imageQualityCombo_SelectedIndexChanged;
            imageCompressionToggle.CheckedChanged += imageCompressionToggle_CheckedChanged;
            stitchFullscreenToggle.CheckedChanged += stitchFullscreenToggle_CheckedChanged;
            framerateCombo.SelectedIndexChanged += framerateCombo_SelectedIndexChanged;
            encodingCombo.SelectedIndexChanged += encodingCombo_SelectedIndexChanged;
            recordCursorToggle.CheckedChanged += recordCursorToggle_CheckedChanged;
            recordAudioToggle.CheckedChanged += recordAudioToggle_CheckedChanged;
            audioDeviceCombo.SelectedIndexChanged += audioDeviceCombo_SelectedIndexChanged;
            useresizablecanvas.CheckedChanged += useresizablecanvas_CheckedChanged;
        }

        void useresizablecanvas_CheckedChanged(object sender, EventArgs e)
        {
            SaveOption("screenshot.use_resizable_canvas", new object[] { useresizablecanvas.Checked });
        }
        
        private string ChooseDir()
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.Description = "Choose a directory for Shotr to save files in before upload: ";
            if (f.ShowDialog() == DialogResult.OK)
            {
                return f.SelectedPath;
            }
            return null;
        }

        private List<string> done = new List<string>();

        private void SaveOption(string name, object[] value)
        {
            Core.Utils.Settings.Instance.ChangeKey(name, value);
        }

        private object[] GetOptions(string name)
        {
            return Core.Utils.Settings.Instance.GetValue(name);
        }

        private void saveToDirectoryToggle_CheckedChanged(object sender, EventArgs e)
        {
            //unhide textbox, allow them to browse.
            if(saveToDirectoryToggle.Checked) 
            {
                //show folder browser.
                string m = ChooseDir();
                if(m != null)
                {
                    metroTextBox1.Text = m;
                    //save option.
                    SaveOption("general.savetodirectory", new object[] { true, m });
                }
            }
            else
            {
                metroTextBox1.Text = "";
                SaveOption("general.savetodirectory", new object[] { false, "" });
            }
        }

        private void showNotificationsToggle_CheckedChanged(object sender, EventArgs e)
        {
            SaveOption("program_show_notifications", new object[] { showNotificationsToggle.Checked });
        }

        private void startupToggle_CheckedChanged(object sender, EventArgs e)
        {
            SaveOption("start_with_windows", new object[] { startupToggle.Checked });
            Utils.AddToStartup(startupToggle.Checked);
        }

        private void minimizedToggle_CheckedChanged(object sender, EventArgs e)
        {
            SaveOption("start_minimized", new object[] { minimizedToggle.Checked });
        }

        private void alphaToggle_CheckedChanged(object sender, EventArgs e)
        {
            DialogResult p = MessageBox.Show(this, "Shotr will restart to check for updates to the latest alpha release. Is that okay?", "Confirm?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            switch (p)
            {
                case DialogResult.Yes:
                    {
                        SaveOption("program_subscribe_to_alpha_beta_releases", new object[] { alphaToggle.Checked });
                        Application.Restart();
                        Environment.Exit(0);
                    }
                    break;
                case DialogResult.No:
                    {
                        SaveOption("program_subscribe_to_alpha_beta_releases", new object[] { !alphaToggle.Checked });
                        alphaToggle.Checked = !alphaToggle.Checked;
                    }
                    break;
                case DialogResult.Cancel:
                    {
                        alphaToggle.Checked = false;
                    }
                    break;
            }
        }

        private void soundToggle_CheckedChanged(object sender, EventArgs e)
        {
            SaveOption("play_sounds", new object[] { soundToggle.Checked });
        }

        private void imageCodecCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileExtensions i = (FileExtensions)Enum.Parse(typeof(FileExtensions), imageCodecCombo.Text);
            CompressionLevel h = (CompressionLevel)Enum.Parse(typeof(CompressionLevel), imageQualityCombo.Text);

            Core.Utils.Settings.Instance.ChangeKey("settings.screenshot", new object[] { i, h, imageCompressionToggle.Checked });
        }

        private void imageQualityCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileExtensions i = (FileExtensions)Enum.Parse(typeof(FileExtensions), imageCodecCombo.Text);
            CompressionLevel h = (CompressionLevel)Enum.Parse(typeof(CompressionLevel), imageQualityCombo.Text);

            Core.Utils.Settings.Instance.ChangeKey("settings.screenshot", new object[] { i, h, imageCompressionToggle.Checked });
        }

        private void imageCompressionToggle_CheckedChanged(object sender, EventArgs e)
        {
            FileExtensions i = (FileExtensions)Enum.Parse(typeof(FileExtensions), imageCodecCombo.Text);
            CompressionLevel h = (CompressionLevel)Enum.Parse(typeof(CompressionLevel), imageQualityCombo.Text);

            Core.Utils.Settings.Instance.ChangeKey("settings.screenshot", new object[] { i, h, imageCompressionToggle.Checked });
        }

        private void stitchFullscreenToggle_CheckedChanged(object sender, EventArgs e)
        {
            SaveOption("program_stitch_fullscreen", new object[] { stitchFullscreenToggle.Checked });
        }

        private void framerateCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveOption("settings.screen_recording", new object[] { Convert.ToInt32(framerateCombo.Text), Convert.ToInt32(encodingCombo.Text), recordCursorToggle.Checked, recordAudioToggle.Checked, audioDeviceCombo.Text });
        }

        private void encodingCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveOption("settings.screen_recording", new object[] { Convert.ToInt32(framerateCombo.Text), Convert.ToInt32(encodingCombo.Text), recordCursorToggle.Checked, recordAudioToggle.Checked, audioDeviceCombo.Text });
        }

        private void recordCursorToggle_CheckedChanged(object sender, EventArgs e)
        {
            SaveOption("settings.screen_recording", new object[] { Convert.ToInt32(framerateCombo.Text), Convert.ToInt32(encodingCombo.Text), recordCursorToggle.Checked, recordAudioToggle.Checked, audioDeviceCombo.Text });
        }

        private void recordAudioToggle_CheckedChanged(object sender, EventArgs e)
        {
            SaveOption("settings.screen_recording", new object[] { Convert.ToInt32(framerateCombo.Text), Convert.ToInt32(encodingCombo.Text), recordCursorToggle.Checked, recordAudioToggle.Checked, audioDeviceCombo.Text });
        }

        private void audioDeviceCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveOption("settings.screen_recording", new object[] { Convert.ToInt32(framerateCombo.Text), Convert.ToInt32(encodingCombo.Text), recordCursorToggle.Checked, recordAudioToggle.Checked, audioDeviceCombo.Text });
        }
    }
}

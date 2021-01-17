using System;
using System.IO;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;
using Shotr.Core.Entities;
using Shotr.Core.Services;
using Shotr.Core.Settings;
using Shotr.Core.Utils;
using ShotrUploaderPlugin;

namespace Shotr.Ui.Forms.Settings
{
    public partial class SettingsForm : DpiScaledForm
    {
        private readonly BaseSettings _settings;
        public SettingsForm(BaseSettings settings)
        {
            _settings = settings;
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            var k = new ScreencastOptions();
            var fmp = new FFmpegHelperService(k);
            fmp.Options.FFmpeg.CLIPath = Path.Combine(SettingsService.FolderPath, "ffmpeg.exe");
            var p = fmp.GetDirectShowDevices();
            if (p.AudioDevices.Count < 0)
            {
                recordAudioToggle.Checked = false;
                recordAudioToggle.Enabled = false;
                audioDeviceCombo.Enabled = false;
            }
            else
            {
                //add to combobox
                for (var i = 0; i < p.AudioDevices.Count; i++)
                {
                    audioDeviceCombo.Items.Add(p.AudioDevices[i]);
                }
                //check settings first.
                if (_settings.Record.AudioDevice is null || string.IsNullOrEmpty(_settings.Record.AudioDevice))
                {
                    audioDeviceCombo.Text = p.AudioDevices[0];
                }
                else
                {
                    if (p.AudioDevices.Contains(_settings.Record.AudioDevice))
                    {
                        audioDeviceCombo.Text = _settings.Record.AudioDevice;
                    }
                    else
                    {
                        audioDeviceCombo.Text = p.AudioDevices[0];
                    }
                }
            }
            //load all settings here.
            if (_settings.Capture.SaveToDirectory)
            {
                metroTextBox1.Text = _settings.Capture.SaveToDirectoryPath;
            }
            saveToDirectoryToggle.Checked = _settings.Capture.SaveToDirectory;
            showNotificationsToggle.Checked = _settings.ShowNotifications;
            startupToggle.Checked = _settings.StartWithWindows;
            minimizedToggle.Checked = _settings.StartMinimized;
            alphaToggle.Checked = _settings.SubscribeToAlphaBeta;
            soundToggle.Checked = _settings.PlaySounds;
            imageCodecCombo.Text = _settings.Capture.Extension.ToString();
            imageQualityCombo.Text = _settings.Capture.CompressionLevel.ToString();
            imageCompressionToggle.Checked = _settings.Capture.CompressionEnabled;
            stitchFullscreenToggle.Checked = _settings.Capture.StitchFullscreen;
            framerateCombo.Text = _settings.Record.Framerate.ToString();
            encodingCombo.Text = _settings.Record.Threads.ToString();
            recordCursorToggle.Checked = _settings.Record.RecordCursor;
            recordAudioToggle.Checked = _settings.Record.RecordAudio;
            audioDeviceCombo.Text = _settings.Record.AudioDevice;
            useresizablecanvas.Checked = _settings.Capture.UseResizableCanvas;

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
            _settings.Capture.UseResizableCanvas = useresizablecanvas.Checked;
            SettingsService.Save(_settings);
        }
        
        private string ChooseDir()
        {
            var f = new FolderBrowserDialog();
            f.Description = "Choose a directory for Shotr to save files in before upload: ";
            if (f.ShowDialog() == DialogResult.OK)
            {
                return f.SelectedPath;
            }
            return null;
        }

        private void saveToDirectoryToggle_CheckedChanged(object sender, EventArgs e)
        {
            //unhide textbox, allow them to browse.
            if(saveToDirectoryToggle.Checked) 
            {
                //show folder browser.
                var saveDirectoryChoosePath = ChooseDir();
                if(saveDirectoryChoosePath != null)
                {
                    metroTextBox1.Text = saveDirectoryChoosePath;
                    _settings.Capture.SaveToDirectory = true;
                    _settings.Capture.SaveToDirectoryPath = saveDirectoryChoosePath;
                }
            }
            else
            {
                metroTextBox1.Text = "";
                _settings.Capture.SaveToDirectory = false;
                _settings.Capture.SaveToDirectoryPath = null;
            }
            SettingsService.Save(_settings);
        }

        private void showNotificationsToggle_CheckedChanged(object sender, EventArgs e)
        {
            _settings.ShowNotifications = showNotificationsToggle.Checked;
            SettingsService.Save(_settings);
        }

        private void startupToggle_CheckedChanged(object sender, EventArgs e)
        {
            _settings.StartWithWindows = startupToggle.Checked;
            Utils.AddToStartup(startupToggle.Checked);
            SettingsService.Save(_settings);
        }

        private void minimizedToggle_CheckedChanged(object sender, EventArgs e)
        {
            _settings.StartMinimized = minimizedToggle.Checked;
            SettingsService.Save(_settings);
        }

        private void alphaToggle_CheckedChanged(object sender, EventArgs e)
        {
            var p = MessageBox.Show(this, "Shotr will restart to check for updates to the latest alpha release. Is that okay?", "Confirm?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            switch (p)
            {
                case DialogResult.Yes:
                    _settings.SubscribeToAlphaBeta = alphaToggle.Checked;
                    SettingsService.Save(_settings);
                    Application.Restart();
                    Environment.Exit(0);
                    break;
                case DialogResult.No:
                case DialogResult.Cancel:
                    alphaToggle.Checked = false;
                    _settings.SubscribeToAlphaBeta = alphaToggle.Checked;
                    break;
            }
        }

        private void soundToggle_CheckedChanged(object sender, EventArgs e)
        {
            _settings.PlaySounds = soundToggle.Checked;
            SettingsService.Save(_settings);
        }

        private void imageCodecCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var imageCodec = (FileExtensions)Enum.Parse(typeof(FileExtensions), imageCodecCombo.Text);
            _settings.Capture.Extension = imageCodec;
            SettingsService.Save(_settings);
        }

        private void imageQualityCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var imageQuality = (CompressionLevel)Enum.Parse(typeof(CompressionLevel), imageQualityCombo.Text);
            _settings.Capture.CompressionLevel = imageQuality;
            SettingsService.Save(_settings);
        }

        private void imageCompressionToggle_CheckedChanged(object sender, EventArgs e)
        {
            _settings.Capture.CompressionEnabled = imageCompressionToggle.Checked;
            SettingsService.Save(_settings);
        }

        private void stitchFullscreenToggle_CheckedChanged(object sender, EventArgs e)
        {
            _settings.Capture.StitchFullscreen = stitchFullscreenToggle.Checked;
            SettingsService.Save(_settings);
        }

        private void framerateCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _settings.Record.Framerate = Convert.ToInt32(framerateCombo.Text);
            SettingsService.Save(_settings);
        }

        private void encodingCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _settings.Record.Threads = Convert.ToInt32(encodingCombo.Text);
            SettingsService.Save(_settings);
        }

        private void recordCursorToggle_CheckedChanged(object sender, EventArgs e)
        {
            _settings.Record.RecordCursor = recordCursorToggle.Checked;
            SettingsService.Save(_settings);
        }

        private void recordAudioToggle_CheckedChanged(object sender, EventArgs e)
        {
            _settings.Record.RecordAudio = recordAudioToggle.Checked;
            SettingsService.Save(_settings);
        }

        private void audioDeviceCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _settings.Record.AudioDevice = audioDeviceCombo.Text;
            SettingsService.Save(_settings);
        }
    }
}

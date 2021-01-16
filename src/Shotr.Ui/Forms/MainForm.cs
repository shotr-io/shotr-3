using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;
using Shotr.Core.Entities.Hotkeys;
using Shotr.Core.Image;
using Shotr.Core.Pipes;
using Shotr.Core.Services;
using Shotr.Core.Settings;
using Shotr.Core.Uploader;
using Shotr.Core.Utils;
using Shotr.Ui.Forms.Settings;
using ShotrUploaderPlugin;

namespace Shotr.Ui.Forms
{
    public partial class MainForm : DpiScaledForm
    {
        private readonly BaseSettings _settings;
        private readonly Uploader _uploader;
        private readonly PipeServer _pipeServer;
        private readonly SettingsForm _settingsForm;
        private readonly AboutForm _aboutForm;
        
        private readonly SingleInstance _tasks;

        private readonly HotKeyService _hotkeyService;
        private readonly SettingsService _settingsService;

        private readonly IEnumerable<IImageUploader> _uploaders;
        private readonly MusicPlayerService _musicPlayerService;
        
        private Icon _shotrIcon;
        private VideoRecorderForm _videoRecorderForm;

        public MainForm(BaseSettings settings,
                        Uploader uploader,
                        PipeServer pipeServer,
                        SingleInstance tasks, 
                        SettingsForm settingsForm,
                        HotKeyService hotkeyService, 
                        SettingsService settingsService, 
                        IEnumerable<IImageUploader> uploaders, 
                        MusicPlayerService musicPlayerService, 
                        AboutForm aboutForm)
        {
            _settings = settings;
            _uploader = uploader;
            _pipeServer = pipeServer;
            _tasks = tasks;
            _hotkeyService = hotkeyService;
            _settingsService = settingsService;
            _uploaders = uploaders;
            _musicPlayerService = musicPlayerService;
            _aboutForm = aboutForm;
            _settingsForm = settingsForm;

            InitializeComponent();
            
            FormBorderStyle = FormBorderStyle.None;
            
            Shown += MainFormShown;
            _pipeServer.PipeServerReceivedClient += _pipeserver_PipeServerReceivedClient;
            _pipeServer.StartServer();

            _shotrIcon = Icon;
            _shotrIcon.ToBitmap();
        }

        public void SetUpForm(bool showInTaskBar, bool visible)
        {
            ShowInTaskbar = showInTaskBar;
            Visible = visible;
        }

        void _pipeserver_PipeServerReceivedClient(object sender, PipeServerEventArgs e)
        {
            switch (e.Data)
            {
                case "--region":
                    var regionHotkey = _hotkeyService.GetHotKey(KeyTask.Region);
                    if (regionHotkey is { })
                    {
                        hook_KeyPressed(this, new KeyPressedEventArgs(regionHotkey.Id));
                    }
                    break;
                case "--record":
                    var recordHotkey = _hotkeyService.GetHotKey(KeyTask.RecordScreen);
                    if (recordHotkey is { })
                    {
                        hook_KeyPressed(this, new KeyPressedEventArgs(recordHotkey.Id));
                    }
                    break;
                case "--launch":
                    Invoke((MethodInvoker)(() =>
                    {
                        WindowState = FormWindowState.Minimized;
                        Show();
                        WindowState = FormWindowState.Normal;
                        ShowInTaskbar = true;
                        // Move to top.
                        Focus();
                        Activate();
                    }));
                    break;
            }
        }

        private void MainFormShown(object sender, EventArgs e)
        {
            if (_settings.StartMinimized)
            {
                ShowInTaskbar = false;
                Visible = false;
            }
            else
            {
                ShadowType = MetroFormShadowType.DropShadow;
                ShowInTaskbar = true;
                Visible = true;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _hotkeyService.KeyPressed += hook_KeyPressed;
            UpdateControls();
            _uploader.StartQueue();
            _uploader.OnUploaded += Uploader_OnUploaded;
            _uploader.OnError += Uploader_OnError;
            _uploader.OnProgress += Uploader_OnProgress;
            
            notifyIcon1.Disposed += (_, _) =>
            {
                notifyIcon1 = new NotifyIcon
                {
                    ContextMenuStrip = contextMenuStrip1,
                    Visible = true,
                };
                notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            };
            
            notifyIcon1.Text = "Shotr";
            notifyIcon1.Icon = (Icon)_shotrIcon.Clone();
        }

        void Uploader_OnProgress(object sender, double progress)
        {
            //set up the icon.
            try
            {
                Invoke((MethodInvoker)(() =>
                {
                    if (progress == 101)
                    {
                        var m = ImageManipulation.DefaultImage();
                        notifyIcon1.Icon.Dispose();
                        notifyIcon1.Icon = m;
                        notifyIcon1.Text = "Shotr";
                        m.Dispose();
                        return;
                    }

                    if (progress == 100)
                    {
                        var m = ImageManipulation.ImageStatus(99);
                        notifyIcon1.Icon.Dispose();
                        notifyIcon1.Icon = m;
                        notifyIcon1.Text = "Server is processing upload...";
                        m.Dispose();
                        return;
                    }
                    var s = ImageManipulation.ImageStatus(Convert.ToInt32(progress));
                    notifyIcon1.Icon.Dispose();
                    notifyIcon1.Icon = s;
                    notifyIcon1.Text = string.Format("Upload Progress: {0}%", Convert.ToInt32(progress));
                    s.Dispose();
                }));
            }
            catch { }
        }

        void Uploader_OnError(object sender, ImageShell e)
        {
            var f = (UploadedImageJsonResult)sender;
            if (f != null && f.ErrorCode == -7)
            {
                Invoke((MethodInvoker)(() =>
                {
                    //shotr_update.
                    MessageBox.Show(this,
                        "Shotr has an important update available! Shotr will now restart to download the update. This update is required to further upload images.",
                        "Shotr Important Update Available!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                    Environment.Exit(0);
                }));
            }
            else
            {
                try
                {
                    var errorNotification = new ErrorNotification(e, f);
                    Invoke((MethodInvoker) (() => { errorNotification.Show(); }));
                }
                catch
                {
                    Console.WriteLine("Error while showing error.");
                }
            }
        }

        private void Uploader_OnUploaded(object sender, UploadResult e)
        {
            if (_settings.Capture.SaveToDirectory)
            {
                if (_settings.Capture.SaveToDirectoryPath is {} && !Directory.Exists(_settings.Capture.SaveToDirectoryPath))
                {
                    Directory.CreateDirectory(_settings.Capture.SaveToDirectoryPath);
                }

                var extension = e != null ? Path.GetExtension(e.URL) : ((FileExtensions) ((object[]) sender)[2]).ToString();
                var filename = $"{_settings.Capture.SaveToDirectoryPath}\\{DateTime.Now:yyyy-MM-dd_hh-mm-ss-tt}{extension}";

                File.WriteAllBytes(filename, (byte[])((object[])sender)[1]);
            }

            var url = e is {} ? _settings.Capture.DirectUrl ? e.URL : e.PageURL : "";

            Invoke((MethodInvoker)(() =>
            {
                try
                {
                    Image jpg;
                    Bitmap b;
                    using (var k = new MemoryStream((byte[]) ((object[]) sender)[1]))
                    {
                        jpg = Image.FromStream(k);
                        b = new Bitmap(jpg);
                    }

                    var dataobj = new DataObject();
                    if (e != null)
                        dataobj.SetText(url);
                    dataobj.SetImage(b);
                    Clipboard.SetDataObject(dataobj);
                    jpg.Dispose();
                    //b.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Cannot set image and text in clipboard at same time, error: {0}", ex);
                    if (e != null)
                        Clipboard.SetText(url);
                }

                try
                {
                    if (e != null)
                    {
                        if (_settings.ShowNotifications)
                        {
                            var notification = new Notification(url, (string) ((object[]) sender)[0]);
                            notification.Show();
                        }
                    }
                    else
                    {
                        if (_settings.ShowNotifications)
                        {
                            var notification = new NoUploadNotification((string) ((object[]) sender)[0]);
                            notification.Show();
                        }
                    }
                }
                catch
                {
                }
            }));
        }

        private void UpdateControls()
        {
            betterListView1.Font = metroLabel2.GetThemeFont();
            UpdateHotKeys();
            betterListView1.DoubleClick += betterListView1_MouseDoubleClick;
            UpdateListView();

            //update other settings.
            metroLabel8.Text = string.Format(metroLabel8.Text, Assembly.GetExecutingAssembly().GetName().Version);

            foreach (var uploader in _uploaders)
            {
                selectedImageUploader.Items.Add(uploader.Title);
            }

            selectedImageUploader.Text = _settings.Capture.Uploader;
            if (selectedImageUploader.Text == "" && selectedImageUploader.Items.Count > 0)
            {
                selectedImageUploader.Text = (string)selectedImageUploader.Items[0];
            }
            UpdateDirectUrl();

            emailLabel.Text = _settings.Login.Email;
        }

        private void UpdateDirectUrl()
        {
            //check if uploader has support for indirect URLs.
            var uploader = GetUploader(_settings.Capture.Uploader);
            if (uploader == null) return;
            //check if it supports indirect urls.
            if (uploader.SupportsPages)
            {
                //enable control for selecting page support.
                metroLabel11.Visible = true;
                directUrlToggle.Visible = true;
                //get from settings or set to default.
                directUrlToggle.Checked = _settings.Capture.DirectUrl;
            }
            else
            {
                metroLabel11.Visible = false;
                directUrlToggle.Visible = false;
            }
        }

        private void UpdateListView()
        {
            UpdateListViewColumnSize();
            var templist = new List<UploadResult>();
            var history = _settingsService.LoadLegacyHistory();
            if (history is { })
            {
                templist.AddRange(history.Select(p => p.Value).ToList());
            }

            var directUrl = _settings.Capture.DirectUrl;
            for (var i = templist.Count - 1; i >= 0; i--)
            {
                if (directUrl)
                {
                    var m = GetUploader(templist[i].Uploader);
                    var x = new ListViewItem { Text = !m.SupportsPages && !directUrl ? templist[i].URL : templist[i].PageURL };
                    x.SubItems.Add(Utils.FromUnixTime(templist[i].Time).ToString());
                    betterListView1.Items.Add(x);
                }
                else
                {
                    var x = new ListViewItem { Text = (directUrl ? templist[i].URL : templist[i].PageURL) };
                    x.SubItems.Add(Utils.FromUnixTime(templist[i].Time).ToString());
                    betterListView1.Items.Add(x);
                }
            }
        }

        private void UpdateListViewColumnSize()
        {
            if (betterListView1 is ListView listView)
            {
                float totalColumnWidth = 0;

                // Get the sum of all column tags
                totalColumnWidth = betterListView1.Size.Width;

                // Calculate the percentage of space each column should 
                // occupy in reference to the other columns and then set the 
                // width of the column to that percentage of the visible space.
                for (var i = 0; i < listView.Columns.Count; i++)
                {
                    float colPercentage = (Convert.ToInt32(totalColumnWidth / 2));
                    listView.Columns[i].Width = (int)colPercentage;
                }
            }
        }

        private void UpdateHotKeys()
        {
            var activeWindowHotKey = _hotkeyService.GetHotKey(KeyTask.ActiveWindow);
            if (activeWindowHotKey is { })
            {
                activeWindowHotKeyButton.Text = activeWindowHotKey.Data.ToString();
                activeWindowHotKeyButton.HotKey = activeWindowHotKey.Data;
            }
            
            var fullscreenHotKey = _hotkeyService.GetHotKey(KeyTask.Fullscreen);
            if (fullscreenHotKey is { })
            {
                fullScreenHotKeyButton.Text = fullscreenHotKey.Data.ToString();
                fullScreenHotKeyButton.HotKey = fullscreenHotKey.Data;
            }
            
            var regionHotKey = _hotkeyService.GetHotKey(KeyTask.Region);
            if (regionHotKey is { })
            {
                regionHotKeyButton.Text = regionHotKey.Data.ToString();
                regionHotKeyButton.HotKey = regionHotKey.Data;
            }
            
            var regionNoUploadHotKey = _hotkeyService.GetHotKey(KeyTask.RegionNoUpload);
            if (regionNoUploadHotKey is { })
            {
                noUploadHotKeyButton.Text = regionNoUploadHotKey.Data.ToString();
                noUploadHotKeyButton.HotKey = regionNoUploadHotKey.Data;
            }
            
            var recordScreenHotKey = _hotkeyService.GetHotKey(KeyTask.RecordScreen);
            if (recordScreenHotKey is { })
            {
                recordScreenHotKeyButton.Text = recordScreenHotKey.Data.ToString();
                recordScreenHotKeyButton.HotKey = recordScreenHotKey.Data;
            }
            
            var uploadClipboardHotKey = _hotkeyService.GetHotKey(KeyTask.UploadClipboard);
            if (uploadClipboardHotKey is { })
            {
                uploadClipboardHotKeyButton.Text = uploadClipboardHotKey.Data.ToString();
                uploadClipboardHotKeyButton.HotKey = uploadClipboardHotKey.Data;
            }
        }

        private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            //initialize screenshot shit, aka show form and capture shit.
            //capture screen.
            if (_tasks.CurrentTask != KeyTask.RecordScreen)
            {
                if (_tasks.CurrentTask != KeyTask.Empty)
                {
                    return;
                }
            }

            var hotkey = _hotkeyService.GetHotKey(e.Id);
            if (hotkey is null)
            {
                return;
            }

            switch (hotkey.Task)
            {
                case KeyTask.Region:
                    _tasks.CurrentTask = hotkey.Task;
                    Invoke((MethodInvoker)(() =>
                    {
                        var capture = Utils.CopyScreen();
                        var screenshotForm = new ScreenshotForm(_settings, _uploader, capture, _tasks);
                        screenshotForm.ShowDialog();

                        var cloneBitmap = screenshotForm.GetProcessedImage();

                        Process(cloneBitmap, true);

                        _tasks.Reset();
                    }));
                    break;
                case KeyTask.RegionNoUpload:
                    _tasks.CurrentTask = hotkey.Task;
                    Invoke((MethodInvoker)(() =>
                    {
                        var capture = Utils.CopyScreen();
                        var screenshotForm = new ScreenshotForm(_settings, _uploader, capture, _tasks);
                        screenshotForm.ShowDialog();

                        var cloneBitmap = screenshotForm.GetProcessedImage();

                        Process(cloneBitmap, false);

                        _tasks.Reset();
                    }));
                    break;
                case KeyTask.Fullscreen:
                    _tasks.CurrentTask = hotkey.Task;
                    Invoke((MethodInvoker)(() =>
                    {
                        //check for shit.
                        var capture = _settings.Capture.StitchFullscreen
                                          ? Utils.CopyScreen()
                                          : Utils.BitBltCopy(Screen.FromPoint(Cursor.Position).Bounds);

                        Process(capture, true);
                        
                        _tasks.Reset();
                    }));
                    break;
                case KeyTask.ActiveWindow:
                    _tasks.CurrentTask = hotkey.Task;
                    Invoke((MethodInvoker)(() =>
                    {
                        var rect = Utils.GetActiveWindowCoords();
                        var cloneBitmap = Utils.CopyActiveWindow(rect);
                        
                        Process(cloneBitmap, true);

                        _tasks.Reset();
                    }));
                    break;
                case KeyTask.RecordScreen:
                    if (_tasks.CurrentTask == KeyTask.RecordScreen)
                    {
                        if (_videoRecorderForm != null)
                        {
                            _videoRecorderForm.Fmp.Close();
                            _videoRecorderForm.Stopwatch.Stop();
                            _videoRecorderForm.Cancel = true;
                            _tasks.Reset();
                        }
                    }
                    else
                    {
                        _tasks.CurrentTask = hotkey.Task;
                        Invoke((MethodInvoker)(() =>
                        {
                            //check settings.
                            if (_settings.Record.ShowWarning)
                            {
                                var recordingNotice = new RecordingNotice(_settings);
                                recordingNotice.ShowDialog();
                            }

                            var capture = Utils.CopyScreen();
                            _videoRecorderForm.SetUpForm(capture, metroLabel9.GetThemeFont(), _tasks);
                            _videoRecorderForm.Show();
                        }));
                    }
                    break;
                case KeyTask.UploadClipboard:
                    _tasks.CurrentTask = hotkey.Task;
                    if (Clipboard.ContainsText())
                    {
                        //try to upload via shotr
                        _uploader.AddToQueue(new ImageShell(Encoding.ASCII.GetBytes(Clipboard.GetText()), FileExtensions.txt));
                    }
                    else if (Clipboard.ContainsImage())
                    {
                        _uploader.AddToQueue(new ImageShell(Utils.ImageToByteArray(Clipboard.GetImage(), FileExtensions.png, false, 100L), FileExtensions.png));
                    }
                    else if (Clipboard.ContainsFileDropList())
                    {
                        var file = Clipboard.GetFileDropList();
                        if (file.Count == 1)
                        {
                            //upload image, first check extension.
                            var ext = Path.GetExtension(file[0]);
                            ext = ext.Replace(".", "");
                            if (Enum.IsDefined(typeof(FileExtensions), ext.ToLower()))
                            {
                                _uploader.AddToQueue(new ImageShell(File.ReadAllBytes(file[0]), (FileExtensions)Enum.Parse(typeof(FileExtensions), ext)));
                            }
                        }
                    }
                    _tasks.Reset();
                    break;
            }

            void Process(Bitmap bitmap, bool upload)
            {
                if (bitmap != null)
                {
                    _musicPlayerService.PlayCaptured();

                    var image = _settings.Capture.Extension switch
                    {
                        { } p when p == FileExtensions.png && _settings.Capture.CompressionEnabled =>
                            Utils.ImageToByteArray(Utils.Quantize(bitmap), FileExtensions.png, false, 0),
                        FileExtensions.png => Utils.ImageToByteArray(bitmap, FileExtensions.png, false, 0),
                        _ => Utils.ImageToByteArray(bitmap, FileExtensions.jpg,
                            _settings.Capture.CompressionEnabled, (long) _settings.Capture.CompressionLevel)
                    };
                            
                    bitmap.Dispose();

                    if (upload)
                    {
                        _uploader.AddToQueue(new ImageShell(image, _settings.Capture.Extension));
                        return;
                    }
                    
                    _uploader.ProcessWithoutUpload(new ImageShell(image, _settings.Capture.Extension));
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsService.Save(_settings);
            Environment.Exit(0);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            Show();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            // Move to top.
            Focus();
            Activate();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void betterListView1_MouseDoubleClick(object sender, EventArgs e)
        {
            //see if item is selected.
            if (betterListView1.SelectedItems.Count > 0)
            {
                //Process.Start(Core.Utils.Settings.Instance.GetUploadedImage(betterListView1.SelectedItems[0].SubItems[1].Text).URL);
            }
        }

        private void clearHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clear history.
            betterListView1.Items.Clear();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _aboutForm.ShowDialog();
        }
        
        private void copyURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (betterListView1.SelectedItems.Count > 0)
            {
                Clipboard.SetText(betterListView1.SelectedItems[0].Text);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            Show();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            //show settings.
            metroTabControl1.SelectTab(1);
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //save image uploader.
            _settings.Capture.Uploader = (string)selectedImageUploader.SelectedItem;
            UpdateDirectUrl();
        }

        private void customUploaderButton_Click(object sender, EventArgs e)
        {
            // TODO: Rework custom uploader functionality
            MessageBox.Show("This functionality is being reworked.");
        }

        private void HotkeyError(string hotkeyName)
        {
            MessageBox.Show(this, $"Failed to set hotkey hook for '{hotkeyName}'. Please make sure the combinations you entered aren't being used by another application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void regionHotkeyButton_OnHotKeyChanged(object sender, EventArgs e)
        {
            var hook = _hotkeyService.SetNewHook(regionHotKeyButton.HotKey.ModifiersEnum, regionHotKeyButton.HotKey.Hotkey, KeyTask.Region);
            if (!hook)
            {
                HotkeyError("Region");
            }
            
            UpdateHotKeys();
        }

        private void fullScreenHotKeyButton_OnHotKeyChanged(object sender, EventArgs e)
        {
            var hook = _hotkeyService.SetNewHook(fullScreenHotKeyButton.HotKey.ModifiersEnum, fullScreenHotKeyButton.HotKey.Hotkey, KeyTask.Fullscreen);
            if (!hook)
            {
                HotkeyError("Fullscreen");
            }
            UpdateHotKeys();
        }

        private void activeWindowHotKeyButton_OnHotKeyChanged(object sender, EventArgs e)
        {
            var hook = _hotkeyService.SetNewHook(activeWindowHotKeyButton.HotKey.ModifiersEnum, activeWindowHotKeyButton.HotKey.Hotkey, KeyTask.ActiveWindow);
            if (!hook)
            {
                HotkeyError("Active Window");
            }
            UpdateHotKeys();
        }

        private void recordScreenHotKeyButton_OnHotKeyChanged(object sender, EventArgs e)
        {
            var hook = _hotkeyService.SetNewHook(recordScreenHotKeyButton.HotKey.ModifiersEnum, recordScreenHotKeyButton.HotKey.Hotkey, KeyTask.RecordScreen);
            if (!hook)
            {
                HotkeyError("Record Screen");
            }
            UpdateHotKeys();
        }

        private void uploadClipboardHotKeyButton_OnHotKeyChanged(object sender, EventArgs e)
        {
            var hook = _hotkeyService.SetNewHook(uploadClipboardHotKeyButton.HotKey.ModifiersEnum, uploadClipboardHotKeyButton.HotKey.Hotkey, KeyTask.UploadClipboard);
            if (!hook)
            {
                HotkeyError("Upload Clipboard");
            }
            UpdateHotKeys();
        }

        private void noUploadHotKeyButton_OnHotKeyChanged(object sender, EventArgs e)
        {
            var hook = _hotkeyService.SetNewHook(noUploadHotKeyButton.HotKey.ModifiersEnum, noUploadHotKeyButton.HotKey.Hotkey, KeyTask.RegionNoUpload);
            if (!hook)
            {
                HotkeyError("Save Only");
            }
            UpdateHotKeys();
        }
        
        private void resetSettingsButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "This will set your settings back to default, continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // todo: Reset to default settings.
                UpdateControls();
            }
        }
        
        private void settingsButton_Click(object sender, EventArgs e)
        {
            //show global settings
            _settingsForm.ShowDialog();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            _settings.Login.Email = null;
            _settings.Login.Token = null;
            _settings.Login.Password = null;
            Application.Restart();
            Environment.Exit(0);
        }

        private void aboutLabel_Click(object sender, EventArgs e)
        {
            //clicked on shotr version at bottom.
            new AboutForm().ShowDialog();
        }

        private void colorPickerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //show color picker form.
            var capture = Utils.CopyScreen();
            var colorPickerForm = new ColorPickerForm(_settings, capture);
            colorPickerForm.ShowDialog();
        }

        private void regionCaptureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var hotkey = _hotkeyService.GetHotKey(KeyTask.Region);
            if (hotkey is { })
            {
                hook_KeyPressed(this, new KeyPressedEventArgs(hotkey.Id));
            }
        }

        private void fullscreenCaptureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var hotkey = _hotkeyService.GetHotKey(KeyTask.Fullscreen);
            if (hotkey is { })
            {
                hook_KeyPressed(this, new KeyPressedEventArgs(hotkey.Id));
            }
        }

        private void recordScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var hotkey = _hotkeyService.GetHotKey(KeyTask.RecordScreen);
            if (hotkey is { })
            {
                hook_KeyPressed(this, new KeyPressedEventArgs(hotkey.Id));
            }
        }

        private void uploadClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var hotkey = _hotkeyService.GetHotKey(KeyTask.UploadClipboard);
            if (hotkey is { })
            {
                hook_KeyPressed(this, new KeyPressedEventArgs(hotkey.Id));
            }
        }

        private IImageUploader? GetUploader(string name)
        {
            return _uploaders.FirstOrDefault(p => p.Title == name);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Shotr.Core;
using Shotr.Core.Controls.Hotkey;
using Shotr.Core.Controls.Theme;
using Shotr.Core.Entities;
using Shotr.Core.Entities.Hotkeys;
using Shotr.Core.Entities.Web;
using Shotr.Core.Image;
using Shotr.Core.MimeDetect;
using Shotr.Core.Pipes;
using Shotr.Core.Services;
using Shotr.Core.Settings;
using Shotr.Core.Uploader;
using Shotr.Core.Utils;
using Shotr.Ui.Forms.Settings;

namespace Shotr.Ui.Forms
{
    public partial class MainForm : ThemedForm
    {
        private readonly BaseSettings _settings;
        private readonly Uploader _uploader;
        private readonly PipeServer _pipeServer;

        private readonly SingleInstance _tasks;

        private readonly HotKeyService _hotkeyService;
        private readonly SettingsService _settingsService;

        private readonly IEnumerable<IImageUploader> _uploaders;
        private readonly MusicPlayerService _musicPlayerService;

        private readonly ShotrApiService _shotrApiService;

        private Icon _shotrIcon;
        private VideoRecorderForm _videoRecorderForm;

        public MainForm(BaseSettings settings,
                        Uploader uploader,
                        PipeServer pipeServer,
                        SingleInstance tasks,
                        HotKeyService hotkeyService,
                        SettingsService settingsService,
                        IEnumerable<IImageUploader> uploaders,
                        MusicPlayerService musicPlayerService,
                        ShotrApiService shotrApiService)
        {
            _settings = settings;
            _uploader = uploader;
            _pipeServer = pipeServer;
            _tasks = tasks;
            _hotkeyService = hotkeyService;
            _settingsService = settingsService;
            _uploaders = uploaders;
            _musicPlayerService = musicPlayerService;
            _shotrApiService = shotrApiService;

            InitializeComponent();

            Shown += MainFormShown;
            _pipeServer.PipeServerReceivedClient += _pipeserver_PipeServerReceivedClient;
            _pipeServer.StartServer();

            _shotrIcon = Icon;
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
            if (DesignMode) return;

            if (_settings.StartMinimized)
            {
                ShowInTaskbar = false;
                Visible = false;
            }
            else
            {
                //ShadowType = MetroFormShadowType.DropShadow;
                ShowInTaskbar = true;
                Visible = true;
            }

            UpdateControls();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var hotkeyList = new Dictionary<KeyTask, HotKeyButton>
            {
                { KeyTask.ActiveWindow, activeWindowHotKeyButton },
                { KeyTask.Fullscreen, fullScreenHotKeyButton },
                { KeyTask.ActiveFullscreen, activeFullscreenHotKeyButton },
                { KeyTask.Region, regionHotKeyButton },
                { KeyTask.UploadClipboard, uploadClipboardHotKeyButton },
                { KeyTask.ColorPicker, colorPickerHotKeyButton },
                { KeyTask.RecordScreen, recordScreenHotKeyButton }
            };

            _hotkeyService.KeyPressed += hook_KeyPressed;
            UpdateControls(firstLoad: true);
            _uploader.StartQueue();
            _uploader.OnUploaded += Uploader_OnUploaded;
            _uploader.OnError += Uploader_OnError;
            _uploader.OnProgress += Uploader_OnProgress;

            activeWindowHotKeyButton.OnHotKeyClicked += (_, _) => UnloadAndDisableHotKeys(KeyTask.ActiveWindow);
            fullScreenHotKeyButton.OnHotKeyClicked += (_, _) => UnloadAndDisableHotKeys(KeyTask.Fullscreen);
            regionHotKeyButton.OnHotKeyClicked += (_, _) => UnloadAndDisableHotKeys(KeyTask.Region);
            uploadClipboardHotKeyButton.OnHotKeyClicked += (_, _) => UnloadAndDisableHotKeys(KeyTask.UploadClipboard);
            colorPickerHotKeyButton.OnHotKeyClicked += (_, _) => UnloadAndDisableHotKeys(KeyTask.ColorPicker);
            recordScreenHotKeyButton.OnHotKeyClicked += (_, _) => UnloadAndDisableHotKeys(KeyTask.RecordScreen);
            activeFullscreenHotKeyButton.OnHotKeyClicked += (_, _) => UnloadAndDisableHotKeys(KeyTask.ActiveFullscreen);

            activeWindowHotKeyButton.OnHotKeyCanceled += (_, _) => ReloadAndEnableHotKeys();
            fullScreenHotKeyButton.OnHotKeyCanceled += (_, _) => ReloadAndEnableHotKeys();
            regionHotKeyButton.OnHotKeyCanceled += (_, _) => ReloadAndEnableHotKeys();
            uploadClipboardHotKeyButton.OnHotKeyCanceled += (_, _) => ReloadAndEnableHotKeys();
            colorPickerHotKeyButton.OnHotKeyCanceled += (_, _) => ReloadAndEnableHotKeys();
            recordScreenHotKeyButton.OnHotKeyCanceled += (_, _) => ReloadAndEnableHotKeys();
            activeFullscreenHotKeyButton.OnHotKeyCanceled += (_, _) => ReloadAndEnableHotKeys();

            activeWindowHotKeyButton.OnHotKeyChanged += (button, _) => SetNewHotKey("Active Window",
                button, KeyTask.ActiveWindow);
            fullScreenHotKeyButton.OnHotKeyChanged += (button, _) => SetNewHotKey("Fullscreen",
                button, KeyTask.Fullscreen);
            regionHotKeyButton.OnHotKeyChanged += (button, _) => SetNewHotKey("Region",
                button, KeyTask.Region);
            uploadClipboardHotKeyButton.OnHotKeyChanged += (button, _) => SetNewHotKey("Clipboard Upload",
                button, KeyTask.UploadClipboard);
            colorPickerHotKeyButton.OnHotKeyChanged += (button, _) => SetNewHotKey("Color Picker",
                button, KeyTask.ColorPicker);
            recordScreenHotKeyButton.OnHotKeyChanged += (button, _) => SetNewHotKey("Record Screen",
                button, KeyTask.RecordScreen);
            activeFullscreenHotKeyButton.OnHotKeyChanged += (button, _) => SetNewHotKey("Active Fullscreen",
                button, KeyTask.ActiveFullscreen);

            notifyIcon1.Disposed += (_, _) =>
            {
                notifyIcon1 = new NotifyIcon
                {
                    ContextMenuStrip = contextMenuStrip1,
                    Visible = true,
                };
                notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            };

            notifyIcon1.Icon = (Icon)_shotrIcon.Clone();

            void SetNewHotKey(string name, object? passedHotKeyButtonObject, KeyTask task)
            {
                if (passedHotKeyButtonObject is HotKeyButton passedHotKeyButton)
                {
                    foreach (var (keyTask, keyButton) in hotkeyList)
                    {
                        // look at other items and see if there's one that already exists.
                        if (keyButton.HotKey is { } && passedHotKeyButton.HotKey is { } &&
                            keyButton.HotKey.HotKey == passedHotKeyButton.HotKey.HotKey && task != keyTask)
                        {
                            // set the hotkey for the found one to none.
                            keyButton.Key = Keys.None;
                            keyButton.HotKey = new HotKeyData(Keys.None);
                            keyButton.Text = "None";
                        }
                    }

                    var hook = _hotkeyService.SetNewHook(passedHotKeyButton.HotKey.ModifiersEnum,
                        passedHotKeyButton.HotKey.HotKey, task);
                    if (!hook)
                    {
                        MessageBox.Show(this,
                            $"Failed to set hotkey hook for '{name}'. Please make sure the combinations you entered aren't being used by another application",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    UpdateHotKeys();
                    ReloadAndEnableHotKeys();
                }
            }

            void UnloadAndDisableHotKeys(KeyTask doNotDisable)
            {
                foreach (var (task, button) in hotkeyList)
                {
                    _hotkeyService.UnloadHotKey(task);

                    if (task == doNotDisable)
                    {
                        continue;
                    }

                    button.Enabled = false;
                }
            }

            void ReloadAndEnableHotKeys()
            {
                foreach (var (task, button) in hotkeyList)
                {
                    _hotkeyService.LoadSingleHotKey(button.HotKey.HotKey, task);
                    button.Enabled = true;
                }
            }
        }

        void Uploader_OnProgress(double progress)
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
                    notifyIcon1.Text = $"Upload Progress: {Convert.ToInt32(progress)}%";
                    s.Dispose();
                }));
            }
            catch
            {
            }
        }

        void Uploader_OnError(FileShell fileShell, bool allowReUpload, FileTypeEnum fileType, string uploader,
                              string errorMessage)
        {
            if (!WineDetectionService.IsWine())
            {
                // Take the current file and save it to a temp file if in mem to allow re-upload.
                var filePath = fileShell.Path ?? Path.GetTempFileName();
                if (fileShell.Data is { } && fileShell.Path is null)
                {
                    File.WriteAllBytes(filePath, fileShell.Data);
                }

                var message = $"Upload to {uploader} failed: {errorMessage}";

                Toast.Send(null, message.Substring(0, message.Length > 128 ? 125 : message.Length) + "...",
                    allowReUpload ? "Retry Upload" : null,
                    allowReUpload ? "retryUpload" : null,
                    allowReUpload ? $"path={filePath}" : null);
            }
            else
            {
                try
                {
                    var errorNotification =
                        new ErrorNotification(fileShell, fileType, allowReUpload, uploader, errorMessage);
                    Invoke((MethodInvoker)(() => { errorNotification.Show(); }));
                }
                catch
                {
                    Console.WriteLine("Error while showing error.");
                }
            }
        }

        private void Uploader_OnUploaded(FileShell fileShell, UploadResult? result, SaveResult? saveResult,
                                         FileTypeEnum fileType, string extension, string uploader)
        {
            var fileName = $"{_settings.Capture.SaveToDirectoryPath}\\{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.{extension}";

            if (_settings.Capture.SaveToDirectory)
            {
                if (_settings.Capture.SaveToDirectoryPath is { } &&
                    !Directory.Exists(_settings.Capture.SaveToDirectoryPath))
                {
                    Directory.CreateDirectory(_settings.Capture.SaveToDirectoryPath);
                }

                if (fileShell.Data is { })
                {
                    File.WriteAllBytes(fileName, fileShell.Data);
                }
                else if (fileShell.Path is { })
                {
                    File.Copy(fileShell.Path, fileName);
                }
            }

            var url = result is { } ? _settings.Capture.DirectUrl ? result.Url : result.PageUrl : "";

            if (result is { })
            {
                // Add to history.
                var listViewItem = new ListViewItem
                {
                    Text = url
                };

                listViewItem.SubItems.Add(result.Time.FromUnixTime().ToString());

                var parsedUrl = new Uri(result.Url);
                var withoutExtension = Path.GetFileNameWithoutExtension(parsedUrl.AbsolutePath);

                var uploadItem = new UploadItem
                {
                    Name = withoutExtension,
                    Extension = extension,
                    Time = result.Time.FromUnixTime()
                };

                _settings.Uploads ??= new List<UploadItem>();
                _settings.Uploads.Add(uploadItem);

                Invoke((MethodInvoker)(() =>
                {
                    themedListView1.Items.Insert(0, listViewItem);
                    uploadCountLabel.Text = _settings.Uploads.Count.ToString();
                }));
            }

            Invoke((MethodInvoker)(() =>
            {
                Image jpg = null;
                Bitmap b = null;
                if (fileType == FileTypeEnum.Image)
                {
                    using (var k = new MemoryStream(fileShell.Data ?? File.ReadAllBytes(fileShell.Path)))
                    {
                        jpg = Image.FromStream(k);
                        b = new Bitmap(jpg);
                    }

                    var dataObj = new DataObject();
                    if (result != null)
                    {
                        dataObj.SetText(url);
                    }

                    dataObj.SetImage(b);
                    Clipboard.SetDataObject(dataObj);
                }
                else
                {
                    Clipboard.SetText(url);
                }

                try
                {
                    string? toastNotificationImagePath = null;
                    if (b is { })
                    {
                        toastNotificationImagePath = Path.Combine(SettingsService.CachePath, "notification.png");
                        b.Save(toastNotificationImagePath);
                    }

                    if (result != null)
                    {
                        if (_settings.ShowNotifications)
                        {
                            if (!WineDetectionService.IsWine())
                            {
                                Toast.Send(fileName,
                                    fileType == FileTypeEnum.Text
                                        ? "Text uploaded and link copied to clipboard!"
                                        : fileType == FileTypeEnum.Video
                                            ? "Recording uploaded and link copied to clipboard!"
                                            : fileType == FileTypeEnum.Image
                                                ? "Screenshot uploaded and link copied to clipboard!"
                                                : "File uploaded and link copied to clipboard!", "View Upload",
                                    "viewUrl",
                                    $"url={url}");
                            }
                            else
                            {
                                var notification = new Notification(url, fileType);
                                notification.Show();
                            }
                        }
                    }
                    else
                    {
                        if (_settings.ShowNotifications)
                        {
                            if (!WineDetectionService.IsWine())
                            {
                                var screenshotText =
                                    $"Screenshot {(_settings.Capture.SaveToDirectory ? "saved and " : "")}copied to clipboard!";
                                Toast.Send(fileName,
                                    fileType == FileTypeEnum.Video
                                        ? "Recording saved!"
                                        : screenshotText,
                                    _settings.Capture.SaveToDirectory ? "Open Containing Folder" : null,
                                    _settings.Capture.SaveToDirectory ? "openDirectory" : null,
                                    _settings.Capture.SaveToDirectory ? $"path={fileName}" : null);
                            }
                            else
                            {
                                var notification = new NoUploadNotification(fileType);
                                notification.Show();
                            }
                        }
                    }
                }
                catch
                {
                }

                jpg?.Dispose();
            }));
        }

        private void UpdateControls(bool firstLoad = false)
        {
            if (firstLoad)
            {
                themedListView1.DoubleClick += betterListView1_MouseDoubleClick;
                var version = Assembly.GetExecutingAssembly().GetName().Version;
                metroLabel8.Text = $"v{version.Major}.{version.Minor}.{version.Build}";
            }

            UpdateHotKeys();
            UpdateListView(firstLoad);

            if (_settings.Login.Enabled == true)
            {
                loginToShotrPanel.Visible = false;
                emailLabel.Text = _settings.Login.Email;
                if (_settings.Uploads is { })
                {
                    uploadCountLabel.Text = _settings.Uploads.Count.ToString();
                }

                myAccountPanel.BringToFront();

                clipboardLabel.Enabled = true;

                uploadClipboardHotKeyButton.Enabled = true;

                // Show History tab
                if (_settings.LegacyHistory is null && !metroTabControl1.TabPages.ContainsKey("metroTabPage4"))
                {
                    metroTabControl1.SelectTab(0);
                    metroTabControl1.TabPages.Insert(0, metroTabPage4);
                }
            }
            else
            {
                // Disable all the other buttons and labels and unregister the hotkeys.
                clipboardLabel.Enabled = false;

                uploadClipboardHotKeyButton.Enabled = false;

                // Hide history tab.
                if (_settings.LegacyHistory is null)
                {
                    metroTabControl1.SelectTab(0);
                    metroTabControl1.TabPages.Remove(metroTabPage4);
                }
            }
        }

        private void UpdateListView(bool firstLoad = false)
        {
            UpdateListViewColumnSize();

            if (_settings.Uploads is { } && _settings.Uploads.Count > 0)
            {
                foreach (var item in _settings.Uploads)
                {
                    var listViewItem = new ListViewItem
                    {
                        Text = $"https://shotr.dev/{item.Name}",
                    };
                    listViewItem.SubItems.Add(item.Time.ToLocalTime().ToString());

                    themedListView1.Items.Add(listViewItem);
                }
            }

            if (firstLoad)
            {
                var templist = new List<UploadResult>();
                if (_settings.LegacyHistory is { })
                {
                    templist.AddRange(_settings.LegacyHistory.Select(p => p.Value).ToList());
                }

                // Check with uploaded history.
                var directUrl = _settings.Capture.DirectUrl;
                for (var i = templist.Count - 1; i >= 0; i--)
                {
                    if (directUrl)
                    {
                        var m = GetUploader(templist[i].Uploader);
                        var x = new ListViewItem
                            { Text = !m.SupportsPages && !directUrl ? templist[i].Url : templist[i].PageUrl };
                        x.SubItems.Add(templist[i].Time.FromUnixTime().ToString());
                        themedListView1.Items.Add(x);
                    }
                    else
                    {
                        var x = new ListViewItem { Text = (directUrl ? templist[i].Url : templist[i].PageUrl) };
                        x.SubItems.Add(templist[i].Time.FromUnixTime().ToString());
                        themedListView1.Items.Add(x);
                    }
                }
            }
        }

        private void UpdateListViewColumnSize()
        {
            if (themedListView1 is ListView listView)
            {
                // Get the sum of all column tags
                var totalColumnWidth = themedListView1.Size.Width;

                // Calculate the percentage of space each column should 
                // occupy in reference to the other columns and then set the 
                // width of the column to that percentage of the visible space.
                for (var i = 0; i < listView.Columns.Count; i++)
                {
                    float colPercentage = Convert.ToInt32(totalColumnWidth / 2);
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
                _settings.Hotkey.ActiveWindow = activeWindowHotKey.Keys;
            }

            var fullscreenHotKey = _hotkeyService.GetHotKey(KeyTask.Fullscreen);
            if (fullscreenHotKey is { })
            {
                fullScreenHotKeyButton.Text = fullscreenHotKey.Data.ToString();
                fullScreenHotKeyButton.HotKey = fullscreenHotKey.Data;
                _settings.Hotkey.Fullscreen = fullscreenHotKey.Keys;
            }

            var regionHotKey = _hotkeyService.GetHotKey(KeyTask.Region);
            if (regionHotKey is { })
            {
                regionHotKeyButton.Text = regionHotKey.Data.ToString();
                regionHotKeyButton.HotKey = regionHotKey.Data;
                _settings.Hotkey.Region = regionHotKey.Keys;
            }

            var colorPickerHotKey = _hotkeyService.GetHotKey(KeyTask.ColorPicker);
            if (colorPickerHotKey is { })
            {
                colorPickerHotKeyButton.Text = colorPickerHotKey.Data.ToString();
                colorPickerHotKeyButton.HotKey = colorPickerHotKey.Data;
                _settings.Hotkey.ColorPicker = colorPickerHotKey.Keys;
            }

            var recordScreenHotKey = _hotkeyService.GetHotKey(KeyTask.RecordScreen);
            if (recordScreenHotKey is { })
            {
                recordScreenHotKeyButton.Text = recordScreenHotKey.Data.ToString();
                recordScreenHotKeyButton.HotKey = recordScreenHotKey.Data;
                _settings.Hotkey.RecordScreen = recordScreenHotKey.Keys;
            }

            var uploadClipboardHotKey = _hotkeyService.GetHotKey(KeyTask.UploadClipboard);
            if (uploadClipboardHotKey is { })
            {
                uploadClipboardHotKeyButton.Text = uploadClipboardHotKey.Data.ToString();
                uploadClipboardHotKeyButton.HotKey = uploadClipboardHotKey.Data;
                _settings.Hotkey.Clipboard = uploadClipboardHotKey.Keys;
            }

            var activeFullscreenHotKey = _hotkeyService.GetHotKey(KeyTask.ActiveFullscreen);
            if (activeFullscreenHotKey is { })
            {
                activeFullscreenHotKeyButton.Text = activeFullscreenHotKey.Data.ToString();
                activeFullscreenHotKeyButton.HotKey = activeFullscreenHotKey.Data;
                _settings.Hotkey.ActiveFullscreen = activeFullscreenHotKey.Keys;
            }

            SettingsService.Save(_settings);
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
                        var currentBoundaries = Utils.GetScreenBoundaries();
                        var sizeToAllocate = currentBoundaries.Width * currentBoundaries.Height * 4;
                        GC.AddMemoryPressure(sizeToAllocate);
                        var capture = Utils.CopyScreen(_settings.Capture.HideCursor);
                        var screenshotForm = new ScreenshotForm(_settings, _uploader, capture, _tasks);
                        screenshotForm.ShowDialog();

                        var cloneBitmap = screenshotForm.GetProcessedImage();

                        switch (screenshotForm.ScreenshotAction)
                        {
                            case ScreenshotActionEnum.Upload:
                                Process(cloneBitmap, true);
                                break;
                            case ScreenshotActionEnum.SaveToFile:
                                Process(cloneBitmap, false, true);
                                break;
                            case ScreenshotActionEnum.SaveToClipboard:
                                Process(cloneBitmap);
                                break;
                        }

                        GC.RemoveMemoryPressure(sizeToAllocate);
                        GC.Collect(3);

                        _tasks.Reset();
                    }));
                    break;
                case KeyTask.ColorPicker:
                    _tasks.CurrentTask = hotkey.Task;
                    Invoke((MethodInvoker)(() =>
                    {
                        var capture = Utils.CopyScreen(_settings.Capture.HideCursor);
                        var colorPickerForm = new ColorPickerForm(_settings, capture);

                        if (colorPickerForm.ShowDialog() == DialogResult.OK)
                        {
                            Toast.Send(null, "Color code copied to clipboard!");
                        }

                        _tasks.Reset();
                    }));
                    break;
                case KeyTask.Fullscreen:
                case KeyTask.ActiveWindow:
                case KeyTask.ActiveFullscreen:
                    _tasks.CurrentTask = hotkey.Task;
                    Invoke((MethodInvoker)(() =>
                    {
                        var capture = Utils.CopyScreen(_settings.Capture.HideCursor);
                        var boundaries = Utils.GetScreenBoundaries();

                        var rect = hotkey.Task switch
                        {
                            KeyTask.Fullscreen => new Rectangle(boundaries.X, boundaries.Y, capture.Width,
                                capture.Height),
                            KeyTask.ActiveWindow => Utils.GetActiveWindowCoords(),
                            KeyTask.ActiveFullscreen => Screen.FromPoint(Cursor.Position).Bounds,
                            _ => throw new ArgumentNullException("Cannot choose nonexistant capture type.")
                        };


                        var screenshotForm = new ScreenshotForm(_settings, _uploader, capture, _tasks, rect);
                        screenshotForm.ShowDialog();

                        var cloneBitmap = screenshotForm.GetProcessedImage();

                        switch (screenshotForm.ScreenshotAction)
                        {
                            case ScreenshotActionEnum.Upload:
                                Process(cloneBitmap, true);
                                break;
                            case ScreenshotActionEnum.SaveToFile:
                                Process(cloneBitmap, false, true);
                                break;
                            case ScreenshotActionEnum.SaveToClipboard:
                                Process(cloneBitmap);
                                break;
                        }

                        _tasks.Reset();
                    }));
                    break;
                case KeyTask.RecordScreen:
                    if (!File.Exists(Path.Combine(SettingsService.FolderPath, "ffmpeg.exe")) ||
                        Utils.MD5File(Path.Combine(SettingsService.FolderPath, "ffmpeg.exe")) !=
                        "05a894305c9bd146dad4cc3ff0e21e83")
                    {
                        var mpg = new FfMpegDownload();
                        if (mpg.ShowDialog() == DialogResult.Cancel)
                        {
                            _tasks.Reset();
                            return;
                        }
                    }

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

                            var capture = Utils.CopyScreen(_settings.Capture.HideCursor);
                            _videoRecorderForm = new VideoRecorderForm(_settings, _musicPlayerService, _uploader,
                                capture, _tasks);
                            _videoRecorderForm.Show();
                        }));
                    }

                    break;
                case KeyTask.UploadClipboard:
                    _tasks.CurrentTask = hotkey.Task;
                    if (Clipboard.ContainsText())
                    {
                        //try to upload via shotr
                        _uploader.AddToQueue(new FileShell(Encoding.ASCII.GetBytes(Clipboard.GetText())));
                    }
                    else if (Clipboard.ContainsImage())
                    {
                        var image = Clipboard.GetImage();
                        if (image is { })
                        {
                            _uploader.AddToQueue(new FileShell(image.ImageToByteArray()));
                        }
                    }
                    else if (Clipboard.ContainsFileDropList())
                    {
                        var file = Clipboard.GetFileDropList();
                        if (file.Count == 1)
                        {
                            var mime = new Mime();
                            var node = mime.DetectFile(file[0]);

                            if (node.FileType != FileTypeEnum.Unknown)
                            {
                                _uploader.AddToQueue(new FileShell(file[0]));
                            }
                        }
                    }

                    _tasks.Reset();
                    break;
            }

            void Process(Bitmap bitmap, bool upload = false, bool saveToFile = false)
            {
                if (bitmap != null)
                {
                    _musicPlayerService.PlayCaptured();
                    var mime = new Mime();

                    var fileMimeType = mime.GetMimeForFileExtension(_settings.Capture.Extension);
                    var image = _settings.Capture.Extension switch
                    {
                        { } p when p == "png" && _settings.Capture.CompressionEnabled => Utils.Quantize(bitmap)
                                                                                              .ImageToByteArrayConvert(
                                                                                                  fileMimeType),
                        "png" => bitmap.ImageToByteArrayConvert(fileMimeType),
                        _ => bitmap.ImageToByteArrayCompressed(fileMimeType, (long)_settings.Capture.CompressionLevel)
                    };

                    bitmap.Dispose();

                    if (upload)
                    {
                        _uploader.AddToQueue(new FileShell(image));
                        return;
                    }

                    if (saveToFile)
                    {
                        var saveDialog = new SaveFileDialog
                        {
                            Filter =
                                $"{_settings.Capture.Extension} files (*.{_settings.Capture.Extension})|*.{_settings.Capture.Extension}|All files (*.*)|*.*",
                            FileName = $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.{_settings.Capture.Extension}",
                        };

                        var result = saveDialog.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            File.WriteAllBytes(saveDialog.FileName, image);
                            Toast.Send(null, "Image saved to file!", "Open Containing Folder", "openDirectory",
                                $"path={saveDialog.FileName}");
                        }

                        return;
                    }

                    _uploader.ProcessWithoutUpload(new FileShell(image));
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
            if (themedListView1.SelectedItems.Count > 0)
            {
                if (_settings.LegacyHistory is { })
                {
                    if (_settings.LegacyHistory.TryGetValue(
                        DateTime.Parse(themedListView1.SelectedItems[0].SubItems[1].Text).ToUnixTime(),
                        out var uploadResult))
                    {
                        uploadResult.Url.OpenUrl();
                        return;
                    }
                }


                if (_settings.Uploads is { })
                {
                    var upload = _settings.Uploads.FirstOrDefault(p =>
                        p.Time.ToLocalTime() == DateTime.Parse(themedListView1.SelectedItems[0].SubItems[1].Text));

                    if (upload is null)
                    {
                        return;
                    }

                    if (_settings.Capture.DirectUrl)
                    {
                        $"https://shotr.dev/{upload.Name}.{upload.Extension}".OpenUrl();
                    }
                    else
                    {
                        $"https://shotr.dev/{upload.Name}".OpenUrl();
                    }
                }
            }
        }

        private void clearHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clear history.
            themedListView1.Items.Clear();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void copyURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (themedListView1.SelectedItems.Count > 0)
            {
                Clipboard.SetText(themedListView1.SelectedItems[0].Text);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            Show();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            //show settings.
            if (metroTabControl1.TabPages.Count > 1)
            {
                metroTabControl1.SelectTab(1);
            }
            else
            {
                metroTabControl1.SelectTab(0);
            }
        }

        private void customUploaderButton_Click(object sender, EventArgs e)
        {
            // TODO: Rework custom uploader functionality
            MessageBox.Show("This functionality is being reworked.");
        }

        private void resetSettingsButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "This will set your settings back to default, continue?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SettingsService.Reset();
                Application.Restart();
                Environment.Exit(0);
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            // Show global settings view
            new SettingsForm(_settings, _uploaders).ShowDialog();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            _settings.Login.Email = null;
            _settings.Login.Token = null;
            _settings.Login.Password = null;
            _settings.Login.Enabled = false;
            SettingsService.Save(_settings);
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
            var capture = Utils.CopyScreen(_settings.Capture.HideCursor);
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

        private void loginToShotrButton_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm(_settings, _shotrApiService);
            loginForm.ShowDialog();
            if (loginForm.DialogResult == DialogResult.OK && _settings.Login.Token is { })
            {
                // Hide the login button and show the account panel.
                _hotkeyService.UnloadHotKeys();
                _hotkeyService.LoadHotKeys();

                UpdateControls();
            }
        }

        private IImageUploader? GetUploader(string name)
        {
            return _uploaders.FirstOrDefault(p => p.Title == name);
        }

        private async void viewAccountButton_Click(object sender, EventArgs e)
        {
            var token = await _shotrApiService.GenerateTemporaryAuthToken();
            if (token is { })
            {
                token.Token.OpenUrl();
            }
        }
    }
}
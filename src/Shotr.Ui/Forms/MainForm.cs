using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MetroFramework5.Controls;
using Shotr.Core.DpiScaling;
using Shotr.Core.Hotkey;
using Shotr.Core.Image;
using Shotr.Core.Pipes;
using Shotr.Core.Plugin;
using Shotr.Core.Uploader;
using Shotr.Core.Utils;
using Shotr.Ui.Forms.Settings;
using ShotrUploaderPlugin;

namespace Shotr.Ui.Forms
{
    public partial class MainForm : DpiScaledForm
    {
        private PipeServer _pipeserver;
        private Icon shotr_icon;
        private Bitmap shotr_icon_bmp;
        private List<ShotrCorePlugin> loadedplugins;

        public MainForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            Shown += MainFormShown;
            _pipeserver = new PipeServer();
            _pipeserver.PipeServerReceivedClient += _pipeserver_PipeServerReceivedClient;
            _pipeserver.StartServer();
            loadedplugins = new List<ShotrCorePlugin>();
            //plugin handler.
            PluginCore.OnPluginsChanged += (sender, e) => {
                //see if it's in our loaded plugins list already.
                foreach (ShotrCorePlugin coreplug in PluginCore.CorePlugin)
                {
                    if (!loadedplugins.Contains(coreplug))
                    {
                        if (coreplug.Enabled)
                        {
                            //load up the plugin.
                            Console.WriteLine("Recognized new plugin {0}. Loading default methods.", coreplug.Name);
                            loadedplugins.Add(coreplug);
                            Form test = coreplug.GetForm(new ShotrCore());
                            MetroTabPage lel = new MetroTabPage();
                            lel.Theme = "NewTheme";
                            //if (test.Size.Width > this.metroTabPage2.Size.Width || test.Size.Height > this.metroTabPage2.Size.Height) continue;
                            while (test.Controls.Count > 0)
                            {
                                foreach (Control w in Utils.GetControls(test.Controls[0]))
                                {
                                    lel.Controls.Add(w);
                                }
                            }
                            //p.BackColor = Color.FromArgb(32, 33, 37);
                            lel.Text = coreplug.Name;
                            metroTabControl1.TabPages.Add(lel);
                        }
                    }
                }
            };
            //load up core plugins.
            PluginCore.LoadCorePlugins();

            new Thread(delegate ()
            {
                bool isforeground = false;
                while (true)
                {
                    try
                    {
                        if (isforeground == false && Utils.IsDXFullScreen())
                        {
                            Invoke((MethodInvoker)(() =>
                            {
                                Core.Utils.Settings.Instance.UnloadHotKeys();
                            }));
                            //get pid and wait for process to end?
                            isforeground = true;
                            Console.WriteLine("Found foreground process: {0}", Utils.GetForegroundProcess().ProcessName);
                        }
                        else if (isforeground && !Utils.IsDXFullScreen())
                        {
                            //Thread.Sleep(5000);
                            Console.WriteLine("Reloaded hotkeys.");
                            Invoke((MethodInvoker)(() =>
                            {
                                Core.Utils.Settings.Instance.LoadHotKeys();
                            }));
                            Console.WriteLine("Finished reloading hotkeys");
                            isforeground = false;
                        }
                    }
                    catch
                    {
                        //wot.
                    }
                    Thread.Sleep(5000);
                }
            }).Start();
            shotr_icon = Icon;
            shotr_icon_bmp = shotr_icon.ToBitmap();
        }

        void _pipeserver_PipeServerReceivedClient(object sender, PipeServerEventArgs e)
        {
            foreach (HotKeyHook m in Core.Utils.Settings.Instance.hotkeys)
            {
                if (e.Data == "--region")
                {
                    if (m.Task == KeyTask.Region)
                    {
                        hook_KeyPressed(this, new KeyPressedEventArgs(m.ID));
                        break;
                    }
                }
                else if (e.Data == "--record")
                {
                    if (m.Task == KeyTask.RecordScreen)
                    {
                        hook_KeyPressed(this, new KeyPressedEventArgs(m.ID));
                        break;
                    }
                }
                else if (e.Data == "--launch")
                {
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
        }
        bool start;
        private void MainFormShown(object sender, EventArgs e)
        {
            if (!start)
            {
                if (Core.Utils.Settings.Instance.settings.ContainsKey("start_minimized") && (bool)Core.Utils.Settings.Instance.settings["start_minimized"][0])
                {
                    ShadowType = MetroFormShadowType.DropShadow;
                    ShowInTaskbar = false;
                    Visible = false;
                    start = true;
                }
                else
                {
                    ShowInTaskbar = true;
                    Visible = true;
                    start = true;
                }
            }
            else
            {
                ShowInTaskbar = true;
                Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Core.Utils.Settings.Instance.hook.KeyPressed += hook_KeyPressed;
            UpdateControls();
            Uploader.StartQueue();
            Uploader.OnUploaded += Uploader_OnUploaded;
            Uploader.OnError += Uploader_OnError;
            Uploader.OnProgress += Uploader_OnProgress;
            notifyIcon1.Disposed += (o, args) =>
            {
                notifyIcon1 = new NotifyIcon
                {
                    ContextMenuStrip = contextMenuStrip1,
                    Visible = true,
                };
                notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            };
            //minimize to window.
            notifyIcon1.Text = "Shotr";
            notifyIcon1.Icon = (Icon)shotr_icon.Clone();
            //add shit to listView.
            itm = deleteToolStripMenuItem;
            PluginCore.OnPluginsChanged += PluginCore_OnPluginsChanged;
            //check if needed to login to shotr.
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
                        Icon m = ImageManipulation.DefaultImage();
                        notifyIcon1.Icon.Dispose();
                        notifyIcon1.Icon = m;
                        notifyIcon1.Text = "Shotr";
                        m.Dispose();
                        return;
                    }

                    if (progress == 100)
                    {
                        Icon m = ImageManipulation.ImageStatus(99);
                        notifyIcon1.Icon.Dispose();
                        notifyIcon1.Icon = m;
                        notifyIcon1.Text = "Server is processing upload...";
                        m.Dispose();
                        return;
                    }
                    Icon s = ImageManipulation.ImageStatus(Convert.ToInt32(progress));
                    notifyIcon1.Icon.Dispose();
                    notifyIcon1.Icon = s;
                    notifyIcon1.Text = string.Format("Upload Progress: {0}%", Convert.ToInt32(progress));
                    s.Dispose();
                }));
            }
            catch { }
        }

        void PluginCore_OnPluginsChanged(object sender, EventArgs e)
        {
            //clear plugin list and reload.
            metroComboBox1.Items.Clear();
            foreach (ImageUploader p in PluginCore.Uploaders)
            {
                metroComboBox1.Items.Add(p.Title);
            }
            metroComboBox1.Text = (Core.Utils.Settings.Instance.GetValue("image_uploader") != null ? (string)Core.Utils.Settings.Instance.GetValue("image_uploader")[0] : "");
            if (metroComboBox1.Text == "" && metroComboBox1.Items.Count > 0)
            {
                metroComboBox1.Text = "Shotr";
            }
        }

        void Uploader_OnError(object sender, ImageShell e)
        {
            ErrorNotification not = null;
            UploadedImageJsonResult f = (UploadedImageJsonResult)sender;
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
                    Invoke((MethodInvoker)(() =>
                    {
                        not = new ErrorNotification(shotr_icon_bmp, e, f) { Visible = true };
                    }));
                }
                catch
                {
                    Console.WriteLine("Error while showing error.");
                }
            }
        }
        List<UploadResult> ImageHistory = new List<UploadResult>();
        private void Uploader_OnUploaded(object sender, UploadResult e)
        {
            if (e != null)
            {
                //Make uploaded sound.
                Core.Utils.Settings.Instance.ImageHistory.Add(e.Time, e);
                Core.Utils.Settings.Instance.SaveSettings();
                if (ImageHistory.Count >= 5)
                {
                    ImageHistory.Remove(ImageHistory[0]);
                }
                ImageHistory.Add(e);

            }

            Notification not = null;
            NoUploadNotification nuot = null;
            ListViewItem x = null;
            bool directurl = false;
            if (e != null)
            {
                directurl = ((Core.Utils.Settings.Instance.GetValue("image_uploader_direct_url") != null && (bool)Core.Utils.Settings.Instance.GetValue("image_uploader_direct_url")[0]) || e.PageURL == "" || !PluginCore.GetUploader(e.Uploader).SupportsPages);
            }

            Invoke((MethodInvoker)(() =>
            {
                try
                {
                    Image jpg;
                    Bitmap b;
                    using (MemoryStream k = new MemoryStream((byte[])((object[])sender)[1]))
                    {
                        jpg = Image.FromStream(k);
                        b = new Bitmap(jpg);
                    }
                    DataObject dataobj = new DataObject();
                    if (e != null)
                        dataobj.SetText((directurl ? e.URL : e.PageURL));
                    dataobj.SetImage(b);
                    Clipboard.SetDataObject(dataobj);
                    jpg.Dispose();
                    //b.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Cannot set image and text in clipboard at same time, error: {0}", ex);
                    if (e != null)
                        Clipboard.SetText((directurl ? e.URL : e.PageURL));
                }
                try
                {
                    if (e != null)
                    {
                        if ((Core.Utils.Settings.Instance.GetValue("program_show_notifications") == null || (bool)Core.Utils.Settings.Instance.GetValue("program_show_notifications")[0]))
                            not = new Notification((directurl ? e.URL : e.PageURL), shotr_icon_bmp, (string)((object[])sender)[0]) { Visible = true };
                    }
                    else
                    {
                        if ((Core.Utils.Settings.Instance.GetValue("program_show_notifications") == null || (bool)Core.Utils.Settings.Instance.GetValue("program_show_notifications")[0]))
                            nuot = new NoUploadNotification(shotr_icon_bmp, (string)((object[])sender)[0]) { Visible = true };
                    }
                }
                catch { }
            }));
            //save to directory.
            if ((bool)Core.Utils.Settings.Instance.GetValue("general.savetodirectory")[0])
            {
                try
                {
                    if (!Directory.Exists((string)Core.Utils.Settings.Instance.GetValue("general.savetodirectory")[1])) Directory.CreateDirectory((string)Core.Utils.Settings.Instance.GetValue("general.savetodirectory")[1]);
                    string filename = "";
                    if (e != null)
                    {
                        filename = string.Format("{0}\\{1:yyyy-MM-dd_hh-mm-ss-tt}{2}", (string)Core.Utils.Settings.Instance.GetValue("general.savetodirectory")[1], DateTime.Now, Path.GetExtension(e.URL));
                    }
                    else
                    {
                        filename = string.Format("{0}\\{1:yyyy-MM-dd_hh-mm-ss-tt}.{2}", (string)Core.Utils.Settings.Instance.GetValue("general.savetodirectory")[1], DateTime.Now, ((FileExtensions)((object[])sender)[2]).ToString());
                    }
                    File.WriteAllBytes(filename, (byte[])((object[])sender)[1]);
                }
                catch { }
            }
            if (e != null)
            {
                x = new ListViewItem { Text = (directurl ? e.URL : e.PageURL) };
                //update list with that shit.
                x.SubItems.Add(Utils.FromUnixTime(e.Time).ToString());
                Invoke((MethodInvoker)(() =>
                {
                    betterListView1.Items.Insert(0, x);
                }));
                //make last 4 images show in tray icon.
                foreach (ToolStripItem w in historyToolStripMenuItem.DropDownItems)
                {
                    w.Click -= p_Click;
                }
                Invoke((MethodInvoker)(() =>
                {
                    historyToolStripMenuItem.DropDownItems.Clear();
                    foreach (UploadResult h in ImageHistory)
                    {
                        ToolStripItem p = historyToolStripMenuItem.DropDownItems.Add((directurl ? h.URL : h.PageURL) + " - " + Utils.FromUnixTime(h.Time));
                        p.Click += p_Click;
                        //add dropdown items to p.
                    }
                }));
            }
        }

        void p_Click(object sender, EventArgs e)
        {
            //open url of text.
            try
            {
                Process.Start(((ToolStripItem)sender).Text.Split('-')[0]);
            }
            catch { }
        }

        private void UpdateControls()
        {
            betterListView1.Font = metroLabel2.GetThemeFont();
            UpdateHotKeys();
            betterListView1.DoubleClick += betterListView1_MouseDoubleClick;
            UpdateListView();

            //update other settings.
            metroLabel8.Text = string.Format(metroLabel8.Text, Assembly.GetExecutingAssembly().GetName().Version);

            foreach (ImageUploader p in PluginCore.Uploaders)
            {
                metroComboBox1.Items.Add(p.Title);
            }
            metroComboBox1.Text = (Core.Utils.Settings.Instance.GetValue("image_uploader") != null ? (string)Core.Utils.Settings.Instance.GetValue("image_uploader")[0] : "");
            if (metroComboBox1.Text == "" && metroComboBox1.Items.Count > 0)
            {
                metroComboBox1.Text = (string)metroComboBox1.Items[0];
            }
            UpdateDirectURL();

            emailLabel.Text = Core.Utils.Settings.Instance.email;
        }

        private void UpdateDirectURL()
        {
            //check if uploader has support for indirect URLs.
            ImageUploader p = PluginCore.GetUploader(metroComboBox1.Text);
            if (p == null) return;
            //check if it supports indirect urls.
            if (p.SupportsPages)
            {
                //enable control for selecting page support.
                metroLabel11.Visible = true;
                metroToggle3.Visible = true;
                //get from settings or set to default.
                metroToggle3.Checked = (Core.Utils.Settings.Instance.GetValue("image_uploader_direct_url") != null && (bool)Core.Utils.Settings.Instance.GetValue("image_uploader_direct_url")[0]);
                if (Core.Utils.Settings.Instance.GetValue("image_uploader_direct_url") == null)
                {
                    Core.Utils.Settings.Instance.ChangeKey("image_uploader_direct_url", new object[] { false });
                }
            }
            else
            {
                metroLabel11.Visible = false;
                metroToggle3.Visible = false;
            }
        }

        private void UpdateListView()
        {
            UpdateListViewColumnSize();
            List<UploadResult> templist = new List<UploadResult>();
            foreach (KeyValuePair<long, UploadResult> p in Core.Utils.Settings.Instance.ImageHistory)
            {
                templist.Add(p.Value);
            }
            bool exists = (Core.Utils.Settings.Instance.GetValue("image_uploader_direct_url") != null);
            bool ps = false;
            if (exists)
                ps = (bool)Core.Utils.Settings.Instance.GetValue("image_uploader_direct_url")[0];
            for (int i = templist.Count - 1; i >= 0; i--)
            {
                if (exists)
                {
                    ImageUploader m = PluginCore.GetUploader(templist[i].Uploader);
                    var x = new ListViewItem { Text = ((m != null ? (!m.SupportsPages && !ps ? templist[i].URL : templist[i].PageURL) : templist[i].URL)) };
                    x.SubItems.Add(Utils.FromUnixTime(templist[i].Time).ToString());
                    betterListView1.Items.Add(x);
                }
                else
                {
                    ListViewItem x = new ListViewItem { Text = (ps ? templist[i].URL : templist[i].PageURL) };
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
                for (int i = 0; i < listView.Columns.Count; i++)
                {
                    float colPercentage = (Convert.ToInt32(totalColumnWidth / 2));
                    listView.Columns[i].Width = (int)colPercentage;
                }
            }
        }

        private void UpdateHotKeys()
        {
            foreach (HotKeyHook f in Core.Utils.Settings.Instance.hotkeys)
            {
                //region, fullscreen, active
                HotKeyData p = new HotKeyData(f.Keys);
                switch (f.Task)
                {
                    case KeyTask.ActiveWindow:
                        hotkeyButton3.Text = p.ToString();
                        hotkeyButton3.HotKey = p;
                        break;
                    case KeyTask.Fullscreen:
                        hotkeyButton2.Text = p.ToString();
                        hotkeyButton2.HotKey = p;
                        break;
                    case KeyTask.Region:
                        hotkeyButton1.Text = p.ToString();
                        hotkeyButton1.HotKey = p;
                        break;
                    case KeyTask.RegionNoUpload:
                        hotkeyButton6.Text = p.ToString();
                        hotkeyButton6.HotKey = p;
                        break;
                    case KeyTask.RecordScreen:
                        hotkeyButton4.Text = p.ToString();
                        hotkeyButton4.HotKey = p;
                        break;
                    case KeyTask.UploadClipboard:
                        hotkeyButton5.Text = p.ToString();
                        hotkeyButton5.HotKey = p;
                        break;
                }
            }
        }
        SingleInstance Tasks = new SingleInstance();
        private GifRecorderForm gifrec;

        private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            //initialize screenshot shit, aka show form and capture shit.
            //capture screen.
            if (Tasks.CurrentTask != KeyTask.RecordScreen)
                if (Tasks.CurrentTask != KeyTask.Empty) return;

            foreach (HotKeyHook p in Core.Utils.Settings.Instance.hotkeys)
                if (p.ID == e.ID)
                {
                    if (p.Task == KeyTask.Region)
                    {
                        Tasks.CurrentTask = p.Task;
                        Invoke((MethodInvoker)(() =>
                        {
                            //Rectangle monitor = Rectangle.Empty;
                            Bitmap yolo = Utils.CopyScreen();
                            ScreenshotForm f = new ScreenshotForm(yolo, Tasks);
                            f.ShowDialog();
                            var cloneBitmap = f.GetProcessedImage();

                            if (cloneBitmap != null)
                            {
                                MusicPlayer.PlayCaptured();

                                if ((FileExtensions)Core.Utils.Settings.Instance.GetValue("settings.screenshot")[0] ==
                                    FileExtensions.png && (bool)Core.Utils.Settings.Instance.GetValue("settings.screenshot")[2])
                                {
                                    Image quantized = Utils.Quantize(cloneBitmap);
                                    cloneBitmap.Dispose();

                                    Uploader.AddToQueue(new ImageShell(
                                        Utils.imageToByteArray(quantized, FileExtensions.png, false, 0),
                                        FileExtensions.png));
                                }
                                else if ((FileExtensions)Core.Utils.Settings.Instance.GetValue("settings.screenshot")[0] ==
                                         FileExtensions.png)
                                {
                                    Uploader.AddToQueue(new ImageShell(
                                        Utils.imageToByteArray(cloneBitmap, FileExtensions.png, false, 0),
                                        FileExtensions.png));
                                }
                                else
                                {
                                    Uploader.AddToQueue(new ImageShell(
                                        Utils.imageToByteArray(cloneBitmap, FileExtensions.jpg,
                                            (bool)Core.Utils.Settings.Instance.GetValue("settings.screenshot")[2],
                                            (int)Core.Utils.Settings.Instance.GetValue("settings.screenshot")[1]),
                                        FileExtensions.jpg));
                                }
                            }

                            Tasks.Reset();
                            f.Dispose();
                            f.Close();
                        }));
                    }
                    else if (p.Task == KeyTask.RegionNoUpload)
                    {
                        Tasks.CurrentTask = p.Task;
                        Invoke((MethodInvoker)(() =>
                        {
                            //Rectangle monitor = Rectangle.Empty;
                            Bitmap yolo = Utils.CopyScreen();
                            ScreenshotForm f = new ScreenshotForm(yolo, Tasks);
                            f.ShowDialog();
                            var cloneBitmap = f.GetProcessedImage();

                            if (cloneBitmap != null)
                            {
                                MusicPlayer.PlayCaptured();

                                if ((FileExtensions)Core.Utils.Settings.Instance.GetValue("settings.screenshot")[0] == FileExtensions.png && (bool)Core.Utils.Settings.Instance.GetValue("settings.screenshot")[2])
                                {
                                    Image quantized = Utils.Quantize(cloneBitmap);
                                    cloneBitmap.Dispose();

                                    Uploader.ProcessWithoutUpload(new ImageShell(Utils.imageToByteArray(quantized, FileExtensions.png, false, 0), FileExtensions.png));
                                }
                                else if ((FileExtensions)Core.Utils.Settings.Instance.GetValue("settings.screenshot")[0] == FileExtensions.png)
                                {
                                    Uploader.ProcessWithoutUpload(new ImageShell(Utils.imageToByteArray(cloneBitmap, FileExtensions.png, false, 0), FileExtensions.png));
                                }
                                else
                                {
                                    Uploader.ProcessWithoutUpload(new ImageShell(Utils.imageToByteArray(cloneBitmap, FileExtensions.jpg, (bool)Core.Utils.Settings.Instance.GetValue("settings.screenshot")[2], (int)Core.Utils.Settings.Instance.GetValue("settings.screenshot")[1]), FileExtensions.jpeg));
                                }
                            }

                            Tasks.Reset();
                            f.Dispose();
                            f.Close();
                        }));
                    }
                    else if (p.Task == KeyTask.Fullscreen)
                    {
                        Tasks.CurrentTask = p.Task;
                        Invoke((MethodInvoker)(() =>
                        {
                            //check for shit.
                            Bitmap yolo = null;
                            if (Core.Utils.Settings.Instance.GetValue("program_stitch_fullscreen") != null)
                            {
                                if ((bool)Core.Utils.Settings.Instance.GetValue("program_stitch_fullscreen")[0])
                                    yolo = Utils.CopyScreen();
                                else
                                    yolo = Utils.BitBltCopy(Screen.FromPoint(Cursor.Position).Bounds);
                            }
                            else
                            {
                                //copy that shit.
                                Core.Utils.Settings.Instance.ChangeKey("program_stitch_fullscreen", new object[] { true });
                                yolo = Utils.CopyScreen();
                            }
                            MusicPlayer.PlayCaptured();
                            if ((FileExtensions)Core.Utils.Settings.Instance.GetValue("settings.screenshot")[0] == FileExtensions.png && (bool)Core.Utils.Settings.Instance.GetValue("settings.screenshot")[2])
                            {
                                Image quantized = Utils.Quantize(yolo);
                                yolo.Dispose();

                                Uploader.AddToQueue(new ImageShell(Utils.imageToByteArray(quantized, FileExtensions.png, false, 0), FileExtensions.png));
                            }
                            else if ((FileExtensions)Core.Utils.Settings.Instance.GetValue("settings.screenshot")[0] == FileExtensions.png && (bool)Core.Utils.Settings.Instance.GetValue("settings.screenshot")[2] == false)
                            {
                                Uploader.AddToQueue(new ImageShell(Utils.imageToByteArray(yolo, FileExtensions.png, false, 0), FileExtensions.png));
                            }
                            else
                            {
                                Uploader.AddToQueue(new ImageShell(Utils.imageToByteArray(yolo, FileExtensions.jpg, (bool)Core.Utils.Settings.Instance.GetValue("settings.screenshot")[2], (int)Core.Utils.Settings.Instance.GetValue("settings.screenshot")[1]), FileExtensions.jpeg));
                            }
                            Tasks.Reset();
                        }));
                    }
                    else if (p.Task == KeyTask.ActiveWindow)
                    {
                        Tasks.CurrentTask = p.Task;
                        Invoke((MethodInvoker)(() =>
                        {
                            Rectangle rect = Utils.GetActiveWindowCoords();
                            Bitmap cloneBitmap = Utils.CopyActiveWindow(rect);
                            MusicPlayer.PlayCaptured();
                            if ((FileExtensions)Core.Utils.Settings.Instance.GetValue("settings.screenshot")[0] == FileExtensions.png && (bool)Core.Utils.Settings.Instance.GetValue("settings.screenshot")[2])
                            {
                                Image quantized = Utils.Quantize(cloneBitmap);
                                cloneBitmap.Dispose();

                                Uploader.AddToQueue(new ImageShell(Utils.imageToByteArray(quantized, FileExtensions.png, false, 0), FileExtensions.png));
                            }
                            else if ((FileExtensions)Core.Utils.Settings.Instance.GetValue("settings.screenshot")[0] == FileExtensions.png)
                            {
                                Uploader.AddToQueue(new ImageShell(Utils.imageToByteArray(cloneBitmap, FileExtensions.png, false, 0), FileExtensions.png));
                            }
                            else
                            {
                                Uploader.AddToQueue(new ImageShell(Utils.imageToByteArray(cloneBitmap, FileExtensions.jpg, (bool)Core.Utils.Settings.Instance.GetValue("settings.screenshot")[2], (int)Core.Utils.Settings.Instance.GetValue("settings.screenshot")[1]), FileExtensions.jpeg));
                            }
                            Tasks.Reset();
                        }));
                    }
                    else if (p.Task == KeyTask.RecordScreen)
                    {
                        if (Tasks.CurrentTask == KeyTask.RecordScreen)
                        {
                            if (gifrec != null)
                            {
                                gifrec.fmp.Close();
                                gifrec.stopwatch.Stop();
                                gifrec.Cancel = true;
                                gifrec.Close();
                                Tasks.Reset();
                            }
                        }
                        else
                        {
                            Tasks.CurrentTask = p.Task;
                            Invoke((MethodInvoker)(() =>
                            {
                                //check settings.
                                if ((bool)Core.Utils.Settings.Instance.GetValue("settings.show_record_warning")[0])
                                {
                                    RecordingNotice rcd = new RecordingNotice();
                                    rcd.ShowDialog();
                                }
                                Bitmap yolo = Utils.CopyScreen();
                                gifrec = new GifRecorderForm(yolo, metroLabel9.GetThemeFont(), Tasks);
                                gifrec.Show();
                            }));
                        }
                    }
                    else if (p.Task == KeyTask.UploadClipboard)
                    {
                        Tasks.CurrentTask = p.Task;
                        //get shit from clipboard.
                        if (Clipboard.ContainsText())
                        {
                            //try to upload via shotr
                            Uploader.AddToQueue(new ImageShell(Encoding.ASCII.GetBytes(Clipboard.GetText()), FileExtensions.txt));
                        }
                        else if (Clipboard.ContainsImage())
                        {
                            Uploader.AddToQueue(new ImageShell(Utils.imageToByteArray(Clipboard.GetImage(), FileExtensions.png, false, 100L), FileExtensions.png));
                        }
                        else if (Clipboard.ContainsFileDropList())
                        {
                            StringCollection f = Clipboard.GetFileDropList();
                            if (f.Count == 1)
                            {
                                //upload image, first check extension.
                                string ext = Path.GetExtension(f[0]);
                                ext = ext.Replace(".", "");
                                if (Enum.IsDefined(typeof(FileExtensions), ext.ToLower()))
                                {
                                    Uploader.AddToQueue(new ImageShell(File.ReadAllBytes(f[0]), (FileExtensions)Enum.Parse(typeof(FileExtensions), ext)));
                                }
                            }
                        }
                        Tasks.Reset();
                    }
                }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Core.Utils.Settings.Instance.SaveSettings();
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
                Process.Start(Core.Utils.Settings.Instance.GetUploadedImage(betterListView1.SelectedItems[0].SubItems[1].Text).URL);
            }
        }

        private void clearHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clear history.
            Core.Utils.Settings.Instance.ImageHistory.Clear();
            Core.Utils.Settings.Instance.SaveSettings();
            betterListView1.Items.Clear();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //show about form.
            AboutForm f = new AboutForm();
            f.ShowDialog();
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
            Core.Utils.Settings.Instance.ChangeKey("image_uploader", new object[] { (string)metroComboBox1.SelectedItem });
            UpdateDirectURL();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (betterListView1.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete these images?", "Confirm Image Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int i = 0; i < betterListView1.SelectedItems.Count; i++)
                    {
                        try
                        {
                            UploadResult p = Core.Utils.Settings.Instance.ImageHistory[Utils.ToUnixTime(DateTime.Parse(betterListView1.SelectedItems[i].SubItems[1].Text))];
                            //check deletion url.
                            WebClient wc = new WebClient { Proxy = null };
                            new Thread(() =>
                            {
                                lock (p)
                                {
                                    try
                                    {
                                        foreach (ImageUploader up in PluginCore.Uploaders)
                                        {
                                            if (up.Title == p.Uploader)
                                            {
                                                if (up.DeletionValues == null)
                                                    wc.UploadValues(p.DelURL, new NameValueCollection { { "confirm", "true" } });
                                                else
                                                    wc.UploadValues(p.DelURL, up.DeletionValues);
                                                break;
                                            }
                                        }
                                    }
                                    catch { }
                                }
                            }).Start();
                        }
                        catch
                        {
                        }
                        Core.Utils.Settings.Instance.ImageHistory.Remove(Utils.ToUnixTime(DateTime.Parse(betterListView1.SelectedItems[i].SubItems[1].Text)));
                        Core.Utils.Settings.Instance.SaveSettings();
                    }
                    betterListView1.Items.Clear();
                    UpdateListView();
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (betterListView1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < betterListView1.SelectedItems.Count; i++)
                    Core.Utils.Settings.Instance.ImageHistory.Remove(Utils.ToUnixTime(DateTime.Parse(betterListView1.SelectedItems[i].SubItems[1].Text)));
                Core.Utils.Settings.Instance.SaveSettings();
                betterListView1.Items.Clear();
                UpdateListView();
            }
        }

        ToolStripItem itm;

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            //check if selected has a delete url.
            if (betterListView1.SelectedItems.Count > 0)
            {
                UploadResult x = Core.Utils.Settings.Instance.GetUploadedImage(betterListView1.SelectedItems[0].SubItems[1].Text);
                if (!string.IsNullOrEmpty(x.DelURL))
                {
                    if (!contextMenuStrip2.Items.Contains(itm))
                        contextMenuStrip2.Items.Insert(1, itm);
                }
                else
                {
                    contextMenuStrip2.Items.Remove(itm);
                }
            }
        }

        private void metroToggle3_CheckedChanged(object sender, EventArgs e)
        {
            Core.Utils.Settings.Instance.ChangeKey("image_uploader_direct_url", new object[] { metroToggle3.Checked });
            //reload listview.
            betterListView1.Items.Clear();
            UpdateListView();
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ask to download image.
            if (betterListView1.SelectedItems.Count > 0)
            {
                string url = Core.Utils.Settings.Instance.GetUploadedImage(betterListView1.SelectedItems[0].SubItems[1].Text).URL;
                SaveFileDialog d = new SaveFileDialog();
                d.Title = "Save Image...";
                d.Filter = "PNG Image Files (*.png)|*.png";
                d.FileName = betterListView1.SelectedItems[0].Text.Split('/')[3].Split('.')[0] + ".png";
                if (d.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        new Thread(delegate () { new WebClient { Proxy = null }.DownloadFile(url, d.FileName); }).Start();
                    }
                    catch
                    {
                        MessageBox.Show(this, "There was an error while saving the image!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        private void metroButton2_Click(object sender, EventArgs e)
        {
            //custom uploaders window.
            CustomUploader cu = new CustomUploader();
            cu.ShowDialog();
        }

        private void HotkeyError(string hotkeyName)
        {
            MessageBox.Show(this, $"Failed to set hotkey hook for '{hotkeyName}'. Please make sure the combinations you entered aren't being used by another application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void hotkeyButton1_OnHotKeyChanged(object sender, EventArgs e)
        {
            bool hook = Core.Utils.Settings.Instance.SetNewHook(hotkeyButton1.HotKey.ModifiersEnum, hotkeyButton1.HotKey.Hotkey, KeyTask.Region);
            if (!hook)
            {
                HotkeyError("Region");
            }
            UpdateHotKeys();
        }

        private void hotkeyButton2_OnHotKeyChanged(object sender, EventArgs e)
        {
            bool hook1 = Core.Utils.Settings.Instance.SetNewHook(hotkeyButton2.HotKey.ModifiersEnum, hotkeyButton2.HotKey.Hotkey, KeyTask.Fullscreen);
            if (!hook1)
            {
                HotkeyError("Fullscreen");
            }
            UpdateHotKeys();
        }

        private void hotkeyButton3_OnHotKeyChanged(object sender, EventArgs e)
        {
            bool hook2 = Core.Utils.Settings.Instance.SetNewHook(hotkeyButton3.HotKey.ModifiersEnum, hotkeyButton3.HotKey.Hotkey, KeyTask.ActiveWindow);
            if (!hook2)
            {
                HotkeyError("Active Window");
            }
            UpdateHotKeys();
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "This will set your settings back to default, continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Core.Utils.Settings.Instance.CreateNewSettings();
                UpdateControls();
            }
        }

        private void hotkeyButton4_OnHotKeyChanged(object sender, EventArgs e)
        {
            bool hook2 = Core.Utils.Settings.Instance.SetNewHook(hotkeyButton4.HotKey.ModifiersEnum, hotkeyButton4.HotKey.Hotkey, KeyTask.RecordScreen);
            if (!hook2)
            {
                HotkeyError("Record Screen");
            }
            UpdateHotKeys();
        }

        private void hotkeyButton5_OnHotKeyChanged(object sender, EventArgs e)
        {
            bool hook = Core.Utils.Settings.Instance.SetNewHook(hotkeyButton5.HotKey.ModifiersEnum, hotkeyButton5.HotKey.Hotkey, KeyTask.UploadClipboard);
            if (!hook)
            {
                HotkeyError("Upload Clipboard");
            }
            UpdateHotKeys();
        }

        private void hotkeyButton6_OnHotKeyChanged(object sender, EventArgs e)
        {
            bool hook = Core.Utils.Settings.Instance.SetNewHook(hotkeyButton6.HotKey.ModifiersEnum, hotkeyButton6.HotKey.Hotkey, KeyTask.RegionNoUpload);
            if (!hook)
            {
                HotkeyError("Save Only");
            }
            UpdateHotKeys();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            //show global settings
            SettingsForm f = new SettingsForm();
            f.ShowDialog();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Core.Utils.Settings.Instance.ChangeKey("shotr.token", new object[] { "" });
            Core.Utils.Settings.Instance.token = "";
            Core.Utils.Settings.Instance.email = "";
            Application.Restart();
            Environment.Exit(0);
        }

        private void metroLabel8_Click(object sender, EventArgs e)
        {
            //clicked on shotr version at bottom.
            new AboutForm().ShowDialog();
        }

        private void colorPickerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //show color picker form.
            Bitmap yolo = Utils.CopyScreen();
            ColorPickerForm f = new ColorPickerForm(yolo, metroLabel9.GetThemeFont());
            f.Show();
        }

        private void regionCaptureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (HotKeyHook m in Core.Utils.Settings.Instance.hotkeys)
            {
                if (m.Task == KeyTask.Region)
                {
                    hook_KeyPressed(this, new KeyPressedEventArgs(m.ID));
                    break;
                }
            }
        }

        private void fullscreenCaptureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (HotKeyHook m in Core.Utils.Settings.Instance.hotkeys)
            {
                if (m.Task == KeyTask.Fullscreen)
                {
                    hook_KeyPressed(this, new KeyPressedEventArgs(m.ID));
                    break;
                }
            }
        }

        private void recordScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (HotKeyHook m in Core.Utils.Settings.Instance.hotkeys)
            {
                if (m.Task == KeyTask.RecordScreen)
                {
                    hook_KeyPressed(this, new KeyPressedEventArgs(m.ID));
                    break;
                }
            }
        }

        private void uploadClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (HotKeyHook m in Core.Utils.Settings.Instance.hotkeys)
            {
                if (m.Task == KeyTask.UploadClipboard)
                {
                    hook_KeyPressed(this, new KeyPressedEventArgs(m.ID));
                    break;
                }
            }
        }
    }
}

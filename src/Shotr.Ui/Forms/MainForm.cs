using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MetroFramework5.Controls;
using Shotr.Ui.DpiScaling;
using Shotr.Ui.Forms.Settings;
using Shotr.Ui.Hotkey;
using Shotr.Ui.Image;
using Shotr.Ui.Pipes;
using Shotr.Ui.Plugin;
using Shotr.Ui.Properties;
using Shotr.Ui.Uploader;
using Shotr.Ui.Utils;
using ShotrUploaderPlugin;

namespace Shotr.Ui.Forms
{
    public partial class MainForm : DpiScaledForm
    {
        private PipeServer _pipeserver;
        private Icon shotr_icon;
        private Bitmap shotr_icon_bmp;
        private List<ShotrCorePlugin> loadedplugins;

        public MainForm() : base()
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
                foreach(ShotrCorePlugin coreplug in PluginCore.CorePlugin) {
                    if (!loadedplugins.Contains(coreplug))
                    {
                        if (coreplug.Enabled)
                        {
                            //load up the plugin.
                            Console.WriteLine("Recognized new plugin {0}. Loading default methods.", coreplug.Name);
                            loadedplugins.Add(coreplug);
                            Form test = coreplug.GetForm(new ShotrCore());
                            MetroTabPage lel = new MetroTabPage();
                            lel.Theme = "Dark";
                            //if (test.Size.Width > this.metroTabPage2.Size.Width || test.Size.Height > this.metroTabPage2.Size.Height) continue;
                            while (test.Controls.Count > 0)
                            {
                                foreach (Control w in Utils.Utils.GetControls(test.Controls[0]))
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

            new Thread(delegate()
            {
                bool isforeground = false;
                while (true)
                {
                    try
                    {
                        if (isforeground == false && Utils.Utils.IsDXFullScreen())
                        {
                            Invoke((MethodInvoker)(() =>
                            {
                                Program.Settings.UnloadHotKeys();
                            }));
                            //get pid and wait for process to end?
                            isforeground = true;
                            Console.WriteLine("Found foreground process: {0}", Utils.Utils.GetForegroundProcess().ProcessName);
                        }
                        else if (isforeground == true && !Utils.Utils.IsDXFullScreen())
                        {
                            //Thread.Sleep(5000);
                            Console.WriteLine("Reloaded hotkeys.");
                            Invoke((MethodInvoker)(() =>
                            {
                                Program.Settings.LoadHotKeys();
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
            foreach (HotKeyHook m in Program.Settings.hotkeys)
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
            }
        }
        bool start = false;
        private void MainFormShown(object sender, EventArgs e)
        {
            if (!start)
            {
                if (Program.Settings.settings.ContainsKey("start_minimized") && (bool)Program.Settings.settings["start_minimized"][0] == true)
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
            Program.Settings.hook.KeyPressed += hook_KeyPressed;
            UpdateControls();
            Uploader.Uploader.StartQueue();
            Uploader.Uploader.OnUploaded += Uploader_OnUploaded;
            Uploader.Uploader.OnError += Uploader_OnError;
            Uploader.Uploader.OnProgress += Uploader_OnProgress;
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
                    else if (progress == 100)
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
            metroComboBox1.Text = (Program.Settings.GetValue("image_uploader") != null ? (string)Program.Settings.GetValue("image_uploader")[0] : "");
            if (metroComboBox1.Text == "" && metroComboBox1.Items.Count > 0)
            {
                metroComboBox1.Text = "Shotr";
            }
        }

        void Uploader_OnError(object sender, ImageShell e)
        {
            ErrorNotification not = null;
            UploadedImageJsonResult f = (UploadedImageJsonResult) sender;
            if (f != null && f.ErrorCode == -7)
            {
                Invoke((MethodInvoker) (() =>
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
                    Invoke((MethodInvoker) (() =>
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
                Program.Settings.ImageHistory.Add(e.Time, e);
                Program.Settings.SaveSettings();
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
                 directurl = ((Program.Settings.GetValue("image_uploader_direct_url") != null ? (bool)Program.Settings.GetValue("image_uploader_direct_url")[0] : false) || e.PageURL == "" || !PluginCore.GetUploader(e.Uploader).SupportsPages);
            }

            Invoke((MethodInvoker)(() =>
            {
                try
                {
                    System.Drawing.Image jpg;
                    Bitmap b;
                    using (MemoryStream k = new MemoryStream((byte[])((object[])sender)[1]))
                    {
                        jpg = System.Drawing.Image.FromStream(k);
                        b = new Bitmap(jpg);
                    }
                    DataObject dataobj = new DataObject();
                    if(e != null)
                        dataobj.SetText((directurl ? e.URL : e.PageURL));
                    dataobj.SetImage(b);
                    Clipboard.SetDataObject(dataobj);
                    jpg.Dispose();
                    //b.Dispose();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Cannot set image and text in clipboard at same time, error: {0}", ex.ToString());
                    if (e != null)
                    Clipboard.SetText((directurl ? e.URL : e.PageURL));
                }
                try
                {
                    if (e != null)
                    {
                        if ((Program.Settings.GetValue("program_show_notifications") != null ? (bool)Program.Settings.GetValue("program_show_notifications")[0] : true))
                            not = new Notification((directurl ? e.URL : e.PageURL), shotr_icon_bmp, (string)((object[])sender)[0]) { Visible = true };
                    }
                    else
                    {
                        if ((Program.Settings.GetValue("program_show_notifications") != null ? (bool)Program.Settings.GetValue("program_show_notifications")[0] : true))
                            nuot = new NoUploadNotification(shotr_icon_bmp, (string)((object[])sender)[0]) { Visible = true };
                    }
                }
                catch { }
            }));
            //save to directory.
            if ((bool)Program.Settings.GetValue("general.savetodirectory")[0] == true)
            {
                try
                {
                    if (!Directory.Exists((string)Program.Settings.GetValue("general.savetodirectory")[1])) Directory.CreateDirectory((string)Program.Settings.GetValue("general.savetodirectory")[1]);
                    string filename = "";
                    if (e != null)
                    {
                        filename = string.Format("{0}\\{1:yyyy-MM-dd_hh-mm-ss-tt}{2}", (string)Program.Settings.GetValue("general.savetodirectory")[1], DateTime.Now, Path.GetExtension(e.URL));
                    }
                    else
                    {
                        filename = string.Format("{0}\\{1:yyyy-MM-dd_hh-mm-ss-tt}.{2}", (string)Program.Settings.GetValue("general.savetodirectory")[1], DateTime.Now, ((FileExtensions)((object[])sender)[2]).ToString());
                    }
                    File.WriteAllBytes(filename, (byte[])((object[])sender)[1]);
                }
                catch { }
            }
            if (e != null)
            {
                x = new ListViewItem { Text = directurl ? e.URL : e.PageURL };
                //update list with that shit.
                x.SubItems.Add(Utils.Utils.FromUnixTime(e.Time).ToString());
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
                        ToolStripItem p = historyToolStripMenuItem.DropDownItems.Add((directurl ? h.URL : h.PageURL) + " - " + Utils.Utils.FromUnixTime(h.Time).ToString(), Resources._1416620630_Newspaper_2_16);
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
            catch{}
        }

        private void UpdateControls()
        {
            betterListView1.Font = metroLabel2.GetThemeFont();
            UpdateHotKeys();
            betterListView1.DoubleClick += betterListView1_MouseDoubleClick;
            //this.betterListView1.DrawColumnHeaderBackground += betterListView1_DrawColumnHeaderBackground;
            UpdateListView();
            
            //update other settings.
            metroLabel8.Text = string.Format(metroLabel8.Text, System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);

            foreach (ImageUploader p in PluginCore.Uploaders)
            {
                metroComboBox1.Items.Add(p.Title);
            }
            metroComboBox1.Text = (Program.Settings.GetValue("image_uploader") != null ? (string)Program.Settings.GetValue("image_uploader")[0] : "");
            if (metroComboBox1.Text == "" && metroComboBox1.Items.Count > 0)
            {
                metroComboBox1.Text = (string)metroComboBox1.Items[0];
            }
            UpdateDirectURL();

            emailLabel.Text = Program.Settings.email;
        }
        
        private void UpdateDirectURL()
        {
            //check if uploader has support for indirect URLs.
            ImageUploader p = PluginCore.GetUploader(metroComboBox1.Text);
            if(p == null) return;
            //check if it supports indirect urls.
            if (p.SupportsPages)
            {
                //enable control for selecting page support.
                metroLabel11.Visible = true;
                metroToggle3.Visible = true;
                //get from settings or set to default.
                metroToggle3.Checked = (Program.Settings.GetValue("image_uploader_direct_url") != null ? (bool)Program.Settings.GetValue("image_uploader_direct_url")[0] : false);
                if (Program.Settings.GetValue("image_uploader_direct_url") == null)
                {
                    Program.Settings.ChangeKey("image_uploader_direct_url", new object[] { false });
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
            foreach (KeyValuePair<long, UploadResult> p in Program.Settings.ImageHistory)
            {
                templist.Add(p.Value);
            }
            bool exists = (Program.Settings.GetValue("image_uploader_direct_url") != null);
            bool ps = false;
            if(exists)
                ps = (bool)Program.Settings.GetValue("image_uploader_direct_url")[0];
            for (int i = templist.Count - 1; i >= 0; i--)
            {
                if (exists)
                {
                    ImageUploader m = PluginCore.GetUploader(templist[i].Uploader);
                    var x = new ListViewItem { Text = ((m != null ? (!m.SupportsPages && !ps ? templist[i].URL : templist[i].PageURL) : templist[i].URL)) };
                    x.SubItems.Add(Utils.Utils.FromUnixTime(templist[i].Time).ToString());
                    betterListView1.Items.Add(x);
                }
                else
                {
                    ListViewItem x = new ListViewItem() { Text = (ps ? templist[i].URL : templist[i].PageURL) };
                    x.SubItems.Add(Utils.Utils.FromUnixTime(templist[i].Time).ToString());
                    betterListView1.Items.Add(x);
                }
            }
        }

        private void UpdateListViewColumnSize()
        {
            var listView = betterListView1 as ListView;
            if (listView != null)
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


        /*void betterListView1_DrawColumnHeaderBackground(object sender, BetterListViewDrawColumnHeaderBackgroundEventArgs eventArgs)
        {
            eventArgs.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 24, 24, 62)), eventArgs.ColumnHeaderBounds.BoundsOuterExtended);
            //fill shit up.
            int x = eventArgs.ColumnHeaderBounds.BoundsInner.X - 3;
            int y = eventArgs.ColumnHeaderBounds.BoundsInner.Y - 3;
            int width = eventArgs.ColumnHeaderBounds.BoundsInner.Width + 4;
            int height = eventArgs.ColumnHeaderBounds.BoundsInner.Height + 4;
            eventArgs.Graphics.DrawRectangle(Pens.White, new Rectangle(x, y, width, height));
        }*/

        private void UpdateHotKeys()
        {
            foreach (HotKeyHook f in Program.Settings.hotkeys)
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

            foreach (HotKeyHook p in Program.Settings.hotkeys)
            if (p.ID == e.ID)
            {
                if (p.Task == KeyTask.Region)
                {
                    Tasks.CurrentTask = p.Task;
                    Invoke((MethodInvoker)(() =>
                    {
                        //Rectangle monitor = Rectangle.Empty;
                        Bitmap yolo = Utils.Utils.CopyScreen();
                        ScreenshotForm f = new ScreenshotForm(yolo, Tasks);
                        f.ShowDialog();
                        var cloneBitmap = f.GetProcessedImage();

                        if (cloneBitmap != null)
                        {
                            MusicPlayer.PlayCaptured();

                            if ((FileExtensions) Program.Settings.GetValue("settings.screenshot")[0] ==
                                FileExtensions.png && (bool) Program.Settings.GetValue("settings.screenshot")[2])
                            {
                                System.Drawing.Image quantized = Utils.Utils.Quantize(cloneBitmap);
                                cloneBitmap.Dispose();

                                Uploader.Uploader.AddToQueue(new ImageShell(
                                    Utils.Utils.imageToByteArray(quantized, FileExtensions.png, false, 0),
                                    FileExtensions.png));
                            }
                            else if ((FileExtensions) Program.Settings.GetValue("settings.screenshot")[0] ==
                                     FileExtensions.png)
                            {
                                Uploader.Uploader.AddToQueue(new ImageShell(
                                    Utils.Utils.imageToByteArray(cloneBitmap, FileExtensions.png, false, 0),
                                    FileExtensions.png));
                            }
                            else
                            {
                                Uploader.Uploader.AddToQueue(new ImageShell(
                                    Utils.Utils.imageToByteArray(cloneBitmap, FileExtensions.jpg,
                                        (bool) Program.Settings.GetValue("settings.screenshot")[2],
                                        (int) Program.Settings.GetValue("settings.screenshot")[1]),
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
                        Bitmap yolo = Utils.Utils.CopyScreen();
                        ScreenshotForm f = new ScreenshotForm(yolo, Tasks);
                        f.ShowDialog();
                        var cloneBitmap = f.GetProcessedImage();

                        if (cloneBitmap != null)
                        {
                            MusicPlayer.PlayCaptured();

                            if ((FileExtensions)Program.Settings.GetValue("settings.screenshot")[0] == FileExtensions.png && (bool)Program.Settings.GetValue("settings.screenshot")[2])
                            {
                                System.Drawing.Image quantized = Utils.Utils.Quantize(cloneBitmap);
                                cloneBitmap.Dispose();

                                Uploader.Uploader.ProcessWithoutUpload(new ImageShell(Utils.Utils.imageToByteArray(quantized, FileExtensions.png, false, 0), FileExtensions.png));
                            }
                            else if ((FileExtensions)Program.Settings.GetValue("settings.screenshot")[0] == FileExtensions.png)
                            {
                                Uploader.Uploader.ProcessWithoutUpload(new ImageShell(Utils.Utils.imageToByteArray(cloneBitmap, FileExtensions.png, false, 0), FileExtensions.png));
                            }
                            else
                            {
                                Uploader.Uploader.ProcessWithoutUpload(new ImageShell(Utils.Utils.imageToByteArray(cloneBitmap, FileExtensions.jpg, (bool)Program.Settings.GetValue("settings.screenshot")[2], (int)Program.Settings.GetValue("settings.screenshot")[1]), FileExtensions.jpeg));
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
                        if (Program.Settings.GetValue("program_stitch_fullscreen") != null)
                        {
                            if ((bool)Program.Settings.GetValue("program_stitch_fullscreen")[0])
                                yolo = Utils.Utils.CopyScreen();
                            else
                                yolo = Utils.Utils.BitBltCopy(Screen.FromPoint(Cursor.Position).Bounds);
                        }
                        else
                        {
                            //copy that shit.
                            Program.Settings.ChangeKey("program_stitch_fullscreen", new object[] { true });
                            yolo = Utils.Utils.CopyScreen();
                        }
                        MusicPlayer.PlayCaptured();
                        if ((FileExtensions)Program.Settings.GetValue("settings.screenshot")[0] == FileExtensions.png && (bool)Program.Settings.GetValue("settings.screenshot")[2])
                        {
                            System.Drawing.Image quantized = Utils.Utils.Quantize(yolo);
                            yolo.Dispose();

                            Uploader.Uploader.AddToQueue(new ImageShell(Utils.Utils.imageToByteArray(quantized, FileExtensions.png, false, 0), FileExtensions.png));
                        }
                        else if ((FileExtensions)Program.Settings.GetValue("settings.screenshot")[0] == FileExtensions.png && (bool)Program.Settings.GetValue("settings.screenshot")[2] == false)
                        {
                            Uploader.Uploader.AddToQueue(new ImageShell(Utils.Utils.imageToByteArray(yolo, FileExtensions.png, false, 0), FileExtensions.png));
                        }
                        else
                        {
                            Uploader.Uploader.AddToQueue(new ImageShell(Utils.Utils.imageToByteArray(yolo, FileExtensions.jpg, (bool)Program.Settings.GetValue("settings.screenshot")[2], (int)Program.Settings.GetValue("settings.screenshot")[1]), FileExtensions.jpeg));
                        }
                        Tasks.Reset();
                    }));
                }
                else if (p.Task == KeyTask.ActiveWindow)
                {
                    Tasks.CurrentTask = p.Task;
                    Invoke((MethodInvoker)(() =>
                    {
                        Rectangle rect = Utils.Utils.GetActiveWindowCoords();
                        Bitmap cloneBitmap = Utils.Utils.CopyActiveWindow(rect);
                        MusicPlayer.PlayCaptured();
                        if ((FileExtensions)Program.Settings.GetValue("settings.screenshot")[0] == FileExtensions.png && (bool)Program.Settings.GetValue("settings.screenshot")[2])
                        {
                            System.Drawing.Image quantized = Utils.Utils.Quantize(cloneBitmap);
                            cloneBitmap.Dispose();

                            Uploader.Uploader.AddToQueue(new ImageShell(Utils.Utils.imageToByteArray(quantized, FileExtensions.png, false, 0), FileExtensions.png));
                        }
                        else if ((FileExtensions)Program.Settings.GetValue("settings.screenshot")[0] == FileExtensions.png)
                        {
                            Uploader.Uploader.AddToQueue(new ImageShell(Utils.Utils.imageToByteArray(cloneBitmap, FileExtensions.png, false, 0), FileExtensions.png));
                        }
                        else
                        {
                            Uploader.Uploader.AddToQueue(new ImageShell(Utils.Utils.imageToByteArray(cloneBitmap, FileExtensions.jpg, (bool)Program.Settings.GetValue("settings.screenshot")[2], (int)Program.Settings.GetValue("settings.screenshot")[1]), FileExtensions.jpeg));
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
                            if ((bool)Program.Settings.GetValue("settings.show_record_warning")[0] == true)
                            {
                                RecordingNotice rcd = new RecordingNotice();
                                rcd.ShowDialog();
                            }
                            Bitmap yolo = Utils.Utils.CopyScreen();
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
                        Uploader.Uploader.AddToQueue(new ImageShell(Encoding.ASCII.GetBytes(Clipboard.GetText()), FileExtensions.txt));
                    }
                    else if (Clipboard.ContainsImage())
                    {
                        Uploader.Uploader.AddToQueue(new ImageShell(Utils.Utils.imageToByteArray(Clipboard.GetImage(), FileExtensions.png, false, 100L), FileExtensions.png));
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
                                Uploader.Uploader.AddToQueue(new ImageShell(File.ReadAllBytes(f[0]), (FileExtensions)Enum.Parse(typeof(FileExtensions), ext)));
                            }
                        }
                    }
                    Tasks.Reset();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Settings.SaveSettings();
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
                Process.Start(Program.Settings.GetUploadedImage(betterListView1.SelectedItems[0].SubItems[1].Text).URL);
            }
        }

        private void clearHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //clear history.
            Program.Settings.ImageHistory.Clear();
            Program.Settings.SaveSettings();
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
            Program.Settings.ChangeKey("image_uploader", new object[] { (string)metroComboBox1.SelectedItem });
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
                            UploadResult p = Program.Settings.ImageHistory[Utils.Utils.ToUnixTime(DateTime.Parse(betterListView1.SelectedItems[i].SubItems[1].Text))];
                            //check deletion url.
                            WebClient wc = new WebClient() { Proxy = null };
                            new Thread(new ThreadStart(delegate()
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
                                                        wc.UploadValues(p.DelURL, new NameValueCollection() { { "confirm", "true" } });
                                                    else
                                                        wc.UploadValues(p.DelURL, up.DeletionValues);
                                                    break;
                                                }
                                            }
                                        }
                                        catch { }
                                    }
                                })).Start();
                        }
                        catch
                        {
                        }
                        Program.Settings.ImageHistory.Remove(Utils.Utils.ToUnixTime(DateTime.Parse(betterListView1.SelectedItems[i].SubItems[1].Text)));
                        Program.Settings.SaveSettings();
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
                    Program.Settings.ImageHistory.Remove(Utils.Utils.ToUnixTime(DateTime.Parse(betterListView1.SelectedItems[i].SubItems[1].Text)));
                Program.Settings.SaveSettings();
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
                UploadResult x = Program.Settings.GetUploadedImage(betterListView1.SelectedItems[0].SubItems[1].Text);
                if (!string.IsNullOrEmpty(x.DelURL))
                {
                    if(!contextMenuStrip2.Items.Contains(itm))
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
            Program.Settings.ChangeKey("image_uploader_direct_url", new object[] { metroToggle3.Checked });
            //reload listview.
            betterListView1.Items.Clear();
            UpdateListView();
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ask to download image.
            if (betterListView1.SelectedItems.Count > 0)
            {
                string url = Program.Settings.GetUploadedImage(betterListView1.SelectedItems[0].SubItems[1].Text).URL;
                SaveFileDialog d = new SaveFileDialog();
                d.Title = "Save Image...";
                d.Filter = "PNG Image Files (*.png)|*.png";
                d.FileName = betterListView1.SelectedItems[0].Text.Split('/')[3].Split('.')[0] + ".png";
                if (d.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        new Thread(delegate() { new WebClient() { Proxy = null }.DownloadFile(url, d.FileName); }).Start();
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
            bool hook = Program.Settings.SetNewHook(hotkeyButton1.HotKey.ModifiersEnum, hotkeyButton1.HotKey.Hotkey, KeyTask.Region);
            if (!hook)
            {
                HotkeyError("Region");
            }
            UpdateHotKeys();
        }

        private void hotkeyButton2_OnHotKeyChanged(object sender, EventArgs e)
        {
            bool hook1 = Program.Settings.SetNewHook(hotkeyButton2.HotKey.ModifiersEnum, hotkeyButton2.HotKey.Hotkey, KeyTask.Fullscreen);
            if (!hook1)
            {
                HotkeyError("Fullscreen");
            }
            UpdateHotKeys();
        }

        private void hotkeyButton3_OnHotKeyChanged(object sender, EventArgs e)
        {
            bool hook2 = Program.Settings.SetNewHook(hotkeyButton3.HotKey.ModifiersEnum, hotkeyButton3.HotKey.Hotkey, KeyTask.ActiveWindow);
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
                Program.Settings.CreateNewSettings();
                UpdateControls();
            }
        }

        private void hotkeyButton4_OnHotKeyChanged(object sender, EventArgs e)
        {
            bool hook2 = Program.Settings.SetNewHook(hotkeyButton4.HotKey.ModifiersEnum, hotkeyButton4.HotKey.Hotkey, KeyTask.RecordScreen);
            if (!hook2)
            {
                HotkeyError("Record Screen");
            }
            UpdateHotKeys();
        }

        private void hotkeyButton5_OnHotKeyChanged(object sender, EventArgs e)
        {
            bool hook = Program.Settings.SetNewHook(hotkeyButton5.HotKey.ModifiersEnum, hotkeyButton5.HotKey.Hotkey, KeyTask.UploadClipboard);
            if (!hook)
            {
                HotkeyError("Upload Clipboard");
            }
            UpdateHotKeys();
        }

        private void hotkeyButton6_OnHotKeyChanged(object sender, EventArgs e)
        {
            bool hook = Program.Settings.SetNewHook(hotkeyButton6.HotKey.ModifiersEnum, hotkeyButton6.HotKey.Hotkey, KeyTask.RegionNoUpload);
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
            Program.Settings.ChangeKey("shotr.token", new object[] { "" });
            Program.Settings.token = "";
            Program.Settings.email = "";
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
            Bitmap yolo = Utils.Utils.CopyScreen();
            ColorPickerForm f = new ColorPickerForm(yolo, metroLabel9.GetThemeFont());
            f.Show();
        }

        private void regionCaptureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (HotKeyHook m in Program.Settings.hotkeys)
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
            foreach (HotKeyHook m in Program.Settings.hotkeys)
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
            foreach (HotKeyHook m in Program.Settings.hotkeys)
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
            foreach (HotKeyHook m in Program.Settings.hotkeys)
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

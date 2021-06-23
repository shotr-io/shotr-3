using System.ComponentModel;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;
using Shotr.Core.Controls.Theme;
using Shotr.Core.Controls.Hotkey;

namespace Shotr.Ui.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regionCaptureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullscreenCaptureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.recordScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.uploadClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.colorPickerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroTextBox1 = new Shotr.Core.Controls.Theme.ThemedTextBox();
            this.metroTabControl1 = new Shotr.Core.Controls.Theme.ThemedTabControl();
            this.metroTabPage4 = new Shotr.Core.Controls.Theme.ThemedTabPage();
            this.themedListView1 = new Shotr.Core.Controls.Theme.ThemedListView();
            this.betterListViewColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.betterListViewColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.metroTabPage2 = new Shotr.Core.Controls.Theme.ThemedTabPage();
            this.metroPanel2 = new Shotr.Core.Controls.Theme.ThemedPanel();
            this.colorPickerHotKeyButton = new Shotr.Core.Controls.Hotkey.HotKeyButton();
            this.saveOnlyLabel = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.uploadClipboardHotKeyButton = new Shotr.Core.Controls.Hotkey.HotKeyButton();
            this.clipboardLabel = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.recordScreenHotKeyButton = new Shotr.Core.Controls.Hotkey.HotKeyButton();
            this.recordScreenLabel = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.activeWindowHotKeyButton = new Shotr.Core.Controls.Hotkey.HotKeyButton();
            this.fullScreenHotKeyButton = new Shotr.Core.Controls.Hotkey.HotKeyButton();
            this.regionHotKeyButton = new Shotr.Core.Controls.Hotkey.HotKeyButton();
            this.metroLabel1 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.regionLabel = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.fullscreenLabel = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.activeWindowLabel = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.metroPanel1 = new Shotr.Core.Controls.Theme.ThemedPanel();
            this.metroButton5 = new Shotr.Core.Controls.Theme.ThemedButton();
            this.metroButton1 = new Shotr.Core.Controls.Theme.ThemedButton();
            this.metroLabel5 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.metroButton2 = new Shotr.Core.Controls.Theme.ThemedButton();
            this.loginToShotrPanel = new Shotr.Core.Controls.Theme.ThemedPanel();
            this.loginToShotrDescriptionLabel = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.loginToShotrButton = new Shotr.Core.Controls.Theme.ThemedButton();
            this.loginToShotrLabel = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.myAccountPanel = new Shotr.Core.Controls.Theme.ThemedPanel();
            this.viewAccountButton = new Shotr.Core.Controls.Theme.ThemedButton();
            this.logoutButton = new Shotr.Core.Controls.Theme.ThemedButton();
            this.uploadCountLabel = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.totalImagesUploadedLabel = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.emailLabel = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.copyURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroLabel8 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.logoPictureBox = new Shotr.Core.Controls.DpiScaling.DpiScaledPictureBox();
            this.contextMenuStrip1.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage4.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.loginToShotrPanel.SuspendLayout();
            this.myAccountPanel.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Shotr";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem,
            this.historyToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(121, 126);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regionCaptureToolStripMenuItem,
            this.fullscreenCaptureToolStripMenuItem,
            this.toolStripSeparator5,
            this.recordScreenToolStripMenuItem,
            this.toolStripSeparator6,
            this.uploadClipboardToolStripMenuItem,
            this.toolStripSeparator7,
            this.colorPickerToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.toolsToolStripMenuItem.Text = "Capture";
            // 
            // regionCaptureToolStripMenuItem
            // 
            this.regionCaptureToolStripMenuItem.Enabled = false;
            this.regionCaptureToolStripMenuItem.Name = "regionCaptureToolStripMenuItem";
            this.regionCaptureToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.regionCaptureToolStripMenuItem.Text = "Region Capture";
            this.regionCaptureToolStripMenuItem.Click += new System.EventHandler(this.regionCaptureToolStripMenuItem_Click);
            // 
            // fullscreenCaptureToolStripMenuItem
            // 
            this.fullscreenCaptureToolStripMenuItem.Enabled = false;
            this.fullscreenCaptureToolStripMenuItem.Name = "fullscreenCaptureToolStripMenuItem";
            this.fullscreenCaptureToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fullscreenCaptureToolStripMenuItem.Text = "Fullscreen Capture";
            this.fullscreenCaptureToolStripMenuItem.Click += new System.EventHandler(this.fullscreenCaptureToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(177, 6);
            // 
            // recordScreenToolStripMenuItem
            // 
            this.recordScreenToolStripMenuItem.Enabled = false;
            this.recordScreenToolStripMenuItem.Name = "recordScreenToolStripMenuItem";
            this.recordScreenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.recordScreenToolStripMenuItem.Text = "Record Screen";
            this.recordScreenToolStripMenuItem.Click += new System.EventHandler(this.recordScreenToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(177, 6);
            // 
            // uploadClipboardToolStripMenuItem
            // 
            this.uploadClipboardToolStripMenuItem.Enabled = false;
            this.uploadClipboardToolStripMenuItem.Name = "uploadClipboardToolStripMenuItem";
            this.uploadClipboardToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.uploadClipboardToolStripMenuItem.Text = "Upload Clipboard";
            this.uploadClipboardToolStripMenuItem.Click += new System.EventHandler(this.uploadClipboardToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(177, 6);
            // 
            // colorPickerToolStripMenuItem
            // 
            this.colorPickerToolStripMenuItem.Name = "colorPickerToolStripMenuItem";
            this.colorPickerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.colorPickerToolStripMenuItem.Text = "Color Picker";
            this.colorPickerToolStripMenuItem.Click += new System.EventHandler(this.colorPickerToolStripMenuItem_Click);
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.historyToolStripMenuItem.Text = "History";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(117, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.toolStripMenuItem1.Text = "About";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(117, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // metroTextBox1
            // 
            this.metroTextBox1.BasePaint = false;
            this.metroTextBox1.Location = new System.Drawing.Point(0, 0);
            this.metroTextBox1.Multiline = false;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.ReadOnly = false;
            this.metroTextBox1.Scaled = true;
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.Size = new System.Drawing.Size(0, 23);
            this.metroTextBox1.TabIndex = 0;
            this.metroTextBox1.TabStop = false;
            this.metroTextBox1.UseSystemPasswordChar = false;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.BasePaint = false;
            this.metroTabControl1.Controls.Add(this.metroTabPage4);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.metroTabControl1.Location = new System.Drawing.Point(6, 57);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.Scaled = true;
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(601, 292);
            this.metroTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.metroTabControl1.TabIndex = 5;
            // 
            // metroTabPage4
            // 
            this.metroTabPage4.BasePaint = false;
            this.metroTabPage4.Controls.Add(this.themedListView1);
            this.metroTabPage4.Location = new System.Drawing.Point(4, 25);
            this.metroTabPage4.Name = "metroTabPage4";
            this.metroTabPage4.Padding = new System.Windows.Forms.Padding(10);
            this.metroTabPage4.Scaled = true;
            this.metroTabPage4.Size = new System.Drawing.Size(593, 263);
            this.metroTabPage4.TabIndex = 3;
            this.metroTabPage4.Text = "History";
            // 
            // themedListView1
            // 
            this.themedListView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(48)))));
            this.themedListView1.BasePaint = true;
            this.themedListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.betterListViewColumnHeader1,
            this.betterListViewColumnHeader2});
            this.themedListView1.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.themedListView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.themedListView1.FullRowSelect = true;
            this.themedListView1.HideSelection = false;
            this.themedListView1.Location = new System.Drawing.Point(6, 6);
            this.themedListView1.Name = "themedListView1";
            this.themedListView1.Scaled = true;
            this.themedListView1.Size = new System.Drawing.Size(581, 253);
            this.themedListView1.TabIndex = 2;
            this.themedListView1.UseCompatibleStateImageBehavior = false;
            this.themedListView1.View = System.Windows.Forms.View.Details;
            // 
            // betterListViewColumnHeader1
            // 
            this.betterListViewColumnHeader1.Name = "betterListViewColumnHeader1";
            this.betterListViewColumnHeader1.Text = "Image URL";
            this.betterListViewColumnHeader1.Width = 260;
            // 
            // betterListViewColumnHeader2
            // 
            this.betterListViewColumnHeader2.Name = "betterListViewColumnHeader2";
            this.betterListViewColumnHeader2.Text = "Time Uploaded";
            this.betterListViewColumnHeader2.Width = 260;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.BasePaint = false;
            this.metroTabPage2.Controls.Add(this.metroPanel2);
            this.metroTabPage2.Controls.Add(this.metroPanel1);
            this.metroTabPage2.Controls.Add(this.loginToShotrPanel);
            this.metroTabPage2.Controls.Add(this.myAccountPanel);
            this.metroTabPage2.Location = new System.Drawing.Point(4, 25);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Scaled = true;
            this.metroTabPage2.Size = new System.Drawing.Size(593, 263);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Settings";
            // 
            // metroPanel2
            // 
            this.metroPanel2.BasePaint = false;
            this.metroPanel2.Controls.Add(this.colorPickerHotKeyButton);
            this.metroPanel2.Controls.Add(this.saveOnlyLabel);
            this.metroPanel2.Controls.Add(this.uploadClipboardHotKeyButton);
            this.metroPanel2.Controls.Add(this.clipboardLabel);
            this.metroPanel2.Controls.Add(this.recordScreenHotKeyButton);
            this.metroPanel2.Controls.Add(this.recordScreenLabel);
            this.metroPanel2.Controls.Add(this.activeWindowHotKeyButton);
            this.metroPanel2.Controls.Add(this.fullScreenHotKeyButton);
            this.metroPanel2.Controls.Add(this.regionHotKeyButton);
            this.metroPanel2.Controls.Add(this.metroLabel1);
            this.metroPanel2.Controls.Add(this.regionLabel);
            this.metroPanel2.Controls.Add(this.fullscreenLabel);
            this.metroPanel2.Controls.Add(this.activeWindowLabel);
            this.metroPanel2.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroPanel2.Location = new System.Drawing.Point(6, 7);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Scaled = true;
            this.metroPanel2.Size = new System.Drawing.Size(282, 254);
            this.metroPanel2.TabIndex = 25;
            // 
            // colorPickerHotKeyButton
            // 
            this.colorPickerHotKeyButton.BasePaint = false;
            this.colorPickerHotKeyButton.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.colorPickerHotKeyButton.Highlight = false;
            this.colorPickerHotKeyButton.HotKey = null;
            this.colorPickerHotKeyButton.Location = new System.Drawing.Point(121, 161);
            this.colorPickerHotKeyButton.Name = "colorPickerHotKeyButton";
            this.colorPickerHotKeyButton.Scaled = true;
            this.colorPickerHotKeyButton.Size = new System.Drawing.Size(142, 21);
            this.colorPickerHotKeyButton.TabIndex = 32;
            this.colorPickerHotKeyButton.Text = "None";
            // 
            // saveOnlyLabel
            // 
            this.saveOnlyLabel.BasePaint = false;
            this.saveOnlyLabel.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.saveOnlyLabel.Location = new System.Drawing.Point(16, 164);
            this.saveOnlyLabel.Name = "saveOnlyLabel";
            this.saveOnlyLabel.Scaled = true;
            this.saveOnlyLabel.Size = new System.Drawing.Size(103, 22);
            this.saveOnlyLabel.TabIndex = 31;
            this.saveOnlyLabel.Text = "Color Picker:";
            // 
            // uploadClipboardHotKeyButton
            // 
            this.uploadClipboardHotKeyButton.BasePaint = false;
            this.uploadClipboardHotKeyButton.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.uploadClipboardHotKeyButton.Highlight = false;
            this.uploadClipboardHotKeyButton.HotKey = null;
            this.uploadClipboardHotKeyButton.Location = new System.Drawing.Point(121, 135);
            this.uploadClipboardHotKeyButton.Name = "uploadClipboardHotKeyButton";
            this.uploadClipboardHotKeyButton.Scaled = true;
            this.uploadClipboardHotKeyButton.Size = new System.Drawing.Size(142, 21);
            this.uploadClipboardHotKeyButton.TabIndex = 30;
            this.uploadClipboardHotKeyButton.Text = "None";
            // 
            // clipboardLabel
            // 
            this.clipboardLabel.BasePaint = false;
            this.clipboardLabel.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.clipboardLabel.Location = new System.Drawing.Point(16, 137);
            this.clipboardLabel.Name = "clipboardLabel";
            this.clipboardLabel.Scaled = true;
            this.clipboardLabel.Size = new System.Drawing.Size(81, 22);
            this.clipboardLabel.TabIndex = 29;
            this.clipboardLabel.Text = "Text Upload:";
            // 
            // recordScreenHotKeyButton
            // 
            this.recordScreenHotKeyButton.BasePaint = false;
            this.recordScreenHotKeyButton.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.recordScreenHotKeyButton.Highlight = false;
            this.recordScreenHotKeyButton.HotKey = null;
            this.recordScreenHotKeyButton.Location = new System.Drawing.Point(121, 109);
            this.recordScreenHotKeyButton.Name = "recordScreenHotKeyButton";
            this.recordScreenHotKeyButton.Scaled = true;
            this.recordScreenHotKeyButton.Size = new System.Drawing.Size(142, 21);
            this.recordScreenHotKeyButton.TabIndex = 28;
            this.recordScreenHotKeyButton.Text = "None";
            // 
            // recordScreenLabel
            // 
            this.recordScreenLabel.BasePaint = false;
            this.recordScreenLabel.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.recordScreenLabel.Location = new System.Drawing.Point(16, 111);
            this.recordScreenLabel.Name = "recordScreenLabel";
            this.recordScreenLabel.Scaled = true;
            this.recordScreenLabel.Size = new System.Drawing.Size(96, 22);
            this.recordScreenLabel.TabIndex = 27;
            this.recordScreenLabel.Text = "Record Screen:";
            // 
            // activeWindowHotKeyButton
            // 
            this.activeWindowHotKeyButton.BasePaint = false;
            this.activeWindowHotKeyButton.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.activeWindowHotKeyButton.Highlight = false;
            this.activeWindowHotKeyButton.HotKey = null;
            this.activeWindowHotKeyButton.Location = new System.Drawing.Point(121, 82);
            this.activeWindowHotKeyButton.Name = "activeWindowHotKeyButton";
            this.activeWindowHotKeyButton.Scaled = true;
            this.activeWindowHotKeyButton.Size = new System.Drawing.Size(142, 21);
            this.activeWindowHotKeyButton.TabIndex = 26;
            this.activeWindowHotKeyButton.Text = "None";
            // 
            // fullScreenHotKeyButton
            // 
            this.fullScreenHotKeyButton.BasePaint = false;
            this.fullScreenHotKeyButton.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.fullScreenHotKeyButton.Highlight = false;
            this.fullScreenHotKeyButton.HotKey = null;
            this.fullScreenHotKeyButton.Location = new System.Drawing.Point(121, 55);
            this.fullScreenHotKeyButton.Name = "fullScreenHotKeyButton";
            this.fullScreenHotKeyButton.Scaled = true;
            this.fullScreenHotKeyButton.Size = new System.Drawing.Size(142, 21);
            this.fullScreenHotKeyButton.TabIndex = 25;
            this.fullScreenHotKeyButton.Text = "None";
            // 
            // regionHotKeyButton
            // 
            this.regionHotKeyButton.BasePaint = false;
            this.regionHotKeyButton.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.regionHotKeyButton.Highlight = false;
            this.regionHotKeyButton.HotKey = null;
            this.regionHotKeyButton.Location = new System.Drawing.Point(121, 28);
            this.regionHotKeyButton.Name = "regionHotKeyButton";
            this.regionHotKeyButton.Scaled = true;
            this.regionHotKeyButton.Size = new System.Drawing.Size(142, 21);
            this.regionHotKeyButton.TabIndex = 24;
            this.regionHotKeyButton.Text = "None";
            // 
            // metroLabel1
            // 
            this.metroLabel1.BasePaint = false;
            this.metroLabel1.Location = new System.Drawing.Point(3, 3);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Scaled = true;
            this.metroLabel1.Size = new System.Drawing.Size(276, 20);
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text = "Action Settings";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // regionLabel
            // 
            this.regionLabel.BasePaint = false;
            this.regionLabel.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.regionLabel.Location = new System.Drawing.Point(16, 31);
            this.regionLabel.Name = "regionLabel";
            this.regionLabel.Scaled = true;
            this.regionLabel.Size = new System.Drawing.Size(53, 22);
            this.regionLabel.TabIndex = 7;
            this.regionLabel.Text = "Region:";
            // 
            // fullscreenLabel
            // 
            this.fullscreenLabel.BasePaint = false;
            this.fullscreenLabel.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.fullscreenLabel.Location = new System.Drawing.Point(16, 58);
            this.fullscreenLabel.Name = "fullscreenLabel";
            this.fullscreenLabel.Scaled = true;
            this.fullscreenLabel.Size = new System.Drawing.Size(70, 22);
            this.fullscreenLabel.TabIndex = 8;
            this.fullscreenLabel.Text = "Fullscreen:";
            // 
            // activeWindowLabel
            // 
            this.activeWindowLabel.BasePaint = false;
            this.activeWindowLabel.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.activeWindowLabel.Location = new System.Drawing.Point(16, 85);
            this.activeWindowLabel.Name = "activeWindowLabel";
            this.activeWindowLabel.Scaled = true;
            this.activeWindowLabel.Size = new System.Drawing.Size(99, 22);
            this.activeWindowLabel.TabIndex = 9;
            this.activeWindowLabel.Text = "Active Window:";
            // 
            // metroPanel1
            // 
            this.metroPanel1.BasePaint = false;
            this.metroPanel1.Controls.Add(this.metroButton5);
            this.metroPanel1.Controls.Add(this.metroButton1);
            this.metroPanel1.Controls.Add(this.metroLabel5);
            this.metroPanel1.Controls.Add(this.metroButton2);
            this.metroPanel1.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroPanel1.Location = new System.Drawing.Point(304, 7);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Scaled = true;
            this.metroPanel1.Size = new System.Drawing.Size(283, 125);
            this.metroPanel1.TabIndex = 24;
            // 
            // metroButton5
            // 
            this.metroButton5.BasePaint = false;
            this.metroButton5.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroButton5.Highlight = false;
            this.metroButton5.Location = new System.Drawing.Point(16, 26);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Scaled = true;
            this.metroButton5.Size = new System.Drawing.Size(251, 23);
            this.metroButton5.TabIndex = 30;
            this.metroButton5.Text = "Global Settings";
            this.metroButton5.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.BasePaint = false;
            this.metroButton1.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroButton1.Highlight = false;
            this.metroButton1.Location = new System.Drawing.Point(16, 84);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Scaled = true;
            this.metroButton1.Size = new System.Drawing.Size(251, 23);
            this.metroButton1.TabIndex = 27;
            this.metroButton1.Text = "Reset To Default Settings";
            this.metroButton1.Click += new System.EventHandler(this.resetSettingsButton_Click);
            // 
            // metroLabel5
            // 
            this.metroLabel5.BasePaint = false;
            this.metroLabel5.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroLabel5.Location = new System.Drawing.Point(3, 3);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Scaled = true;
            this.metroLabel5.Size = new System.Drawing.Size(277, 20);
            this.metroLabel5.TabIndex = 10;
            this.metroLabel5.Text = "Program Settings";
            this.metroLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroButton2
            // 
            this.metroButton2.BasePaint = false;
            this.metroButton2.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroButton2.Highlight = false;
            this.metroButton2.Location = new System.Drawing.Point(16, 55);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Scaled = true;
            this.metroButton2.Size = new System.Drawing.Size(251, 23);
            this.metroButton2.TabIndex = 23;
            this.metroButton2.Text = "Custom Uploaders";
            this.metroButton2.Click += new System.EventHandler(this.customUploaderButton_Click);
            // 
            // loginToShotrPanel
            // 
            this.loginToShotrPanel.BasePaint = false;
            this.loginToShotrPanel.Controls.Add(this.loginToShotrDescriptionLabel);
            this.loginToShotrPanel.Controls.Add(this.loginToShotrButton);
            this.loginToShotrPanel.Controls.Add(this.loginToShotrLabel);
            this.loginToShotrPanel.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.loginToShotrPanel.Location = new System.Drawing.Point(304, 139);
            this.loginToShotrPanel.Name = "loginToShotrPanel";
            this.loginToShotrPanel.Scaled = true;
            this.loginToShotrPanel.Size = new System.Drawing.Size(283, 122);
            this.loginToShotrPanel.TabIndex = 33;
            // 
            // loginToShotrDescriptionLabel
            // 
            this.loginToShotrDescriptionLabel.BasePaint = false;
            this.loginToShotrDescriptionLabel.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.loginToShotrDescriptionLabel.Location = new System.Drawing.Point(16, 34);
            this.loginToShotrDescriptionLabel.Name = "loginToShotrDescriptionLabel";
            this.loginToShotrDescriptionLabel.Scaled = true;
            this.loginToShotrDescriptionLabel.Size = new System.Drawing.Size(250, 22);
            this.loginToShotrDescriptionLabel.TabIndex = 33;
            this.loginToShotrDescriptionLabel.Text = "Log In to Shotr to enable uploads!";
            this.loginToShotrDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loginToShotrButton
            // 
            this.loginToShotrButton.BasePaint = false;
            this.loginToShotrButton.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.loginToShotrButton.Highlight = false;
            this.loginToShotrButton.Location = new System.Drawing.Point(16, 66);
            this.loginToShotrButton.Name = "loginToShotrButton";
            this.loginToShotrButton.Scaled = true;
            this.loginToShotrButton.Size = new System.Drawing.Size(251, 23);
            this.loginToShotrButton.TabIndex = 32;
            this.loginToShotrButton.Text = "Login";
            this.loginToShotrButton.Click += new System.EventHandler(this.loginToShotrButton_Click);
            // 
            // loginToShotrLabel
            // 
            this.loginToShotrLabel.BasePaint = false;
            this.loginToShotrLabel.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.loginToShotrLabel.Location = new System.Drawing.Point(3, 3);
            this.loginToShotrLabel.Name = "loginToShotrLabel";
            this.loginToShotrLabel.Scaled = true;
            this.loginToShotrLabel.Size = new System.Drawing.Size(277, 19);
            this.loginToShotrLabel.TabIndex = 10;
            this.loginToShotrLabel.Text = "My Account";
            this.loginToShotrLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // myAccountPanel
            // 
            this.myAccountPanel.BasePaint = false;
            this.myAccountPanel.Controls.Add(this.viewAccountButton);
            this.myAccountPanel.Controls.Add(this.logoutButton);
            this.myAccountPanel.Controls.Add(this.uploadCountLabel);
            this.myAccountPanel.Controls.Add(this.totalImagesUploadedLabel);
            this.myAccountPanel.Controls.Add(this.emailLabel);
            this.myAccountPanel.Location = new System.Drawing.Point(304, 139);
            this.myAccountPanel.Name = "myAccountPanel";
            this.myAccountPanel.Scaled = true;
            this.myAccountPanel.Size = new System.Drawing.Size(283, 122);
            this.myAccountPanel.TabIndex = 32;
            // 
            // viewAccountButton
            // 
            this.viewAccountButton.BasePaint = false;
            this.viewAccountButton.Highlight = false;
            this.viewAccountButton.Location = new System.Drawing.Point(15, 55);
            this.viewAccountButton.Name = "viewAccountButton";
            this.viewAccountButton.Scaled = true;
            this.viewAccountButton.Size = new System.Drawing.Size(251, 23);
            this.viewAccountButton.TabIndex = 32;
            this.viewAccountButton.Text = "View Account";
            // 
            // logoutButton
            // 
            this.logoutButton.BasePaint = false;
            this.logoutButton.Highlight = false;
            this.logoutButton.Location = new System.Drawing.Point(15, 85);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Scaled = true;
            this.logoutButton.Size = new System.Drawing.Size(251, 23);
            this.logoutButton.TabIndex = 31;
            this.logoutButton.Text = "Log Out";
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // uploadCountLabel
            // 
            this.uploadCountLabel.BasePaint = false;
            this.uploadCountLabel.Location = new System.Drawing.Point(177, 28);
            this.uploadCountLabel.Name = "uploadCountLabel";
            this.uploadCountLabel.Scaled = true;
            this.uploadCountLabel.Size = new System.Drawing.Size(93, 15);
            this.uploadCountLabel.TabIndex = 12;
            this.uploadCountLabel.Text = "0";
            this.uploadCountLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // totalImagesUploadedLabel
            // 
            this.totalImagesUploadedLabel.AutoSize = true;
            this.totalImagesUploadedLabel.BasePaint = false;
            this.totalImagesUploadedLabel.Location = new System.Drawing.Point(13, 28);
            this.totalImagesUploadedLabel.Name = "totalImagesUploadedLabel";
            this.totalImagesUploadedLabel.Scaled = true;
            this.totalImagesUploadedLabel.Size = new System.Drawing.Size(87, 15);
            this.totalImagesUploadedLabel.TabIndex = 11;
            this.totalImagesUploadedLabel.Text = "Total Uploads:";
            // 
            // emailLabel
            // 
            this.emailLabel.BasePaint = false;
            this.emailLabel.Location = new System.Drawing.Point(3, 3);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Scaled = true;
            this.emailLabel.Size = new System.Drawing.Size(277, 19);
            this.emailLabel.TabIndex = 10;
            this.emailLabel.Text = "<email>";
            this.emailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveImageToolStripMenuItem,
            this.toolStripSeparator4,
            this.copyURLToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator3,
            this.toolStripMenuItem2,
            this.clearHistoryToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(153, 126);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // copyURLToolStripMenuItem
            // 
            this.copyURLToolStripMenuItem.Name = "copyURLToolStripMenuItem";
            this.copyURLToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.copyURLToolStripMenuItem.Text = "Copy URL";
            this.copyURLToolStripMenuItem.Click += new System.EventHandler(this.copyURLToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "Remove Entry";
            // 
            // clearHistoryToolStripMenuItem
            // 
            this.clearHistoryToolStripMenuItem.Name = "clearHistoryToolStripMenuItem";
            this.clearHistoryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearHistoryToolStripMenuItem.Text = "Clear History";
            this.clearHistoryToolStripMenuItem.Click += new System.EventHandler(this.clearHistoryToolStripMenuItem_Click);
            // 
            // metroLabel8
            // 
            this.metroLabel8.BasePaint = false;
            this.metroLabel8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLabel8.Font = new System.Drawing.Font("Inter", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroLabel8.Location = new System.Drawing.Point(322, 1);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Scaled = true;
            this.metroLabel8.Size = new System.Drawing.Size(289, 19);
            this.metroLabel8.TabIndex = 2;
            this.metroLabel8.Text = "v{0}";
            this.metroLabel8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.metroLabel8.Click += new System.EventHandler(this.aboutLabel_Click);
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.logoPictureBox.BackgroundImage = Shotr.Ui.Properties.Resources.shotr_logo_banner;
            this.logoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoPictureBox.BasePaint = false;
            this.logoPictureBox.Location = new System.Drawing.Point(5, 11);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Scaled = true;
            this.logoPictureBox.Size = new System.Drawing.Size(143, 53);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 6;
            this.logoPictureBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(613, 360);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.logoPictureBox);
            this.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(20, 31, 20, 21);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shotr";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage4.ResumeLayout(false);
            this.metroTabPage2.ResumeLayout(false);
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.loginToShotrPanel.ResumeLayout(false);
            this.myAccountPanel.ResumeLayout(false);
            this.myAccountPanel.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ThemedTextBox metroTextBox1;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem clearHistoryToolStripMenuItem;
        private ToolStripMenuItem historyToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem copyURLToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem saveImageToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ColumnHeader betterListViewColumnHeader1;
        private ColumnHeader betterListViewColumnHeader2;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem colorPickerToolStripMenuItem;
        private ToolStripMenuItem regionCaptureToolStripMenuItem;
        private ToolStripMenuItem fullscreenCaptureToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem recordScreenToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem uploadClipboardToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ThemedTabControl metroTabControl1;
        private ThemedTabPage metroTabPage2;
        private ThemedLabel activeWindowLabel;
        private ThemedLabel fullscreenLabel;
        private ThemedLabel regionLabel;
        private ThemedLabel metroLabel1;
        private ThemedLabel metroLabel5;
        private ThemedLabel metroLabel8;
        private ThemedTabPage metroTabPage4;
        private ThemedListView themedListView1;
        private ThemedButton metroButton2;
        private ThemedPanel metroPanel2;
        private ThemedPanel metroPanel1;
        private HotKeyButton activeWindowHotKeyButton;
        private HotKeyButton fullScreenHotKeyButton;
        private HotKeyButton regionHotKeyButton;
        private ThemedButton metroButton1;
        private HotKeyButton recordScreenHotKeyButton;
        private ThemedLabel recordScreenLabel;
        private HotKeyButton uploadClipboardHotKeyButton;
        private ThemedLabel clipboardLabel;
        private ThemedButton metroButton5;
        private ThemedPanel myAccountPanel;
        private ThemedLabel uploadCountLabel;
        private ThemedLabel totalImagesUploadedLabel;
        private ThemedLabel emailLabel;
        private ThemedButton logoutButton;
        private ThemedButton viewAccountButton;
        private HotKeyButton colorPickerHotKeyButton;
        private ThemedLabel saveOnlyLabel;
        private ThemedPanel loginToShotrPanel;
        private ThemedButton loginToShotrButton;
        private ThemedLabel loginToShotrLabel;
        private ThemedLabel loginToShotrDescriptionLabel;
        private DpiScaledPictureBox logoPictureBox;
    }
}


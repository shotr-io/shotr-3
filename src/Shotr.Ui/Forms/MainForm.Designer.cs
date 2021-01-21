using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework5.Components;
using Shotr.Core.Controls.DpiScaling;

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
            this.metroTextBox1 = new Shotr.Core.Controls.DpiScaling.DpiScaledTextbox();
            this.metroTabControl1 = new Shotr.Core.Controls.DpiScaling.DpiScaledTabControl();
            this.metroTabPage4 = new Shotr.Core.Controls.DpiScaling.DpiScaledTabPage();
            this.betterListView1 = new Shotr.Core.Controls.DpiScaling.DpiScaledListbox();
            this.betterListViewColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.betterListViewColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.metroTabPage2 = new Shotr.Core.Controls.DpiScaling.DpiScaledTabPage();
            this.metroPanel2 = new Shotr.Core.Controls.DpiScaling.DpiScaledPanel();
            this.noUploadHotKeyButton = new Shotr.Core.Controls.DpiScaling.DpiScaledHotkeyButton();
            this.saveOnlyLabel = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.uploadClipboardHotKeyButton = new Shotr.Core.Controls.DpiScaling.DpiScaledHotkeyButton();
            this.clipboardLabel = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.recordScreenHotKeyButton = new Shotr.Core.Controls.DpiScaling.DpiScaledHotkeyButton();
            this.recordScreenLabel = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.activeWindowHotKeyButton = new Shotr.Core.Controls.DpiScaling.DpiScaledHotkeyButton();
            this.fullScreenHotKeyButton = new Shotr.Core.Controls.DpiScaling.DpiScaledHotkeyButton();
            this.regionHotKeyButton = new Shotr.Core.Controls.DpiScaling.DpiScaledHotkeyButton();
            this.metroLabel1 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.directUrlToggle = new Shotr.Core.Controls.DpiScaling.DpiScaledToggle();
            this.metroLabel11 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.metroLabel9 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.regionLabel = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.selectedImageUploader = new Shotr.Core.Controls.DpiScaling.DpiScaledCombobox();
            this.fullscreenLabel = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.activeWindowLabel = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.metroPanel1 = new Shotr.Core.Controls.DpiScaling.DpiScaledPanel();
            this.metroButton5 = new Shotr.Core.Controls.DpiScaling.DpiScaledButton();
            this.metroButton1 = new Shotr.Core.Controls.DpiScaling.DpiScaledButton();
            this.metroLabel5 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.metroButton2 = new Shotr.Core.Controls.DpiScaling.DpiScaledButton();
            this.loginToShotrPanel = new Shotr.Core.Controls.DpiScaling.DpiScaledPanel();
            this.loginToShotrDescriptionLabel = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.loginToShotrButton = new Shotr.Core.Controls.DpiScaling.DpiScaledButton();
            this.loginToShotrLabel = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.myAccountPanel = new Shotr.Core.Controls.DpiScaling.DpiScaledPanel();
            this.viewAccountButton = new Shotr.Core.Controls.DpiScaling.DpiScaledButton();
            this.logoutButton = new Shotr.Core.Controls.DpiScaling.DpiScaledButton();
            this.uploadCountLabel = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.totalImagesUploadedLabel = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.emailLabel = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.copyURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroLabel8 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.metroStyleExtender1 = new MetroFramework5.Components.MetroStyleExtender(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleExtender1)).BeginInit();
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 126);
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
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.toolsToolStripMenuItem.Text = "Capture";
            // 
            // regionCaptureToolStripMenuItem
            // 
            this.regionCaptureToolStripMenuItem.Enabled = false;
            this.regionCaptureToolStripMenuItem.Name = "regionCaptureToolStripMenuItem";
            this.regionCaptureToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.regionCaptureToolStripMenuItem.Text = "Region Capture";
            this.regionCaptureToolStripMenuItem.Click += new System.EventHandler(this.regionCaptureToolStripMenuItem_Click);
            // 
            // fullscreenCaptureToolStripMenuItem
            // 
            this.fullscreenCaptureToolStripMenuItem.Enabled = false;
            this.fullscreenCaptureToolStripMenuItem.Name = "fullscreenCaptureToolStripMenuItem";
            this.fullscreenCaptureToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.fullscreenCaptureToolStripMenuItem.Text = "Fullscreen Capture";
            this.fullscreenCaptureToolStripMenuItem.Click += new System.EventHandler(this.fullscreenCaptureToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(169, 6);
            // 
            // recordScreenToolStripMenuItem
            // 
            this.recordScreenToolStripMenuItem.Enabled = false;
            this.recordScreenToolStripMenuItem.Name = "recordScreenToolStripMenuItem";
            this.recordScreenToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.recordScreenToolStripMenuItem.Text = "Record Screen";
            this.recordScreenToolStripMenuItem.Click += new System.EventHandler(this.recordScreenToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(169, 6);
            // 
            // uploadClipboardToolStripMenuItem
            // 
            this.uploadClipboardToolStripMenuItem.Enabled = false;
            this.uploadClipboardToolStripMenuItem.Name = "uploadClipboardToolStripMenuItem";
            this.uploadClipboardToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.uploadClipboardToolStripMenuItem.Text = "Upload Clipboard";
            this.uploadClipboardToolStripMenuItem.Click += new System.EventHandler(this.uploadClipboardToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(169, 6);
            // 
            // colorPickerToolStripMenuItem
            // 
            this.colorPickerToolStripMenuItem.Name = "colorPickerToolStripMenuItem";
            this.colorPickerToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.colorPickerToolStripMenuItem.Text = "Color Picker";
            this.colorPickerToolStripMenuItem.Click += new System.EventHandler(this.colorPickerToolStripMenuItem_Click);
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.historyToolStripMenuItem.Text = "History";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuItem1.Text = "About";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(113, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // metroTextBox1
            // 
            this.metroTextBox1.Location = new System.Drawing.Point(0, 0);
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.Size = new System.Drawing.Size(0, 22);
            this.metroTextBox1.TabIndex = 0;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage4);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Location = new System.Drawing.Point(10, 57);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(601, 311);
            this.metroTabControl1.Style = "NewTheme";
            this.metroTabControl1.TabIndex = 5;
            this.metroTabControl1.Theme = "NewTheme";
            // 
            // metroTabPage4
            // 
            this.metroTabPage4.Controls.Add(this.betterListView1);
            this.metroTabPage4.HorizontalScrollbarBarColor = true;
            this.metroTabPage4.Location = new System.Drawing.Point(4, 25);
            this.metroTabPage4.Name = "metroTabPage4";
            this.metroTabPage4.Size = new System.Drawing.Size(593, 282);
            this.metroTabPage4.Style = "NewTheme";
            this.metroTabPage4.TabIndex = 3;
            this.metroTabPage4.Text = "History";
            this.metroTabPage4.Theme = "NewTheme";
            this.metroTabPage4.VerticalScrollbarBarColor = true;
            // 
            // betterListView1
            // 
            this.betterListView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(48)))));
            this.betterListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.betterListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.betterListViewColumnHeader1,
            this.betterListViewColumnHeader2});
            this.betterListView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.betterListView1.FullRowSelect = true;
            this.betterListView1.HideSelection = false;
            this.betterListView1.Location = new System.Drawing.Point(6, 6);
            this.betterListView1.Name = "betterListView1";
            this.betterListView1.Size = new System.Drawing.Size(581, 253);
            this.betterListView1.TabIndex = 2;
            this.betterListView1.UseCompatibleStateImageBehavior = false;
            this.betterListView1.View = System.Windows.Forms.View.Details;
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
            this.metroTabPage2.Controls.Add(this.metroPanel2);
            this.metroTabPage2.Controls.Add(this.metroPanel1);
            this.metroTabPage2.Controls.Add(this.loginToShotrPanel);
            this.metroTabPage2.Controls.Add(this.myAccountPanel);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 25);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(593, 282);
            this.metroTabPage2.Style = "NewTheme";
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Settings";
            this.metroTabPage2.Theme = "NewTheme";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            // 
            // metroPanel2
            // 
            this.metroPanel2.BorderStyle = MetroFramework5.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel2.Controls.Add(this.noUploadHotKeyButton);
            this.metroPanel2.Controls.Add(this.saveOnlyLabel);
            this.metroPanel2.Controls.Add(this.uploadClipboardHotKeyButton);
            this.metroPanel2.Controls.Add(this.clipboardLabel);
            this.metroPanel2.Controls.Add(this.recordScreenHotKeyButton);
            this.metroPanel2.Controls.Add(this.recordScreenLabel);
            this.metroPanel2.Controls.Add(this.activeWindowHotKeyButton);
            this.metroPanel2.Controls.Add(this.fullScreenHotKeyButton);
            this.metroPanel2.Controls.Add(this.regionHotKeyButton);
            this.metroPanel2.Controls.Add(this.metroLabel1);
            this.metroPanel2.Controls.Add(this.directUrlToggle);
            this.metroPanel2.Controls.Add(this.metroLabel11);
            this.metroPanel2.Controls.Add(this.metroLabel9);
            this.metroPanel2.Controls.Add(this.regionLabel);
            this.metroPanel2.Controls.Add(this.selectedImageUploader);
            this.metroPanel2.Controls.Add(this.fullscreenLabel);
            this.metroPanel2.Controls.Add(this.activeWindowLabel);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(6, 7);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(282, 272);
            this.metroPanel2.TabIndex = 25;
            this.metroPanel2.Theme = "NewTheme";
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // noUploadHotKeyButton
            // 
            this.noUploadHotKeyButton.HotKey = null;
            this.noUploadHotKeyButton.Location = new System.Drawing.Point(121, 26);
            this.noUploadHotKeyButton.Name = "noUploadHotKeyButton";
            this.noUploadHotKeyButton.Size = new System.Drawing.Size(142, 21);
            this.noUploadHotKeyButton.Style = "HotKey";
            this.noUploadHotKeyButton.TabIndex = 32;
            this.noUploadHotKeyButton.Text = "None";
            this.noUploadHotKeyButton.Theme = "NewTheme";
            // 
            // saveOnlyLabel
            // 
            this.saveOnlyLabel.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.saveOnlyLabel.Location = new System.Drawing.Point(16, 28);
            this.saveOnlyLabel.Name = "saveOnlyLabel";
            this.saveOnlyLabel.Scaled = true;
            this.saveOnlyLabel.Size = new System.Drawing.Size(103, 22);
            this.saveOnlyLabel.Style = "NewTheme";
            this.saveOnlyLabel.TabIndex = 31;
            this.saveOnlyLabel.Text = "Clipboard Save:";
            this.saveOnlyLabel.Theme = "NewTheme";
            this.saveOnlyLabel.UseCompatibleTextRendering = true;
            // 
            // uploadClipboardHotKeyButton
            // 
            this.uploadClipboardHotKeyButton.HotKey = null;
            this.uploadClipboardHotKeyButton.Location = new System.Drawing.Point(121, 160);
            this.uploadClipboardHotKeyButton.Name = "uploadClipboardHotKeyButton";
            this.uploadClipboardHotKeyButton.Size = new System.Drawing.Size(142, 21);
            this.uploadClipboardHotKeyButton.Style = "HotKey";
            this.uploadClipboardHotKeyButton.TabIndex = 30;
            this.uploadClipboardHotKeyButton.Text = "None";
            this.uploadClipboardHotKeyButton.Theme = "NewTheme";
            // 
            // clipboardLabel
            // 
            this.clipboardLabel.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.clipboardLabel.Location = new System.Drawing.Point(16, 163);
            this.clipboardLabel.Name = "clipboardLabel";
            this.clipboardLabel.Scaled = true;
            this.clipboardLabel.Size = new System.Drawing.Size(81, 22);
            this.clipboardLabel.Style = "NewTheme";
            this.clipboardLabel.TabIndex = 29;
            this.clipboardLabel.Text = "Text Upload:";
            this.clipboardLabel.Theme = "NewTheme";
            this.clipboardLabel.UseCompatibleTextRendering = true;
            // 
            // recordScreenHotKeyButton
            // 
            this.recordScreenHotKeyButton.HotKey = null;
            this.recordScreenHotKeyButton.Location = new System.Drawing.Point(121, 134);
            this.recordScreenHotKeyButton.Name = "recordScreenHotKeyButton";
            this.recordScreenHotKeyButton.Size = new System.Drawing.Size(142, 21);
            this.recordScreenHotKeyButton.Style = "HotKey";
            this.recordScreenHotKeyButton.TabIndex = 28;
            this.recordScreenHotKeyButton.Text = "None";
            this.recordScreenHotKeyButton.Theme = "NewTheme";
            // 
            // recordScreenLabel
            // 
            this.recordScreenLabel.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.recordScreenLabel.Location = new System.Drawing.Point(16, 137);
            this.recordScreenLabel.Name = "recordScreenLabel";
            this.recordScreenLabel.Scaled = true;
            this.recordScreenLabel.Size = new System.Drawing.Size(96, 22);
            this.recordScreenLabel.Style = "NewTheme";
            this.recordScreenLabel.TabIndex = 27;
            this.recordScreenLabel.Text = "Record Screen:";
            this.recordScreenLabel.Theme = "NewTheme";
            this.recordScreenLabel.UseCompatibleTextRendering = true;
            // 
            // activeWindowHotKeyButton
            // 
            this.activeWindowHotKeyButton.HotKey = null;
            this.activeWindowHotKeyButton.Location = new System.Drawing.Point(121, 107);
            this.activeWindowHotKeyButton.Name = "activeWindowHotKeyButton";
            this.activeWindowHotKeyButton.Size = new System.Drawing.Size(142, 21);
            this.activeWindowHotKeyButton.Style = "HotKey";
            this.activeWindowHotKeyButton.TabIndex = 26;
            this.activeWindowHotKeyButton.Text = "None";
            this.activeWindowHotKeyButton.Theme = "NewTheme";
            // 
            // fullScreenHotKeyButton
            // 
            this.fullScreenHotKeyButton.HotKey = null;
            this.fullScreenHotKeyButton.Location = new System.Drawing.Point(121, 80);
            this.fullScreenHotKeyButton.Name = "fullScreenHotKeyButton";
            this.fullScreenHotKeyButton.Size = new System.Drawing.Size(142, 21);
            this.fullScreenHotKeyButton.Style = "HotKey";
            this.fullScreenHotKeyButton.TabIndex = 25;
            this.fullScreenHotKeyButton.Text = "None";
            this.fullScreenHotKeyButton.Theme = "NewTheme";
            // 
            // regionHotKeyButton
            // 
            this.regionHotKeyButton.HotKey = null;
            this.regionHotKeyButton.Location = new System.Drawing.Point(121, 53);
            this.regionHotKeyButton.Name = "regionHotKeyButton";
            this.regionHotKeyButton.Size = new System.Drawing.Size(142, 21);
            this.regionHotKeyButton.Style = "HotKey";
            this.regionHotKeyButton.TabIndex = 24;
            this.regionHotKeyButton.Text = "None";
            this.regionHotKeyButton.Theme = "NewTheme";
            // 
            // metroLabel1
            // 
            this.metroLabel1.FontSize = MetroFramework5.Drawing.MetroFontSize.Medium;
            this.metroLabel1.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Light;
            this.metroLabel1.Location = new System.Drawing.Point(3, 3);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Scaled = true;
            this.metroLabel1.Size = new System.Drawing.Size(276, 20);
            this.metroLabel1.Style = "NewTheme";
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text = "Action Settings";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel1.Theme = "NewTheme";
            this.metroLabel1.UseCompatibleTextRendering = true;
            // 
            // directUrlToggle
            // 
            this.directUrlToggle.Location = new System.Drawing.Point(183, 247);
            this.directUrlToggle.Name = "directUrlToggle";
            this.directUrlToggle.Size = new System.Drawing.Size(80, 19);
            this.directUrlToggle.Style = "NewTheme";
            this.directUrlToggle.TabIndex = 18;
            this.directUrlToggle.Text = "Off";
            this.directUrlToggle.Theme = "NewTheme";
            this.directUrlToggle.UseVisualStyleBackColor = false;
            this.directUrlToggle.Visible = false;
            // 
            // metroLabel11
            // 
            this.metroLabel11.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel11.Location = new System.Drawing.Point(14, 246);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Scaled = true;
            this.metroLabel11.Size = new System.Drawing.Size(116, 20);
            this.metroLabel11.Style = "NewTheme";
            this.metroLabel11.TabIndex = 17;
            this.metroLabel11.Text = "Direct Image URLs:";
            this.metroLabel11.Theme = "NewTheme";
            this.metroLabel11.UseCompatibleTextRendering = true;
            this.metroLabel11.Visible = false;
            // 
            // metroLabel9
            // 
            this.metroLabel9.FontSize = MetroFramework5.Drawing.MetroFontSize.Medium;
            this.metroLabel9.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Light;
            this.metroLabel9.Location = new System.Drawing.Point(3, 186);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Scaled = true;
            this.metroLabel9.Size = new System.Drawing.Size(276, 21);
            this.metroLabel9.Style = "NewTheme";
            this.metroLabel9.TabIndex = 16;
            this.metroLabel9.Text = "Image Uploader";
            this.metroLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel9.Theme = "NewTheme";
            this.metroLabel9.UseCompatibleTextRendering = true;
            // 
            // regionLabel
            // 
            this.regionLabel.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.regionLabel.Location = new System.Drawing.Point(16, 55);
            this.regionLabel.Name = "regionLabel";
            this.regionLabel.Scaled = true;
            this.regionLabel.Size = new System.Drawing.Size(53, 22);
            this.regionLabel.Style = "NewTheme";
            this.regionLabel.TabIndex = 7;
            this.regionLabel.Text = "Region:";
            this.regionLabel.Theme = "NewTheme";
            this.regionLabel.UseCompatibleTextRendering = true;
            // 
            // selectedImageUploader
            // 
            this.selectedImageUploader.FormattingEnabled = true;
            this.selectedImageUploader.ItemHeight = 29;
            this.selectedImageUploader.Location = new System.Drawing.Point(18, 208);
            this.selectedImageUploader.Name = "selectedImageUploader";
            this.selectedImageUploader.Size = new System.Drawing.Size(245, 35);
            this.selectedImageUploader.Style = "NewTheme";
            this.selectedImageUploader.TabIndex = 15;
            this.selectedImageUploader.Theme = "NewTheme";
            this.selectedImageUploader.SelectedIndexChanged += new System.EventHandler(this.metroComboBox1_SelectedIndexChanged);
            // 
            // fullscreenLabel
            // 
            this.fullscreenLabel.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.fullscreenLabel.Location = new System.Drawing.Point(16, 82);
            this.fullscreenLabel.Name = "fullscreenLabel";
            this.fullscreenLabel.Scaled = true;
            this.fullscreenLabel.Size = new System.Drawing.Size(70, 22);
            this.fullscreenLabel.Style = "NewTheme";
            this.fullscreenLabel.TabIndex = 8;
            this.fullscreenLabel.Text = "Fullscreen:";
            this.fullscreenLabel.Theme = "NewTheme";
            this.fullscreenLabel.UseCompatibleTextRendering = true;
            // 
            // activeWindowLabel
            // 
            this.activeWindowLabel.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.activeWindowLabel.Location = new System.Drawing.Point(16, 109);
            this.activeWindowLabel.Name = "activeWindowLabel";
            this.activeWindowLabel.Scaled = true;
            this.activeWindowLabel.Size = new System.Drawing.Size(99, 22);
            this.activeWindowLabel.Style = "NewTheme";
            this.activeWindowLabel.TabIndex = 9;
            this.activeWindowLabel.Text = "Active Window:";
            this.activeWindowLabel.Theme = "NewTheme";
            this.activeWindowLabel.UseCompatibleTextRendering = true;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = MetroFramework5.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.metroButton5);
            this.metroPanel1.Controls.Add(this.metroButton1);
            this.metroPanel1.Controls.Add(this.metroLabel5);
            this.metroPanel1.Controls.Add(this.metroButton2);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(304, 7);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(283, 125);
            this.metroPanel1.TabIndex = 24;
            this.metroPanel1.Theme = "NewTheme";
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroButton5
            // 
            this.metroButton5.FontSize = MetroFramework5.Drawing.MetroFontSize.Default;
            this.metroButton5.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Default;
            this.metroButton5.Location = new System.Drawing.Point(16, 26);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Scaled = true;
            this.metroButton5.Size = new System.Drawing.Size(251, 23);
            this.metroButton5.Style = "NewTheme";
            this.metroButton5.TabIndex = 30;
            this.metroButton5.Text = "Global Settings";
            this.metroButton5.Theme = "NewTheme";
            this.metroButton5.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.FontSize = MetroFramework5.Drawing.MetroFontSize.Default;
            this.metroButton1.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Default;
            this.metroButton1.Location = new System.Drawing.Point(16, 84);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Scaled = true;
            this.metroButton1.Size = new System.Drawing.Size(251, 23);
            this.metroButton1.Style = "NewTheme";
            this.metroButton1.TabIndex = 27;
            this.metroButton1.Text = "Reset To Default Settings";
            this.metroButton1.Theme = "NewTheme";
            this.metroButton1.Click += new System.EventHandler(this.resetSettingsButton_Click);
            // 
            // metroLabel5
            // 
            this.metroLabel5.FontSize = MetroFramework5.Drawing.MetroFontSize.Medium;
            this.metroLabel5.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Light;
            this.metroLabel5.Location = new System.Drawing.Point(3, 3);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Scaled = true;
            this.metroLabel5.Size = new System.Drawing.Size(277, 20);
            this.metroLabel5.Style = "NewTheme";
            this.metroLabel5.TabIndex = 10;
            this.metroLabel5.Text = "Program Settings";
            this.metroLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel5.Theme = "NewTheme";
            this.metroLabel5.UseCompatibleTextRendering = true;
            // 
            // metroButton2
            // 
            this.metroButton2.FontSize = MetroFramework5.Drawing.MetroFontSize.Default;
            this.metroButton2.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Default;
            this.metroButton2.Location = new System.Drawing.Point(16, 55);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Scaled = true;
            this.metroButton2.Size = new System.Drawing.Size(251, 23);
            this.metroButton2.Style = "NewTheme";
            this.metroButton2.TabIndex = 23;
            this.metroButton2.Text = "Custom Uploaders";
            this.metroButton2.Theme = "NewTheme";
            this.metroButton2.Click += new System.EventHandler(this.customUploaderButton_Click);
            // 
            // loginToShotrPanel
            // 
            this.loginToShotrPanel.BorderStyle = MetroFramework5.Drawing.MetroBorderStyle.FixedSingle;
            this.loginToShotrPanel.Controls.Add(this.loginToShotrDescriptionLabel);
            this.loginToShotrPanel.Controls.Add(this.loginToShotrButton);
            this.loginToShotrPanel.Controls.Add(this.loginToShotrLabel);
            this.loginToShotrPanel.HorizontalScrollbarBarColor = true;
            this.loginToShotrPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.loginToShotrPanel.HorizontalScrollbarSize = 10;
            this.loginToShotrPanel.Location = new System.Drawing.Point(304, 139);
            this.loginToShotrPanel.Name = "loginToShotrPanel";
            this.loginToShotrPanel.Size = new System.Drawing.Size(283, 122);
            this.loginToShotrPanel.Style = "NewTheme";
            this.loginToShotrPanel.TabIndex = 33;
            this.loginToShotrPanel.Theme = "NewTheme";
            this.loginToShotrPanel.VerticalScrollbarBarColor = true;
            this.loginToShotrPanel.VerticalScrollbarHighlightOnWheel = false;
            this.loginToShotrPanel.VerticalScrollbarSize = 10;
            // 
            // loginToShotrDescriptionLabel
            // 
            this.loginToShotrDescriptionLabel.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.loginToShotrDescriptionLabel.Location = new System.Drawing.Point(16, 34);
            this.loginToShotrDescriptionLabel.Name = "loginToShotrDescriptionLabel";
            this.loginToShotrDescriptionLabel.Scaled = true;
            this.loginToShotrDescriptionLabel.Size = new System.Drawing.Size(250, 22);
            this.loginToShotrDescriptionLabel.Style = "NewTheme";
            this.loginToShotrDescriptionLabel.TabIndex = 33;
            this.loginToShotrDescriptionLabel.Text = "Log In to Shotr to enable uploads!";
            this.loginToShotrDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loginToShotrDescriptionLabel.Theme = "NewTheme";
            this.loginToShotrDescriptionLabel.UseCompatibleTextRendering = true;
            // 
            // loginToShotrButton
            // 
            this.loginToShotrButton.FontSize = MetroFramework5.Drawing.MetroFontSize.Default;
            this.loginToShotrButton.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Default;
            this.loginToShotrButton.Location = new System.Drawing.Point(16, 66);
            this.loginToShotrButton.Name = "loginToShotrButton";
            this.loginToShotrButton.Scaled = true;
            this.loginToShotrButton.Size = new System.Drawing.Size(251, 23);
            this.loginToShotrButton.Style = "NewTheme";
            this.loginToShotrButton.TabIndex = 32;
            this.loginToShotrButton.Text = "Login";
            this.loginToShotrButton.Theme = "NewTheme";
            this.loginToShotrButton.Click += new System.EventHandler(this.loginToShotrButton_Click);
            // 
            // loginToShotrLabel
            // 
            this.loginToShotrLabel.FontSize = MetroFramework5.Drawing.MetroFontSize.Medium;
            this.loginToShotrLabel.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Light;
            this.loginToShotrLabel.Location = new System.Drawing.Point(3, 3);
            this.loginToShotrLabel.Name = "loginToShotrLabel";
            this.loginToShotrLabel.Scaled = true;
            this.loginToShotrLabel.Size = new System.Drawing.Size(277, 19);
            this.loginToShotrLabel.Style = "NewTheme";
            this.loginToShotrLabel.TabIndex = 10;
            this.loginToShotrLabel.Text = "My Account";
            this.loginToShotrLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loginToShotrLabel.Theme = "NewTheme";
            this.loginToShotrLabel.UseCompatibleTextRendering = true;
            // 
            // myAccountPanel
            // 
            this.myAccountPanel.BorderStyle = MetroFramework5.Drawing.MetroBorderStyle.FixedSingle;
            this.myAccountPanel.Controls.Add(this.viewAccountButton);
            this.myAccountPanel.Controls.Add(this.logoutButton);
            this.myAccountPanel.Controls.Add(this.uploadCountLabel);
            this.myAccountPanel.Controls.Add(this.totalImagesUploadedLabel);
            this.myAccountPanel.Controls.Add(this.emailLabel);
            this.myAccountPanel.HorizontalScrollbarBarColor = true;
            this.myAccountPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.myAccountPanel.HorizontalScrollbarSize = 10;
            this.myAccountPanel.Location = new System.Drawing.Point(304, 139);
            this.myAccountPanel.Name = "myAccountPanel";
            this.myAccountPanel.Size = new System.Drawing.Size(283, 122);
            this.myAccountPanel.Style = "NewTheme";
            this.myAccountPanel.TabIndex = 32;
            this.myAccountPanel.Theme = "NewTheme";
            this.myAccountPanel.VerticalScrollbarBarColor = true;
            this.myAccountPanel.VerticalScrollbarHighlightOnWheel = false;
            this.myAccountPanel.VerticalScrollbarSize = 10;
            // 
            // viewAccountButton
            // 
            this.viewAccountButton.FontSize = MetroFramework5.Drawing.MetroFontSize.Default;
            this.viewAccountButton.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Default;
            this.viewAccountButton.Location = new System.Drawing.Point(15, 55);
            this.viewAccountButton.Name = "viewAccountButton";
            this.viewAccountButton.Scaled = true;
            this.viewAccountButton.Size = new System.Drawing.Size(251, 23);
            this.viewAccountButton.Style = "NewTheme";
            this.viewAccountButton.TabIndex = 32;
            this.viewAccountButton.Text = "View Account";
            this.viewAccountButton.Theme = "NewTheme";
            // 
            // logoutButton
            // 
            this.logoutButton.FontSize = MetroFramework5.Drawing.MetroFontSize.Default;
            this.logoutButton.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Default;
            this.logoutButton.Location = new System.Drawing.Point(15, 85);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Scaled = true;
            this.logoutButton.Size = new System.Drawing.Size(251, 23);
            this.logoutButton.Style = "NewTheme";
            this.logoutButton.TabIndex = 31;
            this.logoutButton.Text = "Log Out";
            this.logoutButton.Theme = "NewTheme";
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // uploadCountLabel
            // 
            this.uploadCountLabel.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.uploadCountLabel.Location = new System.Drawing.Point(177, 28);
            this.uploadCountLabel.Name = "uploadCountLabel";
            this.uploadCountLabel.Scaled = true;
            this.uploadCountLabel.Size = new System.Drawing.Size(93, 15);
            this.uploadCountLabel.Style = "NewTheme";
            this.uploadCountLabel.TabIndex = 12;
            this.uploadCountLabel.Text = "0";
            this.uploadCountLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.uploadCountLabel.Theme = "NewTheme";
            this.uploadCountLabel.UseCompatibleTextRendering = true;
            // 
            // totalImagesUploadedLabel
            // 
            this.totalImagesUploadedLabel.AutoSize = true;
            this.totalImagesUploadedLabel.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.totalImagesUploadedLabel.Location = new System.Drawing.Point(13, 28);
            this.totalImagesUploadedLabel.Name = "totalImagesUploadedLabel";
            this.totalImagesUploadedLabel.Scaled = true;
            this.totalImagesUploadedLabel.Size = new System.Drawing.Size(93, 22);
            this.totalImagesUploadedLabel.Style = "NewTheme";
            this.totalImagesUploadedLabel.TabIndex = 11;
            this.totalImagesUploadedLabel.Text = "Total Uploads:";
            this.totalImagesUploadedLabel.Theme = "NewTheme";
            this.totalImagesUploadedLabel.UseCompatibleTextRendering = true;
            // 
            // emailLabel
            // 
            this.emailLabel.FontSize = MetroFramework5.Drawing.MetroFontSize.Medium;
            this.emailLabel.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Light;
            this.emailLabel.Location = new System.Drawing.Point(3, 3);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Scaled = true;
            this.emailLabel.Size = new System.Drawing.Size(277, 19);
            this.emailLabel.Style = "NewTheme";
            this.emailLabel.TabIndex = 10;
            this.emailLabel.Text = "<email>";
            this.emailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.emailLabel.Theme = "NewTheme";
            this.emailLabel.UseCompatibleTextRendering = true;
            // 
            // contextMenuStrip2
            // 
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
            this.contextMenuStrip2.Size = new System.Drawing.Size(148, 126);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(144, 6);
            // 
            // copyURLToolStripMenuItem
            // 
            this.copyURLToolStripMenuItem.Name = "copyURLToolStripMenuItem";
            this.copyURLToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.copyURLToolStripMenuItem.Text = "Copy URL";
            this.copyURLToolStripMenuItem.Click += new System.EventHandler(this.copyURLToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(144, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(147, 22);
            this.toolStripMenuItem2.Text = "Remove Entry";
            // 
            // clearHistoryToolStripMenuItem
            // 
            this.clearHistoryToolStripMenuItem.Name = "clearHistoryToolStripMenuItem";
            this.clearHistoryToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.clearHistoryToolStripMenuItem.Text = "Clear History";
            this.clearHistoryToolStripMenuItem.Click += new System.EventHandler(this.clearHistoryToolStripMenuItem_Click);
            // 
            // metroLabel8
            // 
            this.metroLabel8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLabel8.Location = new System.Drawing.Point(321, 349);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Scaled = true;
            this.metroLabel8.Size = new System.Drawing.Size(289, 19);
            this.metroLabel8.Style = "NewTheme";
            this.metroLabel8.TabIndex = 2;
            this.metroLabel8.Text = "v{0}";
            this.metroLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel8.Theme = "NewTheme";
            this.metroLabel8.UseCompatibleTextRendering = true;
            this.metroLabel8.Click += new System.EventHandler(this.aboutLabel_Click);
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
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
            this.ClientSize = new System.Drawing.Size(621, 373);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroTabControl1);
            this.DisplayHeader = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(20, 31, 20, 21);
            this.Resizable = false;
            this.ShowCustomWindowButtons = false;
            this.ShowFormTitle = false;
            this.ShowFormTopBorder = false;
            this.ShowInTaskbar = false;
            this.Style = "NewTheme";
            this.Text = "Shotr";
            this.Theme = "NewTheme";
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
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleExtender1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private DpiScaledTextbox metroTextBox1;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem clearHistoryToolStripMenuItem;
        private ToolStripMenuItem historyToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem copyURLToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private MetroStyleExtender metroStyleExtender1;
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
        private DpiScaledTabControl metroTabControl1;
        private DpiScaledTabPage metroTabPage2;
        private DpiScaledLabel activeWindowLabel;
        private DpiScaledLabel fullscreenLabel;
        private DpiScaledLabel regionLabel;
        private DpiScaledLabel metroLabel1;
        private DpiScaledLabel metroLabel5;
        private DpiScaledLabel metroLabel8;
        private DpiScaledTabPage metroTabPage4;
        private DpiScaledLabel metroLabel9;
        private DpiScaledCombobox selectedImageUploader;
        private DpiScaledToggle directUrlToggle;
        private DpiScaledLabel metroLabel11;
        private DpiScaledListbox betterListView1;
        private DpiScaledButton metroButton2;
        private DpiScaledPanel metroPanel2;
        private DpiScaledPanel metroPanel1;
        private DpiScaledHotkeyButton activeWindowHotKeyButton;
        private DpiScaledHotkeyButton fullScreenHotKeyButton;
        private DpiScaledHotkeyButton regionHotKeyButton;
        private DpiScaledButton metroButton1;
        private DpiScaledHotkeyButton recordScreenHotKeyButton;
        private DpiScaledLabel recordScreenLabel;
        private DpiScaledHotkeyButton uploadClipboardHotKeyButton;
        private DpiScaledLabel clipboardLabel;
        private DpiScaledButton metroButton5;
        private DpiScaledPanel myAccountPanel;
        private DpiScaledLabel uploadCountLabel;
        private DpiScaledLabel totalImagesUploadedLabel;
        private DpiScaledLabel emailLabel;
        private DpiScaledButton logoutButton;
        private DpiScaledButton viewAccountButton;
        private DpiScaledHotkeyButton noUploadHotKeyButton;
        private DpiScaledLabel saveOnlyLabel;
        private DpiScaledPanel loginToShotrPanel;
        private DpiScaledButton loginToShotrButton;
        private DpiScaledLabel loginToShotrLabel;
        private DpiScaledLabel loginToShotrDescriptionLabel;
        private DpiScaledPictureBox logoPictureBox;
    }
}


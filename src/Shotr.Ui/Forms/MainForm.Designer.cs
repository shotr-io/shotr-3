using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework5.Components;
using Shotr.Core.DpiScaling;

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
            this.metroTextBox1 = new Shotr.Core.DpiScaling.DpiScaledTextbox();
            this.metroTabControl1 = new Shotr.Core.DpiScaling.DpiScaledTabControl();
            this.metroTabPage4 = new Shotr.Core.DpiScaling.DpiScaledTabPage();
            this.betterListView1 = new Shotr.Core.DpiScaling.DpiScaledListbox();
            this.betterListViewColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.betterListViewColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.metroTabPage2 = new Shotr.Core.DpiScaling.DpiScaledTabPage();
            this.metroPanel2 = new Shotr.Core.DpiScaling.DpiScaledPanel();
            this.hotkeyButton6 = new Shotr.Core.DpiScaling.DpiScaledHotkeyButton();
            this.metroLabel7 = new Shotr.Core.DpiScaling.DpiScaledLabel();
            this.hotkeyButton5 = new Shotr.Core.DpiScaling.DpiScaledHotkeyButton();
            this.metroLabel15 = new Shotr.Core.DpiScaling.DpiScaledLabel();
            this.hotkeyButton4 = new Shotr.Core.DpiScaling.DpiScaledHotkeyButton();
            this.metroLabel14 = new Shotr.Core.DpiScaling.DpiScaledLabel();
            this.hotkeyButton3 = new Shotr.Core.DpiScaling.DpiScaledHotkeyButton();
            this.hotkeyButton2 = new Shotr.Core.DpiScaling.DpiScaledHotkeyButton();
            this.hotkeyButton1 = new Shotr.Core.DpiScaling.DpiScaledHotkeyButton();
            this.metroLabel1 = new Shotr.Core.DpiScaling.DpiScaledLabel();
            this.metroToggle3 = new Shotr.Core.DpiScaling.DpiScaledToggle();
            this.metroLabel11 = new Shotr.Core.DpiScaling.DpiScaledLabel();
            this.metroLabel9 = new Shotr.Core.DpiScaling.DpiScaledLabel();
            this.metroLabel2 = new Shotr.Core.DpiScaling.DpiScaledLabel();
            this.metroComboBox1 = new Shotr.Core.DpiScaling.DpiScaledCombobox();
            this.metroLabel3 = new Shotr.Core.DpiScaling.DpiScaledLabel();
            this.metroLabel4 = new Shotr.Core.DpiScaling.DpiScaledLabel();
            this.metroPanel1 = new Shotr.Core.DpiScaling.DpiScaledPanel();
            this.metroButton5 = new Shotr.Core.DpiScaling.DpiScaledButton();
            this.metroButton1 = new Shotr.Core.DpiScaling.DpiScaledButton();
            this.metroLabel5 = new Shotr.Core.DpiScaling.DpiScaledLabel();
            this.metroButton2 = new Shotr.Core.DpiScaling.DpiScaledButton();
            this.metroPanel4 = new Shotr.Core.DpiScaling.DpiScaledPanel();
            this.metroButton6 = new Shotr.Core.DpiScaling.DpiScaledButton();
            this.metroButton4 = new Shotr.Core.DpiScaling.DpiScaledButton();
            this.uploadCountLabel = new Shotr.Core.DpiScaling.DpiScaledLabel();
            this.metroLabel10 = new Shotr.Core.DpiScaling.DpiScaledLabel();
            this.emailLabel = new Shotr.Core.DpiScaling.DpiScaledLabel();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.copyURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroLabel8 = new Shotr.Core.DpiScaling.DpiScaledLabel();
            this.metroStyleExtender1 = new MetroFramework5.Components.MetroStyleExtender(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage4.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.metroPanel4.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleExtender1)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Text = "notifyIcon1";
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
            this.regionCaptureToolStripMenuItem.Name = "regionCaptureToolStripMenuItem";
            this.regionCaptureToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.regionCaptureToolStripMenuItem.Text = "Region Capture";
            this.regionCaptureToolStripMenuItem.Click += new System.EventHandler(this.regionCaptureToolStripMenuItem_Click);
            // 
            // fullscreenCaptureToolStripMenuItem
            // 
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
            this.historyToolStripMenuItem.Click += new System.EventHandler(this.historyToolStripMenuItem_Click);
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
            this.metroTabControl1.Location = new System.Drawing.Point(13, 57);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(595, 311);
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
            this.metroTabPage4.Size = new System.Drawing.Size(587, 282);
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
            this.betterListView1.Size = new System.Drawing.Size(575, 253);
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
            this.metroTabPage2.Controls.Add(this.metroPanel4);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 25);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(192, 71);
            this.metroTabPage2.Style = "NewTheme";
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Settings";
            this.metroTabPage2.Theme = "NewTheme";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            // 
            // metroPanel2
            // 
            this.metroPanel2.BorderStyle = MetroFramework5.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel2.Controls.Add(this.hotkeyButton6);
            this.metroPanel2.Controls.Add(this.metroLabel7);
            this.metroPanel2.Controls.Add(this.hotkeyButton5);
            this.metroPanel2.Controls.Add(this.metroLabel15);
            this.metroPanel2.Controls.Add(this.hotkeyButton4);
            this.metroPanel2.Controls.Add(this.metroLabel14);
            this.metroPanel2.Controls.Add(this.hotkeyButton3);
            this.metroPanel2.Controls.Add(this.hotkeyButton2);
            this.metroPanel2.Controls.Add(this.hotkeyButton1);
            this.metroPanel2.Controls.Add(this.metroLabel1);
            this.metroPanel2.Controls.Add(this.metroToggle3);
            this.metroPanel2.Controls.Add(this.metroLabel11);
            this.metroPanel2.Controls.Add(this.metroLabel9);
            this.metroPanel2.Controls.Add(this.metroLabel2);
            this.metroPanel2.Controls.Add(this.metroComboBox1);
            this.metroPanel2.Controls.Add(this.metroLabel3);
            this.metroPanel2.Controls.Add(this.metroLabel4);
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
            // hotkeyButton6
            // 
            this.hotkeyButton6.HotKey = null;
            this.hotkeyButton6.Location = new System.Drawing.Point(121, 55);
            this.hotkeyButton6.Name = "hotkeyButton6";
            this.hotkeyButton6.Size = new System.Drawing.Size(142, 21);
            this.hotkeyButton6.Style = "Hotkey";
            this.hotkeyButton6.TabIndex = 32;
            this.hotkeyButton6.Text = "None";
            this.hotkeyButton6.Theme = "NewTheme";
            this.hotkeyButton6.OnHotKeyChanged += new System.EventHandler(this.hotkeyButton6_OnHotKeyChanged);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel7.Location = new System.Drawing.Point(16, 57);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Scaled = true;
            this.metroLabel7.Size = new System.Drawing.Size(71, 22);
            this.metroLabel7.Style = "NewTheme";
            this.metroLabel7.TabIndex = 31;
            this.metroLabel7.Text = "Save Only:";
            this.metroLabel7.Theme = "NewTheme";
            this.metroLabel7.UseCompatibleTextRendering = true;
            // 
            // hotkeyButton5
            // 
            this.hotkeyButton5.HotKey = null;
            this.hotkeyButton5.Location = new System.Drawing.Point(121, 162);
            this.hotkeyButton5.Name = "hotkeyButton5";
            this.hotkeyButton5.Size = new System.Drawing.Size(142, 21);
            this.hotkeyButton5.Style = "Hotkey";
            this.hotkeyButton5.TabIndex = 30;
            this.hotkeyButton5.Text = "None";
            this.hotkeyButton5.Theme = "NewTheme";
            this.hotkeyButton5.OnHotKeyChanged += new System.EventHandler(this.hotkeyButton5_OnHotKeyChanged);
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel15.Location = new System.Drawing.Point(16, 166);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Scaled = true;
            this.metroLabel15.Size = new System.Drawing.Size(71, 22);
            this.metroLabel15.Style = "NewTheme";
            this.metroLabel15.TabIndex = 29;
            this.metroLabel15.Text = "Clipboard:";
            this.metroLabel15.Theme = "NewTheme";
            this.metroLabel15.UseCompatibleTextRendering = true;
            // 
            // hotkeyButton4
            // 
            this.hotkeyButton4.HotKey = null;
            this.hotkeyButton4.Location = new System.Drawing.Point(121, 136);
            this.hotkeyButton4.Name = "hotkeyButton4";
            this.hotkeyButton4.Size = new System.Drawing.Size(142, 21);
            this.hotkeyButton4.Style = "Hotkey";
            this.hotkeyButton4.TabIndex = 28;
            this.hotkeyButton4.Text = "None";
            this.hotkeyButton4.Theme = "NewTheme";
            this.hotkeyButton4.OnHotKeyChanged += new System.EventHandler(this.hotkeyButton4_OnHotKeyChanged);
            // 
            // metroLabel14
            // 
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel14.Location = new System.Drawing.Point(16, 139);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Scaled = true;
            this.metroLabel14.Size = new System.Drawing.Size(96, 22);
            this.metroLabel14.Style = "NewTheme";
            this.metroLabel14.TabIndex = 27;
            this.metroLabel14.Text = "Record Screen:";
            this.metroLabel14.Theme = "NewTheme";
            this.metroLabel14.UseCompatibleTextRendering = true;
            // 
            // hotkeyButton3
            // 
            this.hotkeyButton3.HotKey = null;
            this.hotkeyButton3.Location = new System.Drawing.Point(121, 109);
            this.hotkeyButton3.Name = "hotkeyButton3";
            this.hotkeyButton3.Size = new System.Drawing.Size(142, 21);
            this.hotkeyButton3.Style = "Hotkey";
            this.hotkeyButton3.TabIndex = 26;
            this.hotkeyButton3.Text = "None";
            this.hotkeyButton3.Theme = "NewTheme";
            this.hotkeyButton3.OnHotKeyChanged += new System.EventHandler(this.hotkeyButton3_OnHotKeyChanged);
            // 
            // hotkeyButton2
            // 
            this.hotkeyButton2.HotKey = null;
            this.hotkeyButton2.Location = new System.Drawing.Point(121, 82);
            this.hotkeyButton2.Name = "hotkeyButton2";
            this.hotkeyButton2.Size = new System.Drawing.Size(142, 21);
            this.hotkeyButton2.Style = "Hotkey";
            this.hotkeyButton2.TabIndex = 25;
            this.hotkeyButton2.Text = "None";
            this.hotkeyButton2.Theme = "NewTheme";
            this.hotkeyButton2.OnHotKeyChanged += new System.EventHandler(this.hotkeyButton2_OnHotKeyChanged);
            // 
            // hotkeyButton1
            // 
            this.hotkeyButton1.HotKey = null;
            this.hotkeyButton1.Location = new System.Drawing.Point(121, 27);
            this.hotkeyButton1.Name = "hotkeyButton1";
            this.hotkeyButton1.Size = new System.Drawing.Size(142, 21);
            this.hotkeyButton1.Style = "Hotkey";
            this.hotkeyButton1.TabIndex = 24;
            this.hotkeyButton1.Text = "None";
            this.hotkeyButton1.Theme = "NewTheme";
            this.hotkeyButton1.OnHotKeyChanged += new System.EventHandler(this.hotkeyButton1_OnHotKeyChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.FontSize = MetroFramework5.Drawing.MetroFontSize.Medium;
            this.metroLabel1.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Light;
            this.metroLabel1.Location = new System.Drawing.Point(3, 3);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Scaled = true;
            this.metroLabel1.Size = new System.Drawing.Size(276, 21);
            this.metroLabel1.Style = "NewTheme";
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text = "Hotkey Settings";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel1.Theme = "NewTheme";
            this.metroLabel1.UseCompatibleTextRendering = true;
            // 
            // metroToggle3
            // 
            this.metroToggle3.AutoSize = true;
            this.metroToggle3.Location = new System.Drawing.Point(183, 250);
            this.metroToggle3.Name = "metroToggle3";
            this.metroToggle3.Size = new System.Drawing.Size(80, 19);
            this.metroToggle3.Style = "NewTheme";
            this.metroToggle3.TabIndex = 18;
            this.metroToggle3.Text = "Off";
            this.metroToggle3.Theme = "NewTheme";
            this.metroToggle3.UseVisualStyleBackColor = false;
            this.metroToggle3.Visible = false;
            this.metroToggle3.CheckedChanged += new System.EventHandler(this.metroToggle3_CheckedChanged);
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel11.Location = new System.Drawing.Point(14, 249);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Scaled = true;
            this.metroLabel11.Size = new System.Drawing.Size(116, 22);
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
            this.metroLabel9.Location = new System.Drawing.Point(3, 188);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Scaled = true;
            this.metroLabel9.Size = new System.Drawing.Size(276, 22);
            this.metroLabel9.Style = "NewTheme";
            this.metroLabel9.TabIndex = 16;
            this.metroLabel9.Text = "Image Uploader";
            this.metroLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel9.Theme = "NewTheme";
            this.metroLabel9.UseCompatibleTextRendering = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel2.Location = new System.Drawing.Point(16, 29);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Scaled = true;
            this.metroLabel2.Size = new System.Drawing.Size(53, 22);
            this.metroLabel2.Style = "NewTheme";
            this.metroLabel2.TabIndex = 7;
            this.metroLabel2.Text = "Region:";
            this.metroLabel2.Theme = "NewTheme";
            this.metroLabel2.UseCompatibleTextRendering = true;
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 29;
            this.metroComboBox1.Location = new System.Drawing.Point(18, 211);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(245, 35);
            this.metroComboBox1.Style = "NewTheme";
            this.metroComboBox1.TabIndex = 15;
            this.metroComboBox1.Theme = "NewTheme";
            this.metroComboBox1.SelectedIndexChanged += new System.EventHandler(this.metroComboBox1_SelectedIndexChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel3.Location = new System.Drawing.Point(16, 84);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Scaled = true;
            this.metroLabel3.Size = new System.Drawing.Size(70, 22);
            this.metroLabel3.Style = "NewTheme";
            this.metroLabel3.TabIndex = 8;
            this.metroLabel3.Text = "Fullscreen:";
            this.metroLabel3.Theme = "NewTheme";
            this.metroLabel3.UseCompatibleTextRendering = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel4.Location = new System.Drawing.Point(16, 111);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Scaled = true;
            this.metroLabel4.Size = new System.Drawing.Size(99, 22);
            this.metroLabel4.Style = "NewTheme";
            this.metroLabel4.TabIndex = 9;
            this.metroLabel4.Text = "Active Window:";
            this.metroLabel4.Theme = "NewTheme";
            this.metroLabel4.UseCompatibleTextRendering = true;
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
            this.metroPanel1.Location = new System.Drawing.Point(298, 7);
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
            this.metroButton5.Location = new System.Drawing.Point(16, 28);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Scaled = true;
            this.metroButton5.Size = new System.Drawing.Size(251, 23);
            this.metroButton5.Style = "NewTheme";
            this.metroButton5.TabIndex = 30;
            this.metroButton5.Text = "Global Settings";
            this.metroButton5.Theme = "NewTheme";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.FontSize = MetroFramework5.Drawing.MetroFontSize.Default;
            this.metroButton1.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Default;
            this.metroButton1.Location = new System.Drawing.Point(16, 86);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Scaled = true;
            this.metroButton1.Size = new System.Drawing.Size(251, 23);
            this.metroButton1.Style = "NewTheme";
            this.metroButton1.TabIndex = 27;
            this.metroButton1.Text = "Reset To Default Settings";
            this.metroButton1.Theme = "NewTheme";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click_1);
            // 
            // metroLabel5
            // 
            this.metroLabel5.FontSize = MetroFramework5.Drawing.MetroFontSize.Medium;
            this.metroLabel5.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Light;
            this.metroLabel5.Location = new System.Drawing.Point(3, 3);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Scaled = true;
            this.metroLabel5.Size = new System.Drawing.Size(277, 22);
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
            this.metroButton2.Location = new System.Drawing.Point(16, 57);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Scaled = true;
            this.metroButton2.Size = new System.Drawing.Size(251, 23);
            this.metroButton2.Style = "NewTheme";
            this.metroButton2.TabIndex = 23;
            this.metroButton2.Text = "Custom Uploaders";
            this.metroButton2.Theme = "NewTheme";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroPanel4
            // 
            this.metroPanel4.BorderStyle = MetroFramework5.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel4.Controls.Add(this.metroButton6);
            this.metroPanel4.Controls.Add(this.metroButton4);
            this.metroPanel4.Controls.Add(this.uploadCountLabel);
            this.metroPanel4.Controls.Add(this.metroLabel10);
            this.metroPanel4.Controls.Add(this.emailLabel);
            this.metroPanel4.HorizontalScrollbarBarColor = true;
            this.metroPanel4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel4.HorizontalScrollbarSize = 10;
            this.metroPanel4.Location = new System.Drawing.Point(298, 139);
            this.metroPanel4.Name = "metroPanel4";
            this.metroPanel4.Size = new System.Drawing.Size(283, 122);
            this.metroPanel4.Style = "NewTheme";
            this.metroPanel4.TabIndex = 32;
            this.metroPanel4.Theme = "NewTheme";
            this.metroPanel4.VerticalScrollbarBarColor = true;
            this.metroPanel4.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel4.VerticalScrollbarSize = 10;
            // 
            // metroButton6
            // 
            this.metroButton6.FontSize = MetroFramework5.Drawing.MetroFontSize.Default;
            this.metroButton6.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Default;
            this.metroButton6.Location = new System.Drawing.Point(15, 55);
            this.metroButton6.Name = "metroButton6";
            this.metroButton6.Scaled = true;
            this.metroButton6.Size = new System.Drawing.Size(251, 23);
            this.metroButton6.Style = "NewTheme";
            this.metroButton6.TabIndex = 32;
            this.metroButton6.Text = "View Account";
            this.metroButton6.Theme = "NewTheme";
            // 
            // metroButton4
            // 
            this.metroButton4.FontSize = MetroFramework5.Drawing.MetroFontSize.Default;
            this.metroButton4.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Default;
            this.metroButton4.Location = new System.Drawing.Point(15, 85);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Scaled = true;
            this.metroButton4.Size = new System.Drawing.Size(251, 23);
            this.metroButton4.Style = "NewTheme";
            this.metroButton4.TabIndex = 31;
            this.metroButton4.Text = "Log Out";
            this.metroButton4.Theme = "NewTheme";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
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
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel10.Location = new System.Drawing.Point(13, 28);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Scaled = true;
            this.metroLabel10.Size = new System.Drawing.Size(149, 22);
            this.metroLabel10.Style = "NewTheme";
            this.metroLabel10.TabIndex = 11;
            this.metroLabel10.Text = "Total Images Uploaded:";
            this.metroLabel10.Theme = "NewTheme";
            this.metroLabel10.UseCompatibleTextRendering = true;
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
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip2_Opening);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
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
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
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
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
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
            this.metroLabel8.Location = new System.Drawing.Point(315, 346);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Scaled = true;
            this.metroLabel8.Size = new System.Drawing.Size(289, 22);
            this.metroLabel8.Style = "NewTheme";
            this.metroLabel8.TabIndex = 2;
            this.metroLabel8.Text = "Shotr v{0} - Copyright © 2021 Shotr, Inc.";
            this.metroLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel8.Theme = "NewTheme";
            this.metroLabel8.UseCompatibleTextRendering = true;
            this.metroLabel8.Click += new System.EventHandler(this.metroLabel8_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = MetroFramework5.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(621, 373);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(20, 61, 20, 21);
            this.Resizable = false;
            this.ShadowType = MetroFramework5.Forms.MetroForm.MetroFormShadowType.None;
            this.ShowFormIcon = true;
            this.ShowInTaskbar = false;
            this.Style = "NewTheme";
            this.Text = "Shotr";
            this.Theme = "NewTheme";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage4.ResumeLayout(false);
            this.metroTabPage2.ResumeLayout(false);
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel4.ResumeLayout(false);
            this.metroPanel4.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleExtender1)).EndInit();
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
        private DpiScaledLabel metroLabel4;
        private DpiScaledLabel metroLabel3;
        private DpiScaledLabel metroLabel2;
        private DpiScaledLabel metroLabel1;
        private DpiScaledLabel metroLabel5;
        private DpiScaledLabel metroLabel8;
        private DpiScaledTabPage metroTabPage4;
        private DpiScaledLabel metroLabel9;
        private DpiScaledCombobox metroComboBox1;
        private DpiScaledToggle metroToggle3;
        private DpiScaledLabel metroLabel11;
        private DpiScaledListbox betterListView1;
        private DpiScaledButton metroButton2;
        private DpiScaledPanel metroPanel2;
        private DpiScaledPanel metroPanel1;
        private DpiScaledHotkeyButton hotkeyButton3;
        private DpiScaledHotkeyButton hotkeyButton2;
        private DpiScaledHotkeyButton hotkeyButton1;
        private DpiScaledButton metroButton1;
        private DpiScaledHotkeyButton hotkeyButton4;
        private DpiScaledLabel metroLabel14;
        private DpiScaledHotkeyButton hotkeyButton5;
        private DpiScaledLabel metroLabel15;
        private DpiScaledButton metroButton5;
        private DpiScaledPanel metroPanel4;
        private DpiScaledLabel uploadCountLabel;
        private DpiScaledLabel metroLabel10;
        private DpiScaledLabel emailLabel;
        private DpiScaledButton metroButton4;
        private DpiScaledButton metroButton6;
        private DpiScaledHotkeyButton hotkeyButton6;
        private DpiScaledLabel metroLabel7;
    }
}


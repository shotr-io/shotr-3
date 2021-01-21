using System.ComponentModel;
using Shotr.Core.Controls.DpiScaling;

namespace Shotr.Ui.Forms.Settings
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.metroTabControl1 = new Shotr.Core.Controls.DpiScaling.DpiScaledTabControl();
            this.metroTabPage1 = new Shotr.Core.Controls.DpiScaling.DpiScaledTabPage();
            this.metroPanel2 = new Shotr.Core.Controls.DpiScaling.DpiScaledPanel();
            this.metroLabel13 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.soundToggle = new Shotr.Core.Controls.DpiScaling.DpiScaledToggle();
            this.startupToggle = new Shotr.Core.Controls.DpiScaling.DpiScaledToggle();
            this.metroLabel15 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.metroLabel16 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.minimizedToggle = new Shotr.Core.Controls.DpiScaling.DpiScaledToggle();
            this.metroLabel17 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.alphaToggle = new Shotr.Core.Controls.DpiScaling.DpiScaledToggle();
            this.metroLabel14 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.metroLabel11 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.showNotificationsToggle = new Shotr.Core.Controls.DpiScaling.DpiScaledToggle();
            this.metroPanel1 = new Shotr.Core.Controls.DpiScaling.DpiScaledPanel();
            this.metroTextBox1 = new Shotr.Core.Controls.DpiScaling.DpiScaledTextbox();
            this.metroLabel10 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.saveToDirectoryToggle = new Shotr.Core.Controls.DpiScaling.DpiScaledToggle();
            this.metroLabel9 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.metroTabPage3 = new Shotr.Core.Controls.DpiScaling.DpiScaledTabPage();
            this.metroPanel3 = new Shotr.Core.Controls.DpiScaling.DpiScaledPanel();
            this.metroLabel18 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.useresizablecanvas = new Shotr.Core.Controls.DpiScaling.DpiScaledToggle();
            this.metroLabel19 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.metroLabel12 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.metroLabel6 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.stitchFullscreenToggle = new Shotr.Core.Controls.DpiScaling.DpiScaledToggle();
            this.imageCodecCombo = new Shotr.Core.Controls.DpiScaling.DpiScaledCombobox();
            this.imageCompressionToggle = new Shotr.Core.Controls.DpiScaling.DpiScaledToggle();
            this.metroLabel7 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.metroLabel8 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.imageQualityCombo = new Shotr.Core.Controls.DpiScaling.DpiScaledCombobox();
            this.metroTabPage4 = new Shotr.Core.Controls.DpiScaling.DpiScaledTabPage();
            this.metroPanel4 = new Shotr.Core.Controls.DpiScaling.DpiScaledPanel();
            this.metroLabel5 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.audioDeviceCombo = new Shotr.Core.Controls.DpiScaling.DpiScaledCombobox();
            this.metroLabel4 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.metroLabel20 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.recordAudioToggle = new Shotr.Core.Controls.DpiScaling.DpiScaledToggle();
            this.metroLabel3 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.framerateCombo = new Shotr.Core.Controls.DpiScaling.DpiScaledCombobox();
            this.metroLabel1 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.recordCursorToggle = new Shotr.Core.Controls.DpiScaling.DpiScaledToggle();
            this.encodingCombo = new Shotr.Core.Controls.DpiScaling.DpiScaledCombobox();
            this.metroLabel2 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.dpiScaledPictureBox1 = new Shotr.Core.Controls.DpiScaling.DpiScaledPictureBox();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            this.metroTabPage4.SuspendLayout();
            this.metroPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpiScaledPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Controls.Add(this.metroTabPage4);
            this.metroTabControl1.Location = new System.Drawing.Point(10, 57);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(568, 299);
            this.metroTabControl1.Style = "NewTheme";
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.Theme = "NewTheme";
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.metroPanel2);
            this.metroTabPage1.Controls.Add(this.metroPanel1);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 25);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(560, 270);
            this.metroTabPage1.Style = "NewTheme";
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "General";
            this.metroTabPage1.Theme = "NewTheme";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            // 
            // metroPanel2
            // 
            this.metroPanel2.BorderStyle = MetroFramework5.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel2.Controls.Add(this.metroLabel13);
            this.metroPanel2.Controls.Add(this.soundToggle);
            this.metroPanel2.Controls.Add(this.startupToggle);
            this.metroPanel2.Controls.Add(this.metroLabel15);
            this.metroPanel2.Controls.Add(this.metroLabel16);
            this.metroPanel2.Controls.Add(this.minimizedToggle);
            this.metroPanel2.Controls.Add(this.metroLabel17);
            this.metroPanel2.Controls.Add(this.alphaToggle);
            this.metroPanel2.Controls.Add(this.metroLabel14);
            this.metroPanel2.Controls.Add(this.metroLabel11);
            this.metroPanel2.Controls.Add(this.showNotificationsToggle);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(8, 7);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(544, 162);
            this.metroPanel2.Style = "NewTheme";
            this.metroPanel2.TabIndex = 53;
            this.metroPanel2.Theme = "NewTheme";
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel13.Location = new System.Drawing.Point(17, 129);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Scaled = true;
            this.metroLabel13.Size = new System.Drawing.Size(84, 22);
            this.metroLabel13.Style = "NewTheme";
            this.metroLabel13.TabIndex = 56;
            this.metroLabel13.Text = "Play Sounds:";
            this.metroLabel13.Theme = "NewTheme";
            this.metroLabel13.UseCompatibleTextRendering = true;
            // 
            // soundToggle
            // 
            this.soundToggle.AutoSize = true;
            this.soundToggle.Location = new System.Drawing.Point(447, 128);
            this.soundToggle.Name = "soundToggle";
            this.soundToggle.Size = new System.Drawing.Size(80, 19);
            this.soundToggle.Style = "NewTheme";
            this.soundToggle.TabIndex = 55;
            this.soundToggle.Text = "Off";
            this.soundToggle.Theme = "NewTheme";
            this.soundToggle.UseVisualStyleBackColor = false;
            // 
            // startupToggle
            // 
            this.startupToggle.AutoSize = true;
            this.startupToggle.Location = new System.Drawing.Point(447, 50);
            this.startupToggle.Name = "startupToggle";
            this.startupToggle.Size = new System.Drawing.Size(80, 19);
            this.startupToggle.Style = "NewTheme";
            this.startupToggle.TabIndex = 49;
            this.startupToggle.Text = "Off";
            this.startupToggle.Theme = "NewTheme";
            this.startupToggle.UseVisualStyleBackColor = false;
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel15.Location = new System.Drawing.Point(17, 51);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Scaled = true;
            this.metroLabel15.Size = new System.Drawing.Size(54, 22);
            this.metroLabel15.Style = "NewTheme";
            this.metroLabel15.TabIndex = 50;
            this.metroLabel15.Text = "Startup:";
            this.metroLabel15.Theme = "NewTheme";
            this.metroLabel15.UseCompatibleTextRendering = true;
            // 
            // metroLabel16
            // 
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel16.Location = new System.Drawing.Point(17, 77);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Scaled = true;
            this.metroLabel16.Size = new System.Drawing.Size(101, 22);
            this.metroLabel16.Style = "NewTheme";
            this.metroLabel16.TabIndex = 51;
            this.metroLabel16.Text = "Start Minimized:";
            this.metroLabel16.Theme = "NewTheme";
            this.metroLabel16.UseCompatibleTextRendering = true;
            // 
            // minimizedToggle
            // 
            this.minimizedToggle.AutoSize = true;
            this.minimizedToggle.Location = new System.Drawing.Point(447, 76);
            this.minimizedToggle.Name = "minimizedToggle";
            this.minimizedToggle.Size = new System.Drawing.Size(80, 19);
            this.minimizedToggle.Style = "NewTheme";
            this.minimizedToggle.TabIndex = 52;
            this.minimizedToggle.Text = "Off";
            this.minimizedToggle.Theme = "NewTheme";
            this.minimizedToggle.UseVisualStyleBackColor = false;
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel17.Location = new System.Drawing.Point(17, 103);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Scaled = true;
            this.metroLabel17.Size = new System.Drawing.Size(165, 22);
            this.metroLabel17.Style = "NewTheme";
            this.metroLabel17.TabIndex = 54;
            this.metroLabel17.Text = "Show Alpha/Beta Updates:";
            this.metroLabel17.Theme = "NewTheme";
            this.metroLabel17.UseCompatibleTextRendering = true;
            // 
            // alphaToggle
            // 
            this.alphaToggle.AutoSize = true;
            this.alphaToggle.Location = new System.Drawing.Point(447, 102);
            this.alphaToggle.Name = "alphaToggle";
            this.alphaToggle.Size = new System.Drawing.Size(80, 19);
            this.alphaToggle.Style = "NewTheme";
            this.alphaToggle.TabIndex = 53;
            this.alphaToggle.Text = "Off";
            this.alphaToggle.Theme = "NewTheme";
            this.alphaToggle.UseVisualStyleBackColor = false;
            // 
            // metroLabel14
            // 
            this.metroLabel14.FontSize = MetroFramework5.Drawing.MetroFontSize.Medium;
            this.metroLabel14.Location = new System.Drawing.Point(134, 3);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Scaled = true;
            this.metroLabel14.Size = new System.Drawing.Size(276, 19);
            this.metroLabel14.Style = "NewTheme";
            this.metroLabel14.TabIndex = 7;
            this.metroLabel14.Text = "General Options";
            this.metroLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel14.Theme = "NewTheme";
            this.metroLabel14.UseCompatibleTextRendering = true;
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel11.Location = new System.Drawing.Point(17, 25);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Scaled = true;
            this.metroLabel11.Size = new System.Drawing.Size(120, 22);
            this.metroLabel11.Style = "NewTheme";
            this.metroLabel11.TabIndex = 48;
            this.metroLabel11.Text = "Show Notifications";
            this.metroLabel11.Theme = "NewTheme";
            this.metroLabel11.UseCompatibleTextRendering = true;
            // 
            // showNotificationsToggle
            // 
            this.showNotificationsToggle.AutoSize = true;
            this.showNotificationsToggle.Location = new System.Drawing.Point(447, 24);
            this.showNotificationsToggle.Name = "showNotificationsToggle";
            this.showNotificationsToggle.Size = new System.Drawing.Size(80, 19);
            this.showNotificationsToggle.Style = "NewTheme";
            this.showNotificationsToggle.TabIndex = 47;
            this.showNotificationsToggle.Text = "Off";
            this.showNotificationsToggle.Theme = "NewTheme";
            this.showNotificationsToggle.UseVisualStyleBackColor = false;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = MetroFramework5.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.metroTextBox1);
            this.metroPanel1.Controls.Add(this.metroLabel10);
            this.metroPanel1.Controls.Add(this.saveToDirectoryToggle);
            this.metroPanel1.Controls.Add(this.metroLabel9);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(8, 175);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(544, 85);
            this.metroPanel1.Style = "NewTheme";
            this.metroPanel1.TabIndex = 52;
            this.metroPanel1.Theme = "NewTheme";
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroTextBox1
            // 
            this.metroTextBox1.Location = new System.Drawing.Point(17, 43);
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.ReadOnly = true;
            this.metroTextBox1.Size = new System.Drawing.Size(510, 23);
            this.metroTextBox1.Style = "NewTheme";
            this.metroTextBox1.TabIndex = 54;
            this.metroTextBox1.Theme = "NewTheme";
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel10.Location = new System.Drawing.Point(14, 21);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Scaled = true;
            this.metroLabel10.Size = new System.Drawing.Size(110, 22);
            this.metroLabel10.Style = "NewTheme";
            this.metroLabel10.TabIndex = 53;
            this.metroLabel10.Text = "Save to Directory";
            this.metroLabel10.Theme = "NewTheme";
            this.metroLabel10.UseCompatibleTextRendering = true;
            // 
            // saveToDirectoryToggle
            // 
            this.saveToDirectoryToggle.AutoSize = true;
            this.saveToDirectoryToggle.Location = new System.Drawing.Point(447, 19);
            this.saveToDirectoryToggle.Name = "saveToDirectoryToggle";
            this.saveToDirectoryToggle.Size = new System.Drawing.Size(80, 19);
            this.saveToDirectoryToggle.Style = "NewTheme";
            this.saveToDirectoryToggle.TabIndex = 52;
            this.saveToDirectoryToggle.Text = "Off";
            this.saveToDirectoryToggle.Theme = "NewTheme";
            this.saveToDirectoryToggle.UseVisualStyleBackColor = false;
            // 
            // metroLabel9
            // 
            this.metroLabel9.FontSize = MetroFramework5.Drawing.MetroFontSize.Medium;
            this.metroLabel9.Location = new System.Drawing.Point(134, 3);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Scaled = true;
            this.metroLabel9.Size = new System.Drawing.Size(276, 19);
            this.metroLabel9.Style = "NewTheme";
            this.metroLabel9.TabIndex = 7;
            this.metroLabel9.Text = "Save to Directory";
            this.metroLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel9.Theme = "NewTheme";
            this.metroLabel9.UseCompatibleTextRendering = true;
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.metroPanel3);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 25);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(192, 71);
            this.metroTabPage3.Style = "NewTheme";
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Capture";
            this.metroTabPage3.Theme = "NewTheme";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            // 
            // metroPanel3
            // 
            this.metroPanel3.BorderStyle = MetroFramework5.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel3.Controls.Add(this.metroLabel18);
            this.metroPanel3.Controls.Add(this.useresizablecanvas);
            this.metroPanel3.Controls.Add(this.metroLabel19);
            this.metroPanel3.Controls.Add(this.metroLabel12);
            this.metroPanel3.Controls.Add(this.metroLabel6);
            this.metroPanel3.Controls.Add(this.stitchFullscreenToggle);
            this.metroPanel3.Controls.Add(this.imageCodecCombo);
            this.metroPanel3.Controls.Add(this.imageCompressionToggle);
            this.metroPanel3.Controls.Add(this.metroLabel7);
            this.metroPanel3.Controls.Add(this.metroLabel8);
            this.metroPanel3.Controls.Add(this.imageQualityCombo);
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(8, 7);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(544, 216);
            this.metroPanel3.Style = "NewTheme";
            this.metroPanel3.TabIndex = 53;
            this.metroPanel3.Theme = "NewTheme";
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // metroLabel18
            // 
            this.metroLabel18.AutoSize = true;
            this.metroLabel18.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel18.Location = new System.Drawing.Point(17, 173);
            this.metroLabel18.Name = "metroLabel18";
            this.metroLabel18.Scaled = true;
            this.metroLabel18.Size = new System.Drawing.Size(241, 22);
            this.metroLabel18.Style = "NewTheme";
            this.metroLabel18.TabIndex = 40;
            this.metroLabel18.Text = "Use Resizable Canvas (Enter to Upload):";
            this.metroLabel18.Theme = "NewTheme";
            this.metroLabel18.UseCompatibleTextRendering = true;
            // 
            // useresizablecanvas
            // 
            this.useresizablecanvas.AutoSize = true;
            this.useresizablecanvas.Location = new System.Drawing.Point(447, 174);
            this.useresizablecanvas.Name = "useresizablecanvas";
            this.useresizablecanvas.Size = new System.Drawing.Size(80, 19);
            this.useresizablecanvas.Style = "NewTheme";
            this.useresizablecanvas.TabIndex = 39;
            this.useresizablecanvas.Text = "Off";
            this.useresizablecanvas.Theme = "NewTheme";
            this.useresizablecanvas.UseVisualStyleBackColor = false;
            // 
            // metroLabel19
            // 
            this.metroLabel19.FontSize = MetroFramework5.Drawing.MetroFontSize.Medium;
            this.metroLabel19.Location = new System.Drawing.Point(134, 3);
            this.metroLabel19.Name = "metroLabel19";
            this.metroLabel19.Scaled = true;
            this.metroLabel19.Size = new System.Drawing.Size(276, 19);
            this.metroLabel19.Style = "NewTheme";
            this.metroLabel19.TabIndex = 7;
            this.metroLabel19.Text = "Screenshot Capture Options";
            this.metroLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel19.Theme = "NewTheme";
            this.metroLabel19.UseCompatibleTextRendering = true;
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel12.Location = new System.Drawing.Point(17, 139);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Scaled = true;
            this.metroLabel12.Size = new System.Drawing.Size(162, 22);
            this.metroLabel12.Style = "NewTheme";
            this.metroLabel12.TabIndex = 38;
            this.metroLabel12.Text = "Stitch Fullscreen Captures:";
            this.metroLabel12.Theme = "NewTheme";
            this.metroLabel12.UseCompatibleTextRendering = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel6.Location = new System.Drawing.Point(17, 30);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Scaled = true;
            this.metroLabel6.Size = new System.Drawing.Size(92, 22);
            this.metroLabel6.Style = "NewTheme";
            this.metroLabel6.TabIndex = 36;
            this.metroLabel6.Text = "Image Codec:";
            this.metroLabel6.Theme = "NewTheme";
            this.metroLabel6.UseCompatibleTextRendering = true;
            // 
            // stitchFullscreenToggle
            // 
            this.stitchFullscreenToggle.AutoSize = true;
            this.stitchFullscreenToggle.Location = new System.Drawing.Point(447, 142);
            this.stitchFullscreenToggle.Name = "stitchFullscreenToggle";
            this.stitchFullscreenToggle.Size = new System.Drawing.Size(80, 19);
            this.stitchFullscreenToggle.Style = "NewTheme";
            this.stitchFullscreenToggle.TabIndex = 37;
            this.stitchFullscreenToggle.Text = "Off";
            this.stitchFullscreenToggle.Theme = "NewTheme";
            this.stitchFullscreenToggle.UseVisualStyleBackColor = false;
            // 
            // imageCodecCombo
            // 
            this.imageCodecCombo.FormattingEnabled = true;
            this.imageCodecCombo.ItemHeight = 29;
            this.imageCodecCombo.Items.AddRange(new object[] {
            "png",
            "jpeg"});
            this.imageCodecCombo.Location = new System.Drawing.Point(323, 25);
            this.imageCodecCombo.Name = "imageCodecCombo";
            this.imageCodecCombo.Size = new System.Drawing.Size(204, 35);
            this.imageCodecCombo.Style = "NewTheme";
            this.imageCodecCombo.TabIndex = 31;
            this.imageCodecCombo.Theme = "NewTheme";
            // 
            // imageCompressionToggle
            // 
            this.imageCompressionToggle.AutoSize = true;
            this.imageCompressionToggle.Location = new System.Drawing.Point(447, 110);
            this.imageCompressionToggle.Name = "imageCompressionToggle";
            this.imageCompressionToggle.Size = new System.Drawing.Size(80, 19);
            this.imageCompressionToggle.Style = "NewTheme";
            this.imageCompressionToggle.TabIndex = 32;
            this.imageCompressionToggle.Text = "Off";
            this.imageCompressionToggle.Theme = "NewTheme";
            this.imageCompressionToggle.UseVisualStyleBackColor = false;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel7.Location = new System.Drawing.Point(17, 69);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Scaled = true;
            this.metroLabel7.Size = new System.Drawing.Size(94, 22);
            this.metroLabel7.Style = "NewTheme";
            this.metroLabel7.TabIndex = 35;
            this.metroLabel7.Text = "Image Quality:";
            this.metroLabel7.Theme = "NewTheme";
            this.metroLabel7.UseCompatibleTextRendering = true;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel8.Location = new System.Drawing.Point(17, 107);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Scaled = true;
            this.metroLabel8.Size = new System.Drawing.Size(132, 22);
            this.metroLabel8.Style = "NewTheme";
            this.metroLabel8.TabIndex = 33;
            this.metroLabel8.Text = "Image Compression:";
            this.metroLabel8.Theme = "NewTheme";
            this.metroLabel8.UseCompatibleTextRendering = true;
            // 
            // imageQualityCombo
            // 
            this.imageQualityCombo.FormattingEnabled = true;
            this.imageQualityCombo.ItemHeight = 29;
            this.imageQualityCombo.Items.AddRange(new object[] {
            "Maximum",
            "Ultra",
            "High",
            "Medium",
            "Low"});
            this.imageQualityCombo.Location = new System.Drawing.Point(323, 64);
            this.imageQualityCombo.Name = "imageQualityCombo";
            this.imageQualityCombo.Size = new System.Drawing.Size(204, 35);
            this.imageQualityCombo.Style = "NewTheme";
            this.imageQualityCombo.TabIndex = 34;
            this.imageQualityCombo.Theme = "NewTheme";
            // 
            // metroTabPage4
            // 
            this.metroTabPage4.Controls.Add(this.metroPanel4);
            this.metroTabPage4.HorizontalScrollbarBarColor = true;
            this.metroTabPage4.Location = new System.Drawing.Point(4, 25);
            this.metroTabPage4.Name = "metroTabPage4";
            this.metroTabPage4.Size = new System.Drawing.Size(192, 71);
            this.metroTabPage4.Style = "NewTheme";
            this.metroTabPage4.TabIndex = 3;
            this.metroTabPage4.Text = "Recorder";
            this.metroTabPage4.Theme = "NewTheme";
            this.metroTabPage4.VerticalScrollbarBarColor = true;
            // 
            // metroPanel4
            // 
            this.metroPanel4.BorderStyle = MetroFramework5.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel4.Controls.Add(this.metroLabel5);
            this.metroPanel4.Controls.Add(this.audioDeviceCombo);
            this.metroPanel4.Controls.Add(this.metroLabel4);
            this.metroPanel4.Controls.Add(this.metroLabel20);
            this.metroPanel4.Controls.Add(this.recordAudioToggle);
            this.metroPanel4.Controls.Add(this.metroLabel3);
            this.metroPanel4.Controls.Add(this.framerateCombo);
            this.metroPanel4.Controls.Add(this.metroLabel1);
            this.metroPanel4.Controls.Add(this.recordCursorToggle);
            this.metroPanel4.Controls.Add(this.encodingCombo);
            this.metroPanel4.Controls.Add(this.metroLabel2);
            this.metroPanel4.HorizontalScrollbarBarColor = true;
            this.metroPanel4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel4.HorizontalScrollbarSize = 10;
            this.metroPanel4.Location = new System.Drawing.Point(8, 7);
            this.metroPanel4.Name = "metroPanel4";
            this.metroPanel4.Size = new System.Drawing.Size(544, 216);
            this.metroPanel4.Style = "NewTheme";
            this.metroPanel4.TabIndex = 53;
            this.metroPanel4.Theme = "NewTheme";
            this.metroPanel4.VerticalScrollbarBarColor = true;
            this.metroPanel4.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel4.VerticalScrollbarSize = 10;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel5.Location = new System.Drawing.Point(17, 173);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Scaled = true;
            this.metroLabel5.Size = new System.Drawing.Size(89, 22);
            this.metroLabel5.Style = "NewTheme";
            this.metroLabel5.TabIndex = 48;
            this.metroLabel5.Text = "Audio Device:";
            this.metroLabel5.Theme = "NewTheme";
            this.metroLabel5.UseCompatibleTextRendering = true;
            // 
            // audioDeviceCombo
            // 
            this.audioDeviceCombo.FormattingEnabled = true;
            this.audioDeviceCombo.ItemHeight = 29;
            this.audioDeviceCombo.Location = new System.Drawing.Point(322, 168);
            this.audioDeviceCombo.Name = "audioDeviceCombo";
            this.audioDeviceCombo.Size = new System.Drawing.Size(205, 35);
            this.audioDeviceCombo.Style = "NewTheme";
            this.audioDeviceCombo.TabIndex = 47;
            this.audioDeviceCombo.Theme = "NewTheme";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel4.Location = new System.Drawing.Point(17, 139);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Scaled = true;
            this.metroLabel4.Size = new System.Drawing.Size(90, 22);
            this.metroLabel4.Style = "NewTheme";
            this.metroLabel4.TabIndex = 46;
            this.metroLabel4.Text = "Record Audio:";
            this.metroLabel4.Theme = "NewTheme";
            this.metroLabel4.UseCompatibleTextRendering = true;
            // 
            // metroLabel20
            // 
            this.metroLabel20.FontSize = MetroFramework5.Drawing.MetroFontSize.Medium;
            this.metroLabel20.Location = new System.Drawing.Point(134, 3);
            this.metroLabel20.Name = "metroLabel20";
            this.metroLabel20.Scaled = true;
            this.metroLabel20.Size = new System.Drawing.Size(276, 19);
            this.metroLabel20.Style = "NewTheme";
            this.metroLabel20.TabIndex = 7;
            this.metroLabel20.Text = "Save to Directory";
            this.metroLabel20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel20.Theme = "NewTheme";
            this.metroLabel20.UseCompatibleTextRendering = true;
            // 
            // recordAudioToggle
            // 
            this.recordAudioToggle.AutoSize = true;
            this.recordAudioToggle.Location = new System.Drawing.Point(447, 142);
            this.recordAudioToggle.Name = "recordAudioToggle";
            this.recordAudioToggle.Size = new System.Drawing.Size(80, 19);
            this.recordAudioToggle.Style = "NewTheme";
            this.recordAudioToggle.TabIndex = 45;
            this.recordAudioToggle.Text = "Off";
            this.recordAudioToggle.Theme = "NewTheme";
            this.recordAudioToggle.UseVisualStyleBackColor = false;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel3.Location = new System.Drawing.Point(17, 30);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Scaled = true;
            this.metroLabel3.Size = new System.Drawing.Size(72, 22);
            this.metroLabel3.Style = "NewTheme";
            this.metroLabel3.TabIndex = 44;
            this.metroLabel3.Text = "Framerate:";
            this.metroLabel3.Theme = "NewTheme";
            this.metroLabel3.UseCompatibleTextRendering = true;
            // 
            // framerateCombo
            // 
            this.framerateCombo.FormattingEnabled = true;
            this.framerateCombo.ItemHeight = 29;
            this.framerateCombo.Items.AddRange(new object[] {
            "60",
            "50",
            "40",
            "30",
            "20",
            "15",
            "10"});
            this.framerateCombo.Location = new System.Drawing.Point(323, 25);
            this.framerateCombo.Name = "framerateCombo";
            this.framerateCombo.Size = new System.Drawing.Size(204, 35);
            this.framerateCombo.Style = "NewTheme";
            this.framerateCombo.TabIndex = 39;
            this.framerateCombo.Theme = "NewTheme";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel1.Location = new System.Drawing.Point(17, 69);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Scaled = true;
            this.metroLabel1.Size = new System.Drawing.Size(118, 22);
            this.metroLabel1.Style = "NewTheme";
            this.metroLabel1.TabIndex = 43;
            this.metroLabel1.Text = "Encoding Threads:";
            this.metroLabel1.Theme = "NewTheme";
            this.metroLabel1.UseCompatibleTextRendering = true;
            // 
            // recordCursorToggle
            // 
            this.recordCursorToggle.AutoSize = true;
            this.recordCursorToggle.Location = new System.Drawing.Point(447, 110);
            this.recordCursorToggle.Name = "recordCursorToggle";
            this.recordCursorToggle.Size = new System.Drawing.Size(80, 19);
            this.recordCursorToggle.Style = "NewTheme";
            this.recordCursorToggle.TabIndex = 40;
            this.recordCursorToggle.Text = "Off";
            this.recordCursorToggle.Theme = "NewTheme";
            this.recordCursorToggle.UseVisualStyleBackColor = false;
            // 
            // encodingCombo
            // 
            this.encodingCombo.FormattingEnabled = true;
            this.encodingCombo.ItemHeight = 29;
            this.encodingCombo.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5",
            "4",
            "3",
            "2",
            "1"});
            this.encodingCombo.Location = new System.Drawing.Point(323, 64);
            this.encodingCombo.Name = "encodingCombo";
            this.encodingCombo.Size = new System.Drawing.Size(204, 35);
            this.encodingCombo.Style = "NewTheme";
            this.encodingCombo.TabIndex = 42;
            this.encodingCombo.Theme = "NewTheme";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel2.Location = new System.Drawing.Point(17, 108);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Scaled = true;
            this.metroLabel2.Size = new System.Drawing.Size(94, 22);
            this.metroLabel2.Style = "NewTheme";
            this.metroLabel2.TabIndex = 41;
            this.metroLabel2.Text = "Record Cursor:";
            this.metroLabel2.Theme = "NewTheme";
            this.metroLabel2.UseCompatibleTextRendering = true;
            // 
            // dpiScaledPictureBox1
            // 
            this.dpiScaledPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.dpiScaledPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("dpiScaledPictureBox1.Image")));
            this.dpiScaledPictureBox1.Location = new System.Drawing.Point(5, 11);
            this.dpiScaledPictureBox1.Name = "dpiScaledPictureBox1";
            this.dpiScaledPictureBox1.Scaled = true;
            this.dpiScaledPictureBox1.Size = new System.Drawing.Size(143, 53);
            this.dpiScaledPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dpiScaledPictureBox1.TabIndex = 1;
            this.dpiScaledPictureBox1.TabStop = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = MetroFramework5.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(587, 372);
            this.Controls.Add(this.dpiScaledPictureBox1);
            this.Controls.Add(this.metroTabControl1);
            this.DisplayHeader = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.ShowCustomWindowButtons = false;
            this.ShowFormTopBorder = false;
            this.Style = "NewTheme";
            this.Text = "Settings";
            this.Theme = "NewTheme";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroTabPage3.ResumeLayout(false);
            this.metroPanel3.ResumeLayout(false);
            this.metroPanel3.PerformLayout();
            this.metroTabPage4.ResumeLayout(false);
            this.metroPanel4.ResumeLayout(false);
            this.metroPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpiScaledPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DpiScaledTabControl metroTabControl1;
        private DpiScaledTabPage metroTabPage1;
        private DpiScaledTabPage metroTabPage3;
        private DpiScaledTabPage metroTabPage4;
        private DpiScaledLabel metroLabel5;
        private DpiScaledCombobox audioDeviceCombo;
        private DpiScaledLabel metroLabel4;
        private DpiScaledToggle recordAudioToggle;
        private DpiScaledLabel metroLabel3;
        private DpiScaledLabel metroLabel1;
        private DpiScaledCombobox encodingCombo;
        private DpiScaledLabel metroLabel2;
        private DpiScaledToggle recordCursorToggle;
        private DpiScaledCombobox framerateCombo;
        private DpiScaledLabel metroLabel11;
        private DpiScaledToggle showNotificationsToggle;
        private DpiScaledLabel metroLabel12;
        private DpiScaledToggle stitchFullscreenToggle;
        private DpiScaledLabel metroLabel6;
        private DpiScaledLabel metroLabel7;
        private DpiScaledCombobox imageQualityCombo;
        private DpiScaledLabel metroLabel8;
        private DpiScaledToggle imageCompressionToggle;
        private DpiScaledCombobox imageCodecCombo;
        private DpiScaledPanel metroPanel1;
        private DpiScaledTextbox metroTextBox1;
        private DpiScaledLabel metroLabel10;
        private DpiScaledToggle saveToDirectoryToggle;
        private DpiScaledLabel metroLabel9;
        private DpiScaledPanel metroPanel2;
        private DpiScaledLabel metroLabel14;
        private DpiScaledLabel metroLabel13;
        private DpiScaledToggle soundToggle;
        private DpiScaledToggle startupToggle;
        private DpiScaledLabel metroLabel15;
        private DpiScaledLabel metroLabel16;
        private DpiScaledToggle minimizedToggle;
        private DpiScaledLabel metroLabel17;
        private DpiScaledToggle alphaToggle;
        private DpiScaledPanel metroPanel3;
        private DpiScaledLabel metroLabel19;
        private DpiScaledPanel metroPanel4;
        private DpiScaledLabel metroLabel20;
        private DpiScaledLabel metroLabel18;
        private DpiScaledToggle useresizablecanvas;
        private DpiScaledPictureBox dpiScaledPictureBox1;
    }
}
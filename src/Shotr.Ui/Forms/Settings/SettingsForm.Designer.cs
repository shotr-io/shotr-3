using System.ComponentModel;
using Shotr.Core.Controls.DpiScaling;
using Shotr.Core.Controls.Theme;

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
            this.metroTabControl1 = new Shotr.Core.Controls.Theme.ThemedTabControl();
            this.metroTabPage1 = new Shotr.Core.Controls.Theme.ThemedTabPage();
            this.metroPanel2 = new Shotr.Core.Controls.Theme.ThemedPanel();
            this.metroLabel13 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.soundToggle = new Shotr.Core.Controls.Theme.ThemedToggle();
            this.startupToggle = new Shotr.Core.Controls.Theme.ThemedToggle();
            this.metroLabel15 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.metroLabel16 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.minimizedToggle = new Shotr.Core.Controls.Theme.ThemedToggle();
            this.metroLabel17 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.alphaToggle = new Shotr.Core.Controls.Theme.ThemedToggle();
            this.metroLabel14 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.metroLabel11 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.showNotificationsToggle = new Shotr.Core.Controls.Theme.ThemedToggle();
            this.metroPanel1 = new Shotr.Core.Controls.Theme.ThemedPanel();
            this.metroTextBox1 = new Shotr.Core.Controls.Theme.ThemedTextBox();
            this.metroLabel10 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.saveToDirectoryToggle = new Shotr.Core.Controls.Theme.ThemedToggle();
            this.metroLabel9 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.metroTabPage3 = new Shotr.Core.Controls.Theme.ThemedTabPage();
            this.metroPanel3 = new Shotr.Core.Controls.Theme.ThemedPanel();
            this.metroLabel18 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.useresizablecanvas = new Shotr.Core.Controls.Theme.ThemedToggle();
            this.metroLabel19 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.metroLabel12 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.metroLabel6 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.stitchFullscreenToggle = new Shotr.Core.Controls.Theme.ThemedToggle();
            this.imageCodecCombo = new Shotr.Core.Controls.Theme.ThemedComboBox();
            this.imageCompressionToggle = new Shotr.Core.Controls.Theme.ThemedToggle();
            this.metroLabel7 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.metroLabel8 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.imageQualityCombo = new Shotr.Core.Controls.Theme.ThemedComboBox();
            this.metroTabPage4 = new Shotr.Core.Controls.Theme.ThemedTabPage();
            this.metroPanel4 = new Shotr.Core.Controls.Theme.ThemedPanel();
            this.metroLabel5 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.audioDeviceCombo = new Shotr.Core.Controls.Theme.ThemedComboBox();
            this.metroLabel4 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.metroLabel20 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.recordAudioToggle = new Shotr.Core.Controls.Theme.ThemedToggle();
            this.metroLabel3 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.framerateCombo = new Shotr.Core.Controls.Theme.ThemedComboBox();
            this.metroLabel1 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.recordCursorToggle = new Shotr.Core.Controls.Theme.ThemedToggle();
            this.encodingCombo = new Shotr.Core.Controls.Theme.ThemedComboBox();
            this.metroLabel2 = new Shotr.Core.Controls.Theme.ThemedLabel();
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
            this.metroTabControl1.BasePaint = false;
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Controls.Add(this.metroTabPage4);
            this.metroTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.metroTabControl1.Location = new System.Drawing.Point(10, 57);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.Scaled = true;
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(568, 299);
            this.metroTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.metroTabControl1.TabIndex = 0;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.BasePaint = false;
            this.metroTabPage1.Controls.Add(this.metroPanel2);
            this.metroTabPage1.Controls.Add(this.metroPanel1);
            this.metroTabPage1.Location = new System.Drawing.Point(4, 25);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Scaled = true;
            this.metroTabPage1.Size = new System.Drawing.Size(560, 270);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "General";
            // 
            // metroPanel2
            // 
            this.metroPanel2.BasePaint = false;
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
            this.metroPanel2.Location = new System.Drawing.Point(8, 7);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Scaled = true;
            this.metroPanel2.Size = new System.Drawing.Size(544, 162);
            this.metroPanel2.TabIndex = 53;
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.BasePaint = false;
            this.metroLabel13.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroLabel13.Location = new System.Drawing.Point(63, 132);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Scaled = true;
            this.metroLabel13.Size = new System.Drawing.Size(77, 15);
            this.metroLabel13.TabIndex = 56;
            this.metroLabel13.Text = "Play Sounds";
            // 
            // soundToggle
            // 
            this.soundToggle.AutoSize = true;
            this.soundToggle.BasePaint = false;
            this.soundToggle.Location = new System.Drawing.Point(17, 130);
            this.soundToggle.Name = "soundToggle";
            this.soundToggle.Scaled = true;
            this.soundToggle.Size = new System.Drawing.Size(43, 19);
            this.soundToggle.TabIndex = 55;
            this.soundToggle.Text = "Off";
            this.soundToggle.UseVisualStyleBackColor = false;
            // 
            // startupToggle
            // 
            this.startupToggle.AutoSize = true;
            this.startupToggle.BasePaint = false;
            this.startupToggle.Location = new System.Drawing.Point(17, 52);
            this.startupToggle.Name = "startupToggle";
            this.startupToggle.Scaled = true;
            this.startupToggle.Size = new System.Drawing.Size(43, 19);
            this.startupToggle.TabIndex = 49;
            this.startupToggle.Text = "Off";
            this.startupToggle.UseVisualStyleBackColor = false;
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.BasePaint = false;
            this.metroLabel15.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroLabel15.Location = new System.Drawing.Point(63, 54);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Scaled = true;
            this.metroLabel15.Size = new System.Drawing.Size(82, 15);
            this.metroLabel15.TabIndex = 50;
            this.metroLabel15.Text = "Start With OS";
            // 
            // metroLabel16
            // 
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.BasePaint = false;
            this.metroLabel16.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroLabel16.Location = new System.Drawing.Point(63, 80);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Scaled = true;
            this.metroLabel16.Size = new System.Drawing.Size(95, 15);
            this.metroLabel16.TabIndex = 51;
            this.metroLabel16.Text = "Start Minimized";
            // 
            // minimizedToggle
            // 
            this.minimizedToggle.AutoSize = true;
            this.minimizedToggle.BasePaint = false;
            this.minimizedToggle.Location = new System.Drawing.Point(17, 78);
            this.minimizedToggle.Name = "minimizedToggle";
            this.minimizedToggle.Scaled = true;
            this.minimizedToggle.Size = new System.Drawing.Size(43, 19);
            this.minimizedToggle.TabIndex = 52;
            this.minimizedToggle.Text = "Off";
            this.minimizedToggle.UseVisualStyleBackColor = false;
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.BasePaint = false;
            this.metroLabel17.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroLabel17.Location = new System.Drawing.Point(63, 106);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Scaled = true;
            this.metroLabel17.Size = new System.Drawing.Size(80, 15);
            this.metroLabel17.TabIndex = 54;
            this.metroLabel17.Text = "Enable Alpha";
            // 
            // alphaToggle
            // 
            this.alphaToggle.AutoSize = true;
            this.alphaToggle.BasePaint = false;
            this.alphaToggle.Location = new System.Drawing.Point(17, 104);
            this.alphaToggle.Name = "alphaToggle";
            this.alphaToggle.Scaled = true;
            this.alphaToggle.Size = new System.Drawing.Size(43, 19);
            this.alphaToggle.TabIndex = 53;
            this.alphaToggle.Text = "Off";
            this.alphaToggle.UseVisualStyleBackColor = false;
            // 
            // metroLabel14
            // 
            this.metroLabel14.BasePaint = false;
            this.metroLabel14.Location = new System.Drawing.Point(134, 3);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Scaled = true;
            this.metroLabel14.Size = new System.Drawing.Size(276, 19);
            this.metroLabel14.TabIndex = 7;
            this.metroLabel14.Text = "General Options";
            this.metroLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.BasePaint = false;
            this.metroLabel11.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroLabel11.Location = new System.Drawing.Point(63, 28);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Scaled = true;
            this.metroLabel11.Size = new System.Drawing.Size(113, 15);
            this.metroLabel11.TabIndex = 48;
            this.metroLabel11.Text = "Show Notifications";
            // 
            // showNotificationsToggle
            // 
            this.showNotificationsToggle.AutoSize = true;
            this.showNotificationsToggle.BasePaint = false;
            this.showNotificationsToggle.Location = new System.Drawing.Point(17, 26);
            this.showNotificationsToggle.Name = "showNotificationsToggle";
            this.showNotificationsToggle.Scaled = true;
            this.showNotificationsToggle.Size = new System.Drawing.Size(43, 19);
            this.showNotificationsToggle.TabIndex = 47;
            this.showNotificationsToggle.Text = "Off";
            this.showNotificationsToggle.UseVisualStyleBackColor = false;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BasePaint = false;
            this.metroPanel1.Controls.Add(this.metroTextBox1);
            this.metroPanel1.Controls.Add(this.metroLabel10);
            this.metroPanel1.Controls.Add(this.saveToDirectoryToggle);
            this.metroPanel1.Controls.Add(this.metroLabel9);
            this.metroPanel1.Location = new System.Drawing.Point(8, 175);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Scaled = true;
            this.metroPanel1.Size = new System.Drawing.Size(544, 85);
            this.metroPanel1.TabIndex = 52;
            // 
            // metroTextBox1
            // 
            this.metroTextBox1.BasePaint = false;
            this.metroTextBox1.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroTextBox1.Location = new System.Drawing.Point(17, 43);
            this.metroTextBox1.Multiline = false;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.ReadOnly = true;
            this.metroTextBox1.Scaled = true;
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.Size = new System.Drawing.Size(510, 23);
            this.metroTextBox1.TabIndex = 54;
            this.metroTextBox1.TabStop = false;
            this.metroTextBox1.UseSystemPasswordChar = false;
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.BasePaint = false;
            this.metroLabel10.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroLabel10.Location = new System.Drawing.Point(14, 21);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Scaled = true;
            this.metroLabel10.Size = new System.Drawing.Size(105, 15);
            this.metroLabel10.TabIndex = 53;
            this.metroLabel10.Text = "Save to Directory";
            // 
            // saveToDirectoryToggle
            // 
            this.saveToDirectoryToggle.AutoSize = true;
            this.saveToDirectoryToggle.BasePaint = false;
            this.saveToDirectoryToggle.Location = new System.Drawing.Point(484, 20);
            this.saveToDirectoryToggle.Name = "saveToDirectoryToggle";
            this.saveToDirectoryToggle.Scaled = true;
            this.saveToDirectoryToggle.Size = new System.Drawing.Size(43, 19);
            this.saveToDirectoryToggle.TabIndex = 52;
            this.saveToDirectoryToggle.Text = "Off";
            this.saveToDirectoryToggle.UseVisualStyleBackColor = false;
            // 
            // metroLabel9
            // 
            this.metroLabel9.BasePaint = false;
            this.metroLabel9.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroLabel9.Location = new System.Drawing.Point(134, 3);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Scaled = true;
            this.metroLabel9.Size = new System.Drawing.Size(276, 19);
            this.metroLabel9.TabIndex = 7;
            this.metroLabel9.Text = "Save to Directory";
            this.metroLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.BasePaint = false;
            this.metroTabPage3.Controls.Add(this.metroPanel3);
            this.metroTabPage3.Location = new System.Drawing.Point(4, 25);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Scaled = true;
            this.metroTabPage3.Size = new System.Drawing.Size(560, 270);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Capture";
            // 
            // metroPanel3
            // 
            this.metroPanel3.BasePaint = false;
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
            this.metroPanel3.Location = new System.Drawing.Point(8, 7);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Scaled = true;
            this.metroPanel3.Size = new System.Drawing.Size(544, 216);
            this.metroPanel3.TabIndex = 53;
            // 
            // metroLabel18
            // 
            this.metroLabel18.AutoSize = true;
            this.metroLabel18.BasePaint = false;
            this.metroLabel18.Location = new System.Drawing.Point(17, 173);
            this.metroLabel18.Name = "metroLabel18";
            this.metroLabel18.Scaled = true;
            this.metroLabel18.Size = new System.Drawing.Size(233, 15);
            this.metroLabel18.TabIndex = 40;
            this.metroLabel18.Text = "Use Resizable Canvas (Enter to Upload):";
            // 
            // useresizablecanvas
            // 
            this.useresizablecanvas.AutoSize = true;
            this.useresizablecanvas.BasePaint = false;
            this.useresizablecanvas.Location = new System.Drawing.Point(484, 172);
            this.useresizablecanvas.Name = "useresizablecanvas";
            this.useresizablecanvas.Scaled = true;
            this.useresizablecanvas.Size = new System.Drawing.Size(43, 19);
            this.useresizablecanvas.TabIndex = 39;
            this.useresizablecanvas.Text = "Off";
            this.useresizablecanvas.UseVisualStyleBackColor = false;
            // 
            // metroLabel19
            // 
            this.metroLabel19.BasePaint = false;
            this.metroLabel19.Location = new System.Drawing.Point(134, 3);
            this.metroLabel19.Name = "metroLabel19";
            this.metroLabel19.Scaled = true;
            this.metroLabel19.Size = new System.Drawing.Size(276, 19);
            this.metroLabel19.TabIndex = 7;
            this.metroLabel19.Text = "Screenshot Capture Options";
            this.metroLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.BasePaint = false;
            this.metroLabel12.Location = new System.Drawing.Point(17, 139);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Scaled = true;
            this.metroLabel12.Size = new System.Drawing.Size(158, 15);
            this.metroLabel12.TabIndex = 38;
            this.metroLabel12.Text = "Stitch Fullscreen Captures:";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.BasePaint = false;
            this.metroLabel6.Location = new System.Drawing.Point(17, 30);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Scaled = true;
            this.metroLabel6.Size = new System.Drawing.Size(84, 15);
            this.metroLabel6.TabIndex = 36;
            this.metroLabel6.Text = "Image Codec:";
            // 
            // stitchFullscreenToggle
            // 
            this.stitchFullscreenToggle.AutoSize = true;
            this.stitchFullscreenToggle.BasePaint = false;
            this.stitchFullscreenToggle.Location = new System.Drawing.Point(484, 138);
            this.stitchFullscreenToggle.Name = "stitchFullscreenToggle";
            this.stitchFullscreenToggle.Scaled = true;
            this.stitchFullscreenToggle.Size = new System.Drawing.Size(43, 19);
            this.stitchFullscreenToggle.TabIndex = 37;
            this.stitchFullscreenToggle.Text = "Off";
            this.stitchFullscreenToggle.UseVisualStyleBackColor = false;
            // 
            // imageCodecCombo
            // 
            this.imageCodecCombo.BasePaint = false;
            this.imageCodecCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.imageCodecCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imageCodecCombo.FormattingEnabled = true;
            this.imageCodecCombo.ItemHeight = 15;
            this.imageCodecCombo.Items.AddRange(new object[] {
            "png",
            "jpeg"});
            this.imageCodecCombo.Location = new System.Drawing.Point(323, 25);
            this.imageCodecCombo.Name = "imageCodecCombo";
            this.imageCodecCombo.Scaled = true;
            this.imageCodecCombo.Size = new System.Drawing.Size(204, 21);
            this.imageCodecCombo.TabIndex = 31;
            // 
            // imageCompressionToggle
            // 
            this.imageCompressionToggle.AutoSize = true;
            this.imageCompressionToggle.BasePaint = false;
            this.imageCompressionToggle.Location = new System.Drawing.Point(484, 106);
            this.imageCompressionToggle.Name = "imageCompressionToggle";
            this.imageCompressionToggle.Scaled = true;
            this.imageCompressionToggle.Size = new System.Drawing.Size(43, 19);
            this.imageCompressionToggle.TabIndex = 32;
            this.imageCompressionToggle.Text = "Off";
            this.imageCompressionToggle.UseVisualStyleBackColor = false;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.BasePaint = false;
            this.metroLabel7.Location = new System.Drawing.Point(17, 69);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Scaled = true;
            this.metroLabel7.Size = new System.Drawing.Size(87, 15);
            this.metroLabel7.TabIndex = 35;
            this.metroLabel7.Text = "Image Quality:";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.BasePaint = false;
            this.metroLabel8.Location = new System.Drawing.Point(17, 107);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Scaled = true;
            this.metroLabel8.Size = new System.Drawing.Size(120, 15);
            this.metroLabel8.TabIndex = 33;
            this.metroLabel8.Text = "Image Compression:";
            // 
            // imageQualityCombo
            // 
            this.imageQualityCombo.BasePaint = false;
            this.imageQualityCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.imageQualityCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imageQualityCombo.FormattingEnabled = true;
            this.imageQualityCombo.ItemHeight = 15;
            this.imageQualityCombo.Items.AddRange(new object[] {
            "Maximum",
            "Ultra",
            "High",
            "Medium",
            "Low"});
            this.imageQualityCombo.Location = new System.Drawing.Point(323, 64);
            this.imageQualityCombo.Name = "imageQualityCombo";
            this.imageQualityCombo.Scaled = true;
            this.imageQualityCombo.Size = new System.Drawing.Size(204, 21);
            this.imageQualityCombo.TabIndex = 34;
            // 
            // metroTabPage4
            // 
            this.metroTabPage4.BasePaint = false;
            this.metroTabPage4.Controls.Add(this.metroPanel4);
            this.metroTabPage4.Location = new System.Drawing.Point(4, 25);
            this.metroTabPage4.Name = "metroTabPage4";
            this.metroTabPage4.Scaled = true;
            this.metroTabPage4.Size = new System.Drawing.Size(560, 270);
            this.metroTabPage4.TabIndex = 3;
            this.metroTabPage4.Text = "Recorder";
            // 
            // metroPanel4
            // 
            this.metroPanel4.BasePaint = false;
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
            this.metroPanel4.Location = new System.Drawing.Point(8, 7);
            this.metroPanel4.Name = "metroPanel4";
            this.metroPanel4.Scaled = true;
            this.metroPanel4.Size = new System.Drawing.Size(544, 216);
            this.metroPanel4.TabIndex = 53;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.BasePaint = false;
            this.metroLabel5.Location = new System.Drawing.Point(17, 171);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Scaled = true;
            this.metroLabel5.Size = new System.Drawing.Size(85, 15);
            this.metroLabel5.TabIndex = 48;
            this.metroLabel5.Text = "Audio Device:";
            // 
            // audioDeviceCombo
            // 
            this.audioDeviceCombo.BasePaint = false;
            this.audioDeviceCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.audioDeviceCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.audioDeviceCombo.FormattingEnabled = true;
            this.audioDeviceCombo.ItemHeight = 15;
            this.audioDeviceCombo.Location = new System.Drawing.Point(322, 168);
            this.audioDeviceCombo.Name = "audioDeviceCombo";
            this.audioDeviceCombo.Scaled = true;
            this.audioDeviceCombo.Size = new System.Drawing.Size(205, 21);
            this.audioDeviceCombo.TabIndex = 47;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.BasePaint = false;
            this.metroLabel4.Location = new System.Drawing.Point(17, 139);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Scaled = true;
            this.metroLabel4.Size = new System.Drawing.Size(85, 15);
            this.metroLabel4.TabIndex = 46;
            this.metroLabel4.Text = "Record Audio:";
            // 
            // metroLabel20
            // 
            this.metroLabel20.BasePaint = false;
            this.metroLabel20.Location = new System.Drawing.Point(134, 3);
            this.metroLabel20.Name = "metroLabel20";
            this.metroLabel20.Scaled = true;
            this.metroLabel20.Size = new System.Drawing.Size(276, 19);
            this.metroLabel20.TabIndex = 7;
            this.metroLabel20.Text = "Save to Directory";
            this.metroLabel20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // recordAudioToggle
            // 
            this.recordAudioToggle.AutoSize = true;
            this.recordAudioToggle.BasePaint = false;
            this.recordAudioToggle.Location = new System.Drawing.Point(484, 138);
            this.recordAudioToggle.Name = "recordAudioToggle";
            this.recordAudioToggle.Scaled = true;
            this.recordAudioToggle.Size = new System.Drawing.Size(43, 19);
            this.recordAudioToggle.TabIndex = 45;
            this.recordAudioToggle.Text = "Off";
            this.recordAudioToggle.UseVisualStyleBackColor = false;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BasePaint = false;
            this.metroLabel3.Location = new System.Drawing.Point(17, 30);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Scaled = true;
            this.metroLabel3.Size = new System.Drawing.Size(67, 15);
            this.metroLabel3.TabIndex = 44;
            this.metroLabel3.Text = "Framerate:";
            // 
            // framerateCombo
            // 
            this.framerateCombo.BasePaint = false;
            this.framerateCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.framerateCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.framerateCombo.FormattingEnabled = true;
            this.framerateCombo.ItemHeight = 15;
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
            this.framerateCombo.Scaled = true;
            this.framerateCombo.Size = new System.Drawing.Size(204, 21);
            this.framerateCombo.TabIndex = 39;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BasePaint = false;
            this.metroLabel1.Location = new System.Drawing.Point(17, 69);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Scaled = true;
            this.metroLabel1.Size = new System.Drawing.Size(111, 15);
            this.metroLabel1.TabIndex = 43;
            this.metroLabel1.Text = "Encoding Threads:";
            // 
            // recordCursorToggle
            // 
            this.recordCursorToggle.AutoSize = true;
            this.recordCursorToggle.BasePaint = false;
            this.recordCursorToggle.Location = new System.Drawing.Point(484, 107);
            this.recordCursorToggle.Name = "recordCursorToggle";
            this.recordCursorToggle.Scaled = true;
            this.recordCursorToggle.Size = new System.Drawing.Size(43, 19);
            this.recordCursorToggle.TabIndex = 40;
            this.recordCursorToggle.Text = "Off";
            this.recordCursorToggle.UseVisualStyleBackColor = false;
            // 
            // encodingCombo
            // 
            this.encodingCombo.BasePaint = false;
            this.encodingCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.encodingCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.encodingCombo.FormattingEnabled = true;
            this.encodingCombo.ItemHeight = 15;
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
            this.encodingCombo.Scaled = true;
            this.encodingCombo.Size = new System.Drawing.Size(204, 21);
            this.encodingCombo.TabIndex = 42;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BasePaint = false;
            this.metroLabel2.Location = new System.Drawing.Point(17, 108);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Scaled = true;
            this.metroLabel2.Size = new System.Drawing.Size(90, 15);
            this.metroLabel2.TabIndex = 41;
            this.metroLabel2.Text = "Record Cursor:";
            // 
            // dpiScaledPictureBox1
            // 
            this.dpiScaledPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.dpiScaledPictureBox1.BackgroundImage = Shotr.Ui.Properties.Resources.shotr_logo_banner;
            this.dpiScaledPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dpiScaledPictureBox1.BasePaint = false;
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
            this.ClientSize = new System.Drawing.Size(587, 372);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.dpiScaledPictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
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

        private ThemedTabControl metroTabControl1;
        private ThemedTabPage metroTabPage1;
        private ThemedTabPage metroTabPage3;
        private ThemedTabPage metroTabPage4;
        private ThemedLabel metroLabel5;
        private ThemedComboBox audioDeviceCombo;
        private ThemedLabel metroLabel4;
        private ThemedToggle recordAudioToggle;
        private ThemedLabel metroLabel3;
        private ThemedLabel metroLabel1;
        private ThemedComboBox encodingCombo;
        private ThemedLabel metroLabel2;
        private ThemedToggle recordCursorToggle;
        private ThemedComboBox framerateCombo;
        private ThemedLabel metroLabel11;
        private ThemedToggle showNotificationsToggle;
        private ThemedLabel metroLabel12;
        private ThemedToggle stitchFullscreenToggle;
        private ThemedLabel metroLabel6;
        private ThemedLabel metroLabel7;
        private ThemedComboBox imageQualityCombo;
        private ThemedLabel metroLabel8;
        private ThemedToggle imageCompressionToggle;
        private ThemedComboBox imageCodecCombo;
        private ThemedPanel metroPanel1;
        private ThemedTextBox metroTextBox1;
        private ThemedLabel metroLabel10;
        private ThemedToggle saveToDirectoryToggle;
        private ThemedLabel metroLabel9;
        private ThemedPanel metroPanel2;
        private ThemedLabel metroLabel14;
        private ThemedLabel metroLabel13;
        private ThemedToggle soundToggle;
        private ThemedToggle startupToggle;
        private ThemedLabel metroLabel15;
        private ThemedLabel metroLabel16;
        private ThemedToggle minimizedToggle;
        private ThemedLabel metroLabel17;
        private ThemedToggle alphaToggle;
        private ThemedPanel metroPanel3;
        private ThemedLabel metroLabel19;
        private ThemedPanel metroPanel4;
        private ThemedLabel metroLabel20;
        private ThemedLabel metroLabel18;
        private ThemedToggle useresizablecanvas;
        private DpiScaledPictureBox dpiScaledPictureBox1;
    }
}
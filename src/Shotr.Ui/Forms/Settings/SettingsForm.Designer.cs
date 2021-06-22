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
            this.themedBar7 = new Shotr.Core.Controls.Theme.ThemedBar();
            this.themedBar6 = new Shotr.Core.Controls.Theme.ThemedBar();
            this.themedBar5 = new Shotr.Core.Controls.Theme.ThemedBar();
            this.themedBar3 = new Shotr.Core.Controls.Theme.ThemedBar();
            this.themedBar4 = new Shotr.Core.Controls.Theme.ThemedBar();
            this.chooseSaveToDirectoryButton = new Shotr.Core.Controls.Theme.ThemedButton();
            this.saveToDirectoryPathTextBox = new Shotr.Core.Controls.Theme.ThemedTextBox();
            this.metroLabel10 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.saveToDirectoryToggle = new Shotr.Core.Controls.Theme.ThemedToggle();
            this.metroLabel13 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.soundToggle = new Shotr.Core.Controls.Theme.ThemedToggle();
            this.startupToggle = new Shotr.Core.Controls.Theme.ThemedToggle();
            this.metroLabel15 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.metroLabel16 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.minimizedToggle = new Shotr.Core.Controls.Theme.ThemedToggle();
            this.metroLabel17 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.alphaToggle = new Shotr.Core.Controls.Theme.ThemedToggle();
            this.metroLabel11 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.showNotificationsToggle = new Shotr.Core.Controls.Theme.ThemedToggle();
            this.metroTabPage3 = new Shotr.Core.Controls.Theme.ThemedTabPage();
            this.metroPanel3 = new Shotr.Core.Controls.Theme.ThemedPanel();
            this.themedBar12 = new Shotr.Core.Controls.Theme.ThemedBar();
            this.themedBar11 = new Shotr.Core.Controls.Theme.ThemedBar();
            this.directUrlToggle = new Shotr.Core.Controls.Theme.ThemedToggle();
            this.themedLabel1 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.metroLabel9 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.selectedImageUploader = new Shotr.Core.Controls.Theme.ThemedComboBox();
            this.themedBar10 = new Shotr.Core.Controls.Theme.ThemedBar();
            this.themedBar9 = new Shotr.Core.Controls.Theme.ThemedBar();
            this.themedBar2 = new Shotr.Core.Controls.Theme.ThemedBar();
            this.themedBar8 = new Shotr.Core.Controls.Theme.ThemedBar();
            this.metroLabel18 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.useresizablecanvas = new Shotr.Core.Controls.Theme.ThemedToggle();
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
            this.themedBar16 = new Shotr.Core.Controls.Theme.ThemedBar();
            this.qualityLabel = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.qualityCombo = new Shotr.Core.Controls.Theme.ThemedComboBox();
            this.themedBar15 = new Shotr.Core.Controls.Theme.ThemedBar();
            this.themedBar14 = new Shotr.Core.Controls.Theme.ThemedBar();
            this.themedBar13 = new Shotr.Core.Controls.Theme.ThemedBar();
            this.themedBar1 = new Shotr.Core.Controls.Theme.ThemedBar();
            this.metroLabel5 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.audioDeviceCombo = new Shotr.Core.Controls.Theme.ThemedComboBox();
            this.metroLabel4 = new Shotr.Core.Controls.Theme.ThemedLabel();
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
            this.metroTabControl1.Location = new System.Drawing.Point(1, 57);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.Scaled = true;
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(340, 299);
            this.metroTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.metroTabControl1.TabIndex = 0;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.BasePaint = false;
            this.metroTabPage1.Controls.Add(this.metroPanel2);
            this.metroTabPage1.Location = new System.Drawing.Point(4, 29);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Scaled = true;
            this.metroTabPage1.Size = new System.Drawing.Size(332, 266);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "General";
            // 
            // metroPanel2
            // 
            this.metroPanel2.BasePaint = false;
            this.metroPanel2.Controls.Add(this.themedBar7);
            this.metroPanel2.Controls.Add(this.themedBar6);
            this.metroPanel2.Controls.Add(this.themedBar5);
            this.metroPanel2.Controls.Add(this.themedBar3);
            this.metroPanel2.Controls.Add(this.themedBar4);
            this.metroPanel2.Controls.Add(this.chooseSaveToDirectoryButton);
            this.metroPanel2.Controls.Add(this.saveToDirectoryPathTextBox);
            this.metroPanel2.Controls.Add(this.metroLabel10);
            this.metroPanel2.Controls.Add(this.saveToDirectoryToggle);
            this.metroPanel2.Controls.Add(this.metroLabel13);
            this.metroPanel2.Controls.Add(this.soundToggle);
            this.metroPanel2.Controls.Add(this.startupToggle);
            this.metroPanel2.Controls.Add(this.metroLabel15);
            this.metroPanel2.Controls.Add(this.metroLabel16);
            this.metroPanel2.Controls.Add(this.minimizedToggle);
            this.metroPanel2.Controls.Add(this.metroLabel17);
            this.metroPanel2.Controls.Add(this.alphaToggle);
            this.metroPanel2.Controls.Add(this.metroLabel11);
            this.metroPanel2.Controls.Add(this.showNotificationsToggle);
            this.metroPanel2.Location = new System.Drawing.Point(8, 7);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Scaled = true;
            this.metroPanel2.Size = new System.Drawing.Size(316, 255);
            this.metroPanel2.TabIndex = 53;
            // 
            // themedBar7
            // 
            this.themedBar7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.themedBar7.BasePaint = false;
            this.themedBar7.Location = new System.Drawing.Point(10, 152);
            this.themedBar7.Name = "themedBar7";
            this.themedBar7.Scaled = true;
            this.themedBar7.Size = new System.Drawing.Size(296, 1);
            this.themedBar7.TabIndex = 63;
            this.themedBar7.Text = "themedBar7";
            // 
            // themedBar6
            // 
            this.themedBar6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.themedBar6.BasePaint = false;
            this.themedBar6.Location = new System.Drawing.Point(10, 122);
            this.themedBar6.Name = "themedBar6";
            this.themedBar6.Scaled = true;
            this.themedBar6.Size = new System.Drawing.Size(296, 1);
            this.themedBar6.TabIndex = 62;
            this.themedBar6.Text = "themedBar6";
            // 
            // themedBar5
            // 
            this.themedBar5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.themedBar5.BasePaint = false;
            this.themedBar5.Location = new System.Drawing.Point(10, 92);
            this.themedBar5.Name = "themedBar5";
            this.themedBar5.Scaled = true;
            this.themedBar5.Size = new System.Drawing.Size(296, 1);
            this.themedBar5.TabIndex = 61;
            this.themedBar5.Text = "themedBar5";
            // 
            // themedBar3
            // 
            this.themedBar3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.themedBar3.BasePaint = false;
            this.themedBar3.Location = new System.Drawing.Point(11, 62);
            this.themedBar3.Name = "themedBar3";
            this.themedBar3.Scaled = true;
            this.themedBar3.Size = new System.Drawing.Size(296, 1);
            this.themedBar3.TabIndex = 60;
            this.themedBar3.Text = "themedBar3";
            // 
            // themedBar4
            // 
            this.themedBar4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.themedBar4.BasePaint = false;
            this.themedBar4.Location = new System.Drawing.Point(11, 32);
            this.themedBar4.Name = "themedBar4";
            this.themedBar4.Scaled = true;
            this.themedBar4.Size = new System.Drawing.Size(296, 1);
            this.themedBar4.TabIndex = 59;
            this.themedBar4.Text = "themedBar4";
            // 
            // chooseSaveToDirectoryButton
            // 
            this.chooseSaveToDirectoryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.chooseSaveToDirectoryButton.BasePaint = false;
            this.chooseSaveToDirectoryButton.Highlight = false;
            this.chooseSaveToDirectoryButton.Location = new System.Drawing.Point(263, 183);
            this.chooseSaveToDirectoryButton.Name = "chooseSaveToDirectoryButton";
            this.chooseSaveToDirectoryButton.Scaled = true;
            this.chooseSaveToDirectoryButton.Size = new System.Drawing.Size(41, 23);
            this.chooseSaveToDirectoryButton.TabIndex = 58;
            this.chooseSaveToDirectoryButton.Text = "...";
            this.chooseSaveToDirectoryButton.UseVisualStyleBackColor = false;
            this.chooseSaveToDirectoryButton.Click += new System.EventHandler(this.chooseSaveToDirectoryButton_Click);
            // 
            // saveToDirectoryPathTextBox
            // 
            this.saveToDirectoryPathTextBox.BasePaint = false;
            this.saveToDirectoryPathTextBox.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.saveToDirectoryPathTextBox.Location = new System.Drawing.Point(13, 183);
            this.saveToDirectoryPathTextBox.Multiline = false;
            this.saveToDirectoryPathTextBox.Name = "saveToDirectoryPathTextBox";
            this.saveToDirectoryPathTextBox.ReadOnly = true;
            this.saveToDirectoryPathTextBox.Scaled = true;
            this.saveToDirectoryPathTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.saveToDirectoryPathTextBox.Size = new System.Drawing.Size(242, 23);
            this.saveToDirectoryPathTextBox.TabIndex = 54;
            this.saveToDirectoryPathTextBox.TabStop = false;
            this.saveToDirectoryPathTextBox.UseSystemPasswordChar = false;
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.BasePaint = false;
            this.metroLabel10.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroLabel10.Location = new System.Drawing.Point(10, 160);
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
            this.saveToDirectoryToggle.Location = new System.Drawing.Point(263, 158);
            this.saveToDirectoryToggle.Name = "saveToDirectoryToggle";
            this.saveToDirectoryToggle.Scaled = true;
            this.saveToDirectoryToggle.Size = new System.Drawing.Size(50, 21);
            this.saveToDirectoryToggle.TabIndex = 52;
            this.saveToDirectoryToggle.Text = "Off";
            this.saveToDirectoryToggle.UseVisualStyleBackColor = false;
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.BasePaint = false;
            this.metroLabel13.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroLabel13.Location = new System.Drawing.Point(10, 130);
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
            this.soundToggle.Location = new System.Drawing.Point(263, 128);
            this.soundToggle.Name = "soundToggle";
            this.soundToggle.Scaled = true;
            this.soundToggle.Size = new System.Drawing.Size(50, 21);
            this.soundToggle.TabIndex = 55;
            this.soundToggle.Text = "Off";
            this.soundToggle.UseVisualStyleBackColor = false;
            // 
            // startupToggle
            // 
            this.startupToggle.AutoSize = true;
            this.startupToggle.BasePaint = false;
            this.startupToggle.Location = new System.Drawing.Point(263, 38);
            this.startupToggle.Name = "startupToggle";
            this.startupToggle.Scaled = true;
            this.startupToggle.Size = new System.Drawing.Size(50, 21);
            this.startupToggle.TabIndex = 49;
            this.startupToggle.Text = "Off";
            this.startupToggle.UseVisualStyleBackColor = false;
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.BasePaint = false;
            this.metroLabel15.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroLabel15.Location = new System.Drawing.Point(10, 40);
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
            this.metroLabel16.Location = new System.Drawing.Point(10, 70);
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
            this.minimizedToggle.Location = new System.Drawing.Point(263, 68);
            this.minimizedToggle.Name = "minimizedToggle";
            this.minimizedToggle.Scaled = true;
            this.minimizedToggle.Size = new System.Drawing.Size(50, 21);
            this.minimizedToggle.TabIndex = 52;
            this.minimizedToggle.Text = "Off";
            this.minimizedToggle.UseVisualStyleBackColor = false;
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.BasePaint = false;
            this.metroLabel17.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroLabel17.Location = new System.Drawing.Point(10, 100);
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
            this.alphaToggle.Location = new System.Drawing.Point(263, 98);
            this.alphaToggle.Name = "alphaToggle";
            this.alphaToggle.Scaled = true;
            this.alphaToggle.Size = new System.Drawing.Size(50, 21);
            this.alphaToggle.TabIndex = 53;
            this.alphaToggle.Text = "Off";
            this.alphaToggle.UseVisualStyleBackColor = false;
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.BasePaint = false;
            this.metroLabel11.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroLabel11.Location = new System.Drawing.Point(10, 10);
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
            this.showNotificationsToggle.Location = new System.Drawing.Point(263, 8);
            this.showNotificationsToggle.Name = "showNotificationsToggle";
            this.showNotificationsToggle.Scaled = true;
            this.showNotificationsToggle.Size = new System.Drawing.Size(50, 21);
            this.showNotificationsToggle.TabIndex = 47;
            this.showNotificationsToggle.Text = "Off";
            this.showNotificationsToggle.UseVisualStyleBackColor = false;
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.BasePaint = false;
            this.metroTabPage3.Controls.Add(this.metroPanel3);
            this.metroTabPage3.Location = new System.Drawing.Point(4, 29);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Scaled = true;
            this.metroTabPage3.Size = new System.Drawing.Size(332, 266);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Capture";
            // 
            // metroPanel3
            // 
            this.metroPanel3.BasePaint = false;
            this.metroPanel3.Controls.Add(this.themedBar12);
            this.metroPanel3.Controls.Add(this.themedBar11);
            this.metroPanel3.Controls.Add(this.directUrlToggle);
            this.metroPanel3.Controls.Add(this.themedLabel1);
            this.metroPanel3.Controls.Add(this.metroLabel9);
            this.metroPanel3.Controls.Add(this.selectedImageUploader);
            this.metroPanel3.Controls.Add(this.themedBar10);
            this.metroPanel3.Controls.Add(this.themedBar9);
            this.metroPanel3.Controls.Add(this.themedBar2);
            this.metroPanel3.Controls.Add(this.themedBar8);
            this.metroPanel3.Controls.Add(this.metroLabel18);
            this.metroPanel3.Controls.Add(this.useresizablecanvas);
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
            this.metroPanel3.Size = new System.Drawing.Size(316, 255);
            this.metroPanel3.TabIndex = 53;
            // 
            // themedBar12
            // 
            this.themedBar12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.themedBar12.BasePaint = false;
            this.themedBar12.Location = new System.Drawing.Point(10, 182);
            this.themedBar12.Name = "themedBar12";
            this.themedBar12.Scaled = true;
            this.themedBar12.Size = new System.Drawing.Size(296, 1);
            this.themedBar12.TabIndex = 69;
            this.themedBar12.Text = "themedBar12";
            // 
            // themedBar11
            // 
            this.themedBar11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.themedBar11.BasePaint = false;
            this.themedBar11.Location = new System.Drawing.Point(10, 152);
            this.themedBar11.Name = "themedBar11";
            this.themedBar11.Scaled = true;
            this.themedBar11.Size = new System.Drawing.Size(296, 1);
            this.themedBar11.TabIndex = 68;
            this.themedBar11.Text = "themedBar11";
            // 
            // directUrlToggle
            // 
            this.directUrlToggle.AutoSize = true;
            this.directUrlToggle.BasePaint = false;
            this.directUrlToggle.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.directUrlToggle.Location = new System.Drawing.Point(263, 188);
            this.directUrlToggle.Name = "directUrlToggle";
            this.directUrlToggle.Scaled = true;
            this.directUrlToggle.Size = new System.Drawing.Size(50, 21);
            this.directUrlToggle.TabIndex = 67;
            this.directUrlToggle.Text = "Off";
            this.directUrlToggle.UseVisualStyleBackColor = false;
            this.directUrlToggle.Visible = false;
            this.directUrlToggle.CheckedChanged += new System.EventHandler(this.directUrlToggle_CheckedChanged);
            // 
            // themedLabel1
            // 
            this.themedLabel1.AutoSize = true;
            this.themedLabel1.BasePaint = false;
            this.themedLabel1.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.themedLabel1.Location = new System.Drawing.Point(10, 190);
            this.themedLabel1.Name = "themedLabel1";
            this.themedLabel1.Scaled = true;
            this.themedLabel1.Size = new System.Drawing.Size(128, 15);
            this.themedLabel1.TabIndex = 66;
            this.themedLabel1.Text = "Use Direct Upload Url";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.BasePaint = false;
            this.metroLabel9.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroLabel9.Location = new System.Drawing.Point(10, 160);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Scaled = true;
            this.metroLabel9.Size = new System.Drawing.Size(95, 15);
            this.metroLabel9.TabIndex = 65;
            this.metroLabel9.Text = "Image Uploader";
            this.metroLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // selectedImageUploader
            // 
            this.selectedImageUploader.BasePaint = false;
            this.selectedImageUploader.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.selectedImageUploader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectedImageUploader.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.selectedImageUploader.FormattingEnabled = true;
            this.selectedImageUploader.ItemHeight = 15;
            this.selectedImageUploader.Location = new System.Drawing.Point(178, 157);
            this.selectedImageUploader.Name = "selectedImageUploader";
            this.selectedImageUploader.Scaled = true;
            this.selectedImageUploader.Size = new System.Drawing.Size(128, 21);
            this.selectedImageUploader.TabIndex = 64;
            this.selectedImageUploader.SelectedIndexChanged += new System.EventHandler(this.selectedImageUploader_SelectedIndexChanged);
            // 
            // themedBar10
            // 
            this.themedBar10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.themedBar10.BasePaint = false;
            this.themedBar10.Location = new System.Drawing.Point(10, 122);
            this.themedBar10.Name = "themedBar10";
            this.themedBar10.Scaled = true;
            this.themedBar10.Size = new System.Drawing.Size(296, 1);
            this.themedBar10.TabIndex = 63;
            this.themedBar10.Text = "themedBar10";
            // 
            // themedBar9
            // 
            this.themedBar9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.themedBar9.BasePaint = false;
            this.themedBar9.Location = new System.Drawing.Point(10, 92);
            this.themedBar9.Name = "themedBar9";
            this.themedBar9.Scaled = true;
            this.themedBar9.Size = new System.Drawing.Size(296, 1);
            this.themedBar9.TabIndex = 62;
            this.themedBar9.Text = "themedBar9";
            // 
            // themedBar2
            // 
            this.themedBar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.themedBar2.BasePaint = false;
            this.themedBar2.Location = new System.Drawing.Point(10, 62);
            this.themedBar2.Name = "themedBar2";
            this.themedBar2.Scaled = true;
            this.themedBar2.Size = new System.Drawing.Size(296, 1);
            this.themedBar2.TabIndex = 61;
            this.themedBar2.Text = "themedBar2";
            // 
            // themedBar8
            // 
            this.themedBar8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.themedBar8.BasePaint = false;
            this.themedBar8.Location = new System.Drawing.Point(10, 32);
            this.themedBar8.Name = "themedBar8";
            this.themedBar8.Scaled = true;
            this.themedBar8.Size = new System.Drawing.Size(296, 1);
            this.themedBar8.TabIndex = 60;
            this.themedBar8.Text = "themedBar8";
            // 
            // metroLabel18
            // 
            this.metroLabel18.AutoSize = true;
            this.metroLabel18.BasePaint = false;
            this.metroLabel18.Location = new System.Drawing.Point(10, 130);
            this.metroLabel18.Name = "metroLabel18";
            this.metroLabel18.Scaled = true;
            this.metroLabel18.Size = new System.Drawing.Size(93, 15);
            this.metroLabel18.TabIndex = 40;
            this.metroLabel18.Text = "Enter to Upload";
            // 
            // useresizablecanvas
            // 
            this.useresizablecanvas.AutoSize = true;
            this.useresizablecanvas.BasePaint = false;
            this.useresizablecanvas.Location = new System.Drawing.Point(263, 128);
            this.useresizablecanvas.Name = "useresizablecanvas";
            this.useresizablecanvas.Scaled = true;
            this.useresizablecanvas.Size = new System.Drawing.Size(50, 21);
            this.useresizablecanvas.TabIndex = 39;
            this.useresizablecanvas.Text = "Off";
            this.useresizablecanvas.UseVisualStyleBackColor = false;
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.BasePaint = false;
            this.metroLabel12.Location = new System.Drawing.Point(10, 100);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Scaled = true;
            this.metroLabel12.Size = new System.Drawing.Size(155, 15);
            this.metroLabel12.TabIndex = 38;
            this.metroLabel12.Text = "Stitch Fullscreen Captures";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.BasePaint = false;
            this.metroLabel6.Location = new System.Drawing.Point(10, 10);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Scaled = true;
            this.metroLabel6.Size = new System.Drawing.Size(81, 15);
            this.metroLabel6.TabIndex = 36;
            this.metroLabel6.Text = "Image Codec";
            // 
            // stitchFullscreenToggle
            // 
            this.stitchFullscreenToggle.AutoSize = true;
            this.stitchFullscreenToggle.BasePaint = false;
            this.stitchFullscreenToggle.Location = new System.Drawing.Point(263, 98);
            this.stitchFullscreenToggle.Name = "stitchFullscreenToggle";
            this.stitchFullscreenToggle.Scaled = true;
            this.stitchFullscreenToggle.Size = new System.Drawing.Size(50, 21);
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
            this.imageCodecCombo.Location = new System.Drawing.Point(178, 7);
            this.imageCodecCombo.Name = "imageCodecCombo";
            this.imageCodecCombo.Scaled = true;
            this.imageCodecCombo.Size = new System.Drawing.Size(128, 21);
            this.imageCodecCombo.TabIndex = 31;
            // 
            // imageCompressionToggle
            // 
            this.imageCompressionToggle.AutoSize = true;
            this.imageCompressionToggle.BasePaint = false;
            this.imageCompressionToggle.Location = new System.Drawing.Point(263, 38);
            this.imageCompressionToggle.Name = "imageCompressionToggle";
            this.imageCompressionToggle.Scaled = true;
            this.imageCompressionToggle.Size = new System.Drawing.Size(50, 21);
            this.imageCompressionToggle.TabIndex = 32;
            this.imageCompressionToggle.Text = "Off";
            this.imageCompressionToggle.UseVisualStyleBackColor = false;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.BasePaint = false;
            this.metroLabel7.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroLabel7.Location = new System.Drawing.Point(10, 70);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Scaled = true;
            this.metroLabel7.Size = new System.Drawing.Size(84, 15);
            this.metroLabel7.TabIndex = 35;
            this.metroLabel7.Text = "Image Quality";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.BasePaint = false;
            this.metroLabel8.Location = new System.Drawing.Point(10, 40);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Scaled = true;
            this.metroLabel8.Size = new System.Drawing.Size(117, 15);
            this.metroLabel8.TabIndex = 33;
            this.metroLabel8.Text = "Image Compression";
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
            this.imageQualityCombo.Location = new System.Drawing.Point(178, 67);
            this.imageQualityCombo.Name = "imageQualityCombo";
            this.imageQualityCombo.Scaled = true;
            this.imageQualityCombo.Size = new System.Drawing.Size(128, 21);
            this.imageQualityCombo.TabIndex = 34;
            // 
            // metroTabPage4
            // 
            this.metroTabPage4.BasePaint = false;
            this.metroTabPage4.Controls.Add(this.metroPanel4);
            this.metroTabPage4.Location = new System.Drawing.Point(4, 29);
            this.metroTabPage4.Name = "metroTabPage4";
            this.metroTabPage4.Scaled = true;
            this.metroTabPage4.Size = new System.Drawing.Size(332, 266);
            this.metroTabPage4.TabIndex = 3;
            this.metroTabPage4.Text = "Recorder";
            // 
            // metroPanel4
            // 
            this.metroPanel4.BasePaint = false;
            this.metroPanel4.Controls.Add(this.themedBar16);
            this.metroPanel4.Controls.Add(this.qualityLabel);
            this.metroPanel4.Controls.Add(this.qualityCombo);
            this.metroPanel4.Controls.Add(this.themedBar15);
            this.metroPanel4.Controls.Add(this.themedBar14);
            this.metroPanel4.Controls.Add(this.themedBar13);
            this.metroPanel4.Controls.Add(this.themedBar1);
            this.metroPanel4.Controls.Add(this.metroLabel5);
            this.metroPanel4.Controls.Add(this.audioDeviceCombo);
            this.metroPanel4.Controls.Add(this.metroLabel4);
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
            this.metroPanel4.Size = new System.Drawing.Size(316, 255);
            this.metroPanel4.TabIndex = 53;
            // 
            // themedBar16
            // 
            this.themedBar16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.themedBar16.BasePaint = false;
            this.themedBar16.Location = new System.Drawing.Point(10, 92);
            this.themedBar16.Name = "themedBar16";
            this.themedBar16.Scaled = true;
            this.themedBar16.Size = new System.Drawing.Size(296, 1);
            this.themedBar16.TabIndex = 67;
            this.themedBar16.Text = "themedBar16";
            // 
            // qualityLabel
            // 
            this.qualityLabel.AutoSize = true;
            this.qualityLabel.BasePaint = false;
            this.qualityLabel.Location = new System.Drawing.Point(10, 70);
            this.qualityLabel.Name = "qualityLabel";
            this.qualityLabel.Scaled = true;
            this.qualityLabel.Size = new System.Drawing.Size(47, 15);
            this.qualityLabel.TabIndex = 66;
            this.qualityLabel.Text = "Quality";
            // 
            // qualityComboBox1
            // 
            this.qualityCombo.BasePaint = false;
            this.qualityCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.qualityCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qualityCombo.FormattingEnabled = true;
            this.qualityCombo.ItemHeight = 15;
            this.qualityCombo.Items.AddRange(new object[] {
            "ultrafast",
            "superfast",
            "veryfast",
            "faster",
            "fast",
            "medium",
            "slow",
            "slower",
            "veryslow"});
            this.qualityCombo.Location = new System.Drawing.Point(178, 67);
            this.qualityCombo.Name = "qualityComboBox1";
            this.qualityCombo.Scaled = true;
            this.qualityCombo.Size = new System.Drawing.Size(128, 21);
            this.qualityCombo.TabIndex = 65;
            // 
            // themedBar15
            // 
            this.themedBar15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.themedBar15.BasePaint = false;
            this.themedBar15.Location = new System.Drawing.Point(10, 152);
            this.themedBar15.Name = "themedBar15";
            this.themedBar15.Scaled = true;
            this.themedBar15.Size = new System.Drawing.Size(296, 1);
            this.themedBar15.TabIndex = 64;
            this.themedBar15.Text = "themedBar15";
            // 
            // themedBar14
            // 
            this.themedBar14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.themedBar14.BasePaint = false;
            this.themedBar14.Location = new System.Drawing.Point(10, 122);
            this.themedBar14.Name = "themedBar14";
            this.themedBar14.Scaled = true;
            this.themedBar14.Size = new System.Drawing.Size(296, 1);
            this.themedBar14.TabIndex = 63;
            this.themedBar14.Text = "themedBar14";
            // 
            // themedBar13
            // 
            this.themedBar13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.themedBar13.BasePaint = false;
            this.themedBar13.Location = new System.Drawing.Point(10, 62);
            this.themedBar13.Name = "themedBar13";
            this.themedBar13.Scaled = true;
            this.themedBar13.Size = new System.Drawing.Size(296, 1);
            this.themedBar13.TabIndex = 62;
            this.themedBar13.Text = "themedBar13";
            // 
            // themedBar1
            // 
            this.themedBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.themedBar1.BasePaint = false;
            this.themedBar1.Location = new System.Drawing.Point(10, 32);
            this.themedBar1.Name = "themedBar1";
            this.themedBar1.Scaled = true;
            this.themedBar1.Size = new System.Drawing.Size(296, 1);
            this.themedBar1.TabIndex = 61;
            this.themedBar1.Text = "themedBar1";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.BasePaint = false;
            this.metroLabel5.Location = new System.Drawing.Point(10, 130);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Scaled = true;
            this.metroLabel5.Size = new System.Drawing.Size(82, 15);
            this.metroLabel5.TabIndex = 48;
            this.metroLabel5.Text = "Audio Device";
            // 
            // audioDeviceCombo
            // 
            this.audioDeviceCombo.BasePaint = false;
            this.audioDeviceCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.audioDeviceCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.audioDeviceCombo.FormattingEnabled = true;
            this.audioDeviceCombo.ItemHeight = 15;
            this.audioDeviceCombo.Location = new System.Drawing.Point(178, 127);
            this.audioDeviceCombo.Name = "audioDeviceCombo";
            this.audioDeviceCombo.Scaled = true;
            this.audioDeviceCombo.Size = new System.Drawing.Size(128, 21);
            this.audioDeviceCombo.TabIndex = 47;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.BasePaint = false;
            this.metroLabel4.Location = new System.Drawing.Point(10, 100);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Scaled = true;
            this.metroLabel4.Size = new System.Drawing.Size(82, 15);
            this.metroLabel4.TabIndex = 46;
            this.metroLabel4.Text = "Record Audio";
            // 
            // recordAudioToggle
            // 
            this.recordAudioToggle.AutoSize = true;
            this.recordAudioToggle.BasePaint = false;
            this.recordAudioToggle.Location = new System.Drawing.Point(263, 98);
            this.recordAudioToggle.Name = "recordAudioToggle";
            this.recordAudioToggle.Scaled = true;
            this.recordAudioToggle.Size = new System.Drawing.Size(50, 21);
            this.recordAudioToggle.TabIndex = 45;
            this.recordAudioToggle.Text = "Off";
            this.recordAudioToggle.UseVisualStyleBackColor = false;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BasePaint = false;
            this.metroLabel3.Location = new System.Drawing.Point(10, 10);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Scaled = true;
            this.metroLabel3.Size = new System.Drawing.Size(64, 15);
            this.metroLabel3.TabIndex = 44;
            this.metroLabel3.Text = "Framerate";
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
            this.framerateCombo.Location = new System.Drawing.Point(178, 7);
            this.framerateCombo.Name = "framerateCombo";
            this.framerateCombo.Scaled = true;
            this.framerateCombo.Size = new System.Drawing.Size(128, 21);
            this.framerateCombo.TabIndex = 39;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BasePaint = false;
            this.metroLabel1.Location = new System.Drawing.Point(10, 40);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Scaled = true;
            this.metroLabel1.Size = new System.Drawing.Size(108, 15);
            this.metroLabel1.TabIndex = 43;
            this.metroLabel1.Text = "Encoding Threads";
            // 
            // recordCursorToggle
            // 
            this.recordCursorToggle.AutoSize = true;
            this.recordCursorToggle.BasePaint = false;
            this.recordCursorToggle.Location = new System.Drawing.Point(263, 158);
            this.recordCursorToggle.Name = "recordCursorToggle";
            this.recordCursorToggle.Scaled = true;
            this.recordCursorToggle.Size = new System.Drawing.Size(50, 21);
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
            this.encodingCombo.Location = new System.Drawing.Point(178, 37);
            this.encodingCombo.Name = "encodingCombo";
            this.encodingCombo.Scaled = true;
            this.encodingCombo.Size = new System.Drawing.Size(128, 21);
            this.encodingCombo.TabIndex = 42;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BasePaint = false;
            this.metroLabel2.Location = new System.Drawing.Point(10, 160);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Scaled = true;
            this.metroLabel2.Size = new System.Drawing.Size(87, 15);
            this.metroLabel2.TabIndex = 41;
            this.metroLabel2.Text = "Record Cursor";
            // 
            // dpiScaledPictureBox1
            // 
            this.dpiScaledPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.dpiScaledPictureBox1.BackgroundImage = global::Shotr.Ui.Properties.Resources.shotr_logo_banner;
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
            this.ClientSize = new System.Drawing.Size(343, 358);
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
        private ThemedTextBox saveToDirectoryPathTextBox;
        private ThemedLabel metroLabel10;
        private ThemedToggle saveToDirectoryToggle;
        private ThemedPanel metroPanel2;
        private ThemedLabel metroLabel13;
        private ThemedToggle soundToggle;
        private ThemedToggle startupToggle;
        private ThemedLabel metroLabel15;
        private ThemedLabel metroLabel16;
        private ThemedToggle minimizedToggle;
        private ThemedLabel metroLabel17;
        private ThemedToggle alphaToggle;
        private ThemedPanel metroPanel3;
        private ThemedPanel metroPanel4;
        private ThemedLabel metroLabel18;
        private ThemedToggle useresizablecanvas;
        private DpiScaledPictureBox dpiScaledPictureBox1;
        private ThemedButton chooseSaveToDirectoryButton;
        private ThemedBar themedBar4;
        private ThemedBar themedBar7;
        private ThemedBar themedBar6;
        private ThemedBar themedBar5;
        private ThemedBar themedBar3;
        private ThemedBar themedBar8;
        private ThemedBar themedBar2;
        private ThemedBar themedBar10;
        private ThemedBar themedBar9;
        private ThemedBar themedBar12;
        private ThemedBar themedBar11;
        private ThemedToggle directUrlToggle;
        private ThemedLabel themedLabel1;
        private ThemedLabel metroLabel9;
        private ThemedComboBox selectedImageUploader;
        private ThemedBar themedBar1;
        private ThemedBar themedBar15;
        private ThemedBar themedBar14;
        private ThemedBar themedBar13;
        private ThemedBar themedBar16;
        private ThemedLabel qualityLabel;
        private ThemedComboBox qualityCombo;
    }
}
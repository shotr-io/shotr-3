using System.ComponentModel;
using Shotr.Core.Controls.DpiScaling;
using Shotr.Core.Controls.Theme;

namespace Shotr.Ui.Forms
{
    partial class RecordingNotice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecordingNotice));
            this.metroLabel2 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.metroButton3 = new Shotr.Core.Controls.Theme.ThemedButton();
            this.metroCheckBox1 = new Shotr.Core.Controls.Theme.ThemedToggle();
            this.dpiScaledPictureBox1 = new Shotr.Core.Controls.DpiScaling.DpiScaledPictureBox();
            this.themedLabel1 = new Shotr.Core.Controls.Theme.ThemedLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dpiScaledPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel2
            // 
            this.metroLabel2.Location = new System.Drawing.Point(23, 54);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Scaled = true;
            this.metroLabel2.Size = new System.Drawing.Size(344, 65);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "You can press the hotkey for a video recording to \r\nstop recording in the case yo" +
    "u are recording your\r\nwhole screen or the bottom area.";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel2.UseCompatibleTextRendering = false;
            // 
            // metroButton3
            // 
            this.metroButton3.Highlight = false;
            this.metroButton3.Location = new System.Drawing.Point(147, 151);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Scaled = true;
            this.metroButton3.Size = new System.Drawing.Size(96, 28);
            this.metroButton3.TabIndex = 32;
            this.metroButton3.Text = "OK";
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.Location = new System.Drawing.Point(112, 122);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Scaled = true;
            this.metroCheckBox1.Size = new System.Drawing.Size(47, 22);
            this.metroCheckBox1.TabIndex = 33;
            this.metroCheckBox1.Text = "Don\'t show this again.";
            this.metroCheckBox1.UseVisualStyleBackColor = false;
            // 
            // dpiScaledPictureBox1
            // 
            this.dpiScaledPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.dpiScaledPictureBox1.BackgroundImage = Shotr.Ui.Properties.Resources.shotr_logo_banner;
            this.dpiScaledPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dpiScaledPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("dpiScaledPictureBox1.Image")));
            this.dpiScaledPictureBox1.Location = new System.Drawing.Point(124, 0);
            this.dpiScaledPictureBox1.Name = "dpiScaledPictureBox1";
            this.dpiScaledPictureBox1.Scaled = true;
            this.dpiScaledPictureBox1.Size = new System.Drawing.Size(143, 53);
            this.dpiScaledPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dpiScaledPictureBox1.TabIndex = 34;
            this.dpiScaledPictureBox1.TabStop = false;
            // 
            // themedLabel1
            // 
            this.themedLabel1.AutoSize = true;
            this.themedLabel1.Location = new System.Drawing.Point(165, 125);
            this.themedLabel1.Name = "themedLabel1";
            this.themedLabel1.Scaled = true;
            this.themedLabel1.Size = new System.Drawing.Size(130, 15);
            this.themedLabel1.TabIndex = 35;
            this.themedLabel1.Text = "Don\'t show this again.";
            this.themedLabel1.UseCompatibleTextRendering = false;
            // 
            // RecordingNotice
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(390, 191);
            this.Controls.Add(this.themedLabel1);
            this.Controls.Add(this.dpiScaledPictureBox1);
            this.Controls.Add(this.metroCheckBox1);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroLabel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecordingNotice";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notice";
            ((System.ComponentModel.ISupportInitialize)(this.dpiScaledPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ThemedLabel metroLabel2;
        private ThemedButton metroButton3;
        private ThemedToggle metroCheckBox1;
        private DpiScaledPictureBox dpiScaledPictureBox1;
        private ThemedLabel themedLabel1;
    }
}
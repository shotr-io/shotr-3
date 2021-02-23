using System.ComponentModel;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;
using Shotr.Core.Controls.Theme;

namespace Shotr.Ui.Forms
{
    partial class FfMpegDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FfMpegDownload));
            this.metroLabel1 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.metroProgressBar1 = new Shotr.Core.Controls.Theme.ThemedProgressBar();
            this.metroButton1 = new Shotr.Core.Controls.Theme.ThemedButton();
            this.dpiScaledPictureBox1 = new Shotr.Core.Controls.DpiScaling.DpiScaledPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dpiScaledPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.BasePaint = false;
            this.metroLabel1.Location = new System.Drawing.Point(9, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Scaled = true;
            this.metroLabel1.Size = new System.Drawing.Size(536, 23);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Shotr needs to download ffmpeg in order for screen recording to function.";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroProgressBar1
            // 
            this.metroProgressBar1.BasePaint = false;
            this.metroProgressBar1.Location = new System.Drawing.Point(14, 87);
            this.metroProgressBar1.MaxValue = 100;
            this.metroProgressBar1.Name = "metroProgressBar1";
            this.metroProgressBar1.Scaled = true;
            this.metroProgressBar1.Size = new System.Drawing.Size(531, 23);
            this.metroProgressBar1.TabIndex = 1;
            this.metroProgressBar1.Value = 0;
            // 
            // metroButton1
            // 
            this.metroButton1.BasePaint = false;
            this.metroButton1.Highlight = false;
            this.metroButton1.Location = new System.Drawing.Point(470, 116);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Scaled = true;
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.TabIndex = 2;
            this.metroButton1.Text = "Download";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
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
            this.dpiScaledPictureBox1.TabIndex = 3;
            this.dpiScaledPictureBox1.TabStop = false;
            // 
            // FfMpegDownload
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(559, 155);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroProgressBar1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.dpiScaledPictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FfMpegDownload";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Download ffmpeg";
            ((System.ComponentModel.ISupportInitialize)(this.dpiScaledPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ThemedLabel metroLabel1;
        private ThemedProgressBar metroProgressBar1;
        private ThemedButton metroButton1;
        private DpiScaledPictureBox dpiScaledPictureBox1;
    }
}
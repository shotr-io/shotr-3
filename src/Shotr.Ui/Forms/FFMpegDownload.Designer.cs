using System.ComponentModel;
using MetroFramework5.Controls;
using Shotr.Core.DpiScaling;

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
            this.metroLabel1 = new DpiScaledLabel();
            this.metroProgressBar1 = new MetroFramework5.Controls.MetroProgressBar();
            this.metroButton1 = new DpiScaledButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.Location = new System.Drawing.Point(18, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Scaled = true;
            this.metroLabel1.Size = new System.Drawing.Size(529, 23);
            this.metroLabel1.Style = "NewTheme";
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Shotr needs to download FFMPEG in order for screen recording to function.";
            this.metroLabel1.Theme = "NewTheme";
            // 
            // metroProgressBar1
            // 
            this.metroProgressBar1.Location = new System.Drawing.Point(23, 87);
            this.metroProgressBar1.Name = "metroProgressBar1";
            this.metroProgressBar1.Size = new System.Drawing.Size(513, 23);
            this.metroProgressBar1.Style = "NewTheme";
            this.metroProgressBar1.TabIndex = 1;
            this.metroProgressBar1.Theme = "NewTheme";
            // 
            // metroButton1
            // 
            this.metroButton1.FontSize = MetroFramework5.Drawing.MetroFontSize.Default;
            this.metroButton1.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Default;
            this.metroButton1.Location = new System.Drawing.Point(461, 116);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Scaled = true;
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.Style = "NewTheme";
            this.metroButton1.TabIndex = 2;
            this.metroButton1.Text = "Download";
            this.metroButton1.Theme = "NewTheme";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // FFMpegDownload
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(559, 155);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroProgressBar1);
            this.Controls.Add(this.metroLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FfMpegDownload";
            this.Resizable = false;
            this.ShadowType = MetroFramework5.Forms.MetroForm.MetroFormShadowType.DropShadow;
            this.ShowFormIcon = true;
            this.Style = "NewTheme";
            this.Text = "Download FFMPEG";
            this.Theme = "NewTheme";
            this.ResumeLayout(false);

        }

        #endregion

        private DpiScaledLabel metroLabel1;
        private MetroProgressBar metroProgressBar1;
        private DpiScaledButton metroButton1;
    }
}
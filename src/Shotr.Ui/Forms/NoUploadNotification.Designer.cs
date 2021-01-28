﻿using System.ComponentModel;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;
using Shotr.Core.Controls.Theme;

namespace Shotr.Ui.Forms
{
    partial class NoUploadNotification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoUploadNotification));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.metroLabel1 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.metroLabel2 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // metroLabel1
            // 
            this.metroLabel1.Location = new System.Drawing.Point(40, 14);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Scaled = true;
            this.metroLabel1.Size = new System.Drawing.Size(262, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Screenshot Saved!";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel1.UseCompatibleTextRendering = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.Location = new System.Drawing.Point(5, 49);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Scaled = true;
            this.metroLabel2.Size = new System.Drawing.Size(332, 33);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "The image has been copied to your clipboard.";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroLabel2.UseCompatibleTextRendering = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // NoUploadNotification
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(342, 88);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NoUploadNotification";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.Notification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Timer timer1;
        private ThemedLabel metroLabel1;
        private ThemedLabel metroLabel2;
        private PictureBox pictureBox1;
    }
}
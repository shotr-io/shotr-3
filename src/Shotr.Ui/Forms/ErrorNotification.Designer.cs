﻿using Shotr.Ui.DpiScaling;

namespace Shotr.Ui.Forms
{
    partial class ErrorNotification
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.metroLabel1 = new DpiScaledLabel();
            this.metroLabel2 = new DpiScaledLabel();
            this.metroButton1 = new DpiScaledButton();
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
            this.metroLabel1.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(41, 14);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Scaled = true;
            this.metroLabel1.Size = new System.Drawing.Size(262, 19);
            this.metroLabel1.Style = "NewTheme";
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Error!";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel1.Theme = "NewTheme";
            // 
            // metroLabel2
            // 
            this.metroLabel2.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel2.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Light;
            this.metroLabel2.Location = new System.Drawing.Point(5, 34);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Scaled = true;
            this.metroLabel2.Size = new System.Drawing.Size(332, 19);
            this.metroLabel2.Style = "NewTheme";
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "There was an error while uploading your screenshot.";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroLabel2.Theme = "NewTheme";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(133, 57);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Scaled = true;
            this.metroButton1.Size = new System.Drawing.Size(77, 23);
            this.metroButton1.Style = "NewTheme";
            this.metroButton1.TabIndex = 4;
            this.metroButton1.Text = "Retry";
            this.metroButton1.Theme = "NewTheme";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Shotr.Ui.Properties.Resources.shotr_icon1;
            this.pictureBox1.Location = new System.Drawing.Point(5, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // ErrorNotification
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = MetroFramework5.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(342, 88);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "ErrorNotification";
            this.Resizable = false;
            this.ShadowType = MetroFramework5.Forms.MetroForm.MetroFormShadowType.DropShadow;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Style = "NewTheme";
            this.Theme = "NewTheme";
            this.Load += new System.EventHandler(this.Notification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private DpiScaledLabel metroLabel1;
        private DpiScaledLabel metroLabel2;
        private DpiScaledButton metroButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
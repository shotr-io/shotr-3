using System.ComponentModel;
using System.Windows.Forms;
using Shotr.Core.Controls.Theme;
using Shotr.Core.Controls.DpiScaling;


namespace Shotr.Ui.Forms
{
    partial class ErrorNotification
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.metroLabel1 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.metroLabel2 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.metroButton1 = new Shotr.Core.Controls.Theme.ThemedButton();
            this.pictureBox1 = new Shotr.Core.Controls.DpiScaling.DpiScaledPictureBox();
            this.themedButton1 = new Shotr.Core.Controls.Theme.ThemedButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // metroLabel1
            // 
            this.metroLabel1.BasePaint = false;
            this.metroLabel1.Location = new System.Drawing.Point(41, 14);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Scaled = true;
            this.metroLabel1.Size = new System.Drawing.Size(262, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Error!";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel1.UseCompatibleTextRendering = false;
            // 
            // metroLabel2
            // 
            this.metroLabel2.BasePaint = false;
            this.metroLabel2.Location = new System.Drawing.Point(5, 34);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Scaled = true;
            this.metroLabel2.Size = new System.Drawing.Size(332, 19);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "There was an error while uploading your screenshot.";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroLabel2.UseCompatibleTextRendering = false;
            // 
            // metroButton1
            // 
            this.metroButton1.BasePaint = false;
            this.metroButton1.Highlight = false;
            this.metroButton1.Location = new System.Drawing.Point(133, 57);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Scaled = true;
            this.metroButton1.Size = new System.Drawing.Size(77, 23);
            this.metroButton1.TabIndex = 4;
            this.metroButton1.Text = "Retry";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = Shotr.Ui.Properties.Resources.shotr_icon;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BasePaint = false;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Scaled = true;
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // themedButton1
            // 
            this.themedButton1.BasePaint = false;
            this.themedButton1.Highlight = false;
            this.themedButton1.Location = new System.Drawing.Point(316, 5);
            this.themedButton1.Name = "themedButton1";
            this.themedButton1.Scaled = true;
            this.themedButton1.Size = new System.Drawing.Size(21, 16);
            this.themedButton1.TabIndex = 6;
            this.themedButton1.Text = "X";
            this.themedButton1.UseVisualStyleBackColor = true;
            this.themedButton1.Click += new System.EventHandler(this.themedButton1_Click);
            // 
            // ErrorNotification
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(342, 88);
            this.Controls.Add(this.themedButton1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorNotification";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.Notification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Timer timer1;
        private ThemedLabel metroLabel1;
        private ThemedLabel metroLabel2;
        private ThemedButton metroButton1;
        private DpiScaledPictureBox pictureBox1;
        private ThemedButton themedButton1;
    }
}
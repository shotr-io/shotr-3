using System.ComponentModel;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;
using Shotr.Core.Controls.Theme;

namespace Shotr.Ui.Forms
{
    partial class Notification
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
            this.metroLink1 = new Shotr.Core.Controls.Theme.ThemedLinkLabel();
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
            this.metroLabel1.Location = new System.Drawing.Point(40, 14);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Scaled = true;
            this.metroLabel1.Size = new System.Drawing.Size(262, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Screenshot Uploaded!";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel1.UseCompatibleTextRendering = false;
            // 
            // metroLabel2
            // 
            this.metroLabel2.BasePaint = false;
            this.metroLabel2.Location = new System.Drawing.Point(23, 37);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Scaled = true;
            this.metroLabel2.Size = new System.Drawing.Size(296, 19);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "The link has been copied to your clipboard.";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroLabel2.UseCompatibleTextRendering = false;
            // 
            // metroLink1
            // 
            this.metroLink1.BasePaint = false;
            this.metroLink1.Location = new System.Drawing.Point(40, 61);
            this.metroLink1.Name = "metroLink1";
            this.metroLink1.Scaled = true;
            this.metroLink1.Size = new System.Drawing.Size(262, 14);
            this.metroLink1.TabIndex = 2;
            this.metroLink1.TabStop = true;
            this.metroLink1.Text = "link";
            this.metroLink1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLink1.Click += new System.EventHandler(this.metroLink1_Click);
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
            this.pictureBox1.TabIndex = 3;
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
            this.themedButton1.TabIndex = 4;
            this.themedButton1.Text = "X";
            this.themedButton1.UseVisualStyleBackColor = true;
            // 
            // Notification
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(342, 88);
            this.Controls.Add(this.themedButton1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.metroLink1);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Notification";
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
        private ThemedLinkLabel metroLink1;
        private DpiScaledPictureBox pictureBox1;
        private ThemedButton themedButton1;
    }
}
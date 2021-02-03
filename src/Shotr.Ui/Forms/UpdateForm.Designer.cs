using System.ComponentModel;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;
using Shotr.Core.Controls.Theme;

namespace Shotr.Ui.Forms
{
    partial class UpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            this.metroTextBox1 = new Shotr.Core.Controls.Theme.ThemedTextBox();
            this.metroLabel1 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.metroButton1 = new Shotr.Core.Controls.Theme.ThemedButton();
            this.metroButton2 = new Shotr.Core.Controls.Theme.ThemedButton();
            this.metroLabel2 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.dpiScaledPictureBox1 = new Shotr.Core.Controls.DpiScaling.DpiScaledPictureBox();
            this.themedProgressBar1 = new Shotr.Core.Controls.Theme.ThemedProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dpiScaledPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTextBox1
            // 
            this.metroTextBox1.BasePaint = false;
            this.metroTextBox1.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroTextBox1.Location = new System.Drawing.Point(16, 90);
            this.metroTextBox1.Multiline = true;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.ReadOnly = true;
            this.metroTextBox1.Scaled = true;
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.metroTextBox1.Size = new System.Drawing.Size(420, 154);
            this.metroTextBox1.TabIndex = 2;
            this.metroTextBox1.TabStop = false;
            this.metroTextBox1.Text = "New Stuff has been Added.";
            this.metroTextBox1.UseSystemPasswordChar = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BasePaint = false;
            this.metroLabel1.Location = new System.Drawing.Point(13, 69);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Scaled = true;
            this.metroLabel1.Size = new System.Drawing.Size(91, 15);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Release Notes:";
            this.metroLabel1.UseCompatibleTextRendering = false;
            // 
            // metroButton1
            // 
            this.metroButton1.BasePaint = false;
            this.metroButton1.Highlight = false;
            this.metroButton1.Location = new System.Drawing.Point(280, 63);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Scaled = true;
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.TabIndex = 2;
            this.metroButton1.Text = "Update";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.BasePaint = false;
            this.metroButton2.Highlight = false;
            this.metroButton2.Location = new System.Drawing.Point(361, 63);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Scaled = true;
            this.metroButton2.Size = new System.Drawing.Size(75, 23);
            this.metroButton2.TabIndex = 3;
            this.metroButton2.Text = "Close";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.BasePaint = false;
            this.metroLabel2.Location = new System.Drawing.Point(191, 44);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Scaled = true;
            this.metroLabel2.Size = new System.Drawing.Size(250, 15);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "A new update is available.";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel2.UseCompatibleTextRendering = false;
            // 
            // dpiScaledPictureBox1
            // 
            this.dpiScaledPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.dpiScaledPictureBox1.BackgroundImage = Shotr.Ui.Properties.Resources.shotr_logo_banner;
            this.dpiScaledPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dpiScaledPictureBox1.BasePaint = false;
            this.dpiScaledPictureBox1.Location = new System.Drawing.Point(8, 11);
            this.dpiScaledPictureBox1.Name = "dpiScaledPictureBox1";
            this.dpiScaledPictureBox1.Scaled = true;
            this.dpiScaledPictureBox1.Size = new System.Drawing.Size(143, 53);
            this.dpiScaledPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dpiScaledPictureBox1.TabIndex = 6;
            this.dpiScaledPictureBox1.TabStop = false;
            // 
            // themedProgressBar1
            // 
            this.themedProgressBar1.BasePaint = false;
            this.themedProgressBar1.Location = new System.Drawing.Point(157, 27);
            this.themedProgressBar1.MaxValue = 100;
            this.themedProgressBar1.Name = "themedProgressBar1";
            this.themedProgressBar1.Scaled = true;
            this.themedProgressBar1.Size = new System.Drawing.Size(198, 23);
            this.themedProgressBar1.TabIndex = 7;
            this.themedProgressBar1.Text = "themedProgressBar1";
            this.themedProgressBar1.Value = 0;
            this.themedProgressBar1.Visible = false;
            // 
            // UpdateForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(451, 260);
            this.Controls.Add(this.themedProgressBar1);
            this.Controls.Add(this.dpiScaledPictureBox1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroTextBox1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UpdateForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shotr Updater";
            this.Load += new System.EventHandler(this.UpdateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dpiScaledPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ThemedTextBox metroTextBox1;
        private ThemedLabel metroLabel1;
        private ThemedButton metroButton1;
        private ThemedButton metroButton2;
        private ThemedLabel metroLabel2;
        private DpiScaledPictureBox dpiScaledPictureBox1;
        private ThemedProgressBar themedProgressBar1;
    }
}
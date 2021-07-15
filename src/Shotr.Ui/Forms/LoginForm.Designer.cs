using System.ComponentModel;
using Shotr.Core.Controls.DpiScaling;
using Shotr.Core.Controls.Theme;

namespace Shotr.Ui.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.ThemedButton1 = new Shotr.Core.Controls.Theme.ThemedButton();
            this.ThemedLabel1 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.emailTextBox = new Shotr.Core.Controls.Theme.ThemedTextBox();
            this.passwordTextBox = new Shotr.Core.Controls.Theme.ThemedTextBox();
            this.ThemedLabel2 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.ThemedLabel3 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.ThemedToggle1 = new Shotr.Core.Controls.Theme.ThemedToggle();
            this.ThemedLinkLabel1 = new Shotr.Core.Controls.Theme.ThemedLinkLabel();
            this.ThemedLinkLabel2 = new Shotr.Core.Controls.Theme.ThemedLinkLabel();
            this.dpiScaledPictureBox1 = new Shotr.Core.Controls.DpiScaling.DpiScaledPictureBox();
            this.themedLabel4 = new Shotr.Core.Controls.Theme.ThemedLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dpiScaledPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ThemedButton1
            // 
            this.ThemedButton1.BasePaint = false;
            this.ThemedButton1.Highlight = false;
            this.ThemedButton1.Location = new System.Drawing.Point(14, 259);
            this.ThemedButton1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ThemedButton1.Name = "ThemedButton1";
            this.ThemedButton1.Scaled = true;
            this.ThemedButton1.Size = new System.Drawing.Size(413, 28);
            this.ThemedButton1.TabIndex = 0;
            this.ThemedButton1.Text = "Sign in";
            this.ThemedButton1.Click += new System.EventHandler(this.ThemedButton1_Click);
            // 
            // ThemedLabel1
            // 
            this.ThemedLabel1.BasePaint = false;
            this.ThemedLabel1.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ThemedLabel1.Location = new System.Drawing.Point(27, 86);
            this.ThemedLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ThemedLabel1.Name = "ThemedLabel1";
            this.ThemedLabel1.Scaled = true;
            this.ThemedLabel1.Size = new System.Drawing.Size(387, 29);
            this.ThemedLabel1.TabIndex = 1;
            this.ThemedLabel1.Text = "Sign in to your account";
            this.ThemedLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ThemedLabel1.UseCompatibleTextRendering = false;
            // 
            // ThemedTextBox1
            // 
            this.emailTextBox.BasePaint = false;
            this.emailTextBox.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.emailTextBox.Location = new System.Drawing.Point(14, 144);
            this.emailTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.emailTextBox.Multiline = false;
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.ReadOnly = false;
            this.emailTextBox.Scaled = true;
            this.emailTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.emailTextBox.Size = new System.Drawing.Size(413, 25);
            this.emailTextBox.TabIndex = 2;
            this.emailTextBox.TabStop = false;
            this.emailTextBox.UseSystemPasswordChar = false;
            // 
            // ThemedTextBox2
            // 
            this.passwordTextBox.BasePaint = false;
            this.passwordTextBox.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.passwordTextBox.Location = new System.Drawing.Point(14, 196);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.passwordTextBox.Multiline = false;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.ReadOnly = false;
            this.passwordTextBox.Scaled = true;
            this.passwordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passwordTextBox.Size = new System.Drawing.Size(413, 25);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.TabStop = false;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // ThemedLabel2
            // 
            this.ThemedLabel2.AutoSize = true;
            this.ThemedLabel2.BasePaint = false;
            this.ThemedLabel2.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ThemedLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ThemedLabel2.Location = new System.Drawing.Point(10, 126);
            this.ThemedLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ThemedLabel2.Name = "ThemedLabel2";
            this.ThemedLabel2.Scaled = true;
            this.ThemedLabel2.Size = new System.Drawing.Size(88, 15);
            this.ThemedLabel2.TabIndex = 4;
            this.ThemedLabel2.Text = "Email Address:";
            this.ThemedLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ThemedLabel2.UseCompatibleTextRendering = false;
            // 
            // ThemedLabel3
            // 
            this.ThemedLabel3.AutoSize = true;
            this.ThemedLabel3.BasePaint = false;
            this.ThemedLabel3.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ThemedLabel3.Location = new System.Drawing.Point(10, 178);
            this.ThemedLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ThemedLabel3.Name = "ThemedLabel3";
            this.ThemedLabel3.Scaled = true;
            this.ThemedLabel3.Size = new System.Drawing.Size(65, 15);
            this.ThemedLabel3.TabIndex = 5;
            this.ThemedLabel3.Text = "Password:";
            this.ThemedLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ThemedLabel3.UseCompatibleTextRendering = false;
            // 
            // ThemedToggle1
            // 
            this.ThemedToggle1.BasePaint = false;
            this.ThemedToggle1.Location = new System.Drawing.Point(14, 229);
            this.ThemedToggle1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ThemedToggle1.Name = "ThemedToggle1";
            this.ThemedToggle1.Scaled = true;
            this.ThemedToggle1.Size = new System.Drawing.Size(55, 22);
            this.ThemedToggle1.TabIndex = 6;
            this.ThemedToggle1.Text = "Remember me";
            this.ThemedToggle1.UseVisualStyleBackColor = false;
            // 
            // ThemedLinkLabel1
            // 
            this.ThemedLinkLabel1.AutoSize = true;
            this.ThemedLinkLabel1.BasePaint = false;
            this.ThemedLinkLabel1.Location = new System.Drawing.Point(324, 231);
            this.ThemedLinkLabel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ThemedLinkLabel1.Name = "ThemedLinkLabel1";
            this.ThemedLinkLabel1.Scaled = true;
            this.ThemedLinkLabel1.Size = new System.Drawing.Size(107, 15);
            this.ThemedLinkLabel1.TabIndex = 8;
            this.ThemedLinkLabel1.TabStop = true;
            this.ThemedLinkLabel1.Text = "Forgot Password?";
            this.ThemedLinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ThemedLinkLabel1.Click += new System.EventHandler(this.ThemedLinkLabel1_Click);
            // 
            // ThemedLinkLabel2
            // 
            this.ThemedLinkLabel2.BasePaint = false;
            this.ThemedLinkLabel2.Location = new System.Drawing.Point(14, 302);
            this.ThemedLinkLabel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ThemedLinkLabel2.Name = "ThemedLinkLabel2";
            this.ThemedLinkLabel2.Scaled = true;
            this.ThemedLinkLabel2.Size = new System.Drawing.Size(413, 27);
            this.ThemedLinkLabel2.TabIndex = 9;
            this.ThemedLinkLabel2.TabStop = true;
            this.ThemedLinkLabel2.Text = "Don\'t have an account? Click here!";
            this.ThemedLinkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ThemedLinkLabel2.Click += new System.EventHandler(this.ThemedLinkLabel2_Click);
            // 
            // dpiScaledPictureBox1
            // 
            this.dpiScaledPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.dpiScaledPictureBox1.BackgroundImage = Shotr.Ui.Properties.Resources.shotr_logo_banner;
            this.dpiScaledPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dpiScaledPictureBox1.BasePaint = false;
            this.dpiScaledPictureBox1.Location = new System.Drawing.Point(124, 13);
            this.dpiScaledPictureBox1.Name = "dpiScaledPictureBox1";
            this.dpiScaledPictureBox1.Scaled = true;
            this.dpiScaledPictureBox1.Size = new System.Drawing.Size(187, 70);
            this.dpiScaledPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dpiScaledPictureBox1.TabIndex = 10;
            this.dpiScaledPictureBox1.TabStop = false;
            // 
            // themedLabel4
            // 
            this.themedLabel4.AutoSize = true;
            this.themedLabel4.BasePaint = false;
            this.themedLabel4.Location = new System.Drawing.Point(76, 232);
            this.themedLabel4.Name = "themedLabel4";
            this.themedLabel4.Scaled = true;
            this.themedLabel4.Size = new System.Drawing.Size(88, 15);
            this.themedLabel4.TabIndex = 11;
            this.themedLabel4.Text = "Remember Me";
            this.themedLabel4.UseCompatibleTextRendering = false;
            // 
            // LoginForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(441, 340);
            this.Controls.Add(this.themedLabel4);
            this.Controls.Add(this.dpiScaledPictureBox1);
            this.Controls.Add(this.ThemedLinkLabel2);
            this.Controls.Add(this.ThemedLinkLabel1);
            this.Controls.Add(this.ThemedToggle1);
            this.Controls.Add(this.ThemedLabel3);
            this.Controls.Add(this.ThemedLabel2);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.ThemedLabel1);
            this.Controls.Add(this.ThemedButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shotr";
            ((System.ComponentModel.ISupportInitialize)(this.dpiScaledPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ThemedButton ThemedButton1;
        private ThemedLabel ThemedLabel1;
        private ThemedTextBox emailTextBox;
        private ThemedTextBox passwordTextBox;
        private ThemedLabel ThemedLabel2;
        private ThemedLabel ThemedLabel3;
        private ThemedToggle ThemedToggle1;
        private ThemedLinkLabel ThemedLinkLabel1;
        private ThemedLinkLabel ThemedLinkLabel2;
        private DpiScaledPictureBox dpiScaledPictureBox1;
        private ThemedLabel themedLabel4;
    }
}
using System.ComponentModel;
using Shotr.Core.Controls.DpiScaling;

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
            this.dpiScaledButton1 = new Shotr.Core.Controls.DpiScaling.DpiScaledButton();
            this.dpiScaledLabel1 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.dpiScaledTextbox1 = new Shotr.Core.Controls.DpiScaling.DpiScaledTextbox();
            this.dpiScaledTextbox2 = new Shotr.Core.Controls.DpiScaling.DpiScaledTextbox();
            this.dpiScaledLabel2 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.dpiScaledLabel3 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.dpiScaledCheckbox1 = new Shotr.Core.Controls.DpiScaling.DpiScaledCheckbox();
            this.dpiScaledLinkLabel1 = new Shotr.Core.Controls.DpiScaling.DpiScaledLinkLabel();
            this.dpiScaledLinkLabel2 = new Shotr.Core.Controls.DpiScaling.DpiScaledLinkLabel();
            this.dpiScaledPictureBox1 = new Shotr.Core.Controls.DpiScaling.DpiScaledPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dpiScaledPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dpiScaledButton1
            // 
            this.dpiScaledButton1.FontSize = MetroFramework5.Drawing.MetroFontSize.Default;
            this.dpiScaledButton1.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Regular;
            this.dpiScaledButton1.Location = new System.Drawing.Point(14, 259);
            this.dpiScaledButton1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dpiScaledButton1.Name = "dpiScaledButton1";
            this.dpiScaledButton1.Scaled = true;
            this.dpiScaledButton1.Size = new System.Drawing.Size(413, 28);
            this.dpiScaledButton1.Style = "NewTheme";
            this.dpiScaledButton1.TabIndex = 0;
            this.dpiScaledButton1.Text = "Sign in";
            this.dpiScaledButton1.Theme = "NewTheme";
            this.dpiScaledButton1.Click += new System.EventHandler(this.dpiScaledButton1_Click);
            // 
            // dpiScaledLabel1
            // 
            this.dpiScaledLabel1.FontSize = MetroFramework5.Drawing.MetroFontSize.Large;
            this.dpiScaledLabel1.Location = new System.Drawing.Point(27, 86);
            this.dpiScaledLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dpiScaledLabel1.Name = "dpiScaledLabel1";
            this.dpiScaledLabel1.Scaled = true;
            this.dpiScaledLabel1.Size = new System.Drawing.Size(387, 29);
            this.dpiScaledLabel1.Style = "NewTheme";
            this.dpiScaledLabel1.TabIndex = 1;
            this.dpiScaledLabel1.Text = "Sign in to your account";
            this.dpiScaledLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dpiScaledLabel1.Theme = "NewTheme";
            this.dpiScaledLabel1.UseCompatibleTextRendering = true;
            // 
            // dpiScaledTextbox1
            // 
            this.dpiScaledTextbox1.Location = new System.Drawing.Point(14, 144);
            this.dpiScaledTextbox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dpiScaledTextbox1.Name = "dpiScaledTextbox1";
            this.dpiScaledTextbox1.Size = new System.Drawing.Size(413, 23);
            this.dpiScaledTextbox1.Style = "NewTheme";
            this.dpiScaledTextbox1.TabIndex = 2;
            this.dpiScaledTextbox1.Theme = "NewTheme";
            // 
            // dpiScaledTextbox2
            // 
            this.dpiScaledTextbox2.Location = new System.Drawing.Point(14, 199);
            this.dpiScaledTextbox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dpiScaledTextbox2.Name = "dpiScaledTextbox2";
            this.dpiScaledTextbox2.PasswordChar = '*';
            this.dpiScaledTextbox2.Size = new System.Drawing.Size(413, 23);
            this.dpiScaledTextbox2.Style = "NewTheme";
            this.dpiScaledTextbox2.TabIndex = 3;
            this.dpiScaledTextbox2.Theme = "NewTheme";
            // 
            // dpiScaledLabel2
            // 
            this.dpiScaledLabel2.FontSize = MetroFramework5.Drawing.MetroFontSize.Medium;
            this.dpiScaledLabel2.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Light;
            this.dpiScaledLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dpiScaledLabel2.Location = new System.Drawing.Point(9, 115);
            this.dpiScaledLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dpiScaledLabel2.Name = "dpiScaledLabel2";
            this.dpiScaledLabel2.Scaled = true;
            this.dpiScaledLabel2.Size = new System.Drawing.Size(144, 29);
            this.dpiScaledLabel2.Style = "NewTheme";
            this.dpiScaledLabel2.TabIndex = 4;
            this.dpiScaledLabel2.Text = "Email address:";
            this.dpiScaledLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dpiScaledLabel2.Theme = "NewTheme";
            this.dpiScaledLabel2.UseCompatibleTextRendering = true;
            // 
            // dpiScaledLabel3
            // 
            this.dpiScaledLabel3.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Light;
            this.dpiScaledLabel3.Location = new System.Drawing.Point(9, 169);
            this.dpiScaledLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dpiScaledLabel3.Name = "dpiScaledLabel3";
            this.dpiScaledLabel3.Scaled = true;
            this.dpiScaledLabel3.Size = new System.Drawing.Size(102, 29);
            this.dpiScaledLabel3.Style = "NewTheme";
            this.dpiScaledLabel3.TabIndex = 5;
            this.dpiScaledLabel3.Text = "Password:";
            this.dpiScaledLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dpiScaledLabel3.Theme = "NewTheme";
            this.dpiScaledLabel3.UseCompatibleTextRendering = true;
            // 
            // dpiScaledCheckbox1
            // 
            this.dpiScaledCheckbox1.AutoSize = true;
            this.dpiScaledCheckbox1.Location = new System.Drawing.Point(14, 229);
            this.dpiScaledCheckbox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dpiScaledCheckbox1.Name = "dpiScaledCheckbox1";
            this.dpiScaledCheckbox1.Size = new System.Drawing.Size(113, 22);
            this.dpiScaledCheckbox1.Style = "NewTheme";
            this.dpiScaledCheckbox1.TabIndex = 6;
            this.dpiScaledCheckbox1.Text = "Remember me";
            this.dpiScaledCheckbox1.Theme = "NewTheme";
            this.dpiScaledCheckbox1.UseVisualStyleBackColor = false;
            // 
            // dpiScaledLinkLabel1
            // 
            this.dpiScaledLinkLabel1.Location = new System.Drawing.Point(288, 226);
            this.dpiScaledLinkLabel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dpiScaledLinkLabel1.Name = "dpiScaledLinkLabel1";
            this.dpiScaledLinkLabel1.Scaled = true;
            this.dpiScaledLinkLabel1.Size = new System.Drawing.Size(142, 27);
            this.dpiScaledLinkLabel1.Style = "NewTheme";
            this.dpiScaledLinkLabel1.TabIndex = 8;
            this.dpiScaledLinkLabel1.Text = "Forgot Password?";
            this.dpiScaledLinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dpiScaledLinkLabel1.Theme = "NewTheme";
            this.dpiScaledLinkLabel1.UseVisualStyleBackColor = false;
            this.dpiScaledLinkLabel1.Click += new System.EventHandler(this.dpiScaledLinkLabel1_Click);
            // 
            // dpiScaledLinkLabel2
            // 
            this.dpiScaledLinkLabel2.Location = new System.Drawing.Point(14, 309);
            this.dpiScaledLinkLabel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dpiScaledLinkLabel2.Name = "dpiScaledLinkLabel2";
            this.dpiScaledLinkLabel2.Scaled = true;
            this.dpiScaledLinkLabel2.Size = new System.Drawing.Size(413, 27);
            this.dpiScaledLinkLabel2.Style = "NewTheme";
            this.dpiScaledLinkLabel2.TabIndex = 9;
            this.dpiScaledLinkLabel2.Text = "Don\'t have an account? Click here!";
            this.dpiScaledLinkLabel2.Theme = "NewTheme";
            this.dpiScaledLinkLabel2.UseVisualStyleBackColor = false;
            this.dpiScaledLinkLabel2.Click += new System.EventHandler(this.dpiScaledLinkLabel2_Click);
            // 
            // dpiScaledPictureBox1
            // 
            this.dpiScaledPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.dpiScaledPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("dpiScaledPictureBox1.Image")));
            this.dpiScaledPictureBox1.Location = new System.Drawing.Point(124, 13);
            this.dpiScaledPictureBox1.Name = "dpiScaledPictureBox1";
            this.dpiScaledPictureBox1.Scaled = true;
            this.dpiScaledPictureBox1.Size = new System.Drawing.Size(187, 70);
            this.dpiScaledPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dpiScaledPictureBox1.TabIndex = 10;
            this.dpiScaledPictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 340);
            this.Controls.Add(this.dpiScaledPictureBox1);
            this.Controls.Add(this.dpiScaledLinkLabel2);
            this.Controls.Add(this.dpiScaledLinkLabel1);
            this.Controls.Add(this.dpiScaledCheckbox1);
            this.Controls.Add(this.dpiScaledLabel3);
            this.Controls.Add(this.dpiScaledLabel2);
            this.Controls.Add(this.dpiScaledTextbox2);
            this.Controls.Add(this.dpiScaledTextbox1);
            this.Controls.Add(this.dpiScaledLabel1);
            this.Controls.Add(this.dpiScaledButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            this.Resizable = false;
            this.ShowCustomWindowButtons = false;
            this.ShowFormIcon = true;
            this.ShowFormTitle = false;
            this.ShowFormTopBorder = false;
            this.ShowIcon = false;
            this.Style = "NewTheme";
            this.Text = "Shotr";
            this.Theme = "NewTheme";
            ((System.ComponentModel.ISupportInitialize)(this.dpiScaledPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DpiScaledButton dpiScaledButton1;
        private DpiScaledLabel dpiScaledLabel1;
        private DpiScaledTextbox dpiScaledTextbox1;
        private DpiScaledTextbox dpiScaledTextbox2;
        private DpiScaledLabel dpiScaledLabel2;
        private DpiScaledLabel dpiScaledLabel3;
        private DpiScaledCheckbox dpiScaledCheckbox1;
        private DpiScaledLinkLabel dpiScaledLinkLabel1;
        private DpiScaledLinkLabel dpiScaledLinkLabel2;
        private DpiScaledPictureBox dpiScaledPictureBox1;
    }
}
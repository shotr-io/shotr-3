using Shotr.Ui.DpiScaling;

namespace Shotr.Ui.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.dpiScaledButton1 = new DpiScaledButton();
            this.dpiScaledLabel1 = new DpiScaledLabel();
            this.dpiScaledTextbox1 = new DpiScaledTextbox();
            this.dpiScaledTextbox2 = new DpiScaledTextbox();
            this.dpiScaledLabel2 = new DpiScaledLabel();
            this.dpiScaledLabel3 = new DpiScaledLabel();
            this.dpiScaledCheckbox1 = new DpiScaledCheckbox();
            this.dpiScaledLinkLabel1 = new DpiScaledLinkLabel();
            this.dpiScaledLinkLabel2 = new DpiScaledLinkLabel();
            this.SuspendLayout();
            // 
            // dpiScaledButton1
            // 
            this.dpiScaledButton1.FontSize = MetroFramework5.Drawing.MetroFontSize.Medium;
            this.dpiScaledButton1.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Regular;
            this.dpiScaledButton1.Location = new System.Drawing.Point(23, 324);
            this.dpiScaledButton1.Name = "dpiScaledButton1";
            this.dpiScaledButton1.Scaled = true;
            this.dpiScaledButton1.Size = new System.Drawing.Size(332, 43);
            this.dpiScaledButton1.Style = "NewTheme";
            this.dpiScaledButton1.TabIndex = 0;
            this.dpiScaledButton1.Text = "Sign in";
            this.dpiScaledButton1.Theme = "NewTheme";
            this.dpiScaledButton1.Click += new System.EventHandler(this.dpiScaledButton1_Click);
            // 
            // dpiScaledLabel1
            // 
            this.dpiScaledLabel1.FontSize = MetroFramework5.Drawing.MetroFontSize.Large;
            this.dpiScaledLabel1.Location = new System.Drawing.Point(23, 86);
            this.dpiScaledLabel1.Name = "dpiScaledLabel1";
            this.dpiScaledLabel1.Scaled = true;
            this.dpiScaledLabel1.Size = new System.Drawing.Size(332, 40);
            this.dpiScaledLabel1.Style = "NewTheme";
            this.dpiScaledLabel1.TabIndex = 1;
            this.dpiScaledLabel1.Text = "Sign in to your account";
            this.dpiScaledLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dpiScaledLabel1.Theme = "NewTheme";
            // 
            // dpiScaledTextbox1
            // 
            this.dpiScaledTextbox1.FontSize = MetroFramework5.Drawing.MetroFontSize.Large;
            this.dpiScaledTextbox1.Location = new System.Drawing.Point(23, 163);
            this.dpiScaledTextbox1.Name = "dpiScaledTextbox1";
            this.dpiScaledTextbox1.Size = new System.Drawing.Size(332, 32);
            this.dpiScaledTextbox1.Style = "NewTheme";
            this.dpiScaledTextbox1.TabIndex = 2;
            this.dpiScaledTextbox1.Theme = "NewTheme";
            // 
            // dpiScaledTextbox2
            // 
            this.dpiScaledTextbox2.FontSize = MetroFramework5.Drawing.MetroFontSize.Large;
            this.dpiScaledTextbox2.Location = new System.Drawing.Point(23, 227);
            this.dpiScaledTextbox2.Name = "dpiScaledTextbox2";
            this.dpiScaledTextbox2.PasswordChar = '*';
            this.dpiScaledTextbox2.Size = new System.Drawing.Size(332, 32);
            this.dpiScaledTextbox2.Style = "NewTheme";
            this.dpiScaledTextbox2.TabIndex = 3;
            this.dpiScaledTextbox2.Theme = "NewTheme";
            // 
            // dpiScaledLabel2
            // 
            this.dpiScaledLabel2.AutoSize = true;
            this.dpiScaledLabel2.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Bold;
            this.dpiScaledLabel2.Location = new System.Drawing.Point(18, 137);
            this.dpiScaledLabel2.Name = "dpiScaledLabel2";
            this.dpiScaledLabel2.Scaled = true;
            this.dpiScaledLabel2.Size = new System.Drawing.Size(123, 25);
            this.dpiScaledLabel2.Style = "NewTheme";
            this.dpiScaledLabel2.TabIndex = 4;
            this.dpiScaledLabel2.Text = "Email address";
            this.dpiScaledLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dpiScaledLabel2.Theme = "NewTheme";
            // 
            // dpiScaledLabel3
            // 
            this.dpiScaledLabel3.AutoSize = true;
            this.dpiScaledLabel3.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Bold;
            this.dpiScaledLabel3.Location = new System.Drawing.Point(18, 201);
            this.dpiScaledLabel3.Name = "dpiScaledLabel3";
            this.dpiScaledLabel3.Scaled = true;
            this.dpiScaledLabel3.Size = new System.Drawing.Size(87, 25);
            this.dpiScaledLabel3.Style = "NewTheme";
            this.dpiScaledLabel3.TabIndex = 5;
            this.dpiScaledLabel3.Text = "Password";
            this.dpiScaledLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dpiScaledLabel3.Theme = "NewTheme";
            // 
            // dpiScaledCheckbox1
            // 
            this.dpiScaledCheckbox1.AutoSize = true;
            this.dpiScaledCheckbox1.Location = new System.Drawing.Point(23, 270);
            this.dpiScaledCheckbox1.Name = "dpiScaledCheckbox1";
            this.dpiScaledCheckbox1.Size = new System.Drawing.Size(113, 22);
            this.dpiScaledCheckbox1.Style = "NewTheme";
            this.dpiScaledCheckbox1.TabIndex = 6;
            this.dpiScaledCheckbox1.Text = "Remember me";
            this.dpiScaledCheckbox1.Theme = "NewTheme";
            // 
            // dpiScaledLinkLabel1
            // 
            this.dpiScaledLinkLabel1.Location = new System.Drawing.Point(233, 265);
            this.dpiScaledLinkLabel1.Name = "dpiScaledLinkLabel1";
            this.dpiScaledLinkLabel1.Scaled = true;
            this.dpiScaledLinkLabel1.Size = new System.Drawing.Size(122, 23);
            this.dpiScaledLinkLabel1.Style = "NewTheme";
            this.dpiScaledLinkLabel1.TabIndex = 8;
            this.dpiScaledLinkLabel1.Text = "Forgot Password?";
            this.dpiScaledLinkLabel1.Theme = "NewTheme";
            this.dpiScaledLinkLabel1.Click += new System.EventHandler(this.dpiScaledLinkLabel1_Click);
            // 
            // dpiScaledLinkLabel2
            // 
            this.dpiScaledLinkLabel2.Location = new System.Drawing.Point(23, 373);
            this.dpiScaledLinkLabel2.Name = "dpiScaledLinkLabel2";
            this.dpiScaledLinkLabel2.Scaled = true;
            this.dpiScaledLinkLabel2.Size = new System.Drawing.Size(332, 23);
            this.dpiScaledLinkLabel2.Style = "NewTheme";
            this.dpiScaledLinkLabel2.TabIndex = 9;
            this.dpiScaledLinkLabel2.Text = "Don\'t have an account? Click here!";
            this.dpiScaledLinkLabel2.Theme = "NewTheme";
            this.dpiScaledLinkLabel2.Click += new System.EventHandler(this.dpiScaledLinkLabel2_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework5.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(378, 432);
            this.Controls.Add(this.dpiScaledLinkLabel2);
            this.Controls.Add(this.dpiScaledLinkLabel1);
            this.Controls.Add(this.dpiScaledCheckbox1);
            this.Controls.Add(this.dpiScaledLabel3);
            this.Controls.Add(this.dpiScaledLabel2);
            this.Controls.Add(this.dpiScaledTextbox2);
            this.Controls.Add(this.dpiScaledTextbox1);
            this.Controls.Add(this.dpiScaledLabel1);
            this.Controls.Add(this.dpiScaledButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Resizable = false;
            this.ShowFormIcon = true;
            this.Style = "NewTheme";
            this.Text = "Shotr";
            this.Theme = "NewTheme";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DpiScaling.DpiScaledButton dpiScaledButton1;
        private DpiScaling.DpiScaledLabel dpiScaledLabel1;
        private DpiScaling.DpiScaledTextbox dpiScaledTextbox1;
        private DpiScaling.DpiScaledTextbox dpiScaledTextbox2;
        private DpiScaling.DpiScaledLabel dpiScaledLabel2;
        private DpiScaling.DpiScaledLabel dpiScaledLabel3;
        private DpiScaling.DpiScaledCheckbox dpiScaledCheckbox1;
        private DpiScaling.DpiScaledLinkLabel dpiScaledLinkLabel1;
        private DpiScaling.DpiScaledLinkLabel dpiScaledLinkLabel2;
    }
}
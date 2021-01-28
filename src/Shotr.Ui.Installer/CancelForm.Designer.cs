using Shotr.Core.Controls.DpiScaling;

namespace Shotr.Ui.Installer
{
    partial class CancelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CancelForm));
            this.metroLabel1 = new MetroFramework5.Controls.MetroLabel();
            this.noButton = new MetroFramework5.Controls.MetroButton();
            this.yesButton = new MetroFramework5.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.FontSize = MetroFramework5.Drawing.MetroFontSize.Large;
            this.metroLabel1.Location = new System.Drawing.Point(71, 29);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(403, 29);

            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Are you sure you want to exit Shotr Setup?";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.metroLabel1.UseCompatibleTextRendering = true;
            // 
            // noButton
            // 
            this.noButton.Location = new System.Drawing.Point(429, 61);
            this.noButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(88, 27);

            this.noButton.TabIndex = 1;
            this.noButton.Text = "No";

            this.noButton.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // yesButton
            // 
            this.yesButton.Location = new System.Drawing.Point(335, 61);
            this.yesButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(88, 27);

            this.yesButton.TabIndex = 2;
            this.yesButton.Text = "Yes";

            this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
            // 
            // CancelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 104);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.metroLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CancelForm";
            this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);




            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework5.Controls.MetroLabel metroLabel1;
        private MetroFramework5.Controls.MetroButton noButton;
        private MetroFramework5.Controls.MetroButton yesButton;
    }
}
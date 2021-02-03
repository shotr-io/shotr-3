using System.ComponentModel;
using Shotr.Core.Controls.DpiScaling;
using Shotr.Core.Controls.Theme;

namespace Shotr.Ui.Forms.Settings
{
    partial class CustomUploaderPrompt
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
            this.metroLabel1 = new ThemedLabel();
            this.metroTextBox1 = new ThemedTextBox();
            this.metroButton3 = new ThemedButton();
            this.metroLabel2 = new ThemedLabel();
            this.metroTextBox2 = new ThemedTextBox();
            this.metroTextBox3 = new ThemedTextBox();
            this.metroLabel3 = new ThemedLabel();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.Location = new System.Drawing.Point(22, 26);
            this.metroLabel1.Name = "metroLabel1";

            this.metroLabel1.Size = new System.Drawing.Size(375, 38);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Please input an example of what an image URL for your custom \r\nuploader would loo" +
    "k like:";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroTextBox1
            // 
            this.metroTextBox1.Location = new System.Drawing.Point(27, 71);
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.Size = new System.Drawing.Size(372, 23);
            this.metroTextBox1.TabIndex = 1;
            // 
            // metroButton3
            // 
            this.metroButton3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroButton3.Location = new System.Drawing.Point(262, 302);
            this.metroButton3.Name = "metroButton3";

            this.metroButton3.Size = new System.Drawing.Size(137, 23);
            this.metroButton3.TabIndex = 13;
            this.metroButton3.Text = "Continue";
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(22, 175);
            this.metroLabel2.Name = "metroLabel2";

            this.metroLabel2.Size = new System.Drawing.Size(177, 25);
            this.metroLabel2.TabIndex = 14;
            this.metroLabel2.Text = "Other Examples Include:";
            // 
            // metroTextBox2
            // 
            this.metroTextBox2.Location = new System.Drawing.Point(27, 197);
            this.metroTextBox2.Multiline = true;
            this.metroTextBox2.Name = "metroTextBox2";
            this.metroTextBox2.ReadOnly = true;
            this.metroTextBox2.Size = new System.Drawing.Size(372, 99);
            this.metroTextBox2.TabIndex = 15;
            // 
            // metroTextBox3
            // 
            this.metroTextBox3.Location = new System.Drawing.Point(27, 145);
            this.metroTextBox3.Name = "metroTextBox3";
            this.metroTextBox3.Size = new System.Drawing.Size(372, 23);
            this.metroTextBox3.TabIndex = 16;
            // 
            // metroLabel3
            // 
            this.metroLabel3.Location = new System.Drawing.Point(23, 101);
            this.metroLabel3.Name = "metroLabel3";

            this.metroLabel3.Size = new System.Drawing.Size(369, 38);
            this.metroLabel3.TabIndex = 17;
            this.metroLabel3.Text = "If you have deletion built in, please give an example of the\r\ndeletion URL here:";
            // 
            // CustomUploaderPrompt
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;

            this.ClientSize = new System.Drawing.Size(422, 340);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroTextBox3);
            this.Controls.Add(this.metroTextBox2);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroTextBox1);
            this.Controls.Add(this.metroLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.Name = "CustomUploaderPrompt";


            this.ShowIcon = false;


            this.TopMost = true;
            this.Load += new System.EventHandler(this.CustomUploaderPrompt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ThemedLabel metroLabel1;
        private ThemedTextBox metroTextBox1;
        private ThemedButton metroButton3;
        private ThemedLabel metroLabel2;
        private ThemedTextBox metroTextBox2;
        private ThemedTextBox metroTextBox3;
        private ThemedLabel metroLabel3;
    }
}
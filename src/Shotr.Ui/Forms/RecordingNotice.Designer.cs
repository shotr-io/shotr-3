using System.ComponentModel;
using Shotr.Core.Controls.DpiScaling;

namespace Shotr.Ui.Forms
{
    partial class RecordingNotice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecordingNotice));
            this.metroLabel2 = new Shotr.Core.Controls.DpiScaling.DpiScaledLabel();
            this.metroButton3 = new Shotr.Core.Controls.DpiScaling.DpiScaledButton();
            this.metroCheckBox1 = new Shotr.Core.Controls.DpiScaling.DpiScaledCheckbox();
            this.dpiScaledPictureBox1 = new Shotr.Core.Controls.DpiScaling.DpiScaledPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dpiScaledPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel2
            // 
            this.metroLabel2.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel2.Location = new System.Drawing.Point(23, 54);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Scaled = true;
            this.metroLabel2.Size = new System.Drawing.Size(344, 65);
            this.metroLabel2.Style = "NewTheme";
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "You can press the hotkey for a video recording to \r\nstop recording in the case yo" +
    "u are recording your\r\nwhole screen or the bottom area.";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel2.Theme = "NewTheme";
            this.metroLabel2.UseCompatibleTextRendering = true;
            // 
            // metroButton3
            // 
            this.metroButton3.FontSize = MetroFramework5.Drawing.MetroFontSize.Default;
            this.metroButton3.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Default;
            this.metroButton3.Location = new System.Drawing.Point(147, 151);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Scaled = true;
            this.metroButton3.Size = new System.Drawing.Size(96, 28);
            this.metroButton3.Style = "NewTheme";
            this.metroButton3.TabIndex = 32;
            this.metroButton3.Text = "OK";
            this.metroButton3.Theme = "NewTheme";
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.Location = new System.Drawing.Point(112, 122);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(167, 22);
            this.metroCheckBox1.Style = "NewTheme";
            this.metroCheckBox1.TabIndex = 33;
            this.metroCheckBox1.Text = "Don\'t show this again.";
            this.metroCheckBox1.Theme = "NewTheme";
            this.metroCheckBox1.UseVisualStyleBackColor = false;
            // 
            // dpiScaledPictureBox1
            // 
            this.dpiScaledPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.dpiScaledPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("dpiScaledPictureBox1.Image")));
            this.dpiScaledPictureBox1.Location = new System.Drawing.Point(124, 0);
            this.dpiScaledPictureBox1.Name = "dpiScaledPictureBox1";
            this.dpiScaledPictureBox1.Scaled = true;
            this.dpiScaledPictureBox1.Size = new System.Drawing.Size(143, 53);
            this.dpiScaledPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dpiScaledPictureBox1.TabIndex = 34;
            this.dpiScaledPictureBox1.TabStop = false;
            // 
            // RecordingNotice
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = MetroFramework5.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(390, 191);
            this.Controls.Add(this.dpiScaledPictureBox1);
            this.Controls.Add(this.metroCheckBox1);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroLabel2);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "RecordingNotice";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.ShowCustomWindowButtons = false;
            this.ShowFormIcon = true;
            this.ShowFormTopBorder = false;
            this.ShowInTaskbar = false;
            this.Style = "NewTheme";
            this.Text = "Notice";
            this.Theme = "NewTheme";
            ((System.ComponentModel.ISupportInitialize)(this.dpiScaledPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DpiScaledLabel metroLabel2;
        private DpiScaledButton metroButton3;
        private DpiScaledCheckbox metroCheckBox1;
        private DpiScaledPictureBox dpiScaledPictureBox1;
    }
}
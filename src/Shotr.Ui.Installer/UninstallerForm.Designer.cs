using Shotr.Core.Controls.DpiScaling;

namespace Shotr.Ui.Installer
{
    partial class UninstallerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UninstallerForm));
            this.step1CancelButton = new Shotr.Core.Controls.Theme.ThemedButton();
            this.step1NextButton = new Shotr.Core.Controls.Theme.ThemedButton();
            this.metroPanel1 = new Shotr.Core.Controls.Theme.ThemedPanel();
            this.metroTile1 = new Shotr.Core.Controls.Theme.ThemedBar();
            this.metroLabel1 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.metroLabel2 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.metroLabel3 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.metroLabel4 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.metroLabel5 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.step1GroupPanel = new Shotr.Core.Controls.Theme.ThemedPanel();
            this.dpiScaledPictureBox2 = new Shotr.Core.Controls.DpiScaling.DpiScaledPictureBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.step3GroupPanel = new Shotr.Core.Controls.Theme.ThemedPanel();
            this.dpiScaledPictureBox3 = new Shotr.Core.Controls.DpiScaling.DpiScaledPictureBox();
            this.metroLabel17 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.metroLabel16 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.metroTile2 = new Shotr.Core.Controls.Theme.ThemedBar();
            this.metroPanel10 = new Shotr.Core.Controls.Theme.ThemedPanel();
            this.step5FinishButton = new Shotr.Core.Controls.Theme.ThemedButton();
            this.metroLabel14 = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.step4ExtractLabel = new Shotr.Core.Controls.Theme.ThemedLabel();
            this.metroPanel4 = new Shotr.Core.Controls.Theme.ThemedPanel();
            this.finalNextButton = new Shotr.Core.Controls.Theme.ThemedButton();
            this.step4CancelButton = new Shotr.Core.Controls.Theme.ThemedButton();
            this.step4ProgressBar = new Shotr.Core.Controls.Theme.ThemedProgressBar();
            this.step2GroupPanel = new Shotr.Core.Controls.Theme.ThemedPanel();
            this.dpiScaledPictureBox1 = new Shotr.Core.Controls.DpiScaling.DpiScaledPictureBox();
            this.metroPanel1.SuspendLayout();
            this.step1GroupPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpiScaledPictureBox2)).BeginInit();
            this.step3GroupPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpiScaledPictureBox3)).BeginInit();
            this.metroPanel10.SuspendLayout();
            this.metroPanel4.SuspendLayout();
            this.step2GroupPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpiScaledPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // step1CancelButton
            // 
            this.step1CancelButton.BasePaint = false;
            this.step1CancelButton.Highlight = false;
            this.step1CancelButton.Location = new System.Drawing.Point(472, 23);
            this.step1CancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.step1CancelButton.Name = "step1CancelButton";
            this.step1CancelButton.Scaled = true;
            this.step1CancelButton.Size = new System.Drawing.Size(85, 27);
            this.step1CancelButton.TabIndex = 0;
            this.step1CancelButton.Text = "Cancel";
            this.step1CancelButton.Click += new System.EventHandler(this.step1CancelButton_Click);
            // 
            // step1NextButton
            // 
            this.step1NextButton.BasePaint = false;
            this.step1NextButton.Highlight = false;
            this.step1NextButton.Location = new System.Drawing.Point(380, 23);
            this.step1NextButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.step1NextButton.Name = "step1NextButton";
            this.step1NextButton.Scaled = true;
            this.step1NextButton.Size = new System.Drawing.Size(85, 27);
            this.step1NextButton.TabIndex = 1;
            this.step1NextButton.Text = "Next";
            this.step1NextButton.Click += new System.EventHandler(this.step1NextButton_Click);
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(48)))));
            this.metroPanel1.BasePaint = false;
            this.metroPanel1.Controls.Add(this.step1NextButton);
            this.metroPanel1.Controls.Add(this.step1CancelButton);
            this.metroPanel1.ForeColor = System.Drawing.Color.Gray;
            this.metroPanel1.Location = new System.Drawing.Point(0, 341);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Scaled = true;
            this.metroPanel1.Size = new System.Drawing.Size(583, 74);
            this.metroPanel1.TabIndex = 2;
            // 
            // metroTile1
            // 
            this.metroTile1.BasePaint = false;
            this.metroTile1.Location = new System.Drawing.Point(223, 0);
            this.metroTile1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Scaled = true;
            this.metroTile1.Size = new System.Drawing.Size(1, 341);
            this.metroTile1.TabIndex = 3;
            this.metroTile1.Text = "metroTile1";
            // 
            // metroLabel1
            // 
            this.metroLabel1.BasePaint = false;
            this.metroLabel1.Font = new System.Drawing.Font("Inter", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroLabel1.Location = new System.Drawing.Point(231, 20);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Scaled = true;
            this.metroLabel1.Size = new System.Drawing.Size(345, 42);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Welcome to the Shotr";
            this.metroLabel1.UseCompatibleTextRendering = false;
            // 
            // metroLabel2
            // 
            this.metroLabel2.BasePaint = false;
            this.metroLabel2.Font = new System.Drawing.Font("Inter", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroLabel2.Location = new System.Drawing.Point(232, 53);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Scaled = true;
            this.metroLabel2.Size = new System.Drawing.Size(281, 36);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Uninstall Wizard";
            this.metroLabel2.UseCompatibleTextRendering = false;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BasePaint = false;
            this.metroLabel3.Location = new System.Drawing.Point(235, 103);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Scaled = true;
            this.metroLabel3.Size = new System.Drawing.Size(267, 15);
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "This wizard will guide you through the removal";
            this.metroLabel3.UseCompatibleTextRendering = false;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.BasePaint = false;
            this.metroLabel4.Location = new System.Drawing.Point(235, 125);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Scaled = true;
            this.metroLabel4.Size = new System.Drawing.Size(256, 15);
            this.metroLabel4.TabIndex = 7;
            this.metroLabel4.Text = "of Shotr. It is recommended that you close all";
            this.metroLabel4.UseCompatibleTextRendering = false;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.BasePaint = false;
            this.metroLabel5.Location = new System.Drawing.Point(235, 147);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Scaled = true;
            this.metroLabel5.Size = new System.Drawing.Size(194, 15);
            this.metroLabel5.TabIndex = 8;
            this.metroLabel5.Text = "other applications before starting.";
            this.metroLabel5.UseCompatibleTextRendering = false;
            // 
            // step1GroupPanel
            // 
            this.step1GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(48)))));
            this.step1GroupPanel.BasePaint = false;
            this.step1GroupPanel.Controls.Add(this.dpiScaledPictureBox2);
            this.step1GroupPanel.Controls.Add(this.metroLabel5);
            this.step1GroupPanel.Controls.Add(this.metroLabel4);
            this.step1GroupPanel.Controls.Add(this.metroLabel3);
            this.step1GroupPanel.Controls.Add(this.metroLabel2);
            this.step1GroupPanel.Controls.Add(this.metroTile1);
            this.step1GroupPanel.Controls.Add(this.metroLabel1);
            this.step1GroupPanel.Controls.Add(this.metroPanel1);
            this.step1GroupPanel.Location = new System.Drawing.Point(0, 0);
            this.step1GroupPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.step1GroupPanel.Name = "step1GroupPanel";
            this.step1GroupPanel.Scaled = true;
            this.step1GroupPanel.Size = new System.Drawing.Size(583, 415);
            this.step1GroupPanel.TabIndex = 9;
            // 
            // dpiScaledPictureBox2
            // 
            this.dpiScaledPictureBox2.BackgroundImage = Shotr.Ui.Installer.Properties.Resources.Shotr_Logo_Banner___icon_with_new_color___White;
            this.dpiScaledPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dpiScaledPictureBox2.BasePaint = false;
            this.dpiScaledPictureBox2.Location = new System.Drawing.Point(13, 15);
            this.dpiScaledPictureBox2.Name = "dpiScaledPictureBox2";
            this.dpiScaledPictureBox2.Scaled = true;
            this.dpiScaledPictureBox2.Size = new System.Drawing.Size(198, 74);
            this.dpiScaledPictureBox2.TabIndex = 9;
            this.dpiScaledPictureBox2.TabStop = false;
            // 
            // step3GroupPanel
            // 
            this.step3GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(48)))));
            this.step3GroupPanel.BasePaint = false;
            this.step3GroupPanel.Controls.Add(this.dpiScaledPictureBox3);
            this.step3GroupPanel.Controls.Add(this.metroLabel17);
            this.step3GroupPanel.Controls.Add(this.metroLabel16);
            this.step3GroupPanel.Controls.Add(this.metroTile2);
            this.step3GroupPanel.Controls.Add(this.metroPanel10);
            this.step3GroupPanel.Controls.Add(this.metroLabel14);
            this.step3GroupPanel.Location = new System.Drawing.Point(0, 0);
            this.step3GroupPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.step3GroupPanel.Name = "step3GroupPanel";
            this.step3GroupPanel.Scaled = true;
            this.step3GroupPanel.Size = new System.Drawing.Size(583, 415);
            this.step3GroupPanel.TabIndex = 14;
            // 
            // dpiScaledPictureBox3
            // 
            this.dpiScaledPictureBox3.BackgroundImage = Shotr.Ui.Installer.Properties.Resources.Shotr_Logo_Banner___icon_with_new_color___White;
            this.dpiScaledPictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dpiScaledPictureBox3.BasePaint = false;
            this.dpiScaledPictureBox3.Location = new System.Drawing.Point(13, 15);
            this.dpiScaledPictureBox3.Name = "dpiScaledPictureBox3";
            this.dpiScaledPictureBox3.Scaled = true;
            this.dpiScaledPictureBox3.Size = new System.Drawing.Size(198, 74);
            this.dpiScaledPictureBox3.TabIndex = 19;
            this.dpiScaledPictureBox3.TabStop = false;
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.BasePaint = false;
            this.metroLabel17.Location = new System.Drawing.Point(235, 125);
            this.metroLabel17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Scaled = true;
            this.metroLabel17.Size = new System.Drawing.Size(39, 15);
            this.metroLabel17.TabIndex = 18;
            this.metroLabel17.Text = "Shotr.";
            this.metroLabel17.UseCompatibleTextRendering = false;
            // 
            // metroLabel16
            // 
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.BasePaint = false;
            this.metroLabel16.Location = new System.Drawing.Point(235, 103);
            this.metroLabel16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Scaled = true;
            this.metroLabel16.Size = new System.Drawing.Size(282, 15);
            this.metroLabel16.TabIndex = 17;
            this.metroLabel16.Text = "This wizard has successfully finished uninstalling";
            this.metroLabel16.UseCompatibleTextRendering = false;
            // 
            // metroTile2
            // 
            this.metroTile2.BasePaint = false;
            this.metroTile2.Location = new System.Drawing.Point(223, 0);
            this.metroTile2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Scaled = true;
            this.metroTile2.Size = new System.Drawing.Size(1, 341);
            this.metroTile2.TabIndex = 15;
            this.metroTile2.Text = "metroTile2";
            // 
            // metroPanel10
            // 
            this.metroPanel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(48)))));
            this.metroPanel10.BasePaint = false;
            this.metroPanel10.Controls.Add(this.step5FinishButton);
            this.metroPanel10.ForeColor = System.Drawing.Color.Gray;
            this.metroPanel10.Location = new System.Drawing.Point(0, 341);
            this.metroPanel10.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.metroPanel10.Name = "metroPanel10";
            this.metroPanel10.Scaled = true;
            this.metroPanel10.Size = new System.Drawing.Size(583, 74);
            this.metroPanel10.TabIndex = 14;
            // 
            // step5FinishButton
            // 
            this.step5FinishButton.BasePaint = false;
            this.step5FinishButton.Highlight = false;
            this.step5FinishButton.Location = new System.Drawing.Point(472, 23);
            this.step5FinishButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.step5FinishButton.Name = "step5FinishButton";
            this.step5FinishButton.Scaled = true;
            this.step5FinishButton.Size = new System.Drawing.Size(85, 27);
            this.step5FinishButton.TabIndex = 0;
            this.step5FinishButton.Text = "Finish";
            this.step5FinishButton.Click += new System.EventHandler(this.step5FinishButton_Click);
            // 
            // metroLabel14
            // 
            this.metroLabel14.BasePaint = false;
            this.metroLabel14.Font = new System.Drawing.Font("Inter", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroLabel14.Location = new System.Drawing.Point(231, 20);
            this.metroLabel14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Scaled = true;
            this.metroLabel14.Size = new System.Drawing.Size(345, 42);
            this.metroLabel14.TabIndex = 13;
            this.metroLabel14.Text = "Uninstall Successful";
            this.metroLabel14.UseCompatibleTextRendering = false;
            // 
            // step4ExtractLabel
            // 
            this.step4ExtractLabel.BasePaint = false;
            this.step4ExtractLabel.Location = new System.Drawing.Point(22, 185);
            this.step4ExtractLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.step4ExtractLabel.Name = "step4ExtractLabel";
            this.step4ExtractLabel.Scaled = true;
            this.step4ExtractLabel.Size = new System.Drawing.Size(528, 27);
            this.step4ExtractLabel.TabIndex = 17;
            this.step4ExtractLabel.Text = "Downloading...";
            this.step4ExtractLabel.UseCompatibleTextRendering = false;
            // 
            // metroPanel4
            // 
            this.metroPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(48)))));
            this.metroPanel4.BasePaint = false;
            this.metroPanel4.Controls.Add(this.finalNextButton);
            this.metroPanel4.Controls.Add(this.step4CancelButton);
            this.metroPanel4.ForeColor = System.Drawing.Color.Gray;
            this.metroPanel4.Location = new System.Drawing.Point(0, 341);
            this.metroPanel4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.metroPanel4.Name = "metroPanel4";
            this.metroPanel4.Scaled = true;
            this.metroPanel4.Size = new System.Drawing.Size(583, 74);
            this.metroPanel4.TabIndex = 12;
            // 
            // finalNextButton
            // 
            this.finalNextButton.BasePaint = false;
            this.finalNextButton.Highlight = false;
            this.finalNextButton.Location = new System.Drawing.Point(380, 23);
            this.finalNextButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.finalNextButton.Name = "finalNextButton";
            this.finalNextButton.Scaled = true;
            this.finalNextButton.Size = new System.Drawing.Size(85, 27);
            this.finalNextButton.TabIndex = 2;
            this.finalNextButton.Text = "Next";
            this.finalNextButton.Visible = false;
            this.finalNextButton.Click += new System.EventHandler(this.finalNextButton_Click);
            // 
            // step4CancelButton
            // 
            this.step4CancelButton.BasePaint = false;
            this.step4CancelButton.Highlight = false;
            this.step4CancelButton.Location = new System.Drawing.Point(472, 23);
            this.step4CancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.step4CancelButton.Name = "step4CancelButton";
            this.step4CancelButton.Scaled = true;
            this.step4CancelButton.Size = new System.Drawing.Size(85, 27);
            this.step4CancelButton.TabIndex = 0;
            this.step4CancelButton.Text = "Cancel";
            this.step4CancelButton.Click += new System.EventHandler(this.step4CancelButton_Click);
            // 
            // step4ProgressBar
            // 
            this.step4ProgressBar.BasePaint = false;
            this.step4ProgressBar.Location = new System.Drawing.Point(27, 208);
            this.step4ProgressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.step4ProgressBar.MaxValue = 100;
            this.step4ProgressBar.Name = "step4ProgressBar";
            this.step4ProgressBar.Scaled = true;
            this.step4ProgressBar.Size = new System.Drawing.Size(530, 27);
            this.step4ProgressBar.TabIndex = 14;
            this.step4ProgressBar.Value = 0;
            // 
            // step2GroupPanel
            // 
            this.step2GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(48)))));
            this.step2GroupPanel.BasePaint = false;
            this.step2GroupPanel.Controls.Add(this.dpiScaledPictureBox1);
            this.step2GroupPanel.Controls.Add(this.step4ProgressBar);
            this.step2GroupPanel.Controls.Add(this.metroPanel4);
            this.step2GroupPanel.Controls.Add(this.step4ExtractLabel);
            this.step2GroupPanel.Location = new System.Drawing.Point(0, 0);
            this.step2GroupPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.step2GroupPanel.Name = "step2GroupPanel";
            this.step2GroupPanel.Scaled = true;
            this.step2GroupPanel.Size = new System.Drawing.Size(583, 415);
            this.step2GroupPanel.TabIndex = 13;
            // 
            // dpiScaledPictureBox1
            // 
            this.dpiScaledPictureBox1.BackgroundImage = Shotr.Ui.Installer.Properties.Resources.Shotr_Logo_Banner___icon_with_new_color___White;
            this.dpiScaledPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dpiScaledPictureBox1.BasePaint = false;
            this.dpiScaledPictureBox1.Location = new System.Drawing.Point(13, 15);
            this.dpiScaledPictureBox1.Name = "dpiScaledPictureBox1";
            this.dpiScaledPictureBox1.Scaled = true;
            this.dpiScaledPictureBox1.Size = new System.Drawing.Size(198, 74);
            this.dpiScaledPictureBox1.TabIndex = 18;
            this.dpiScaledPictureBox1.TabStop = false;
            // 
            // UninstallerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(583, 415);
            this.Controls.Add(this.step1GroupPanel);
            this.Controls.Add(this.step3GroupPanel);
            this.Controls.Add(this.step2GroupPanel);
            this.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "UninstallerForm";
            this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shotr - Uninstall";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.metroPanel1.ResumeLayout(false);
            this.step1GroupPanel.ResumeLayout(false);
            this.step1GroupPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpiScaledPictureBox2)).EndInit();
            this.step3GroupPanel.ResumeLayout(false);
            this.step3GroupPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpiScaledPictureBox3)).EndInit();
            this.metroPanel10.ResumeLayout(false);
            this.metroPanel4.ResumeLayout(false);
            this.step2GroupPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dpiScaledPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Shotr.Core.Controls.Theme.ThemedButton step1CancelButton;
        private Shotr.Core.Controls.Theme.ThemedButton step1NextButton;
        private Shotr.Core.Controls.Theme.ThemedPanel metroPanel1;
        private Shotr.Core.Controls.Theme.ThemedBar metroTile1;
        private Shotr.Core.Controls.Theme.ThemedLabel metroLabel1;
        private Shotr.Core.Controls.Theme.ThemedLabel metroLabel2;
        private Shotr.Core.Controls.Theme.ThemedLabel metroLabel3;
        private Shotr.Core.Controls.Theme.ThemedLabel metroLabel4;
        private Shotr.Core.Controls.Theme.ThemedLabel metroLabel5;
        private Shotr.Core.Controls.Theme.ThemedPanel step1GroupPanel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private Shotr.Core.Controls.Theme.ThemedPanel step3GroupPanel;
        private Shotr.Core.Controls.Theme.ThemedLabel metroLabel16;
        private Shotr.Core.Controls.Theme.ThemedBar metroTile2;
        private Shotr.Core.Controls.Theme.ThemedPanel metroPanel10;
        private Shotr.Core.Controls.Theme.ThemedButton step5FinishButton;
        private Shotr.Core.Controls.Theme.ThemedLabel metroLabel14;
        private Shotr.Core.Controls.Theme.ThemedLabel metroLabel17;
        private Shotr.Core.Controls.Theme.ThemedLabel step4ExtractLabel;
        private Shotr.Core.Controls.Theme.ThemedPanel metroPanel4;
        private Shotr.Core.Controls.Theme.ThemedButton finalNextButton;
        private Shotr.Core.Controls.Theme.ThemedButton step4CancelButton;
        private Shotr.Core.Controls.Theme.ThemedProgressBar step4ProgressBar;
        private Shotr.Core.Controls.Theme.ThemedPanel step2GroupPanel;
        private DpiScaledPictureBox dpiScaledPictureBox1;
        private DpiScaledPictureBox dpiScaledPictureBox2;
        private DpiScaledPictureBox dpiScaledPictureBox3;
    }
}


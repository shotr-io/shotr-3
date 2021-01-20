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
            this.step1CancelButton = new MetroFramework5.Controls.MetroButton();
            this.step1NextButton = new MetroFramework5.Controls.MetroButton();
            this.metroPanel1 = new MetroFramework5.Controls.MetroPanel();
            this.metroTile1 = new MetroFramework5.Controls.MetroTile();
            this.metroLabel1 = new MetroFramework5.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework5.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework5.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework5.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework5.Controls.MetroLabel();
            this.step1GroupPanel = new MetroFramework5.Controls.MetroPanel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.step3GroupPanel = new MetroFramework5.Controls.MetroPanel();
            this.metroLabel17 = new MetroFramework5.Controls.MetroLabel();
            this.metroLabel16 = new MetroFramework5.Controls.MetroLabel();
            this.metroTile2 = new MetroFramework5.Controls.MetroTile();
            this.metroPanel10 = new MetroFramework5.Controls.MetroPanel();
            this.step5FinishButton = new MetroFramework5.Controls.MetroButton();
            this.metroLabel14 = new MetroFramework5.Controls.MetroLabel();
            this.step4ExtractLabel = new MetroFramework5.Controls.MetroLabel();
            this.metroPanel9 = new MetroFramework5.Controls.MetroPanel();
            this.metroLabel15 = new MetroFramework5.Controls.MetroLabel();
            this.metroPanel4 = new MetroFramework5.Controls.MetroPanel();
            this.finalNextButton = new MetroFramework5.Controls.MetroButton();
            this.step4CancelButton = new MetroFramework5.Controls.MetroButton();
            this.step4ProgressBar = new MetroFramework5.Controls.MetroProgressBar();
            this.step2GroupPanel = new MetroFramework5.Controls.MetroPanel();
            this.metroPanel1.SuspendLayout();
            this.step1GroupPanel.SuspendLayout();
            this.step3GroupPanel.SuspendLayout();
            this.metroPanel10.SuspendLayout();
            this.metroPanel4.SuspendLayout();
            this.step2GroupPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // step1CancelButton
            // 
            this.step1CancelButton.Location = new System.Drawing.Point(472, 13);
            this.step1CancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.step1CancelButton.Name = "step1CancelButton";
            this.step1CancelButton.Size = new System.Drawing.Size(85, 27);
            this.step1CancelButton.Style = "NewTheme";
            this.step1CancelButton.TabIndex = 0;
            this.step1CancelButton.Text = "Cancel";
            this.step1CancelButton.Theme = "NewTheme";
            this.step1CancelButton.Click += new System.EventHandler(this.step1CancelButton_Click);
            // 
            // step1NextButton
            // 
            this.step1NextButton.Location = new System.Drawing.Point(380, 13);
            this.step1NextButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.step1NextButton.Name = "step1NextButton";
            this.step1NextButton.Size = new System.Drawing.Size(85, 27);
            this.step1NextButton.Style = "NewTheme";
            this.step1NextButton.TabIndex = 1;
            this.step1NextButton.Text = "Next";
            this.step1NextButton.Theme = "NewTheme";
            this.step1NextButton.Click += new System.EventHandler(this.step1NextButton_Click);
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(48)))));
            this.metroPanel1.BorderStyle = MetroFramework5.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.step1NextButton);
            this.metroPanel1.Controls.Add(this.step1CancelButton);
            this.metroPanel1.ForeColor = System.Drawing.Color.Gray;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 12;
            this.metroPanel1.Location = new System.Drawing.Point(-10, 330);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(604, 74);
            this.metroPanel1.Style = "NewTheme";
            this.metroPanel1.TabIndex = 2;
            this.metroPanel1.Theme = "NewTheme";
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 12;
            // 
            // metroTile1
            // 
            this.metroTile1.Location = new System.Drawing.Point(223, -31);
            this.metroTile1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(1, 362);
            this.metroTile1.Style = "NewTheme";
            this.metroTile1.TabIndex = 3;
            this.metroTile1.Text = "metroTile1";
            this.metroTile1.Theme = "NewTheme";
            this.metroTile1.UseVisualStyleBackColor = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.FontSize = MetroFramework5.Drawing.MetroFontSize.Large;
            this.metroLabel1.Location = new System.Drawing.Point(231, -6);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(345, 42);
            this.metroLabel1.Style = "NewTheme";
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Welcome to the Shotr Uninstall";
            this.metroLabel1.Theme = "NewTheme";
            this.metroLabel1.UseCompatibleTextRendering = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.FontSize = MetroFramework5.Drawing.MetroFontSize.Large;
            this.metroLabel2.Location = new System.Drawing.Point(231, 22);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(154, 36);
            this.metroLabel2.Style = "NewTheme";
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Wizard";
            this.metroLabel2.Theme = "NewTheme";
            this.metroLabel2.UseCompatibleTextRendering = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework5.Drawing.MetroFontSize.Medium;
            this.metroLabel3.Location = new System.Drawing.Point(231, 77);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(331, 25);
            this.metroLabel3.Style = "NewTheme";
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "This wizard will guide you through the removal";
            this.metroLabel3.Theme = "NewTheme";
            this.metroLabel3.UseCompatibleTextRendering = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(231, 99);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(325, 25);
            this.metroLabel4.Style = "NewTheme";
            this.metroLabel4.TabIndex = 7;
            this.metroLabel4.Text = "of Shotr. It is recommended that you close all";
            this.metroLabel4.Theme = "NewTheme";
            this.metroLabel4.UseCompatibleTextRendering = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(231, 121);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(245, 25);
            this.metroLabel5.Style = "NewTheme";
            this.metroLabel5.TabIndex = 8;
            this.metroLabel5.Text = "other applications before starting.";
            this.metroLabel5.Theme = "NewTheme";
            this.metroLabel5.UseCompatibleTextRendering = true;
            // 
            // step1GroupPanel
            // 
            this.step1GroupPanel.BackColor = System.Drawing.Color.Transparent;
            this.step1GroupPanel.Controls.Add(this.metroLabel5);
            this.step1GroupPanel.Controls.Add(this.metroLabel4);
            this.step1GroupPanel.Controls.Add(this.metroLabel3);
            this.step1GroupPanel.Controls.Add(this.metroLabel2);
            this.step1GroupPanel.Controls.Add(this.metroTile1);
            this.step1GroupPanel.Controls.Add(this.metroLabel1);
            this.step1GroupPanel.Controls.Add(this.metroPanel1);
            this.step1GroupPanel.HorizontalScrollbarBarColor = true;
            this.step1GroupPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.step1GroupPanel.HorizontalScrollbarSize = 12;
            this.step1GroupPanel.Location = new System.Drawing.Point(0, 33);
            this.step1GroupPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.step1GroupPanel.Name = "step1GroupPanel";
            this.step1GroupPanel.Size = new System.Drawing.Size(583, 381);
            this.step1GroupPanel.TabIndex = 9;
            this.step1GroupPanel.VerticalScrollbarBarColor = true;
            this.step1GroupPanel.VerticalScrollbarHighlightOnWheel = false;
            this.step1GroupPanel.VerticalScrollbarSize = 12;
            // 
            // step3GroupPanel
            // 
            this.step3GroupPanel.BackColor = System.Drawing.Color.Transparent;
            this.step3GroupPanel.Controls.Add(this.metroLabel17);
            this.step3GroupPanel.Controls.Add(this.metroLabel16);
            this.step3GroupPanel.Controls.Add(this.metroTile2);
            this.step3GroupPanel.Controls.Add(this.metroPanel10);
            this.step3GroupPanel.Controls.Add(this.metroLabel14);
            this.step3GroupPanel.HorizontalScrollbarBarColor = true;
            this.step3GroupPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.step3GroupPanel.HorizontalScrollbarSize = 12;
            this.step3GroupPanel.Location = new System.Drawing.Point(0, 35);
            this.step3GroupPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.step3GroupPanel.Name = "step3GroupPanel";
            this.step3GroupPanel.Size = new System.Drawing.Size(583, 381);
            this.step3GroupPanel.Style = "NewTheme";
            this.step3GroupPanel.TabIndex = 14;
            this.step3GroupPanel.Theme = "NewTheme";
            this.step3GroupPanel.VerticalScrollbarBarColor = true;
            this.step3GroupPanel.VerticalScrollbarHighlightOnWheel = false;
            this.step3GroupPanel.VerticalScrollbarSize = 12;
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.FontSize = MetroFramework5.Drawing.MetroFontSize.Medium;
            this.metroLabel17.Location = new System.Drawing.Point(231, 62);
            this.metroLabel17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Size = new System.Drawing.Size(50, 25);
            this.metroLabel17.Style = "NewTheme";
            this.metroLabel17.TabIndex = 18;
            this.metroLabel17.Text = "Shotr.";
            this.metroLabel17.Theme = "NewTheme";
            this.metroLabel17.UseCompatibleTextRendering = true;
            // 
            // metroLabel16
            // 
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.FontSize = MetroFramework5.Drawing.MetroFontSize.Medium;
            this.metroLabel16.Location = new System.Drawing.Point(231, 39);
            this.metroLabel16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Size = new System.Drawing.Size(344, 25);
            this.metroLabel16.Style = "NewTheme";
            this.metroLabel16.TabIndex = 17;
            this.metroLabel16.Text = "This wizard has successfully finished uninstalling";
            this.metroLabel16.Theme = "NewTheme";
            this.metroLabel16.UseCompatibleTextRendering = true;
            // 
            // metroTile2
            // 
            this.metroTile2.Location = new System.Drawing.Point(223, -31);
            this.metroTile2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(1, 362);
            this.metroTile2.Style = "NewTheme";
            this.metroTile2.TabIndex = 15;
            this.metroTile2.Text = "metroTile2";
            this.metroTile2.Theme = "NewTheme";
            this.metroTile2.UseVisualStyleBackColor = false;
            // 
            // metroPanel10
            // 
            this.metroPanel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(48)))));
            this.metroPanel10.BorderStyle = MetroFramework5.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel10.Controls.Add(this.step5FinishButton);
            this.metroPanel10.ForeColor = System.Drawing.Color.Gray;
            this.metroPanel10.HorizontalScrollbarBarColor = true;
            this.metroPanel10.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel10.HorizontalScrollbarSize = 12;
            this.metroPanel10.Location = new System.Drawing.Point(-10, 330);
            this.metroPanel10.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.metroPanel10.Name = "metroPanel10";
            this.metroPanel10.Size = new System.Drawing.Size(604, 74);
            this.metroPanel10.Style = "NewTheme";
            this.metroPanel10.TabIndex = 14;
            this.metroPanel10.Theme = "NewTheme";
            this.metroPanel10.VerticalScrollbarBarColor = true;
            this.metroPanel10.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel10.VerticalScrollbarSize = 12;
            // 
            // step5FinishButton
            // 
            this.step5FinishButton.Location = new System.Drawing.Point(472, 13);
            this.step5FinishButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.step5FinishButton.Name = "step5FinishButton";
            this.step5FinishButton.Size = new System.Drawing.Size(85, 27);
            this.step5FinishButton.Style = "NewTheme";
            this.step5FinishButton.TabIndex = 0;
            this.step5FinishButton.Text = "Finish";
            this.step5FinishButton.Theme = "NewTheme";
            this.step5FinishButton.Click += new System.EventHandler(this.step5FinishButton_Click);
            // 
            // metroLabel14
            // 
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.FontSize = MetroFramework5.Drawing.MetroFontSize.Large;
            this.metroLabel14.Location = new System.Drawing.Point(231, -6);
            this.metroLabel14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(223, 31);
            this.metroLabel14.Style = "NewTheme";
            this.metroLabel14.TabIndex = 13;
            this.metroLabel14.Text = "Successfully Uninstalled";
            this.metroLabel14.Theme = "NewTheme";
            this.metroLabel14.UseCompatibleTextRendering = true;
            // 
            // step4ExtractLabel
            // 
            this.step4ExtractLabel.Location = new System.Drawing.Point(22, 42);
            this.step4ExtractLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.step4ExtractLabel.Name = "step4ExtractLabel";
            this.step4ExtractLabel.Size = new System.Drawing.Size(528, 27);
            this.step4ExtractLabel.Style = "NewTheme";
            this.step4ExtractLabel.TabIndex = 17;
            this.step4ExtractLabel.Text = "Downloading...";
            this.step4ExtractLabel.Theme = "NewTheme";
            this.step4ExtractLabel.UseCompatibleTextRendering = true;
            // 
            // metroPanel9
            // 
            this.metroPanel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(72)))), ((int)(((byte)(165)))));
            this.metroPanel9.HorizontalScrollbarBarColor = true;
            this.metroPanel9.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel9.HorizontalScrollbarSize = 12;
            this.metroPanel9.Location = new System.Drawing.Point(-5, 38);
            this.metroPanel9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.metroPanel9.Name = "metroPanel9";
            this.metroPanel9.Size = new System.Drawing.Size(594, 1);
            this.metroPanel9.TabIndex = 10;
            this.metroPanel9.VerticalScrollbarBarColor = true;
            this.metroPanel9.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel9.VerticalScrollbarSize = 12;
            // 
            // metroLabel15
            // 
            this.metroLabel15.FontSize = MetroFramework5.Drawing.MetroFontSize.Large;
            this.metroLabel15.Location = new System.Drawing.Point(224, -6);
            this.metroLabel15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(134, 36);
            this.metroLabel15.Style = "NewTheme";
            this.metroLabel15.TabIndex = 11;
            this.metroLabel15.Text = "Uninstalling";
            this.metroLabel15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroLabel15.Theme = "NewTheme";
            this.metroLabel15.UseCompatibleTextRendering = true;
            // 
            // metroPanel4
            // 
            this.metroPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(48)))));
            this.metroPanel4.BorderStyle = MetroFramework5.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel4.Controls.Add(this.finalNextButton);
            this.metroPanel4.Controls.Add(this.step4CancelButton);
            this.metroPanel4.ForeColor = System.Drawing.Color.Gray;
            this.metroPanel4.HorizontalScrollbarBarColor = true;
            this.metroPanel4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel4.HorizontalScrollbarSize = 12;
            this.metroPanel4.Location = new System.Drawing.Point(-10, 330);
            this.metroPanel4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.metroPanel4.Name = "metroPanel4";
            this.metroPanel4.Size = new System.Drawing.Size(604, 74);
            this.metroPanel4.Style = "NewTheme";
            this.metroPanel4.TabIndex = 12;
            this.metroPanel4.Theme = "NewTheme";
            this.metroPanel4.VerticalScrollbarBarColor = true;
            this.metroPanel4.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel4.VerticalScrollbarSize = 12;
            // 
            // finalNextButton
            // 
            this.finalNextButton.Location = new System.Drawing.Point(380, 13);
            this.finalNextButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.finalNextButton.Name = "finalNextButton";
            this.finalNextButton.Size = new System.Drawing.Size(85, 27);
            this.finalNextButton.Style = "NewTheme";
            this.finalNextButton.TabIndex = 2;
            this.finalNextButton.Text = "Next";
            this.finalNextButton.Theme = "NewTheme";
            this.finalNextButton.Visible = false;
            this.finalNextButton.Click += new System.EventHandler(this.finalNextButton_Click);
            // 
            // step4CancelButton
            // 
            this.step4CancelButton.Location = new System.Drawing.Point(472, 13);
            this.step4CancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.step4CancelButton.Name = "step4CancelButton";
            this.step4CancelButton.Size = new System.Drawing.Size(85, 27);
            this.step4CancelButton.Style = "NewTheme";
            this.step4CancelButton.TabIndex = 0;
            this.step4CancelButton.Text = "Cancel";
            this.step4CancelButton.Theme = "NewTheme";
            this.step4CancelButton.Click += new System.EventHandler(this.step4CancelButton_Click);
            // 
            // step4ProgressBar
            // 
            this.step4ProgressBar.Location = new System.Drawing.Point(27, 65);
            this.step4ProgressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.step4ProgressBar.MarqueeAnimationSpeed = 10;
            this.step4ProgressBar.Name = "step4ProgressBar";
            this.step4ProgressBar.ProgressBarStyle = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.step4ProgressBar.Size = new System.Drawing.Size(530, 27);
            this.step4ProgressBar.Style = "NewTheme";
            this.step4ProgressBar.TabIndex = 14;
            this.step4ProgressBar.Theme = "NewTheme";
            // 
            // step2GroupPanel
            // 
            this.step2GroupPanel.BackColor = System.Drawing.Color.Transparent;
            this.step2GroupPanel.Controls.Add(this.step4ProgressBar);
            this.step2GroupPanel.Controls.Add(this.metroPanel4);
            this.step2GroupPanel.Controls.Add(this.metroLabel15);
            this.step2GroupPanel.Controls.Add(this.metroPanel9);
            this.step2GroupPanel.Controls.Add(this.step4ExtractLabel);
            this.step2GroupPanel.HorizontalScrollbarBarColor = true;
            this.step2GroupPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.step2GroupPanel.HorizontalScrollbarSize = 12;
            this.step2GroupPanel.Location = new System.Drawing.Point(0, 33);
            this.step2GroupPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.step2GroupPanel.Name = "step2GroupPanel";
            this.step2GroupPanel.Size = new System.Drawing.Size(583, 381);
            this.step2GroupPanel.Style = "NewTheme";
            this.step2GroupPanel.TabIndex = 13;
            this.step2GroupPanel.Theme = "NewTheme";
            this.step2GroupPanel.VerticalScrollbarBarColor = true;
            this.step2GroupPanel.VerticalScrollbarHighlightOnWheel = false;
            this.step2GroupPanel.VerticalScrollbarSize = 12;
            // 
            // UninstallerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 415);
            this.Controls.Add(this.step2GroupPanel);
            this.Controls.Add(this.step1GroupPanel);
            this.Controls.Add(this.step3GroupPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "UninstallerForm";
            this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            this.Resizable = false;
            this.ShowFormIcon = true;
            this.Style = "NewTheme";
            this.Text = "Shotr";
            this.Theme = "NewTheme";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.metroPanel1.ResumeLayout(false);
            this.step1GroupPanel.ResumeLayout(false);
            this.step1GroupPanel.PerformLayout();
            this.step3GroupPanel.ResumeLayout(false);
            this.step3GroupPanel.PerformLayout();
            this.metroPanel10.ResumeLayout(false);
            this.metroPanel4.ResumeLayout(false);
            this.step2GroupPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework5.Controls.MetroButton step1CancelButton;
        private MetroFramework5.Controls.MetroButton step1NextButton;
        private MetroFramework5.Controls.MetroPanel metroPanel1;
        private MetroFramework5.Controls.MetroTile metroTile1;
        private MetroFramework5.Controls.MetroLabel metroLabel1;
        private MetroFramework5.Controls.MetroLabel metroLabel2;
        private MetroFramework5.Controls.MetroLabel metroLabel3;
        private MetroFramework5.Controls.MetroLabel metroLabel4;
        private MetroFramework5.Controls.MetroLabel metroLabel5;
        private MetroFramework5.Controls.MetroPanel step1GroupPanel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private MetroFramework5.Controls.MetroPanel step3GroupPanel;
        private MetroFramework5.Controls.MetroLabel metroLabel16;
        private MetroFramework5.Controls.MetroTile metroTile2;
        private MetroFramework5.Controls.MetroPanel metroPanel10;
        private MetroFramework5.Controls.MetroButton step5FinishButton;
        private MetroFramework5.Controls.MetroLabel metroLabel14;
        private MetroFramework5.Controls.MetroLabel metroLabel17;
        private MetroFramework5.Controls.MetroLabel step4ExtractLabel;
        private MetroFramework5.Controls.MetroPanel metroPanel9;
        private MetroFramework5.Controls.MetroLabel metroLabel15;
        private MetroFramework5.Controls.MetroPanel metroPanel4;
        private MetroFramework5.Controls.MetroButton finalNextButton;
        private MetroFramework5.Controls.MetroButton step4CancelButton;
        private MetroFramework5.Controls.MetroProgressBar step4ProgressBar;
        private MetroFramework5.Controls.MetroPanel step2GroupPanel;
    }
}


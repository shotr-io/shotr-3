using Shotr.Ui.DpiScaling;

namespace Shotr.Ui.Forms
{
    partial class UpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            this.metroTextBox1 = new DpiScaledTextbox();
            this.metroLabel1 = new DpiScaledLabel();
            this.metroButton1 = new DpiScaledButton();
            this.metroButton2 = new DpiScaledButton();
            this.metroLabel2 = new DpiScaledLabel();
            this.metroProgressSpinner1 = new MetroFramework5.Controls.MetroProgressSpinner();
            this.SuspendLayout();
            // 
            // metroTextBox1
            // 
            this.metroTextBox1.Location = new System.Drawing.Point(16, 90);
            this.metroTextBox1.Multiline = true;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.ReadOnly = true;
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.metroTextBox1.Size = new System.Drawing.Size(420, 154);
            this.metroTextBox1.Style = "NewTheme";
            this.metroTextBox1.TabIndex = 1;
            this.metroTextBox1.TabStop = false;
            this.metroTextBox1.Text = "New Stuff has been Added.";
            this.metroTextBox1.Theme = "NewTheme";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(12, 64);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Scaled = true;
            this.metroLabel1.Size = new System.Drawing.Size(112, 25);
            this.metroLabel1.Style = "NewTheme";
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Release Notes:";
            this.metroLabel1.Theme = "NewTheme";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(280, 63);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Scaled = true;
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.Style = "NewTheme";
            this.metroButton1.TabIndex = 2;
            this.metroButton1.Text = "Update";
            this.metroButton1.Theme = "NewTheme";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(361, 63);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Scaled = true;
            this.metroButton2.Size = new System.Drawing.Size(75, 23);
            this.metroButton2.Style = "NewTheme";
            this.metroButton2.TabIndex = 3;
            this.metroButton2.Text = "Close";
            this.metroButton2.Theme = "NewTheme";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework5.Drawing.MetroFontSize.Small;
            this.metroLabel2.Location = new System.Drawing.Point(234, 41);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Scaled = true;
            this.metroLabel2.Size = new System.Drawing.Size(213, 22);
            this.metroLabel2.Style = "NewTheme";
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "An update is available, download?";
            this.metroLabel2.Theme = "NewTheme";
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.BackColor = System.Drawing.Color.Transparent;
            this.metroProgressSpinner1.Location = new System.Drawing.Point(226, 27);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(25, 25);
            this.metroProgressSpinner1.Style = "NewTheme";
            this.metroProgressSpinner1.TabIndex = 5;
            this.metroProgressSpinner1.TabStop = false;
            this.metroProgressSpinner1.Theme = "NewTheme";
            this.metroProgressSpinner1.Visible = false;
            this.metroProgressSpinner1.Click += new System.EventHandler(this.metroProgressSpinner1_Click);
            // 
            // UpdateForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = MetroFramework5.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(451, 260);
            this.Controls.Add(this.metroProgressSpinner1);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UpdateForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework5.Forms.MetroForm.MetroFormShadowType.DropShadow;
            this.ShowFormIcon = true;
            this.Style = "NewTheme";
            this.Text = "Shotr Updater";
            this.Theme = "NewTheme";
            this.Load += new System.EventHandler(this.UpdateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DpiScaledTextbox metroTextBox1;
        private DpiScaledLabel metroLabel1;
        private DpiScaledButton metroButton1;
        private DpiScaledButton metroButton2;
        private DpiScaledLabel metroLabel2;
        private MetroFramework5.Controls.MetroProgressSpinner metroProgressSpinner1;
    }
}
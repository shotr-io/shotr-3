using Shotr.Ui.DpiScaling;

namespace Shotr.Ui.Plugin.CorePlugins
{
    partial class CorePluginForm
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
            this.metroButton1 = new DpiScaledButton();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(5, 5);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(113, 26);
            this.metroButton1.TabIndex = 0;
            this.metroButton1.Text = "Do Stuff";
            this.metroButton1.Theme = "Dark";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // CorePluginForm
            // 
            
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(587, 263);
            this.Controls.Add(this.metroButton1);
            this.Name = "CorePluginForm";
            this.Theme = "Dark";
            this.ResumeLayout(false);

        }

        #endregion

        private DpiScaledButton metroButton1;

    }
}
using System.ComponentModel;
using System.Windows.Forms;
using Shotr.Core.DpiScaling;

namespace Shotr.Ui.Forms.Settings
{
    partial class CustomUploader
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomUploader));
            this.betterListView1 = new DpiScaledListbox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroPanel1 = new DpiScaledPanel();
            this.dpiScaledButton1 = new DpiScaledButton();
            this.metroToggle1 = new DpiScaledToggle();
            this.metroLabel6 = new DpiScaledLabel();
            this.metroLabel5 = new DpiScaledLabel();
            this.metroTextBox5 = new DpiScaledTextbox();
            this.metroLabel4 = new DpiScaledLabel();
            this.metroTextBox4 = new DpiScaledTextbox();
            this.metroButton2 = new DpiScaledButton();
            this.metroButton1 = new DpiScaledButton();
            this.metroTextBox3 = new DpiScaledTextbox();
            this.metroTextBox2 = new DpiScaledTextbox();
            this.metroComboBox1 = new DpiScaledCombobox();
            this.metroLabel3 = new DpiScaledLabel();
            this.metroLabel1 = new DpiScaledLabel();
            this.betterListView2 = new DpiScaledListbox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.metroLabel2 = new DpiScaledLabel();
            this.metroTextBox1 = new DpiScaledTextbox();
            this.metroPanel2 = new DpiScaledPanel();
            this.metroButton4 = new DpiScaledButton();
            this.metroButton3 = new DpiScaledButton();
            ((System.ComponentModel.ISupportInitialize)(this.betterListView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.betterListView2)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // betterListView1
            // 
            this.betterListView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(48)))));
            this.betterListView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.betterListView1.Location = new System.Drawing.Point(15, 63);
            this.betterListView1.Name = "betterListView1";
            this.betterListView1.Size = new System.Drawing.Size(245, 510);
            this.betterListView1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.toolStripSeparator1,
            this.testToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(118, 76);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(114, 6);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = MetroFramework5.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.dpiScaledButton1);
            this.metroPanel1.Controls.Add(this.metroToggle1);
            this.metroPanel1.Controls.Add(this.metroLabel6);
            this.metroPanel1.Controls.Add(this.metroLabel5);
            this.metroPanel1.Controls.Add(this.metroTextBox5);
            this.metroPanel1.Controls.Add(this.metroLabel4);
            this.metroPanel1.Controls.Add(this.metroTextBox4);
            this.metroPanel1.Controls.Add(this.metroButton2);
            this.metroPanel1.Controls.Add(this.metroButton1);
            this.metroPanel1.Controls.Add(this.metroTextBox3);
            this.metroPanel1.Controls.Add(this.metroTextBox2);
            this.metroPanel1.Controls.Add(this.metroComboBox1);
            this.metroPanel1.Controls.Add(this.metroLabel3);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Controls.Add(this.betterListView2);
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.Controls.Add(this.metroTextBox1);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(273, 63);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(245, 510);
            this.metroPanel1.Style = "NewTheme";
            this.metroPanel1.TabIndex = 1;
            this.metroPanel1.Theme = "NewTheme";
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            this.metroPanel1.Visible = false;
            // 
            // dpiScaledButton1
            // 
            this.dpiScaledButton1.FontSize = MetroFramework5.Drawing.MetroFontSize.Default;
            this.dpiScaledButton1.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Default;
            this.dpiScaledButton1.Location = new System.Drawing.Point(155, 8);
            this.dpiScaledButton1.Name = "dpiScaledButton1";
            this.dpiScaledButton1.Scaled = true;
            this.dpiScaledButton1.Size = new System.Drawing.Size(76, 25);
            this.dpiScaledButton1.Style = "NewTheme";
            this.dpiScaledButton1.TabIndex = 18;
            this.dpiScaledButton1.Text = "Cancel";
            this.dpiScaledButton1.Theme = "NewTheme";
            this.dpiScaledButton1.Click += new System.EventHandler(this.dpiScaledButton1_Click);
            // 
            // metroToggle1
            // 
            this.metroToggle1.AutoSize = true;
            this.metroToggle1.Location = new System.Drawing.Point(150, 121);
            this.metroToggle1.Name = "metroToggle1";
            this.metroToggle1.Size = new System.Drawing.Size(80, 17);
            this.metroToggle1.Style = "NewTheme";
            this.metroToggle1.TabIndex = 17;
            this.metroToggle1.Text = "Off";
            this.metroToggle1.Theme = "NewTheme";
            // 
            // metroLabel6
            // 
            this.metroLabel6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(11, 119);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Scaled = true;
            this.metroLabel6.Size = new System.Drawing.Size(107, 25);
            this.metroLabel6.Style = "NewTheme";
            this.metroLabel6.TabIndex = 16;
            this.metroLabel6.Text = "Page Support:";
            this.metroLabel6.Theme = "NewTheme";
            // 
            // metroLabel5
            // 
            this.metroLabel5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(11, 64);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Scaled = true;
            this.metroLabel5.Size = new System.Drawing.Size(103, 25);
            this.metroLabel5.Style = "NewTheme";
            this.metroLabel5.TabIndex = 15;
            this.metroLabel5.Text = "Uploader URL:";
            this.metroLabel5.Theme = "NewTheme";
            // 
            // metroTextBox5
            // 
            this.metroTextBox5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroTextBox5.Location = new System.Drawing.Point(16, 92);
            this.metroTextBox5.Name = "metroTextBox5";
            this.metroTextBox5.PromptText = "http://my.com/script.php";
            this.metroTextBox5.Size = new System.Drawing.Size(214, 23);
            this.metroTextBox5.Style = "NewTheme";
            this.metroTextBox5.TabIndex = 14;
            this.metroTextBox5.Theme = "NewTheme";
            // 
            // metroLabel4
            // 
            this.metroLabel4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(11, 205);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Scaled = true;
            this.metroLabel4.Size = new System.Drawing.Size(121, 25);
            this.metroLabel4.Style = "NewTheme";
            this.metroLabel4.TabIndex = 13;
            this.metroLabel4.Text = "File Form Name:";
            this.metroLabel4.Theme = "NewTheme";
            // 
            // metroTextBox4
            // 
            this.metroTextBox4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroTextBox4.Location = new System.Drawing.Point(16, 231);
            this.metroTextBox4.Name = "metroTextBox4";
            this.metroTextBox4.PromptText = "shotr_image";
            this.metroTextBox4.Size = new System.Drawing.Size(214, 23);
            this.metroTextBox4.Style = "NewTheme";
            this.metroTextBox4.TabIndex = 12;
            this.metroTextBox4.Theme = "NewTheme";
            // 
            // metroButton2
            // 
            this.metroButton2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroButton2.FontSize = MetroFramework5.Drawing.MetroFontSize.Default;
            this.metroButton2.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Default;
            this.metroButton2.Location = new System.Drawing.Point(155, 343);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Scaled = true;
            this.metroButton2.Size = new System.Drawing.Size(75, 23);
            this.metroButton2.Style = "NewTheme";
            this.metroButton2.TabIndex = 11;
            this.metroButton2.Text = "Save";
            this.metroButton2.Theme = "NewTheme";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroButton1.FontSize = MetroFramework5.Drawing.MetroFontSize.Default;
            this.metroButton1.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Default;
            this.metroButton1.Location = new System.Drawing.Point(16, 343);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Scaled = true;
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.Style = "NewTheme";
            this.metroButton1.TabIndex = 10;
            this.metroButton1.Text = "Add";
            this.metroButton1.Theme = "NewTheme";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroTextBox3
            // 
            this.metroTextBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroTextBox3.Location = new System.Drawing.Point(16, 314);
            this.metroTextBox3.Name = "metroTextBox3";
            this.metroTextBox3.PromptText = "Value";
            this.metroTextBox3.Size = new System.Drawing.Size(214, 23);
            this.metroTextBox3.Style = "NewTheme";
            this.metroTextBox3.TabIndex = 9;
            this.metroTextBox3.Theme = "NewTheme";
            // 
            // metroTextBox2
            // 
            this.metroTextBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroTextBox2.Location = new System.Drawing.Point(16, 281);
            this.metroTextBox2.Name = "metroTextBox2";
            this.metroTextBox2.PromptText = "Key";
            this.metroTextBox2.Size = new System.Drawing.Size(214, 23);
            this.metroTextBox2.Style = "NewTheme";
            this.metroTextBox2.TabIndex = 8;
            this.metroTextBox2.Theme = "NewTheme";
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 29;
            this.metroComboBox1.Items.AddRange(new object[] {
            "POST",
            "GET"});
            this.metroComboBox1.Location = new System.Drawing.Point(16, 167);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(214, 35);
            this.metroComboBox1.Style = "NewTheme";
            this.metroComboBox1.TabIndex = 7;
            this.metroComboBox1.Theme = "NewTheme";
            // 
            // metroLabel3
            // 
            this.metroLabel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(11, 143);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Scaled = true;
            this.metroLabel3.Size = new System.Drawing.Size(107, 25);
            this.metroLabel3.Style = "NewTheme";
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "Request Type:";
            this.metroLabel3.Theme = "NewTheme";
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(12, 257);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Scaled = true;
            this.metroLabel1.Size = new System.Drawing.Size(112, 25);
            this.metroLabel1.Style = "NewTheme";
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Upload Values:";
            this.metroLabel1.Theme = "NewTheme";
            // 
            // betterListView2
            // 
            this.betterListView2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.betterListView2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(48)))));
            this.betterListView2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.betterListView2.Location = new System.Drawing.Point(16, 372);
            this.betterListView2.Name = "betterListView2";
            this.betterListView2.Size = new System.Drawing.Size(214, 127);
            this.betterListView2.TabIndex = 2;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(118, 26);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(117, 22);
            this.toolStripMenuItem2.Text = "Remove";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(11, 9);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Scaled = true;
            this.metroLabel2.Size = new System.Drawing.Size(122, 25);
            this.metroLabel2.Style = "NewTheme";
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Uploader Name:";
            this.metroLabel2.Theme = "NewTheme";
            // 
            // metroTextBox1
            // 
            this.metroTextBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroTextBox1.Location = new System.Drawing.Point(17, 38);
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PromptText = "My Custom Uploader";
            this.metroTextBox1.Size = new System.Drawing.Size(214, 23);
            this.metroTextBox1.Style = "NewTheme";
            this.metroTextBox1.TabIndex = 3;
            this.metroTextBox1.Theme = "NewTheme";
            // 
            // metroPanel2
            // 
            this.metroPanel2.BorderStyle = MetroFramework5.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel2.Controls.Add(this.metroButton4);
            this.metroPanel2.Controls.Add(this.metroButton3);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(273, 63);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(245, 510);
            this.metroPanel2.Style = "NewTheme";
            this.metroPanel2.TabIndex = 2;
            this.metroPanel2.Theme = "NewTheme";
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroButton4.FontSize = MetroFramework5.Drawing.MetroFontSize.Default;
            this.metroButton4.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Default;
            this.metroButton4.Location = new System.Drawing.Point(13, 43);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Scaled = true;
            this.metroButton4.Size = new System.Drawing.Size(218, 23);
            this.metroButton4.Style = "NewTheme";
            this.metroButton4.TabIndex = 13;
            this.metroButton4.Text = "Add a Custom Uploader";
            this.metroButton4.Theme = "NewTheme";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroButton3.FontSize = MetroFramework5.Drawing.MetroFontSize.Default;
            this.metroButton3.FontWeight = MetroFramework5.Drawing.MetroFontWeight.Default;
            this.metroButton3.Location = new System.Drawing.Point(13, 13);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Scaled = true;
            this.metroButton3.Size = new System.Drawing.Size(218, 23);
            this.metroButton3.Style = "NewTheme";
            this.metroButton3.TabIndex = 12;
            this.metroButton3.Text = "Add a Shotr Uploader";
            this.metroButton3.Theme = "NewTheme";
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // CustomUploader
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = MetroFramework5.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(533, 588);
            this.Controls.Add(this.betterListView1);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomUploader";
            this.Resizable = false;
            this.ShadowType = MetroFramework5.Forms.MetroForm.MetroFormShadowType.DropShadow;
            this.ShowFormIcon = true;
            this.Style = "NewTheme";
            this.Text = "Custom Uploaders";
            this.Theme = "NewTheme";
            this.Load += new System.EventHandler(this.CustomUploader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.betterListView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.betterListView2)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.metroPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DpiScaledListbox betterListView1;
        private DpiScaledPanel metroPanel1;
        private DpiScaledTextbox metroTextBox1;
        private DpiScaledListbox betterListView2;
        private DpiScaledLabel metroLabel2;
        private DpiScaledLabel metroLabel5;
        private DpiScaledTextbox metroTextBox5;
        private DpiScaledLabel metroLabel4;
        private DpiScaledTextbox metroTextBox4;
        private DpiScaledButton metroButton2;
        private DpiScaledButton metroButton1;
        private DpiScaledTextbox metroTextBox3;
        private DpiScaledTextbox metroTextBox2;
        private DpiScaledCombobox metroComboBox1;
        private DpiScaledLabel metroLabel3;
        private DpiScaledLabel metroLabel1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem removeToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem testToolStripMenuItem;
        private DpiScaledToggle metroToggle1;
        private DpiScaledLabel metroLabel6;
        private DpiScaledPanel metroPanel2;
        private DpiScaledButton metroButton4;
        private DpiScaledButton metroButton3;
        private DpiScaledButton dpiScaledButton1;
    }
}
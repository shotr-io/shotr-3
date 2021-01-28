// using System.ComponentModel;
// using System.Windows.Forms;
// using Shotr.Core.DpiScaling;
//
// namespace Shotr.Ui.Forms.Settings
// {
//     partial class CustomUploader
//     {
//         /// <summary>
//         /// Required designer variable.
//         /// </summary>
//         private IContainer components = null;
//
//         /// <summary>
//         /// Clean up any resources being used.
//         /// </summary>
//         /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//         protected override void Dispose(bool disposing)
//         {
//             if (disposing && (components != null))
//             {
//                 components.Dispose();
//             }
//             base.Dispose(disposing);
//         }
//
//         #region Windows Form Designer generated code
//
//         /// <summary>
//         /// Required method for Designer support - do not modify
//         /// the contents of this method with the code editor.
//         /// </summary>
//         private void InitializeComponent()
//         {
//             this.components = new System.ComponentModel.Container();
//             System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomUploader));
//             this.betterListView1 = new Shotr.Core.DpiScaling.DpiScaledListbox();
//             this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
//             this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
//             this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//             this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//             this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
//             this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//             this.metroPanel1 = new Shotr.Core.DpiScaling.ThemedPanel();
//             this.ThemedButton1 = new Shotr.Core.DpiScaling.ThemedButton();
//             this.metroToggle1 = new Shotr.Core.DpiScaling.ThemedToggle();
//             this.metroLabel6 = new Shotr.Core.DpiScaling.ThemedLabel();
//             this.metroLabel5 = new Shotr.Core.DpiScaling.ThemedLabel();
//             this.metroTextBox5 = new Shotr.Core.DpiScaling.ThemedTextBox();
//             this.metroLabel4 = new Shotr.Core.DpiScaling.ThemedLabel();
//             this.metroTextBox4 = new Shotr.Core.DpiScaling.ThemedTextBox();
//             this.metroButton2 = new Shotr.Core.DpiScaling.ThemedButton();
//             this.metroButton1 = new Shotr.Core.DpiScaling.ThemedButton();
//             this.metroTextBox3 = new Shotr.Core.DpiScaling.ThemedTextBox();
//             this.metroTextBox2 = new Shotr.Core.DpiScaling.ThemedTextBox();
//             this.metroComboBox1 = new Shotr.Core.DpiScaling.ThemedComboBox();
//             this.metroLabel3 = new Shotr.Core.DpiScaling.ThemedLabel();
//             this.metroLabel1 = new Shotr.Core.DpiScaling.ThemedLabel();
//             this.betterListView2 = new Shotr.Core.DpiScaling.DpiScaledListbox();
//             this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
//             this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
//             this.metroLabel2 = new Shotr.Core.DpiScaling.ThemedLabel();
//             this.metroTextBox1 = new Shotr.Core.DpiScaling.ThemedTextBox();
//             this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
//             this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
//             this.metroPanel2 = new Shotr.Core.DpiScaling.ThemedPanel();
//             this.metroButton4 = new Shotr.Core.DpiScaling.ThemedButton();
//             this.metroButton3 = new Shotr.Core.DpiScaling.ThemedButton();
//             this.contextMenuStrip1.SuspendLayout();
//             this.metroPanel1.SuspendLayout();
//             this.contextMenuStrip2.SuspendLayout();
//             this.metroPanel2.SuspendLayout();
//             this.SuspendLayout();
//             // 
//             // betterListView1
//             // 
//             this.betterListView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(48)))));
//             this.betterListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
//             this.columnHeader3});
//             this.betterListView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
//             this.betterListView1.FullRowSelect = true;
//             this.betterListView1.HideSelection = false;
//             this.betterListView1.Location = new System.Drawing.Point(15, 63);
//             this.betterListView1.Name = "betterListView1";
//             this.betterListView1.Size = new System.Drawing.Size(245, 510);
//             this.betterListView1.TabIndex = 0;
//             this.betterListView1.UseCompatibleStateImageBehavior = false;
//             this.betterListView1.View = System.Windows.Forms.View.Details;
//             // 
//             // columnHeader3
//             // 
//             this.columnHeader3.Text = "Name";
//             this.columnHeader3.Width = 220;
//             // 
//             // contextMenuStrip1
//             // 
//             this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
//             this.editToolStripMenuItem,
//             this.removeToolStripMenuItem,
//             this.toolStripSeparator1,
//             this.testToolStripMenuItem});
//             this.contextMenuStrip1.Name = "contextMenuStrip1";
//             this.contextMenuStrip1.Size = new System.Drawing.Size(118, 76);
//             // 
//             // editToolStripMenuItem
//             // 
//             this.editToolStripMenuItem.Name = "editToolStripMenuItem";
//             this.editToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
//             this.editToolStripMenuItem.Text = "Edit";
//             this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
//             // 
//             // removeToolStripMenuItem
//             // 
//             this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
//             this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
//             this.removeToolStripMenuItem.Text = "Remove";
//             this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
//             // 
//             // toolStripSeparator1
//             // 
//             this.toolStripSeparator1.Name = "toolStripSeparator1";
//             this.toolStripSeparator1.Size = new System.Drawing.Size(114, 6);
//             // 
//             // testToolStripMenuItem
//             // 
//             this.testToolStripMenuItem.Name = "testToolStripMenuItem";
//             this.testToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
//             this.testToolStripMenuItem.Text = "Test";
//             this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
//             // 
//             // metroPanel1
//             // 

//             this.metroPanel1.Controls.Add(this.ThemedButton1);
//             this.metroPanel1.Controls.Add(this.metroToggle1);
//             this.metroPanel1.Controls.Add(this.metroLabel6);
//             this.metroPanel1.Controls.Add(this.metroLabel5);
//             this.metroPanel1.Controls.Add(this.metroTextBox5);
//             this.metroPanel1.Controls.Add(this.metroLabel4);
//             this.metroPanel1.Controls.Add(this.metroTextBox4);
//             this.metroPanel1.Controls.Add(this.metroButton2);
//             this.metroPanel1.Controls.Add(this.metroButton1);
//             this.metroPanel1.Controls.Add(this.metroTextBox3);
//             this.metroPanel1.Controls.Add(this.metroTextBox2);
//             this.metroPanel1.Controls.Add(this.metroComboBox1);
//             this.metroPanel1.Controls.Add(this.metroLabel3);
//             this.metroPanel1.Controls.Add(this.metroLabel1);
//             this.metroPanel1.Controls.Add(this.betterListView2);
//             this.metroPanel1.Controls.Add(this.metroLabel2);
//             this.metroPanel1.Controls.Add(this.metroTextBox1);
//             this.metroPanel1.HorizontalScrollbarBarColor = true;
//             this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
//             this.metroPanel1.HorizontalScrollbarSize = 10;
//             this.metroPanel1.Location = new System.Drawing.Point(273, 63);
//             this.metroPanel1.Name = "metroPanel1";
//             this.metroPanel1.Size = new System.Drawing.Size(245, 510);

//             this.metroPanel1.TabIndex = 1;

//             this.metroPanel1.VerticalScrollbarBarColor = true;
//             this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
//             this.metroPanel1.VerticalScrollbarSize = 10;
//             this.metroPanel1.Visible = false;
//             // 
//             // ThemedButton1
//             // 


//             this.ThemedButton1.Location = new System.Drawing.Point(155, 8);
//             this.ThemedButton1.Name = "ThemedButton1";

//             this.ThemedButton1.Size = new System.Drawing.Size(76, 25);

//             this.ThemedButton1.TabIndex = 18;
//             this.ThemedButton1.Text = "Cancel";

//             this.ThemedButton1.Click += new System.EventHandler(this.ThemedButton1_Click);
//             // 
//             // metroToggle1
//             // 
//             this.metroToggle1.AutoSize = true;
//             this.metroToggle1.Location = new System.Drawing.Point(150, 121);
//             this.metroToggle1.Name = "metroToggle1";
//             this.metroToggle1.Size = new System.Drawing.Size(80, 19);

//             this.metroToggle1.TabIndex = 17;
//             this.metroToggle1.Text = "Off";

//             this.metroToggle1.UseVisualStyleBackColor = false;
//             // 
//             // metroLabel6
//             // 
//             this.metroLabel6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//             this.metroLabel6.AutoSize = true;
//             this.metroLabel6.Location = new System.Drawing.Point(11, 119);
//             this.metroLabel6.Name = "metroLabel6";

//             this.metroLabel6.Size = new System.Drawing.Size(107, 25);

//             this.metroLabel6.TabIndex = 16;
//             this.metroLabel6.Text = "Page Support:";

//             this.metroLabel6.UseCompatibleTextRendering = true;
//             // 
//             // metroLabel5
//             // 
//             this.metroLabel5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//             this.metroLabel5.AutoSize = true;
//             this.metroLabel5.Location = new System.Drawing.Point(11, 64);
//             this.metroLabel5.Name = "metroLabel5";

//             this.metroLabel5.Size = new System.Drawing.Size(103, 25);

//             this.metroLabel5.TabIndex = 15;
//             this.metroLabel5.Text = "Uploader URL:";

//             this.metroLabel5.UseCompatibleTextRendering = true;
//             // 
//             // metroTextBox5
//             // 
//             this.metroTextBox5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//             this.metroTextBox5.Location = new System.Drawing.Point(16, 92);
//             this.metroTextBox5.Name = "metroTextBox5";
//             this.metroTextBox5.PromptText = "http://my.com/script.php";
//             this.metroTextBox5.Size = new System.Drawing.Size(214, 23);

//             this.metroTextBox5.TabIndex = 14;

//             // 
//             // metroLabel4
//             // 
//             this.metroLabel4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//             this.metroLabel4.AutoSize = true;
//             this.metroLabel4.Location = new System.Drawing.Point(11, 205);
//             this.metroLabel4.Name = "metroLabel4";

//             this.metroLabel4.Size = new System.Drawing.Size(121, 25);

//             this.metroLabel4.TabIndex = 13;
//             this.metroLabel4.Text = "File Form Name:";

//             this.metroLabel4.UseCompatibleTextRendering = true;
//             // 
//             // metroTextBox4
//             // 
//             this.metroTextBox4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//             this.metroTextBox4.Location = new System.Drawing.Point(16, 231);
//             this.metroTextBox4.Name = "metroTextBox4";
//             this.metroTextBox4.PromptText = "shotr_image";
//             this.metroTextBox4.Size = new System.Drawing.Size(214, 23);

//             this.metroTextBox4.TabIndex = 12;

//             // 
//             // metroButton2
//             // 
//             this.metroButton2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;


//             this.metroButton2.Location = new System.Drawing.Point(155, 343);
//             this.metroButton2.Name = "metroButton2";

//             this.metroButton2.Size = new System.Drawing.Size(75, 23);

//             this.metroButton2.TabIndex = 11;
//             this.metroButton2.Text = "Save";

//             this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
//             // 
//             // metroButton1
//             // 
//             this.metroButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;


//             this.metroButton1.Location = new System.Drawing.Point(16, 343);
//             this.metroButton1.Name = "metroButton1";

//             this.metroButton1.Size = new System.Drawing.Size(75, 23);

//             this.metroButton1.TabIndex = 10;
//             this.metroButton1.Text = "Add";

//             this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
//             // 
//             // metroTextBox3
//             // 
//             this.metroTextBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//             this.metroTextBox3.Location = new System.Drawing.Point(16, 314);
//             this.metroTextBox3.Name = "metroTextBox3";
//             this.metroTextBox3.PromptText = "Value";
//             this.metroTextBox3.Size = new System.Drawing.Size(214, 23);

//             this.metroTextBox3.TabIndex = 9;

//             // 
//             // metroTextBox2
//             // 
//             this.metroTextBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//             this.metroTextBox2.Location = new System.Drawing.Point(16, 281);
//             this.metroTextBox2.Name = "metroTextBox2";
//             this.metroTextBox2.PromptText = "Key";
//             this.metroTextBox2.Size = new System.Drawing.Size(214, 23);

//             this.metroTextBox2.TabIndex = 8;

//             // 
//             // metroComboBox1
//             // 
//             this.metroComboBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//             this.metroComboBox1.FormattingEnabled = true;
//             this.metroComboBox1.ItemHeight = 29;
//             this.metroComboBox1.Items.AddRange(new object[] {
//             "POST",
//             "GET"});
//             this.metroComboBox1.Location = new System.Drawing.Point(16, 167);
//             this.metroComboBox1.Name = "metroComboBox1";
//             this.metroComboBox1.Size = new System.Drawing.Size(214, 35);

//             this.metroComboBox1.TabIndex = 7;

//             // 
//             // metroLabel3
//             // 
//             this.metroLabel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//             this.metroLabel3.AutoSize = true;
//             this.metroLabel3.Location = new System.Drawing.Point(11, 143);
//             this.metroLabel3.Name = "metroLabel3";

//             this.metroLabel3.Size = new System.Drawing.Size(107, 25);

//             this.metroLabel3.TabIndex = 6;
//             this.metroLabel3.Text = "Request Type:";

//             this.metroLabel3.UseCompatibleTextRendering = true;
//             // 
//             // metroLabel1
//             // 
//             this.metroLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//             this.metroLabel1.AutoSize = true;
//             this.metroLabel1.Location = new System.Drawing.Point(12, 257);
//             this.metroLabel1.Name = "metroLabel1";

//             this.metroLabel1.Size = new System.Drawing.Size(112, 25);

//             this.metroLabel1.TabIndex = 5;
//             this.metroLabel1.Text = "Upload Values:";

//             this.metroLabel1.UseCompatibleTextRendering = true;
//             // 
//             // betterListView2
//             // 
//             this.betterListView2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//             this.betterListView2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(48)))));
//             this.betterListView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
//             this.columnHeader1,
//             this.columnHeader2});
//             this.betterListView2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
//             this.betterListView2.FullRowSelect = true;
//             this.betterListView2.HideSelection = false;
//             this.betterListView2.Location = new System.Drawing.Point(16, 372);
//             this.betterListView2.Name = "betterListView2";
//             this.betterListView2.Size = new System.Drawing.Size(214, 127);
//             this.betterListView2.TabIndex = 2;
//             this.betterListView2.UseCompatibleStateImageBehavior = false;
//             this.betterListView2.View = System.Windows.Forms.View.Details;
//             // 
//             // columnHeader1
//             // 
//             this.columnHeader1.Text = "Key";
//             this.columnHeader1.Width = 100;
//             // 
//             // columnHeader2
//             // 
//             this.columnHeader2.Text = "Value";
//             this.columnHeader2.Width = 100;
//             // 
//             // metroLabel2
//             // 
//             this.metroLabel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//             this.metroLabel2.AutoSize = true;
//             this.metroLabel2.Location = new System.Drawing.Point(11, 9);
//             this.metroLabel2.Name = "metroLabel2";

//             this.metroLabel2.Size = new System.Drawing.Size(122, 25);

//             this.metroLabel2.TabIndex = 4;
//             this.metroLabel2.Text = "Uploader Name:";

//             this.metroLabel2.UseCompatibleTextRendering = true;
//             // 
//             // metroTextBox1
//             // 
//             this.metroTextBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//             this.metroTextBox1.Location = new System.Drawing.Point(17, 38);
//             this.metroTextBox1.Name = "metroTextBox1";
//             this.metroTextBox1.PromptText = "My Custom Uploader";
//             this.metroTextBox1.Size = new System.Drawing.Size(214, 23);

//             this.metroTextBox1.TabIndex = 3;

//             // 
//             // contextMenuStrip2
//             // 
//             this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
//             this.toolStripMenuItem2});
//             this.contextMenuStrip2.Name = "contextMenuStrip1";
//             this.contextMenuStrip2.Size = new System.Drawing.Size(118, 26);
//             // 
//             // toolStripMenuItem2
//             // 
//             this.toolStripMenuItem2.Name = "toolStripMenuItem2";
//             this.toolStripMenuItem2.Size = new System.Drawing.Size(117, 22);
//             this.toolStripMenuItem2.Text = "Remove";
//             this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
//             // 
//             // metroPanel2
//             // 

//             this.metroPanel2.Controls.Add(this.metroButton4);
//             this.metroPanel2.Controls.Add(this.metroButton3);
//             this.metroPanel2.HorizontalScrollbarBarColor = true;
//             this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
//             this.metroPanel2.HorizontalScrollbarSize = 10;
//             this.metroPanel2.Location = new System.Drawing.Point(273, 63);
//             this.metroPanel2.Name = "metroPanel2";
//             this.metroPanel2.Size = new System.Drawing.Size(245, 510);

//             this.metroPanel2.TabIndex = 2;

//             this.metroPanel2.VerticalScrollbarBarColor = true;
//             this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
//             this.metroPanel2.VerticalScrollbarSize = 10;
//             // 
//             // metroButton4
//             // 
//             this.metroButton4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;


//             this.metroButton4.Location = new System.Drawing.Point(13, 43);
//             this.metroButton4.Name = "metroButton4";

//             this.metroButton4.Size = new System.Drawing.Size(218, 23);

//             this.metroButton4.TabIndex = 13;
//             this.metroButton4.Text = "Add a Custom Uploader";

//             this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
//             // 
//             // metroButton3
//             // 
//             this.metroButton3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;


//             this.metroButton3.Location = new System.Drawing.Point(13, 13);
//             this.metroButton3.Name = "metroButton3";

//             this.metroButton3.Size = new System.Drawing.Size(218, 23);

//             this.metroButton3.TabIndex = 12;
//             this.metroButton3.Text = "Add a Shotr Uploader";

//             this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
//             // 
//             // CustomUploader
//             // 
//             this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;

//             this.ClientSize = new System.Drawing.Size(533, 588);
//             this.Controls.Add(this.betterListView1);
//             this.Controls.Add(this.metroPanel1);
//             this.Controls.Add(this.metroPanel2);
//             this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
//             this.Location = new System.Drawing.Point(0, 0);
//             this.Name = "CustomUploader";




//             this.Text = "Custom Uploaders";

//             this.Load += new System.EventHandler(this.CustomUploader_Load);
//             this.contextMenuStrip1.ResumeLayout(false);
//             this.metroPanel1.ResumeLayout(false);
//             this.metroPanel1.PerformLayout();
//             this.contextMenuStrip2.ResumeLayout(false);
//             this.metroPanel2.ResumeLayout(false);
//             this.ResumeLayout(false);
//
//         }
//
//         #endregion
//
//         private DpiScaledListbox betterListView1;
//         private ThemedPanel metroPanel1;
//         private ThemedTextBox metroTextBox1;
//         private DpiScaledListbox betterListView2;
//         private ThemedLabel metroLabel2;
//         private ThemedLabel metroLabel5;
//         private ThemedTextBox metroTextBox5;
//         private ThemedLabel metroLabel4;
//         private ThemedTextBox metroTextBox4;
//         private ThemedButton metroButton2;
//         private ThemedButton metroButton1;
//         private ThemedTextBox metroTextBox3;
//         private ThemedTextBox metroTextBox2;
//         private ThemedComboBox metroComboBox1;
//         private ThemedLabel metroLabel3;
//         private ThemedLabel metroLabel1;
//         private ContextMenuStrip contextMenuStrip1;
//         private ToolStripMenuItem editToolStripMenuItem;
//         private ToolStripMenuItem removeToolStripMenuItem;
//         private ContextMenuStrip contextMenuStrip2;
//         private ToolStripMenuItem toolStripMenuItem2;
//         private ToolStripSeparator toolStripSeparator1;
//         private ToolStripMenuItem testToolStripMenuItem;
//         private ThemedToggle metroToggle1;
//         private ThemedLabel metroLabel6;
//         private ThemedPanel metroPanel2;
//         private ThemedButton metroButton4;
//         private ThemedButton metroButton3;
//         private ThemedButton ThemedButton1;
//         private ColumnHeader columnHeader3;
//         private ColumnHeader columnHeader1;
//         private ColumnHeader columnHeader2;
//     }
// }
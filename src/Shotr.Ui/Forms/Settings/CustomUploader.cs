using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Windows.Forms;
using Shotr.Ui.Custom;
using Shotr.Ui.DpiScaling;
using Shotr.Ui.Plugin;

namespace Shotr.Ui.Forms.Settings
{
    public partial class CustomUploader : DpiScaledForm
    {
        private bool cuploader = false;
        private NameValueCollection nvc = new NameValueCollection();
        public CustomUploader()
        {
            InitializeComponent();

            betterListView1.SetFont(metroLabel2.GetThemeFont());
            betterListView2.SetFont(metroLabel2.GetThemeFont());

            betterListView1.Font = metroLabel2.GetThemeFont();
            betterListView2.Font = metroLabel2.GetThemeFont();

            betterListView1.Update();
            betterListView2.Update();

            UpdateListViewColumnSize(betterListView1);
            UpdateListViewColumnSize(betterListView2);
            //this.betterListView2.DrawColumnHeaderBackground += betterListView2_DrawColumnHeaderBackground;
        }

        private void UpdateListViewColumnSize(ListView blv)
        {
            var listView = blv;
            if (listView != null)
            {
                float totalColumnWidth = betterListView1.Size.Width;
                for (int i = 0; i < listView.Columns.Count; i++)
                {
                    float colPercentage = (Convert.ToInt32(totalColumnWidth / listView.Columns.Count));
                    listView.Columns[i].Width = (int)colPercentage;
                    //prevent item from being movable.
                    //listView.Columns[i].AllowResize = false;
                }
            }
        }

        /*private void betterListView1_DrawColumnHeaderBackground(object sender, BetterListViewDrawColumnHeaderBackgroundEventArgs eventArgs)
        {
            eventArgs.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(24, 24, 62)), eventArgs.ColumnHeaderBounds.BoundsOuterExtended);
            //fill shit up.
            int x = eventArgs.ColumnHeaderBounds.BoundsInner.X - 3;
            int y = eventArgs.ColumnHeaderBounds.BoundsInner.Y - 3;
            int width = eventArgs.ColumnHeaderBounds.BoundsInner.Width + 4;
            int height = eventArgs.ColumnHeaderBounds.BoundsInner.Height + 4;
            eventArgs.Graphics.DrawRectangle(Pens.White, new Rectangle(x, y, width, height));
        }

        private void betterListView2_DrawColumnHeaderBackground(object sender, BetterListViewDrawColumnHeaderBackgroundEventArgs eventArgs)
        {
            eventArgs.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(24, 24, 62)), eventArgs.ColumnHeaderBounds.BoundsOuterExtended);
            //fill shit up.
            int x = eventArgs.ColumnHeaderBounds.BoundsInner.X - 3;
            int y = eventArgs.ColumnHeaderBounds.BoundsInner.Y - 3;
            int width = eventArgs.ColumnHeaderBounds.BoundsInner.Width + 4;
            int height = eventArgs.ColumnHeaderBounds.BoundsInner.Height + 4;
            eventArgs.Graphics.DrawRectangle(Pens.White, new Rectangle(x, y, width, height));
        }*/

        private void CustomUploader_Load(object sender, EventArgs e)
        {
            metroComboBox1.Text = "POST";
            //load all custom uploaders.
            object[] pl = Program.Settings.GetValue("program_custom_uploaders");
            if (pl != null)
            {
                foreach (CustomUploaderInstance u in ((List<CustomUploaderInstance>)pl[0]))
                {
                    var f = new ListViewItem();
                    f.Text = u.Title;
                    betterListView1.Items.Add(f);
                }
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //nvc.Add(metroTextBox2.Text, metroTextBox3.Text);
            if (metroTextBox2.Text.Length <= 0 && metroTextBox3.Text.Length <= 0)
            {
                MessageBox.Show("Please fill out the form key and value before adding.");
                return;
            }
            var p = new ListViewItem();
            p.Text = metroTextBox2.Text;
            p.SubItems.Add(metroTextBox3.Text);
            betterListView2.Items.Add(p);
            metroTextBox2.Text = "";
            metroTextBox3.Text = "";
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (metroButton2.Text == "Save")
            {
                //prepare to add all shits to a customuploader instance.
                NameValueCollection x = new NameValueCollection();
                foreach (ListViewItem i in betterListView2.Items)
                {
                    x.Add(i.Text, i.SubItems[1].Text);
                }
                string curl = "";
                if (cuploader)
                {
                    CustomUploaderPrompt cm = new CustomUploaderPrompt();
                    if (cm.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    curl = cm.UploaderURL;
                }
                CustomUploaderInstance m = new CustomUploaderInstance(metroTextBox1.Text, metroTextBox5.Text, metroComboBox1.Text, metroTextBox4.Text, metroToggle1.Checked, x, cuploader, curl);
                //add custom uploaders to the plugin loader instance.
                PluginCore.AddImageUploaderItem(m.Uploader);
                //add to settings instance to save for later.
                //"program_custom_uploaders"
                object[] pl = Program.Settings.GetValue("program_custom_uploaders");
                if (pl != null)
                {
                    ((List<CustomUploaderInstance>)pl[0]).Add(m);
                    Program.Settings.ChangeKey("program_custom_uploaders", new object[] { ((List<CustomUploaderInstance>)pl[0]) });
                }
                else if (pl == null)
                {
                    Program.Settings.ChangeKey("program_custom_uploaders", new object[] { new List<CustomUploaderInstance>() { m } });
                }
                ClearAllShits();
                //add to lv1.
                var l = new ListViewItem() { Text = m.Title };
                betterListView1.Items.Add(l);
            }
            else
            {
                //update lv item.
                foreach (ListViewItem m in betterListView1.Items)
                {
                    if (m.Text == oldname)
                    {
                        //ok, let's update it.
                        //update shit.
                        NameValueCollection x = new NameValueCollection();
                        foreach (ListViewItem i in betterListView2.Items)
                        {
                            x.Add(i.Text, i.SubItems[1].Text);
                        }
                        //grab old customuploaderinstance
                        CustomUploaderInstance old = GetCustomUploaderInstance(oldname);
                        string curl = "";
                        if (cuploader)
                        {
                            CustomUploaderPrompt cm = new CustomUploaderPrompt();
                            if (cm.ShowDialog() != DialogResult.OK)
                            {
                                return;
                            }
                            curl = cm.UploaderURL;
                        }
                        CustomUploaderInstance w = new CustomUploaderInstance(metroTextBox1.Text, metroTextBox5.Text, metroComboBox1.Text, metroTextBox4.Text, metroToggle1.Checked, x, cuploader, curl);
                        //remove from plugin core
                        PluginCore.RemoveImageUploaderItem(old.Uploader);
                        object[] pl = Program.Settings.GetValue("program_custom_uploaders");
                        if (pl != null)
                        {
                            ((List<CustomUploaderInstance>)pl[0]).Remove(old);
                            ((List<CustomUploaderInstance>)pl[0]).Add(w);
                            Program.Settings.ChangeKey("program_custom_uploaders", new object[] { ((List<CustomUploaderInstance>)pl[0]) });
                            Program.Settings.SaveSettings();
                        }
                        PluginCore.AddImageUploaderItem(w.Uploader);
                        //get ready to add.
                        m.Text = w.Title;
                        ClearAllShits();
                        // add
                        break;
                    }
                }
                metroButton2.Text = "Save";
            }
            cuploader = false;
            metroPanel2.Visible = true;
            metroPanel1.Visible = false;
        }

        private void ClearAllShits()
        {
             //clear all shits.
            metroTextBox1.Text = "";
            metroTextBox5.Text = "";
            metroTextBox4.Text = "";
            metroComboBox1.Text = "";
            metroToggle1.Checked = false;
            cuploader = false;
            //go through values.
            betterListView2.Items.Clear();
        }

        private CustomUploaderInstance GetCustomUploaderInstance(string name)
        {
            object[] pl = Program.Settings.GetValue("program_custom_uploaders");
            if (pl != null)
            {
                List<CustomUploaderInstance> m = ((List<CustomUploaderInstance>)pl[0]);
                foreach (CustomUploaderInstance x in m)
                {
                    if (x.Title == name)
                    {
                        return x;
                    }
                }
            }
            return null;
        }
        private string oldname = "";
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //load it and fill in the values.
            if (betterListView1.SelectedItems.Count > 0)
            {
                //go ahead and edit the selected one,.
                CustomUploaderInstance p = GetCustomUploaderInstance(betterListView1.SelectedItems[0].Text);
                if (p == null)
                {
                    //wot
                }
                else
                {
                    //grab each item and load that sheit.
                    oldname = p.Title;
                    metroTextBox1.Text = p.Title;
                    metroTextBox5.Text = p.URL;
                    metroTextBox4.Text = p.FormName;
                    metroComboBox1.Text = p.RequestType;
                    metroToggle1.Checked = p.UsePageURL;
                    if (p.UseCustomUploader) cuploader = true;
                    metroButton2.Text = "Edit";
                    //go through values.
                    betterListView2.Items.Clear();
                    for (int i = 0; i < p.UploadValues.Count; i++)
                    {
                        var l = new ListViewItem() { Text = p.UploadValues.Keys[i] };
                        l.SubItems.Add(p.UploadValues[i]);
                        betterListView2.Items.Add(l);
                    }
                    metroPanel2.Visible = false;
                    metroPanel1.Visible = true;
                }
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //update lv item.  
            if (betterListView1.SelectedItems.Count > 0)
            {
                foreach (ListViewItem m in betterListView1.Items)
                {
                    if (m.Text == betterListView1.SelectedItems[0].Text)
                    {
                        //grab old customuploaderinstance
                        CustomUploaderInstance old = GetCustomUploaderInstance(m.Text);
                        //remove from plugin core
                        PluginCore.RemoveImageUploaderItem(old.Uploader);
                        object[] pl = Program.Settings.GetValue("program_custom_uploaders");
                        if (pl != null)
                        {
                            ((List<CustomUploaderInstance>)pl[0]).Remove(old);
                            Program.Settings.ChangeKey("program_custom_uploaders", new object[] { ((List<CustomUploaderInstance>)pl[0]) });                           
                        }
                        betterListView1.Items.Remove(m);
                        break;
                    }
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //remove selected one from bl2
            if (betterListView2.SelectedItems.Count > 0)
            {
                betterListView2.Items.Remove(betterListView2.SelectedItems[0]);
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //test an image upload?
            //TODO
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            //shotr uplaoder.
            metroPanel2.Visible = false;
            metroPanel1.Visible = true;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            //custom uplaoder
            cuploader = true;
            metroPanel2.Visible = false;
            metroPanel1.Visible = true;
        }

        private void dpiScaledButton1_Click(object sender, EventArgs e)
        {
            ClearAllShits();
            metroPanel2.Visible = true;
            metroPanel1.Visible = false;
        }
    }
}

// using System;
// using System.Collections.Generic;
// using System.Collections.Specialized;
// using System.Windows.Forms;
// using Shotr.Core.Custom;
// using Shotr.Core.DpiScaling;
// using Shotr.Core.Plugin;
// using Shotr.Core.Settings;
//
// namespace Shotr.Ui.Forms.Settings
// {
//     public partial class CustomUploader : DpiScaledForm
//     {
//         private bool _customUploader;
//         private NameValueCollection _nvc = new NameValueCollection();
//
//         private readonly BaseSettings _settings;
//         
//         public CustomUploader(BaseSettings settings)
//         {
//             _settings = settings;
//             
//             InitializeComponent();
//
//             betterListView1.SetFont(metroLabel2.GetThemeFont());
//             betterListView2.SetFont(metroLabel2.GetThemeFont());
//
//             betterListView1.Font = metroLabel2.GetThemeFont();
//             betterListView2.Font = metroLabel2.GetThemeFont();
//
//             betterListView1.Update();
//             betterListView2.Update();
//
//             UpdateListViewColumnSize(betterListView1);
//             UpdateListViewColumnSize(betterListView2);
//         }
//
//         private void UpdateListViewColumnSize(ListView blv)
//         {
//             var listView = blv;
//             if (listView != null)
//             {
//                 float totalColumnWidth = betterListView1.Size.Width;
//                 for (var i = 0; i < listView.Columns.Count; i++)
//                 {
//                     float colPercentage = (Convert.ToInt32(totalColumnWidth / listView.Columns.Count));
//                     listView.Columns[i].Width = (int)colPercentage;
//                     //prevent item from being movable.
//                     //listView.Columns[i].AllowResize = false;
//                 }
//             }
//         }
//
//         private void CustomUploader_Load(object sender, EventArgs e)
//         {
//             metroComboBox1.Text = "POST";
//             //load all custom uploaders.
//             /*object[] pl = Core.Utils.Settings.Instance.GetValue("program_custom_uploaders");
//             if (pl != null)
//             {
//                 foreach (var u in ((List<CustomUploaderInstance>)pl[0]))
//                 {
//                     var f = new ListViewItem();
//                     f.Text = u.Title;
//                     betterListView1.Items.Add(f);
//                 }
//             }*/
//         }
//
//         private void metroButton1_Click(object sender, EventArgs e)
//         {
//             //nvc.Add(metroTextBox2.Text, metroTextBox3.Text);
//             if (metroTextBox2.Text.Length <= 0 && metroTextBox3.Text.Length <= 0)
//             {
//                 MessageBox.Show("Please fill out the form key and value before adding.");
//                 return;
//             }
//             var p = new ListViewItem();
//             p.Text = metroTextBox2.Text;
//             p.SubItems.Add(metroTextBox3.Text);
//             betterListView2.Items.Add(p);
//             metroTextBox2.Text = "";
//             metroTextBox3.Text = "";
//         }
//
//         private void metroButton2_Click(object sender, EventArgs e)
//         {
//             if (metroButton2.Text == "Save")
//             {
//                 //prepare to add all shits to a customuploader instance.
//                 var x = new NameValueCollection();
//                 foreach (ListViewItem i in betterListView2.Items)
//                 {
//                     x.Add(i.Text, i.SubItems[1].Text);
//                 }
//                 var curl = "";
//                 if (_customUploader)
//                 {
//                     var cm = new CustomUploaderPrompt();
//                     if (cm.ShowDialog() != DialogResult.OK)
//                     {
//                         return;
//                     }
//                     curl = cm.UploaderUrl;
//                 }
//                 var m = new CustomUploaderInstance(metroTextBox1.Text, metroTextBox5.Text, metroComboBox1.Text, metroTextBox4.Text, metroToggle1.Checked, x, _customUploader, curl);
//                 //add custom uploaders to the plugin loader instance.
//                 PluginCore.AddImageUploaderItem(m.Uploader);
//                 //add to settings instance to save for later.
//                 //"program_custom_uploaders"
//                 object[] pl = Core.Utils.Settings.Instance.GetValue("program_custom_uploaders");
//                 if (pl != null)
//                 {
//                     ((List<CustomUploaderInstance>)pl[0]).Add(m);
//                     Core.Utils.Settings.Instance.ChangeKey("program_custom_uploaders", new object[] { ((List<CustomUploaderInstance>)pl[0]) });
//                 }
//                 else if (pl == null)
//                 {
//                     Core.Utils.Settings.Instance.ChangeKey("program_custom_uploaders", new object[] { new List<CustomUploaderInstance> { m } });
//                 }
//                 ClearAllShits();
//                 //add to lv1.
//                 var l = new ListViewItem { Text = m.Title };
//                 betterListView1.Items.Add(l);
//             }
//             else
//             {
//                 //update lv item.
//                 foreach (ListViewItem m in betterListView1.Items)
//                 {
//                     if (m.Text == _oldname)
//                     {
//                         //ok, let's update it.
//                         //update shit.
//                         var x = new NameValueCollection();
//                         foreach (ListViewItem i in betterListView2.Items)
//                         {
//                             x.Add(i.Text, i.SubItems[1].Text);
//                         }
//                         //grab old customuploaderinstance
//                         var old = GetCustomUploaderInstance(_oldname);
//                         var curl = "";
//                         if (_customUploader)
//                         {
//                             var cm = new CustomUploaderPrompt();
//                             if (cm.ShowDialog() != DialogResult.OK)
//                             {
//                                 return;
//                             }
//                             curl = cm.UploaderUrl;
//                         }
//                         var w = new CustomUploaderInstance(metroTextBox1.Text, metroTextBox5.Text, metroComboBox1.Text, metroTextBox4.Text, metroToggle1.Checked, x, _customUploader, curl);
//                         //remove from plugin core
//                         PluginCore.RemoveImageUploaderItem(old.Uploader);
//                         object[] pl = Core.Utils.Settings.Instance.GetValue("program_custom_uploaders");
//                         if (pl != null)
//                         {
//                             ((List<CustomUploaderInstance>)pl[0]).Remove(old);
//                             ((List<CustomUploaderInstance>)pl[0]).Add(w);
//                             Core.Utils.Settings.Instance.ChangeKey("program_custom_uploaders", new object[] { ((List<CustomUploaderInstance>)pl[0]) });
//                             Core.Utils.Settings.Instance.SaveSettings();
//                         }
//                         PluginCore.AddImageUploaderItem(w.Uploader);
//                         //get ready to add.
//                         m.Text = w.Title;
//                         ClearAllShits();
//                         // add
//                         break;
//                     }
//                 }
//                 metroButton2.Text = "Save";
//             }
//             _customUploader = false;
//             metroPanel2.Visible = true;
//             metroPanel1.Visible = false;
//         }
//
//         private void ClearAllShits()
//         {
//              //clear all shits.
//             metroTextBox1.Text = "";
//             metroTextBox5.Text = "";
//             metroTextBox4.Text = "";
//             metroComboBox1.Text = "";
//             metroToggle1.Checked = false;
//             _customUploader = false;
//             //go through values.
//             betterListView2.Items.Clear();
//         }
//
//         private CustomUploaderInstance GetCustomUploaderInstance(string name)
//         {
//             object[] pl = Core.Utils.Settings.Instance.GetValue("program_custom_uploaders");
//             if (pl != null)
//             {
//                 var m = ((List<CustomUploaderInstance>)pl[0]);
//                 foreach (var x in m)
//                 {
//                     if (x.Title == name)
//                     {
//                         return x;
//                     }
//                 }
//             }
//             return null;
//         }
//         private string _oldname = "";
//         private void editToolStripMenuItem_Click(object sender, EventArgs e)
//         {
//             //load it and fill in the values.
//             if (betterListView1.SelectedItems.Count > 0)
//             {
//                 //go ahead and edit the selected one,.
//                 var p = GetCustomUploaderInstance(betterListView1.SelectedItems[0].Text);
//                 if (p == null)
//                 {
//                     //wot
//                 }
//                 else
//                 {
//                     //grab each item and load that sheit.
//                     _oldname = p.Title;
//                     metroTextBox1.Text = p.Title;
//                     metroTextBox5.Text = p.URL;
//                     metroTextBox4.Text = p.FormName;
//                     metroComboBox1.Text = p.RequestType;
//                     metroToggle1.Checked = p.UsePageURL;
//                     if (p.UseCustomUploader) _customUploader = true;
//                     metroButton2.Text = "Edit";
//                     //go through values.
//                     betterListView2.Items.Clear();
//                     for (var i = 0; i < p.UploadValues.Count; i++)
//                     {
//                         var l = new ListViewItem { Text = p.UploadValues.Keys[i] };
//                         l.SubItems.Add(p.UploadValues[i]);
//                         betterListView2.Items.Add(l);
//                     }
//                     metroPanel2.Visible = false;
//                     metroPanel1.Visible = true;
//                 }
//             }
//         }
//
//         private void removeToolStripMenuItem_Click(object sender, EventArgs e)
//         {
//             //update lv item.  
//             if (betterListView1.SelectedItems.Count > 0)
//             {
//                 foreach (ListViewItem m in betterListView1.Items)
//                 {
//                     if (m.Text == betterListView1.SelectedItems[0].Text)
//                     {
//                         //grab old customuploaderinstance
//                         var old = GetCustomUploaderInstance(m.Text);
//                         //remove from plugin core
//                         PluginCore.RemoveImageUploaderItem(old.Uploader);
//                         object[] pl = Core.Utils.Settings.Instance.GetValue("program_custom_uploaders");
//                         if (pl != null)
//                         {
//                             ((List<CustomUploaderInstance>)pl[0]).Remove(old);
//                             Core.Utils.Settings.Instance.ChangeKey("program_custom_uploaders", new object[] { ((List<CustomUploaderInstance>)pl[0]) });                           
//                         }
//                         betterListView1.Items.Remove(m);
//                         break;
//                     }
//                 }
//             }
//         }
//
//         private void toolStripMenuItem2_Click(object sender, EventArgs e)
//         {
//             //remove selected one from bl2
//             if (betterListView2.SelectedItems.Count > 0)
//             {
//                 betterListView2.Items.Remove(betterListView2.SelectedItems[0]);
//             }
//         }
//
//         private void testToolStripMenuItem_Click(object sender, EventArgs e)
//         {
//             //test an image upload?
//             //TODO
//         }
//
//         private void metroButton3_Click(object sender, EventArgs e)
//         {
//             //shotr uplaoder.
//             metroPanel2.Visible = false;
//             metroPanel1.Visible = true;
//         }
//
//         private void metroButton4_Click(object sender, EventArgs e)
//         {
//             //custom uplaoder
//             _customUploader = true;
//             metroPanel2.Visible = false;
//             metroPanel1.Visible = true;
//         }
//
//         private void dpiScaledButton1_Click(object sender, EventArgs e)
//         {
//             ClearAllShits();
//             metroPanel2.Visible = true;
//             metroPanel1.Visible = false;
//         }
//     }
// }

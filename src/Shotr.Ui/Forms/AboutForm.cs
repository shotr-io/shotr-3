using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using Shotr.Core.Controls.Theme;
using Shotr.Core.UpdateFramework;

namespace Shotr.Ui.Forms
{
    public partial class AboutForm : ThemedForm
    {
        public AboutForm()
        {
            InitializeComponent();
            try
            {
                var p = new WebClient { Proxy = null };
                var changelog = p.DownloadString("https://shotr.dev/api/updates");
                var responses = JsonConvert.DeserializeObject<List<UpdaterResponse>>(changelog);
                var totalChangelog = "";
                foreach (var response in responses)
                {
                    totalChangelog = $"{totalChangelog}=== v{response.Version} ===\r\n{response.Changes}\r\n\r\n";
                }
                metroTextBox1.Text = totalChangelog;
                metroTextBox1.DeselectAll();
            }
            catch
            {
                metroTextBox1.Text = "Unable to get changelog. Please try again later.";
            }
            metroTextBox1.DeselectAll();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            metroTextBox1.DeselectAll();
        }
    }
}
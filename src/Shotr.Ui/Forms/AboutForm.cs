using System;
using System.Net;
using Shotr.Core.Controls.DpiScaling;
using Shotr.Core.Controls.Theme;

namespace Shotr.Ui.Forms
{
    public partial class AboutForm : ThemedForm
    {
        public AboutForm()
        {
            InitializeComponent();
            metroTextBox1.DeselectAll();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            metroTextBox1.DeselectAll();

            //load changelog.
            try
            {
                var p = new WebClient { Proxy = null };
                var changelog = p.DownloadString("https://shotr.io/changelog");
                changelog = changelog.Replace("<br>", "\r\n");
                metroTextBox1.Text = changelog;
            }
            catch
            {
                metroTextBox1.Text = "Unable to get changelog. Please try again later.";
            }
            Focus();

            metroTextBox1.DeselectAll();
        }
    }
}
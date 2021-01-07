using System;
using System.Net;
using Shotr.Ui.DpiScaling;

namespace Shotr.Ui.Forms
{
    public partial class AboutForm : DpiScaledForm
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            //load changelog.
            try
            {
                WebClient p = new WebClient() { Proxy = null };
                string changelog = p.DownloadString("https://shotr.io/changelog");
                changelog = changelog.Replace("<br>", "\r\n");
                metroTextBox1.Text = changelog;
            }
            catch
            {
                metroTextBox1.Text = "Unable to get changelog. Please try again later.";
            }
            Focus();
        }
    }
}
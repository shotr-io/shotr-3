using System.Diagnostics;
using System.Windows.Forms;
using Shotr.Core.Controls.Theme;

namespace Shotr.Ui.Forms
{
    public partial class ThemeShowcase : ThemedForm
    {
        public ThemeShowcase()
        {
            InitializeComponent();
        }

        private void themedLinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { UseShellExecute = true, FileName = "https://google.com" });
        }

        private void themedButton2_Click(object sender, System.EventArgs e)
        {
            themedProgressBar1.Value += 10;
        }

        private void themedButton3_Click(object sender, System.EventArgs e)
        {
            themedProgressBar1.Value -= 10;
        }
    }
}

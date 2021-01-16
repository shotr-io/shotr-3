using System;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;

namespace Shotr.Ui.Forms.Settings
{
    public partial class CustomUploaderPrompt : DpiScaledForm
    {
        public CustomUploaderPrompt()
        {
            InitializeComponent();
        }
        public string UploaderUrl = "";
        private void CustomUploaderPrompt_Load(object sender, EventArgs e)
        {
            metroTextBox2.Text = "http://yoursite.com/PskdaAf.png\r\nhttp://sub.yoursite.com/Image.png\r\nhttp://yoursite.com/Image.jpg\r\n";
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {        
            Uri url;
            if (!Uri.TryCreate(metroTextBox1.Text, UriKind.RelativeOrAbsolute, out url))
            {
                MessageBox.Show("Please input a valid URL.");
                return;
            }
            UploaderUrl = metroTextBox1.Text;
            DialogResult = DialogResult.OK;
        }
    }
}

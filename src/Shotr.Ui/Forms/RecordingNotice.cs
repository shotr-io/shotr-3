using System;
using Shotr.Core.DpiScaling;

namespace Shotr.Ui.Forms
{
    public partial class RecordingNotice : DpiScaledForm
    {
        public RecordingNotice()
        {
            InitializeComponent();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            //check for checkbox.
            if (metroCheckBox1.Checked)
            {
                Core.Utils.Settings.Instance.ChangeKey("settings.show_record_warning", new object[] { false });
            }
            Close();
        }
    }
}

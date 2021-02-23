using System;
using Shotr.Core.Controls.Theme;
using Shotr.Core.Services;
using Shotr.Core.Settings;

namespace Shotr.Ui.Forms
{
    public partial class RecordingNotice : ThemedForm
    {
        private readonly BaseSettings _settings;
        public RecordingNotice(BaseSettings settings)
        {
            _settings = settings;
            InitializeComponent();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            //check for checkbox.
            if (metroCheckBox1.Checked)
            {
                _settings.Record.ShowWarning = false;
                SettingsService.Save(_settings);
            }
            Close();
        }
    }
}

using System;
using System.Net.Http;
using System.Windows.Forms;
using Shotr.Core;
using Shotr.Core.Controls.Theme;
using Shotr.Core.Services;
using Shotr.Core.Settings;

namespace Shotr.Ui.Forms
{
    public partial class LoginForm : ThemedForm
    {
        private readonly BaseSettings _settings;
        private readonly ShotrApiService _shotrApiService;

        public LoginForm(BaseSettings settings, ShotrApiService shotrApiService)
        {
            _settings = settings;
            _shotrApiService = shotrApiService;
            
            InitializeComponent();
        }

        private async void ThemedButton1_Click(object sender, EventArgs e)
        {
            ThemedButton1.Enabled = false;
            emailTextBox.Enabled = false;
            passwordTextBox.Enabled = false;
            try
            {
                var user = await _shotrApiService.Login(emailTextBox.TextBoxText, passwordTextBox.TextBoxText);
                if (user is { })
                {
                    DialogResult = DialogResult.OK;
                    _settings.Login.Token = user.Token;
                    _settings.Login.Email = user.Email;
                    _settings.Uploads = user.Uploads;
                    _settings.Login.Enabled = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password!");
                }
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("There was an error connecting to the internet! Please fix your internet connection before launching Shotr...");
            }
        }

        private void ThemedLinkLabel1_Click(object sender, EventArgs e)
        {
            // Open browser with link to forgot page
#if DEBUG || BETATEST
            "https://shotr.dev/auth/forgot".OpenUrl();
#else
            "https://shotr.io/auth/forgot".OpenUrl();
#endif
        }

        private void ThemedLinkLabel2_Click(object sender, EventArgs e)
        {
            // Register page
#if DEBUG || BETATEST
            "https://shotr.dev/auth/register".OpenUrl();
#else
            "https://shotr.io/auth/forgot".OpenUrl();
#endif
        }
    }
}

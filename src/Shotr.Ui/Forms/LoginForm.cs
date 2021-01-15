using System;
using System.Diagnostics;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;
using Shotr.Core;
using Shotr.Core.Controls.DpiScaling;
using Shotr.Core.Model;
using Shotr.Core.Settings;

namespace Shotr.Ui.Forms
{
    public partial class LoginForm : DpiScaledForm
    {
        private bool _isClosing;

        private readonly BaseSettings _settings;

        public LoginForm(BaseSettings settings)
        {
            _settings = settings;
            
            InitializeComponent();
        }

        private void dpiScaledButton1_Click(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();

            var formContent = new MultipartFormDataContent
            {
                { new StringContent(dpiScaledTextbox1.Text), "email" },
                { new StringContent(dpiScaledTextbox2.Text), "password" }
            };
            
            var response = httpClient.PostAsync("https://shotr.dev/api", formContent).Result;

            try
            {

                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var user = JsonConvert.DeserializeObject<LoginResponse>(content);
                    // Sign in
                    _isClosing = true;
                    DialogResult = DialogResult.OK;
                    _settings.Login.Token = user.Token;
                    _settings.Login.Email = user.Email;
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

        private void dpiScaledLinkLabel1_Click(object sender, EventArgs e)
        {
            // Open browser with link to forgot page
#if DEBUG
            "https://shotr.dev/auth/forgot".OpenUrl();
#else
            "https://shotr.io/auth/forgot".OpenUrl();
#endif
        }

        private void dpiScaledLinkLabel2_Click(object sender, EventArgs e)
        {
            // Register page
#if DEBUG
            "https://shotr.dev/auth/register".OpenUrl();
#else
            "https://shotr.io/auth/forgot".OpenUrl();
#endif
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isClosing)
            {
                Environment.Exit(0);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}

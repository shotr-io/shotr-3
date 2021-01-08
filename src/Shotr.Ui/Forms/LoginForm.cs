using System;
using System.Diagnostics;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;
using Shotr.Core.DpiScaling;
using Shotr.Core.Model;

namespace Shotr.Ui.Forms
{
    public partial class LoginForm : DpiScaledForm
    {
        private bool _isClosing;

        public LoginForm()
        {
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
                    Core.Utils.Settings.Instance.login = true;
                    Core.Utils.Settings.Instance.token = user.Token;
                    Core.Utils.Settings.Instance.email = user.Email;
                    Core.Utils.Settings.Instance.ChangeKey("shotr.token", new object[] {user.Token});
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
            Process.Start("https://shotr.dev/auth/forgot");
#else
            Process.Start("https://shotr.io/auth/forgot");
#endif
        }

        private void dpiScaledLinkLabel2_Click(object sender, EventArgs e)
        {
            // Register page
#if DEBUG
            Process.Start("https://shotr.dev/auth/register");
#else
            Process.Start("https://shotr.io/auth/forgot");
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

using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Shotr.Ui.Utils;

namespace Shotr.Ui.LoginFramework
{
    public class ShotrWeb
    {
        public ShotrWeb(ShotrLoginReply re)
        {
        }

        private string _token;
        private string _count;
    }

    public class ShotrLoginRequest
    {
        private string _email;
        private string _password;
#if DEBUG
        private string shotr_web = "https://shotr.dev/api/login";
        //private string shotr_web = "http://localhost/api/login";
#else
        private string shotr_web = "https://shotr.io/";
#endif

        public ShotrLoginRequest()
        {
            _email = Program.Settings.email;
            _password = Program.Settings.password;
        }
        
        public ShotrLoginRequest(string email, string password)
        {
            _email = email;
            _password = password;
        }

        public ShotrLoginReply DoLogin()
        {
            WebClient m = new WebClient() { Proxy = null };
            NameValueCollection p = new NameValueCollection() {
                {"email", _email},
                {"password", _password }
            };
            try
            {
                byte[] replytext = m.UploadValues(shotr_web, p);
                //attempt to convert to json class
                string rep = Encoding.ASCII.GetString(replytext);
                ShotrLoginReply reply = JsonConvert.DeserializeObject<ShotrLoginReply>(rep);

                if (!reply.Error)
                {
                    if (Program.Settings.GetValue("shotr.login") == null ||
                        ((object[]) Program.Settings.GetValue("shotr.login")).Length <= 0)
                    {
                        //save login creds.
                        dcrypt dc = null;
                        if (Program.Settings.GetValue("shotr.key") != null &&
                            ((object[]) Program.Settings.GetValue("shotr.key")).Length >= 1)
                        {
                            dc = new dcrypt((byte[]) Program.Settings.GetValue("shotr.key")[0]);
                        }
                        else
                        {
                            //generate new dcrypt key.
                            dc = new dcrypt();
                            Program.Settings.ChangeKey("shotr.key", new object[] {dc.Key});
                        }

                        //save response.
                        Program.Settings.ChangeKey("shotr.login",
                            new object[]
                            {
                                dc.Encrypt(Encoding.ASCII.GetBytes(_email)),
                                dc.Encrypt(Encoding.ASCII.GetBytes(_password)),
                                dc.Encrypt(Encoding.ASCII.GetBytes(reply.Token))
                            });
                    }

                    Program.Settings.email = _email;
                    Program.Settings.password = _password;
                    Program.Settings.token = reply.Token;
                    Program.Settings.login = true;
                }

                return reply;
            }
            catch(Exception ex)
            {
                return new ShotrLoginReply()
                {
                    Error = true,
                    ErrorMessage = ex.ToString(),
                    ServerError = true
                };
            }
        }

    }

    public class ShotrLoginReply
    {
        [JsonProperty("error")]
        public bool Error { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("uploaded_count")]
        public string UploadedCount { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public bool ServerError { get; set; }
    }
}

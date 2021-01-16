using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Shotr.Core.Settings;

namespace Shotr.Core.Services
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
        private string? _email;
        private string? _password;
#if DEBUG
        private string shotr_web = "https://shotr.dev/api/login";
        //private string shotr_web = "http://localhost/api/login";
#else
        private string shotr_web = "https://shotr.io/";
#endif
        private readonly BaseSettings _settings;

        public ShotrLoginRequest(BaseSettings settings)
        {
            _settings = settings;
        }

        public ShotrLoginReply DoLogin()
        {
            var m = new WebClient { Proxy = null };
            var p = new NameValueCollection
            {
                {"email", _settings.Login.Email },
                {"password", _settings.Login.Password }
            };
            try
            {
                var replytext = m.UploadValues(shotr_web, p);
                //attempt to convert to json class
                var rep = Encoding.ASCII.GetString(replytext);
                var reply = JsonConvert.DeserializeObject<ShotrLoginReply>(rep);

                if (!reply.Error)
                {
                    _settings.Login.Token = reply.Token;
                }

                return reply;
            }
            catch(Exception ex)
            {
                return new ShotrLoginReply
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

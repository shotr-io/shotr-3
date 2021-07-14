using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shotr.Core.Settings;

namespace Shotr.Core.Services
{
    public class ShotrApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly BaseSettings _config;

#if LOCAL
        private const string _baseUrl = "http://192.168.86.15:8082";
#else
        private const string _baseUrl = "https://shotr.dev";
#endif

        public ShotrApiService(
            IHttpClientFactory httpClientFactory,
            BaseSettings config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        public async Task<TemporaryAuthTokenResponse?> GenerateTemporaryAuthToken()
        {
            var client = MakeClient();
            var response = await client.PostAsync($"{_baseUrl}/api/token/temporary", new StringContent(""));
            return await Deserialize<TemporaryAuthTokenResponse?>(response);
        }

        private HttpClient MakeClient()
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("token", _config.Login.Token);

            return client;
        }

        private async Task<T> Deserialize<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
    }

    public class TemporaryAuthTokenResponse
    {
        public string Token { get; set; }
    }
}

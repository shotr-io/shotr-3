using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shotr.Core.Model;
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
            var output = await Deserialize<TemporaryAuthTokenResponse?>(response);

            if (output is null)
            {
                Console.WriteLine($"Error while creating temporary token. Error message: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
            }

            return output;
        }

        public async Task<LoginResponse?> Login(string? email = null, string? password = null)
        {
            var client = MakeClient();

            if (email is null || password is null)
            {
                var response = await client.GetAsync($"{_baseUrl}/api");
                return await Deserialize<LoginResponse>(response);
            }

            var formContent = new MultipartFormDataContent
            {
                {new StringContent(email), "email"},
                {new StringContent(password), "password"}
            };

            var loginResponse = await client.PostAsync($"{_baseUrl}/api", formContent);
            return await Deserialize<LoginResponse>(loginResponse);
        }

        private HttpClient MakeClient(bool addToken = true)
        {
            var client = _httpClientFactory.CreateClient();

            if (_config.Login.Token is { })
            {
                client.DefaultRequestHeaders.Add("token", _config.Login.Token);
            }

            return client;
        }

        private async Task<T?> Deserialize<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }

            return default;
        }
    }

    public class TemporaryAuthTokenResponse
    {
        public string Token { get; set; }
    }
}

using Newtonsoft.Json;

namespace Shotr.Core.UpdateFramework
{
    public class UpdaterResponse
    {
        public UpdaterResponse()
        {
            // To disable nullable context warnings
            Version = string.Empty;
            Changelog = string.Empty;
            UpdatedAt = string.Empty;
            UpdateUrl = string.Empty;
        }

        [JsonProperty("error")]
        public bool Error { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("changelog")]
        public string Changelog { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("update_url")]
        public string UpdateUrl { get; set; }

        [JsonProperty("alpha")]
        public bool Alpha { get; set; }

        [JsonProperty("beta")]
        public bool Beta { get; set; }

        [JsonProperty("stable")]
        public bool Stable { get; set; }
    }
}

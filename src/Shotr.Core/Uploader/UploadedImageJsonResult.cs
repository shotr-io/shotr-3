using Newtonsoft.Json;

namespace Shotr.Core.Uploader
{
    public class UploadedImageJsonResult
    {
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("page_url")]
        public string PageUrl { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("error")]
        public bool Error { get; set; }

        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }
}

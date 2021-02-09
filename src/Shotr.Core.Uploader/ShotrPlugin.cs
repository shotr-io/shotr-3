using System;

namespace Shotr.Core.Uploader
{
    [Serializable]
    public class UploadResult : BaseResult
    {
        /// <summary>
        /// Creates a new upload result.
        /// </summary>
        /// <param name="url">The URL of the image.</param>
        /// <param name="pageurl">The non-direct URL of the image. This may be blank.</param>
        /// <param name="delurl">The deletion URL of the image. This may be blank.</param>
        /// <param name="time">The unix timestamp the image was uploaded at.</param>
        /// <param name="uploader">The name of the uploader that this was uploaded with. Use this.Title for simplicity.</param>
        /// <param name="error">Failed to upload, set this to true if the image failed to upload. This way, no values are required to be set.</param>
        public UploadResult(string uploader, string url, string pageUrl, long time, bool error, string? errorMessage = null)
        {
            Uploader = uploader;
            Url = url;
            PageUrl = pageUrl;
            Time = time;
            Error = error;
            ErrorMessage = errorMessage;
        }

        public UploadResult(string uploader, string url, string pageUrl, string deleteUrl, long time, bool error, string? errorMessage = null)
        {
            Uploader = uploader;
            Url = url;
            PageUrl = pageUrl;
            DeleteUrl = deleteUrl;
            Time = time;
            Error = error;
            ErrorMessage = errorMessage;
        }

        public string Uploader { get; }
        public string Url { get; }
        public string PageUrl { get; }
        public string? DeleteUrl { get; }
        public bool Error { get; }
        public string? ErrorMessage { get; }
    }
}

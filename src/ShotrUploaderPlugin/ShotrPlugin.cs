using System;

namespace ShotrUploaderPlugin
{
    [Serializable]
    public class UploadResult
    {
        private bool _error;
        private string _url = "";
        private string _delurl = "";
        private long _time;
        private string _uploader = "";
        private string _pageurl = "";

        /// <summary>
        /// Creates a new upload result.
        /// </summary>
        /// <param name="url">The URL of the image.</param>
        /// <param name="pageurl">The non-direct URL of the image. This may be blank.</param>
        /// <param name="delurl">The deletion URL of the image. This may be blank.</param>
        /// <param name="time">The unix timestamp the image was uploaded at.</param>
        /// <param name="uploader">The name of the uploader that this was uploaded with. Use this.Title for simplicity.</param>
        /// <param name="error">Failed to upload, set this to true if the image failed to upload. This way, no values are required to be set.</param>
        public UploadResult(string url, string pageurl, string delurl, long time, string uploader, bool error)
        {
            _url = url;
            _pageurl = pageurl;
            _error = error;
            _delurl = delurl;
            _time = time;
            _uploader = uploader;
        }

        public string Uploader { get { return _uploader; } }
        public string DelURL { get { return _delurl; } }
        public string URL { get { return _url; } }
        public bool Error { get { return _error; } }
        public long Time { get { return _time; } }
        public string PageURL { get { return _pageurl; } }
        public bool NewSite { get; set; }
    }

    public class ImageShell
    {
        public ImageShell(byte[] f, FileExtensions imf)
        {
            Data = f;
            Extension = imf;
        }
        public FileExtensions Extension { get; private set; }
        public string ContentType { get { return ContentTypeConverter.ExtToContent(Extension.ToString()); } }
        public byte[] Data { get; set; }
    }
    public enum FileExtensions
    {
        png, jpg, jpeg, txt, bmp, mp4, c, cs, vb, js, java, css, py, cpp, html, php, gif, webm, mp3, sh, zip, gz, rar
    }
    public static class ContentTypeConverter
    {
        public static string ExtToContent(string ext)
        {
            switch (ext)
            {
                case "png":
                    return "image/png";
                case "jpg":
                    return "image/jpeg";
                case "jpeg":
                    return "image/jpeg";
                case "txt":
                    return "text/plain";
                case "c":
                    return "text/x-c";
                case "js":
                    return "text/javascript";
                case "java":
                    return "text/java";
                case "py":
                    return "text/x-python";
                case "cs":
                    return "text/plain";
                case "vb":
                    return "text/plain";
                case "mp4":
                    return "video/mp4";
                case "webm":
                    return "video/webm";
                default:
                    return "text/plain";
            }
        }
    }
}

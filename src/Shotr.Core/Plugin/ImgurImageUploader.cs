using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Shotr.Core.Uploader;

namespace Shotr.Core.Plugin
{
    class ImgurImageUploader : IImageUploader
    {
        private string clientid = "d297fd441566f99";
        private string URL = "http://imgur.com";
        private string ImgURL = "http://i.imgur.com";
        //ImgurClientSecret = "0cfdf9368cbf988e69dff262d0425debd440fcc2";

        public NameValueCollection UploadValues => throw new NotImplementedException();

        public NameValueCollection HeaderValues => throw new NotImplementedException();

        public string FileValueName => throw new NotImplementedException();

        public string UploaderUrl => throw new NotImplementedException();

        public string Title => "Imgur";

        public bool UseUploadMethod => true;

        public UploadResult UploadImage(FileShell file)
        {
            var w = new WebClient();
            w.Headers.Add("Authorization", "Client-ID " + clientid);
            var Keys = new NameValueCollection();
            try
            {
                Keys.Add("image", Convert.ToBase64String(file.Data));
                var responseArray = w.UploadValues("https://api.imgur.com/3/image", Keys);
                var result = Encoding.ASCII.GetString(responseArray);

                var reg = new Regex("link\":\"(.*?)\"");
                var match = reg.Match(result);
                var url = match.ToString().Replace("link\":\"", "").Replace("\"", "").Replace("\\/", "/");

                var deletereg = new Regex("deletehash\":\"(.*?)\"");
                var match1 = deletereg.Match(result);
                var deletehash = match1.ToString().Replace("deletehash\":\"", "").Replace("\"", "").Replace("\\/", "/");
                deletehash = string.Format("{0}/delete/{1}", URL, deletehash);

                var pageurl = url.Replace(".png", "").Replace(".jpg", "").Replace(".gif", "").Replace(ImgURL, PageUrl);

                return new UploadResult(Title, url, pageurl, deletehash, DateTime.Now.ToUnixTime(), false);
            }
            catch (Exception ex)
            {
                return new UploadResult(Title, "", "", DateTime.Now.ToUnixTime(), true, ex.Message);
            }
        }

        public NameValueCollection DeletionValues =>
            new NameValueCollection
            {
                {"confirm", "true"}
            };

        public bool SupportsPages => true;

        public string PageUrl => "http://imgur.com";
    }
}

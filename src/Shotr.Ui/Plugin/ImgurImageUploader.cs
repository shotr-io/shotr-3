using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using ShotrUploaderPlugin;

namespace Shotr.Ui.Plugin
{
    class ImgurImageUploader : ImageUploader
    {
        private string clientid = "d297fd441566f99";
        private string URL = "http://imgur.com";
        private string ImgURL = "http://i.imgur.com";
        //ImgurClientSecret = "0cfdf9368cbf988e69dff262d0425debd440fcc2";

        public override System.Collections.Specialized.NameValueCollection UploadValues
        {
            get { throw new NotImplementedException(); }
        }

        public override System.Collections.Specialized.NameValueCollection HeaderValues
        {
            get { throw new NotImplementedException(); }
        }

        public override string FileValueName
        {
            get { throw new NotImplementedException(); }
        }

        public override string UploaderURL
        {
	        get { throw new NotImplementedException(); }
        }

        public override string Title
        {
            get { return "Imgur"; }
        }

        public override bool UseUploadMethod
        {
            get { return true; }
        }

        public override UploadResult UploadImage(ImageShell f)
        {
            WebClient w = new WebClient();
            w.Headers.Add("Authorization", "Client-ID " + clientid);
            System.Collections.Specialized.NameValueCollection Keys = new System.Collections.Specialized.NameValueCollection();
            try
            {
                Keys.Add("image", Convert.ToBase64String(f.Data));
                byte[] responseArray = w.UploadValues("https://api.imgur.com/3/image", Keys);
                string result = Encoding.ASCII.GetString(responseArray);

                Regex reg = new Regex("link\":\"(.*?)\"");
                Match match = reg.Match(result);
                string url = match.ToString().Replace("link\":\"", "").Replace("\"", "").Replace("\\/", "/");

                Regex deletereg = new Regex("deletehash\":\"(.*?)\"");
                Match match1 = deletereg.Match(result);
                string deletehash = match1.ToString().Replace("deletehash\":\"", "").Replace("\"", "").Replace("\\/", "/");
                deletehash = string.Format("{0}/delete/{1}", URL, deletehash);

                string pageurl = url.Replace(".png", "").Replace(".jpg", "").Replace(".gif", "").Replace(ImgURL, PageURL);

                return new UploadResult(url, pageurl, deletehash, Utils.Utils.ToUnixTime(DateTime.Now), Title, false);
            }
            catch
            {
                return new UploadResult("", "", "", Utils.Utils.ToUnixTime(DateTime.Now), Title, true);
            }
        }

        public override System.Collections.Specialized.NameValueCollection DeletionValues
        {
            get {
                return new System.Collections.Specialized.NameValueCollection()
                {
                    {"confirm", "true"}
                };
            }
        }

        public override bool SupportsPages
        {
            get { return true; }
        }

        public override string PageURL
        {
            get { return "http://imgur.com"; }
        }
    }
}

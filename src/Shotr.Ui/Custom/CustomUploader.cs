using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using Shotr.Ui.Utils;
using ShotrUploaderPlugin;

namespace Shotr.Ui.Custom
{
    [Serializable]
    public class CustomUploaderInstance
    {
        private string _title;

        private string _url;
        private string _requesttype;
        private string _formname;
        private bool _usepages;
        private bool _customuploader;
        private string _curl;
        //custom uploader stuffs

        private NameValueCollection _uploadvalues;

        private UploaderBridge _imguploader;

        public CustomUploaderInstance(string name, string url, string requesttype, string formname, bool usepages, NameValueCollection uploadvalues, bool custom, string curl)
        {
            _title = name;
            _url = url;
            _requesttype = requesttype;
            _formname = formname;
            _uploadvalues = uploadvalues;
            _usepages = usepages;
            _customuploader = custom;
            _curl = curl;
            _imguploader = new UploaderBridge(this);
        }

        public bool UseCustomUploader { get { return _customuploader; } set { value = _customuploader; } }
        public string CustomUploaderURL { get { return _curl; } set { value = _curl; } }
        public bool UsePageURL { get { return _usepages; } set { value = _usepages; } }
        public string Title { get { return _title; } set { _title = value; } }
        public string URL { get { return _url; } set { _url = value; } }
        public string RequestType { get { return _requesttype; } set { _requesttype = value; } }
        public string FormName { get { return _formname; } set { _formname = value; } }
        public NameValueCollection UploadValues { get { return _uploadvalues; } set { _uploadvalues = value; } }

        public ImageUploader Uploader
        {
            get
            {
                return _imguploader;
            }
        }
    }
    [Serializable]
    public class UploaderBridge : ImageUploader
    {
        private CustomUploaderInstance inst;
        public UploaderBridge(CustomUploaderInstance p)
        {
            inst = p;
        }

        public override string Title
        {
            get { return inst.Title; }
        }

        public override bool UseUploadMethod
        {
            get { return inst.UseCustomUploader; }
        }

        public override string FileValueName
        {
            get { return inst.FormName; }
        }

        public override string UploaderURL
        {
            get { return inst.URL; }
        }

        public override NameValueCollection UploadValues
        {
            get { return inst.UploadValues; }
        }

        public override NameValueCollection HeaderValues
        {
            get { return new NameValueCollection(); }
        }

        public override bool SupportsPages
        {
            get { return inst.UsePageURL; }
        }

        public override string PageURL
        {
            get { throw new NotImplementedException(); }
        }

        public override NameValueCollection DeletionValues
        {
            get { return null; }
        }

        public override UploadResult UploadImage(ImageShell k)
        {
            //parse page for inst values.
            try
            {
                string m = FileUploader.UploadFile(UploaderURL, k.Data, string.Format("{0}.{1}", Utils.Utils.GetRandomString(5), k.Extension.ToString()), FileValueName, k.ContentType, UploadValues, HeaderValues);
                //attempt to parse the URL out of it.
                Uri s = new Uri(inst.CustomUploaderURL);
                m = m.Replace("\\", "");
                char[] arr = m.ToCharArray();

                arr = Array.FindAll<char>(arr, (c => (char.IsLetterOrDigit(c)
                                                  || char.IsWhiteSpace(c)
                                                  || c == '-' || c == '/' || c == '.' || c == ':')));
                string newm = "";
                for (int i = 0; i < m.Length; i++)
                {
                    if (!arr.Contains(m[i]))
                        newm += ' ';
                    else
                        newm += m[i];
                }
                Regex reg = new Regex(s.Scheme+"://"+s.Host+"/([^\\s]+)");
                Match p = reg.Match(newm);
                if(p.Success == false)
                {
                    //uhm not found, error?
                    return new UploadResult("", "", "", 0, Title, true);
                }
                //remove .ext from match
                reg = new Regex("(.*\\.)");
                Match x = reg.Match(p.Value);

                return new UploadResult(p.Value, x.Success ? x.Value.Substring(0, x.Value.Length - 1) : "", "", Utils.Utils.ToUnixTime(DateTime.Now), Title, false);
            }
            catch
            {
                return new UploadResult("", "", "", 0, Title, true);
            }
        }
    }
    //somehow convert it to a ImageUploader instance?
}

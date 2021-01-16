using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using Shotr.Core.Services;
using Shotr.Core.Utils;
using ShotrUploaderPlugin;

namespace Shotr.Core.Custom
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

        public bool UseCustomUploader { get => _customuploader;
            set => value = _customuploader;
        }
        public string CustomUploaderURL { get => _curl;
            set => value = _curl;
        }
        public bool UsePageURL { get => _usepages;
            set => value = _usepages;
        }
        public string Title { get => _title;
            set => _title = value;
        }
        public string URL { get => _url;
            set => _url = value;
        }
        public string RequestType { get => _requesttype;
            set => _requesttype = value;
        }
        public string FormName { get => _formname;
            set => _formname = value;
        }
        public NameValueCollection UploadValues { get => _uploadvalues;
            set => _uploadvalues = value;
        }

        public IImageUploader Uploader => _imguploader;
    }
    [Serializable]
    public class UploaderBridge : IImageUploader
    {
        private CustomUploaderInstance inst;
        public UploaderBridge(CustomUploaderInstance p)
        {
            inst = p;
        }

        public string Title => inst.Title;

        public bool UseUploadMethod => inst.UseCustomUploader;

        public string FileValueName => inst.FormName;

        public string UploaderURL => inst.URL;

        public NameValueCollection UploadValues => inst.UploadValues;

        public NameValueCollection HeaderValues => new NameValueCollection();

        public bool SupportsPages => inst.UsePageURL;

        public string PageURL => throw new NotImplementedException();

        public NameValueCollection DeletionValues => null;

        public UploadResult UploadImage(ImageShell k)
        {
            //parse page for inst values.
            try
            {
                var m = FileUploaderService.UploadFile(UploaderURL, k.Data, string.Format("{0}.{1}", Utils.Utils.GetRandomString(5), k.Extension.ToString()), FileValueName, k.ContentType, UploadValues, HeaderValues);
                //attempt to parse the URL out of it.
                var s = new Uri(inst.CustomUploaderURL);
                m = m.Replace("\\", "");
                var arr = m.ToCharArray();

                arr = Array.FindAll(arr, (c => (char.IsLetterOrDigit(c)
                                                  || char.IsWhiteSpace(c)
                                                  || c == '-' || c == '/' || c == '.' || c == ':')));
                var newm = "";
                for (var i = 0; i < m.Length; i++)
                {
                    if (!arr.Contains(m[i]))
                        newm += ' ';
                    else
                        newm += m[i];
                }
                var reg = new Regex(s.Scheme+"://"+s.Host+"/([^\\s]+)");
                var p = reg.Match(newm);
                if(p.Success == false)
                {
                    //uhm not found, error?
                    return new UploadResult("", "", "", 0, Title, true);
                }
                //remove .ext from match
                reg = new Regex("(.*\\.)");
                var x = reg.Match(p.Value);

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

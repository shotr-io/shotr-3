using System;
using System.Collections.Specialized;
using ShotrUploaderPlugin;

namespace Shotr.Ui.Plugin
{
    class ShotrImageUploader : ImageUploader
    {
        public override NameValueCollection UploadValues
        {
            get { return null;  }
        }

        public override NameValueCollection HeaderValues
        {
            get
            {
                if (Program.Settings.login)
                {
                    return new NameValueCollection { { "token", Program.Settings.token } };
                }
                else
                {
                    return new NameValueCollection();
                }
            }
        }

        public override string FileValueName
        {
            get { return "file"; }
        }

        public override string UploaderURL
        {
            get { 
#if DEBUG
                //return "http://localhost:5001/api/upload";
                return "https://shotr.dev/api/upload";
#else
                return "https://shotr.io/upload"; 
#endif
            }
        }

        public override string Title
        {
            get { return "Shotr"; }
        }

        public override bool UseUploadMethod
        {
            get { return false; }
        }

        public override UploadResult UploadImage(ImageShell k)
        {
            throw new NotImplementedException();
        }

        public override NameValueCollection DeletionValues
        {
            get
            {
                return new NameValueCollection()
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
            get { 
#if DEBUG
                    return "https://shotr.dev/"; 
#else
                    return "https://shotr.io/"; 
#endif
                }
        }
    }
}

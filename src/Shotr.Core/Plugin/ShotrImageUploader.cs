using System;
using System.Collections.Specialized;
using Shotr.Core.Utils;
using ShotrUploaderPlugin;

namespace Shotr.Core.Plugin
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
                if (Settings.Instance.login)
                {
                    return new NameValueCollection { { "token", Settings.Instance.token } };
                }

                return new NameValueCollection();
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
                return new NameValueCollection
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

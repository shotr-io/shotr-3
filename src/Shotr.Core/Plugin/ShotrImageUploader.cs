using System;
using System.Collections.Specialized;
using Shotr.Core.Settings;
using ShotrUploaderPlugin;

namespace Shotr.Core.Plugin
{
    public class ShotrImageUploader : ImageUploader
    {
        private readonly BaseSettings _settings;
        public ShotrImageUploader(BaseSettings settings)
        {
            _settings = settings;
        }
        
        public override NameValueCollection UploadValues => null;

        public override NameValueCollection HeaderValues
        {
            get
            {
                if (_settings.Login.Token is {})
                {
                    return new NameValueCollection { { "token", _settings.Login.Token } };
                }

                return new NameValueCollection();
            }
        }

        public override string FileValueName => "file";

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

        public override string Title => "Shotr";

        public override bool UseUploadMethod => false;

        public override UploadResult UploadImage(ImageShell k)
        {
            throw new NotImplementedException();
        }

        public override NameValueCollection DeletionValues =>
            new NameValueCollection
            {
                {"confirm", "true"}
            };

        public override bool SupportsPages => true;

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

using System;
using System.Collections.Specialized;
using Shotr.Core.Settings;
using ShotrUploaderPlugin;

namespace Shotr.Core.Plugin
{
    public class ShotrImageUploader : IImageUploader
    {
        private readonly BaseSettings _settings;
        public ShotrImageUploader(BaseSettings settings)
        {
            _settings = settings;
        }
        
        public NameValueCollection UploadValues => null;

        public NameValueCollection HeaderValues
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

        public string FileValueName => "file";

        public string UploaderURL
        {
            get { 
#if DEBUG || BETATEST
                //return "http://localhost:5001/api/upload";
                return "https://shotr.dev/api/upload";
#else
                return "https://shotr.io/upload"; 
#endif
            }
        }

        public string Title => "Shotr";

        public bool UseUploadMethod => false;

        public UploadResult UploadImage(ImageShell k)
        {
            throw new NotImplementedException();
        }

        public NameValueCollection DeletionValues =>
            new NameValueCollection
            {
                {"confirm", "true"}
            };

        public bool SupportsPages => true;

        public string PageURL
        {
            get {
#if DEBUG || BETATEST
                return "https://shotr.dev/"; 
#else
                    return "https://shotr.io/"; 
#endif
                }
        }
    }
}

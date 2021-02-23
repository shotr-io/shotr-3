using System;
using System.Collections.Specialized;
using Shotr.Core.Settings;
using Shotr.Core.Uploader;

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

        public string UploaderUrl => "https://shotr.dev/api/upload";

        public string Title => "Shotr";

        public bool UseUploadMethod => false;

        public UploadResult UploadImage(FileShell file)
        {
            throw new NotImplementedException();
        }

        public NameValueCollection DeletionValues =>
            new NameValueCollection
            {
                {"confirm", "true"}
            };

        public bool SupportsPages => true;

        public string PageUrl => "https://shotr.dev/"; 
    }
}

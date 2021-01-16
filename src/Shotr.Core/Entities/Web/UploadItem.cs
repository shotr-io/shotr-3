using System;

namespace Shotr.Core.Entities.Web
{
    public class UploadItem
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public string MimeType { get; set; }
        public string TextContent { get; set; }
        public string Extension { get; set; }
        public string FileType { get; set; }
    }
}

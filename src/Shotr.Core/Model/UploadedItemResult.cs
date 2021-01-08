namespace Shotr.Core.Model
{
    public class UploadedItemResult
    {
        public string Url { get; set; }
        public string RawUrl { get; set; }
        public string Name { get; set; }
        public bool Error { get; set; }
        public string ErrorMessage { get; set; }
    }
}

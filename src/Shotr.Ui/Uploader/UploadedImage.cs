namespace Shotr.Ui.Uploader
{
    public class UploadedImage
    {
        public long Time;
        public string URL;
        public string DelURL;

        public UploadedImage(long time, string url, string delurl)
        {
            Time = time;
            URL = url;
            DelURL = delurl;
        }
    }
}

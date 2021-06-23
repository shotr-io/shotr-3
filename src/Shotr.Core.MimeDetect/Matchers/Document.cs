namespace Shotr.Core.MimeDetect.Matchers
{
    public class Document
    {
        public static bool Pdf(byte[] f)
        {
            return f.Prefix(new byte[] {0x25, 0x50, 0x44, 0x46});
        }
    }
}
using System.Linq;

namespace Shotr.Core.MimeDetect.Matchers
{
    public class Image
    {
        public static bool Png(byte[] f)
        {
            return f.Prefix(new byte[] {0x89, 0x50, 0x4e, 0x47, 0x0d, 0x0a, 0x1a, 0x0a});
        }

        public static bool Jpg(byte[] f)
        {
            return f.Prefix(new byte[] {0xff, 0xd8, 0xff});
        }

        public static bool Gif(byte[] f)
        {
            return f.Prefix("GIF87a") || f.Prefix("GIF89a");
        }

        public static bool Webp(byte[] f)
        {
            return f.Length > 11 && f.Prefix(new byte[] {0x52, 0x49, 0x46, 0x46}) &&
                   f.Skip(8).ToArray().Prefix(new byte[] {0x57, 0x45, 0x42, 0x50});
        }
        
        public static bool Bmp(byte[] f) {
            return f.Length > 1 && f[0] == 0x42 && f[1] == 0x4D;
        }

        public static bool Ps(byte[] f)
        {
            return f.Prefix("%!PS-Adobe-");
        }

        public static bool Psd(byte[] f)
        {
            return f.Prefix("8BPS");
        }

        public static bool Ico(byte[] f)
        {
            return f.Length > 3 && f[0] == 0x00 && f[1] == 0x00 && f[2] == 0x01 && f[3] == 0x00;
        }

        public static bool Tiff(byte[] f)
        {
            return f.Prefix(new byte[] {0x49, 0x49, 0x2A, 0x00}) ||
                   f.Prefix(new byte[] {0x4D, 0x4D, 0x00, 0x2A});
        }

        public static bool Svg(byte[] f)
        {
            return f.Prefix("<svg");
        }

        public static bool Heic(byte[] f)
        {
            return f.Skip(4).ToArray().Prefix(new byte[] {0x66, 0x74, 0x79, 0x70, 0x68, 0x65, 0x69, 0x63});
        }
    }
}
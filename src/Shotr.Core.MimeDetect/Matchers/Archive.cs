using System.Linq;

namespace Shotr.Core.MimeDetect.Matchers
{
    public class Archive : Matcher
    {
        public static bool Zip(byte[] file)
        {
            return file.Length > 3 && file[0] == 0x50 && file[1] == 0x4B &&
                   (file[2] == 0x03 || file[2] == 0x05 || file[2] == 0x07) &&
                   (file[3] == 0x04 || file[3] == 0x06 || file[3] == 0x08);
        }

        public static bool Rar(byte[] file)
        {
            return file.Length > 8 &&
                   (file.Prefix(new byte[] {0x52, 0x61, 0x72, 0x21, 0x1A, 0x07, 0x01, 0x00}) ||
                    file.Prefix(new byte[] {0x52, 0x61, 0x72, 0x21, 0x1A, 0x07, 0x00}));
        }

        public static bool TarGz(byte[] file)
        {
            return file.Length > 2 && file.Prefix(new byte[] {0x1F, 0x8B, 0x08});
        }
        
        public static bool SevenZ(byte[] file)
        {
            return file.Prefix(new byte[] {0x37, 0x7A, 0xBC, 0xAF, 0x27, 0x1C});
        }

        public static bool Epub(byte[] file)
        {
            if (file.Length < 58)
            {
                return false;
            }

            return file.Skip(30).ToArray().Prefix("mimetypeapplication/epub+zip");
        }

        public static bool Jar(byte[] file)
        {
            return file.Contains("META-INF/MANIFEST.MF");
        }
    }
}
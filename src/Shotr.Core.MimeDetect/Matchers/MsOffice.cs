using System.Linq;

namespace Shotr.Core.MimeDetect.Matchers
{
    public class MsOffice
    {
        public static bool Xlsx(byte[] file)
        {
            return file.Contains("xl/");
        }

        public static bool Docx(byte[] file)
        {
            return file.Contains("word/");
        }

        public static bool Pptx(byte[] file)
        {
            return file.Contains("ppt/");
        }

        public static bool Doc(byte[] file)
        {
            if (file.Length < 516)
            {
                return false;
            }

            var head = new byte[] {0xd0, 0xcf, 0x11, 0xe0, 0xa1, 0xb1, 0x1a, 0xe1};
            var offset512 = new byte[] {0xec, 0xa5, 0xc1, 0x00};

            return file.Prefix(head) && file.Skip(512).ToArray().Prefix(offset512);
        }

        public static bool Ppt(byte[] file)
        {
            if (file.Length < 520)
            {
                return false;
            }

            if (!file.Prefix(new byte[] {0xd0, 0xcf, 0x11, 0xe0, 0xa1, 0xb1, 0x1a, 0xe1}))
            {
                return false;
            }
            
            var offset512 = file.Skip(512).ToArray();
            if (offset512.Prefix(new byte[] {0xa0, 0x46, 0x1d, 0xf0}) ||
                offset512.Prefix(new byte[] {0x00, 0x6e, 0x1e, 0xf0}) ||
                offset512.Prefix(new byte[] {0x0f, 0x00, 0xe8, 0x03}))
            {
                return true;
            }

            if (offset512.Prefix(new byte[] {0xfd, 0xff, 0xff, 0xff}) &&
                file.Skip(518).ToArray().Prefix(new byte[] {0x00, 0x00}))
            {
                return true;
            }

            return false;
        }

        public static bool Xls(byte[] file)
        {
            if (file.Length < 520)
            {
                return false;
            }

            if (file.Prefix(new byte[] {0xd0, 0xcf, 0x11, 0xe0, 0xa1, 0xb1, 0x1a, 0xe1}))
            {
                var offset512 = file.Skip(512).ToArray();
                var subheaders = new byte[][]
                {
                    new byte[] { 0x09, 0x08, 0x10, 0x00, 0x00, 0x06, 0x05, 0x00 },
                    new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x10 },
                    new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x1f },
                    new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x22 },
                    new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x23 },
                    new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x28 },
                    new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x29 },
                };

                return subheaders.Any(sub => offset512.Prefix(sub));
            }

            return false;
        }
    }
}
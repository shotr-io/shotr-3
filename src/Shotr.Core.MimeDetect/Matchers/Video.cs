using System;
using System.Linq;

namespace Shotr.Core.MimeDetect.Matchers
{
    public class Video
    {
        public static bool Mp4(byte[] f)
        {
            if (f.Length < 12)
            {
                return false;
            }

            var boxSize = BitConverter.ToUInt32(f, 0).ToBigEndian();

            if (boxSize % 4 != 0 || f.Length < boxSize)
            {
                return false;
            }

            if (!f.Skip(4).ToArray().Prefix("ftyp"))
            {
                return false;
            }

            for (var i = 8; i < boxSize; i += 4)
            {
                if (i == 12)
                {
                    continue;
                }

                if (f.Skip(i).ToArray().Prefix("mp4"))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool WebM(byte[] f)
        {

            return f.Prefix(new byte[] {0x1a, 0x45, 0xdf, 0xa3});
        }

        public static bool ThreeGP(byte[] f)
        {

            return f.Length > 11 &&
                   f.Skip(4).ToArray().Prefix(new byte[] {0x66, 0x74,0x79,0x70,0x33,0x67,0x70});
        }

        public static bool Flv(byte[] f)
        {
            return f.Prefix(new byte[] {0x46, 0x4c, 0x56, 0x01});
        }

        public static bool Mpeg(byte[] f)
        {
            return f.Length > 3 && f.Prefix(new byte[] {0x00, 0x00, 0x01}) &&
                   f[3] >= 0xB0 && f[3] <= 0xbf;
        }

        public static bool Quicktime(byte[] f)
        {
            var x = f.Skip(4).ToArray();
            return f.Length > 12 && x.Prefix("ftypqt  ") || x.Prefix("moov");
        }

        public static bool Avi(byte[] f)
        {
            return f.Length > 16 && f.Skip(4).ToArray().Prefix("RIFF") && f.Skip(8).ToArray().Prefix("AVI LIST");
        }
    }
}
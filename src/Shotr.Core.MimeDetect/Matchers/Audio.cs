using System.Linq;

namespace Shotr.Core.MimeDetect.Matchers
{
    public class Audio : Matcher
    {
        public static bool Mp3(byte[] f)
        {
            return f.Prefix(new byte[] {0x49, 0x44, 0x33});
        }

        public static bool Flac(byte[] f)
        {
            return f.Prefix(new byte[] {0x66, 0x4C, 0x61, 0x43, 0x00, 0x00, 0x22});
        }

        public static bool Midi(byte[] f)
        {
            return f.Prefix(new byte[] {0x4D, 0x54, 0x68, 0x64});
        }

        public static bool Ape(byte[] f)
        {
            return f.Prefix(new byte[]
            {
                0x4d, 0x41, 0x43, 0x20, 0x96, 0x0f, 0x00, 0x00, 0x34, 0x00, 0x00, 0x00, 0x18, 0x00, 0x00, 0x00, 0x90,
                0xe3
            });
        }

        public static bool MusePack(byte[] f)
        {
            return false;
        }

        public static bool Wav(byte[] f)
        {
            return f.Prefix(new byte[] {0x52, 0x49, 0x46, 0x46}) &&
                   f.Skip(8).ToArray().Prefix(new byte[] {0x57, 0x41, 0x56, 0x45});
        }

        public static bool Aiff(byte[] f)
        {
            return f.Prefix(new byte[] {0x46, 0xf4, 0x52, 0x4d}) &&
                   f.Skip(8).ToArray().Prefix(new byte[] {0x41, 0x49, 0x46, 0x46});
        }

        public static bool Ogg(byte[] f)
        {
            return f.Prefix(new byte[] {0x4f, 0x67, 0x67, 0x53, 0x00});
        }

        public static bool Au(byte[] f)
        {
            return f.Prefix(new byte[] {0x2e, 0x73, 0x6e, 0x64});
        }
    }
}
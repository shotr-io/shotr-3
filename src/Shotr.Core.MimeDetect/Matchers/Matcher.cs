using System.Linq;

namespace Shotr.Core.MimeDetect.Matchers
{
    public class Matcher
    {
        public static bool True(byte[] file)
        {
            return true;
        }

        public static bool False(byte[] file)
        {
            return false;
        }

        public static byte[] TrimLws(byte[] file)
        {
            var firstNonWs = 0;
            while (firstNonWs < file.LongLength && IsWs(file[firstNonWs]))
            {
                firstNonWs++;
            }

            return file.Skip(firstNonWs).ToArray();
        }

        public static byte[] TrimRws(byte[] file)
        {
            var lastNonWs = file.Length - 1;
            while (lastNonWs > 0 && IsWs(file[lastNonWs]))
            {
                lastNonWs--;
            }

            return file.Take(lastNonWs + 1).ToArray();
        }
        
        public static byte[] FirstLine(byte[] file)
        {
            var lineEnd = 0;
            while (lineEnd < file.Length && file[lineEnd] != (byte) '\n')
            {
                lineEnd++;
            }

            return file.Take(lineEnd).ToArray();
        }

        private static bool IsWs(byte b)
        {
            switch (b)
            {
                case (byte)'\t':
                case (byte)'\n':
                case (byte)'\x0c':
                case (byte)'\r':
                case (byte)' ':
                    return true;
                default:
                    return false;
            }
        }
    }
}
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Shotr.Core
{
    public static class Extensions
    {
        public static void OpenUrl(this string url)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                url = url.Replace("&", "^&");
                Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", url);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", url);
            }
        }

        public static TextFormatFlags AsTextFormatFlags(this ContentAlignment alignment)
        {
            return alignment switch
            {
                ContentAlignment.BottomLeft => TextFormatFlags.Bottom | TextFormatFlags.Left,
                ContentAlignment.BottomCenter => TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter,
                ContentAlignment.BottomRight => TextFormatFlags.Bottom | TextFormatFlags.Right,
                ContentAlignment.MiddleLeft => TextFormatFlags.VerticalCenter | TextFormatFlags.Left,
                ContentAlignment.MiddleCenter => TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter,
                ContentAlignment.MiddleRight => TextFormatFlags.VerticalCenter | TextFormatFlags.Right,
                ContentAlignment.TopLeft => TextFormatFlags.Top | TextFormatFlags.Left,
                ContentAlignment.TopCenter => TextFormatFlags.Top | TextFormatFlags.HorizontalCenter,
                ContentAlignment.TopRight => TextFormatFlags.Top | TextFormatFlags.Right,
                _ => throw new InvalidEnumArgumentException()
            };
        }

        public static byte[] ImageToByteArray(this System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        public static byte[] ImageToByteArrayConvert(this System.Drawing.Image imageIn, string mimeType, int quality = 100)
        {
            using (var ms = new MemoryStream())
            {
                var myImageCodecInfo = GetEncoderInfo(mimeType);
                var encoderParams = new EncoderParameters(1);
                var qualityEncoder = new EncoderParameter(Encoder.Quality, quality);
                encoderParams.Param[0] = qualityEncoder;
                imageIn.Save(ms, myImageCodecInfo, encoderParams);

                return ms.ToArray();
            }
        }

        public static byte[] ImageToByteArrayCompressed(this System.Drawing.Image imageIn, string mimeType, long quality)
        {
            using (var ms = new MemoryStream())
            {
                var myImageCodecInfo = GetEncoderInfo(mimeType);
                var myEncoderParameters = new EncoderParameters(1);
                var myEncoderParameter = new EncoderParameter(Encoder.Quality, quality);
                myEncoderParameters.Param[0] = myEncoderParameter;

                imageIn.Save(ms, myImageCodecInfo, myEncoderParameters);

                return ms.ToArray();
            }
        }

        public static DateTime FromUnixTime(this long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        public static long ToUnixTime(this DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date - epoch).TotalSeconds);
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
    }
}
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;
using Microsoft.Win32;
using Shotr.Core.Entities;
using Shotr.Core.Quantizer;
using ShotrUploaderPlugin;

namespace Shotr.Core.Utils
{
    public class Utils
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

        [DllImport("user32.dll")]
        private static extern IntPtr GetShellWindow();


        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        private static WuQuantizer qz = new WuQuantizer();

        public static System.Drawing.Image Quantize(Bitmap img)
        {
            return qz.QuantizeImage(img, 0, 0);
        }

        public static System.Drawing.Image Apply(ColorMatrix matrix, System.Drawing.Image img)
        {
            var dest = CreateEmptyBitmap(img, PixelFormat.Format32bppArgb);
            var destRect = new Rectangle(0, 0, dest.Width, dest.Height);
            return Apply(matrix, img, dest, destRect);
        }

        public static System.Drawing.Image Apply(ColorMatrix matrix, System.Drawing.Image src, System.Drawing.Image dest, Rectangle destRect)
        {
            using (var graphics = Graphics.FromImage(dest))
            {
                using (var attributes = new ImageAttributes())
                {
                    attributes.ClearColorMatrix();
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.DrawImage(src, destRect, 0, 0, src.Width, src.Height, GraphicsUnit.Pixel, attributes);
                }
            }
            return dest;
        }

        public static Bitmap CreateEmptyBitmap(System.Drawing.Image img, PixelFormat pixelFormat, int widthOffset = 0, int heightOffset = 0)
        {
			try {
                var bitmap = new Bitmap(img.Width + widthOffset, img.Height + heightOffset, pixelFormat);
                bitmap.SetResolution(img.HorizontalResolution, img.VerticalResolution);
                return bitmap;
			}
			catch{
				return null;
			}
        }

        public static Bitmap CopyActiveWindow(Rectangle src)
        {
			try {
                var CurrScreen = Screen.FromPoint(Cursor.Position).Bounds;
                var bmpScreenCapture = new Bitmap(src.Width, src.Height);
                var g = Graphics.FromImage(bmpScreenCapture);
                g.CopyFromScreen(new Point(src.Left, src.Top),
                                         Point.Empty,
                                         src.Size);
                return bmpScreenCapture;
			}
			catch {
				return null;
			}
        }

        public static Bitmap CopyScreen()
        {
            var height = 0;
            var width = 0;
            var left = 0;
            var top = 0;
            var i = 0;
            foreach (var screen in Screen.AllScreens)
            {
                screen.GetDpi(DpiType.Effective, out var dpiX, out var dpiY);
                height = screen.Bounds.Height >= height ? (screen.Bounds.Height) : height;
                width += screen.Bounds.Width;
                left = left >= screen.Bounds.X ? screen.Bounds.X : left;
                top = top >= screen.Bounds.Y ? screen.Bounds.Y : top;
                if (screen.Bounds.Y + screen.Bounds.Height > height) height = screen.Bounds.Y + screen.Bounds.Height;
                if (top < 0 || screen.Bounds.Y >= height) height += screen.Bounds.Height;
                Console.WriteLine("Monitor {4} [ScalingX: {5}, ScalingY: {6}]: - Top: {0}, Left: {1}, Width: {2}, Height: {3}", screen.Bounds.Top, screen.Bounds.Left, screen.Bounds.Width, screen.Bounds.Height, i, dpiX, dpiY);
                i++;
            }
            
            var CurrScreen = new Rectangle(new Point(left, top), new Size(width, height));

            Console.WriteLine("Post Scaling: - Top: {0}, Left: {1}, Width: {2}, Height: {3}", CurrScreen.Y, CurrScreen.X, CurrScreen.Width, CurrScreen.Height);

            var w = BitBltCopy(CurrScreen);
            var g = Graphics.FromImage(w);
            Bitmap cursor;
            try
            {
                int x = 0, y = 0;
                cursor = WinApi.CaptureCursor(ref x, ref y);
                //calculate x & y's real position relative to the form.
                //which is (-left)+x | (-top)+y
                x = x + -left;
                y = y + -top;
                g.DrawImage(cursor, new Point(x, y));
                cursor.Dispose();
            }
            catch {
            }
            g.Flush();
            g.Dispose();
            return w;
        }

        public static string GetFilenameExtension(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                var pos = filePath.LastIndexOf('.');

                if (pos >= 0)
                {
                    return filePath.Substring(pos + 1).ToLowerInvariant();
                }
            }

            return null;
        }

        /// <summary>
        ///     Specifies a raster-operation code. These codes define how the color data for the
        ///     source rectangle is to be combined with the color data for the destination
        ///     rectangle to achieve the final color.
        /// </summary>
        enum TernaryRasterOperations : uint
        {
            /// <summary>dest = source</summary>
            SRCCOPY = 0x00CC0020,
            /// <summary>dest = source OR dest</summary>
            SRCPAINT = 0x00EE0086,
            /// <summary>dest = source AND dest</summary>
            SRCAND = 0x008800C6,
            /// <summary>dest = source XOR dest</summary>
            SRCINVERT = 0x00660046,
            /// <summary>dest = source AND (NOT dest)</summary>
            SRCERASE = 0x00440328,
            /// <summary>dest = (NOT source)</summary>
            NOTSRCCOPY = 0x00330008,
            /// <summary>dest = (NOT src) AND (NOT dest)</summary>
            NOTSRCERASE = 0x001100A6,
            /// <summary>dest = (source AND pattern)</summary>
            MERGECOPY = 0x00C000CA,
            /// <summary>dest = (NOT source) OR dest</summary>
            MERGEPAINT = 0x00BB0226,
            /// <summary>dest = pattern</summary>
            PATCOPY = 0x00F00021,
            /// <summary>dest = DPSnoo</summary>
            PATPAINT = 0x00FB0A09,
            /// <summary>dest = pattern XOR dest</summary>
            PATINVERT = 0x005A0049,
            /// <summary>dest = (NOT dest)</summary>
            DSTINVERT = 0x00550009,
            /// <summary>dest = BLACK</summary>
            BLACKNESS = 0x00000042,
            /// <summary>dest = WHITE</summary>
            WHITENESS = 0x00FF0062,
            /// <summary>
            /// Capture window as seen on screen.  This includes layered windows 
            /// such as WPF windows with AllowsTransparency="true"
            /// </summary>
            CAPTUREBLT = 0x40000000
        }

        // P/Invoke declarations
        [DllImport("gdi32.dll")]
        static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest,
            int nWidthDest, int nHeightDest,
            IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc,
            TernaryRasterOperations dwRop);
        [DllImport("gdi32.dll")]
        static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int
        wDest, int hDest, IntPtr hdcSource, int xSrc, int ySrc, CopyPixelOperation rop);
        [DllImport("user32.dll")]
        static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDc);
        [DllImport("gdi32.dll")]
        static extern IntPtr DeleteDC(IntPtr hDc);
        [DllImport("gdi32.dll")]
        static extern IntPtr DeleteObject(IntPtr hDc);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr ptr);
        public static Bitmap BitBltCopy(Rectangle scr)
        {
            var hDesk = GetDesktopWindow();
            var hSrce = GetWindowDC(hDesk);
            var hDest = CreateCompatibleDC(hSrce);
            var hBmp = CreateCompatibleBitmap(hSrce, scr.Width, scr.Height);
            var hOldBmp = SelectObject(hDest, hBmp);
            var b = BitBlt(hDest, 0, 0, scr.Width, scr.Height, hSrce, scr.X, scr.Y, CopyPixelOperation.SourceCopy | CopyPixelOperation.CaptureBlt);
            var bmp = System.Drawing.Image.FromHbitmap(hBmp);
            SelectObject(hDest, hOldBmp);
            DeleteObject(hBmp);
            DeleteDC(hDest);
            ReleaseDC(hDesk, hSrce);
            return bmp;
        }

        public static Rectangle GetActiveWindowCoords()
        {
            var foregroundWindowsHandle = GetForegroundWindow();
            var rect = new Rect();
            GetWindowRect(foregroundWindowsHandle, ref rect);
            var bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
            //grab image
            return bounds;
        }

        public static ColorMatrix Contrast(float value)
        {
            var newColorMatrix = new float[5][];
            var numArray2 = new float[5];
            numArray2[0] = value;
            newColorMatrix[0] = numArray2;
            var numArray3 = new float[5];
            numArray3[1] = value;
            newColorMatrix[1] = numArray3;
            var numArray4 = new float[5];
            numArray4[2] = value;
            newColorMatrix[2] = numArray4;
            var numArray5 = new float[5];
            numArray5[3] = 1f;
            newColorMatrix[3] = numArray5;
            var numArray6 = new float[5];
            numArray6[4] = 1f;
            newColorMatrix[4] = numArray6;
            return new ColorMatrix(newColorMatrix);
        }

        public static string GetRandomString(int len)
        {
            var path = Path.GetRandomFileName();
            path = path.Replace(".", "");
            if (path.Length < len)
            {
                while (path.Length < len)
                {
                    path += Path.GetRandomFileName();
                    path = path.Replace(".", "");
                }
                //once it hits here, truncate?
                return path.Substring(0, len);
            }

            if (path.Length > len)
            {
                //substring.
                return path.Substring(0, len);
            }
            //equal to length, return it.
            return path;
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

        public static byte[] ImageToByteArray(System.Drawing.Image imageIn, FileExtensions ext, bool compress, long quality)
        {
            using (var ms = new MemoryStream())
            {
                if (compress)
                {
                    var myImageCodecInfo =
                        GetEncoderInfo("image/" + (ext == FileExtensions.jpeg ? "jpeg" :
                                                   ext == FileExtensions.jpg ? "jpeg" : ext.ToString()));
                    var myEncoder = Encoder.Quality;
                    var myEncoderParameters = new EncoderParameters(1);
                    var myEncoderParameter = new EncoderParameter(myEncoder, quality);
                    myEncoderParameters.Param[0] = myEncoderParameter;

                    imageIn.Save(ms, myImageCodecInfo, myEncoderParameters);
                }
                else
                {
                    var imageFormat = ext switch
                    {
                        FileExtensions.gif  => ImageFormat.Gif,
                        FileExtensions.png  => ImageFormat.Png,
                        FileExtensions.bmp  => ImageFormat.Bmp,
                        FileExtensions.jpg  => ImageFormat.Jpeg,
                        FileExtensions.jpeg => ImageFormat.Jpeg,
                        _                   => ImageFormat.Png,
                    };
                    
                    imageIn.Save(ms, imageFormat);
                }

                return ms.ToArray();
            }
        }

        public static DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        public static long ToUnixTime(DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date - epoch).TotalSeconds);
        }

        public static void AddToStartup(bool add)
        {
            if (add)
            {
                var addt = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                addt.SetValue("Shotr", "\"" + Application.ExecutablePath + "\"");
                addt.Close();
            }
            else
            {
                var remove = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                remove.DeleteValue("Shotr");
                remove.Close();
            }
        }


        public static string MD5File(string filepath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filepath))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                }
            }
        }

        public static void Decompress(string filepath, string outputpath)
        {
            using (var f = File.OpenRead(filepath))
            {
                using (var decompress = new GZipStream(f, CompressionMode.Decompress, false))
                {
                    try
                    {
                        const int size = 1024;
                        var buffer = new byte[size];
                        using (var m = File.OpenWrite(outputpath))
                        {
                            var count = 0;
                            do
                            {
                                count = decompress.Read(buffer, 0, size);
                                if (count > 0)
                                {
                                    m.Write(buffer, 0, count);
                                }
                            }
                            while (count > 0);
                        }
                    }
                    catch
                    {
                        throw new InvalidDataException();
                    }
                }
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(HandleRef hWnd, [In, Out] ref RECT rect);

        public static bool IsForegroundFullScreen()
        {
            return IsForegroundFullScreen(null);
        }

        public static bool IsForegroundFullScreen(Screen screen)
        {
            if (screen == null)
            {
                screen = Screen.PrimaryScreen;
            }
            var rect = new RECT();
            GetWindowRect(new HandleRef(null, GetForegroundWindow()), ref rect);
            return new Rectangle(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top).Contains(screen.Bounds);
        }

        public static Process? GetForegroundProcess()
        {
            if (IsForegroundFullScreen())
            {
                //get process name
                uint pid = 0;
                GetWindowThreadProcessId(GetForegroundWindow(), out pid);
                var x = Process.GetProcessById((int)pid);
                if (x.ProcessName.Contains("explorer") || x.ProcessName.Contains(Process.GetCurrentProcess().ProcessName))
                {
                    return null;
                }
                return x;
            }
            return null;
        }
    }
}

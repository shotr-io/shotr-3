using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Shotr.Core.Capture
{
    class Capture
    {
        public static Bitmap CaptureCursor(ref int x, ref int y)
        {
            try
            {
                Bitmap bmp;
                IntPtr hicon;
                var ci = new Win32Stuff.CURSORINFO();
                Win32Stuff.ICONINFO icInfo;
                ci.cbSize = Marshal.SizeOf(ci);
                if (Win32Stuff.GetCursorInfo(out ci))
                {
                    if (ci.flags == Win32Stuff.CURSOR_SHOWING)
                    {
                        hicon = Win32Stuff.CopyIcon(ci.hCursor);
                        if (Win32Stuff.GetIconInfo(hicon, out icInfo))
                        {
                            x = ci.ptScreenPos.x - icInfo.xHotspot;
                            y = ci.ptScreenPos.y - icInfo.yHotspot;
                            try
                            {
                                Icon ic = Icon.FromHandle(hicon);
                                bmp = ic.ToBitmap();
                                return bmp;
                            }
                            catch { return null; }
                        }
                    }
                }
                return null;
            }
            catch { return null; }
        }
    }
}

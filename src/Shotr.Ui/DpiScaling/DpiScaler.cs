using System;
using System.Drawing;
using System.Windows.Forms;
using Shotr.Ui.Utils;

namespace Shotr.Ui.DpiScaling
{
    public class DpiScaler
    {
        private static float _scalingFactor = -1f;

        public static bool NotDpiScaling(Control control)
        {
            return GetScalingFactor(control).Equals(1f) || (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");
        }

        public static float GetScalingFactor(Control control)
        {
            if (_scalingFactor.Equals(-1f))
            {
                Screen.FromControl(control).GetDpi(DpiType.Effective, out var dpiX, out var dpiY);
                _scalingFactor = (dpiX / 96f);
                Console.WriteLine("DPI Scaling Factor/DpiX: {0} ({1}).", _scalingFactor, dpiX);
            }

            return _scalingFactor;
        }

        public static (Size, Point) ScaleControl(Control control, Size size, Point location)
        {
            if (control.Size.IsEmpty || control.Location.IsEmpty)
            {
                return (size, location);
            }

            var dpiScalingFactor = GetScalingFactor(control);

            if (size.IsEmpty)
            {
                size = control.Size;
            }

            if (location.IsEmpty)
            {
                location = control.Location;
            }

            if (!dpiScalingFactor.Equals(1))
            {
                control.Size = new Size((int)(size.Width * dpiScalingFactor), (int)(size.Height * dpiScalingFactor));
                control.Location = new Point((int)(location.X * dpiScalingFactor), (int)(location.Y * dpiScalingFactor));   
            }

            return (size, location);
        }

        public static (Size, Point) ScaleSize(Control control, Size size, Point location)
        {
            var dpiScalingFactor = GetScalingFactor(control);

            if (size.IsEmpty)
            {
                size = control.Size;
            }

            if (location.IsEmpty)
            {
                location = control.Location;
            }

            if (!dpiScalingFactor.Equals(1))
            {
                control.Size = new Size((int)(size.Width * dpiScalingFactor), (int)(size.Height * dpiScalingFactor));
            }

            return (size, location);
        }

        public static (Size, Point) ScaleLocation(Control control, Size size, Point location)
        {
            var dpiScalingFactor = GetScalingFactor(control);

            if (size.IsEmpty)
            {
                size = control.Size;
            }

            if (location.IsEmpty)
            {
                location = control.Location;
            }

            if (!dpiScalingFactor.Equals(1))
            {
                control.Location = new Point((int)(location.X * dpiScalingFactor), (int)(location.Y * dpiScalingFactor));
            }

            return (size, location);
        }

        public static Font ScaleFont(Font font, Control control, float factor = 1f)
        {
            var dpiScalingFactor = GetScalingFactor(control);

            if (NotDpiScaling(control))
            {
                return font;
            }

            if (factor < 1f) 
            {
                if (dpiScalingFactor < 2f)
                {
                    factor += 0.1f;
                }

                if (dpiScalingFactor < 1.75f)
                {
                    factor += 0.1f;
                }

                if (dpiScalingFactor < 1.5f)
                {
                    factor += 0.1f;
                }
            }

            Console.WriteLine("Font Size: {0} ({1}) - Scaling: {2} * {3}", (font.SizeInPoints * ((dpiScalingFactor * 96f) / 72) * dpiScalingFactor) * factor, font.SizeInPoints * (dpiScalingFactor / 72), dpiScalingFactor, font.Size);
            return new Font(font.FontFamily, ((font.SizeInPoints * ((dpiScalingFactor * 96f) / 72)) * dpiScalingFactor) * factor, font.Style, GraphicsUnit.Pixel);
        }
    }
}

using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Shotr.Core.Entities;

namespace Shotr.Core.Controls.DpiScaling
{
    public class DpiScaler
    {
        private static float _scalingFactor = -1f;

        public static bool NotDpiScaling(Control control)
        {
            var process = Process.GetCurrentProcess();
            var notScaling = process.ProcessName == "DesignToolsServer" || GetScalingFactor(control).Equals(1f);
            process.Dispose();

            return notScaling;
        }

        public static float GetScalingFactor(Control control)
        {
            Screen.FromControl(control).GetDpi(DpiType.Effective, out var dpiX, out var dpiY);
            if (_scalingFactor.Equals(-1f) || !_scalingFactor.Equals(dpiX / 96f))
            {
                _scalingFactor = (dpiX / 96f);
                Console.WriteLine("DPI Scaling Factor/DpiX: {0} ({1}).", _scalingFactor, dpiX);
            }

            return _scalingFactor;
        }

        public static (Size, Point) ScaleControl(Control control, Size size, Point location, bool scaleLocation = true)
        {
            if (control.Size.IsEmpty)
            {
                return (size, location);
            }

            var dpiScalingFactor = GetScalingFactor(control);
            if (NotDpiScaling(control))
            {
                return (size, location);
            }

            if (size.IsEmpty)
            {
                size = control is Form or TabPage or TabControl ? control.ClientSize : control.Size;
            }

            if (location.IsEmpty)
            {
                location = control.Location;
            }

            if (control is Form or TabPage or TabControl)
            {
                control.ClientSize = new Size((int)(size.Width * dpiScalingFactor), (int)(size.Height * dpiScalingFactor));
            }
            else
            {
                control.Size = new Size((int)(size.Width * dpiScalingFactor), (int)(size.Height * dpiScalingFactor));
            }

            if (scaleLocation)
            {
                control.Location = new Point((int)(location.X * dpiScalingFactor), (int)(location.Y * dpiScalingFactor));
            }

            return (size, location);
        }

        public static (Size, Point) ScaleSize(Control control, Size size, Point location)
        {
            var dpiScalingFactor = GetScalingFactor(control);
            if (NotDpiScaling(control))
            {
                return (size, location);
            }

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

            if (NotDpiScaling(control))
            {
                return (size, location);
            }

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

        public static Font ScaleFont(Font font, Control control)
        {
            var dpiScalingFactor = GetScalingFactor(control);

            if (NotDpiScaling(control))
            {
                return font;
            }

            var originalScalingFactor = dpiScalingFactor;

            if (dpiScalingFactor > 1f)
            {
                // only scale text if it's > 1x
                dpiScalingFactor = dpiScalingFactor - 0.25f;
            }

            float newSize = 0f;
            if (font.Unit == GraphicsUnit.Pixel)
            {
                newSize = font.Size * dpiScalingFactor;
            }
            else if (font.Unit == GraphicsUnit.Point)
            {
                newSize = (font.SizeInPoints * ((dpiScalingFactor * 96f) / 72) * dpiScalingFactor);
            }

            Console.WriteLine($"DPI Scaled Font: {control.GetType()} - Original Font Size: {font.Size} {font.Unit} => {newSize} Pixel (using scaleFactor = {dpiScalingFactor} [orig: {originalScalingFactor}])");
            
            return Theme.Theme.Font(newSize);
        }
    }
}

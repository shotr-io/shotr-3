using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework5.Drawing;
using Microsoft.Win32;

namespace Shotr.Core.Controls.DpiScaling
{
    public class DpiScaledPictureBox : PictureBox
    {
        public bool Scaled { get; set; } = true;

        private Size _nsize { get; set; }
        private Point _nlocation { get; set; }

        public DpiScaledPictureBox()
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                if (DpiScaler.NotDpiScaling(this))
                {
                    return;
                }

                EventHandler handler = (_, _) =>
                {
                    if (Scaled)
                    {
                        (_nsize, _nlocation) = DpiScaler.ScaleControl(this, _nsize, _nlocation);
                        Console.WriteLine("DPI Scaled PictureBox: {0} - {1}x{2} ({3}x{4})", Text, Size.Width, Size.Height, _nsize.Width, _nsize.Height);
                    }
                };

                VisibleChanged += handler;
                SystemEvents.DisplaySettingsChanged += handler;
            }
        }
    }
}

using System;
using System.ComponentModel;
using System.Drawing;
using MetroFramework5.Drawing;
using Microsoft.Win32;
using Shotr.Ui.Hotkey;

namespace Shotr.Ui.DpiScaling
{
    class DpiScaledHotkeyButton : HotkeyButton
    {
        private Size _nsize { get; set; }
        private Point _nlocation { get; set; }

        public DpiScaledHotkeyButton() : base()
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                if (DpiScaler.NotDpiScaling(this))
                {
                    return;
                }

                EventHandler handler = (sender, args) =>
                {
                    (_nsize, _nlocation) = DpiScaler.ScaleControl(this, _nsize, _nlocation);
                    Console.WriteLine("DPI Scaled Hotkey: {0} - {1}x{2} ({3}x{4})", Text, Size.Width, Size.Height, _nsize.Width, _nsize.Height);
                };

                VisibleChanged += handler;
                SystemEvents.DisplaySettingsChanged += handler;
            }
        }

        public override Font GetThemeFont(string category = null)
        {
            var font = ShouldSerializeFont() ? Font : GetThemeFont(MetroFontSize.Default, MetroFontWeight.Default, category);

            return DpiScaler.ScaleFont(font, this);
        }
    }
}

using System;
using System.ComponentModel;
using System.Drawing;
using MetroFramework5.Controls;
using MetroFramework5.Drawing;
using Microsoft.Win32;

namespace Shotr.Ui.DpiScaling
{
    public class DpiScaledButton : MetroButton
    {
        public bool Scaled { get; set; } = true;

		private Size _nsize { get; set; }
        private Point _nlocation { get; set; }

        public DpiScaledButton() : base()
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                if (DpiScaler.NotDpiScaling(this))
                {
                    return;
                }

                EventHandler handler = (sender, args) =>
                {
                    if (Scaled)
                    {
                        (_nsize, _nlocation) = DpiScaler.ScaleControl(this, _nsize, _nlocation);
                        Console.WriteLine("DPI Scaled Button: {0} - {1}x{2} ({3}x{4})", Text, Size.Width, Size.Height, _nsize.Width, _nsize.Height);
                    }
                };

                VisibleChanged += handler;
                SystemEvents.DisplaySettingsChanged += handler;
            }
        }

        private MetroFontSize _fontSize = MetroFontSize.Default;
        private MetroFontWeight _fontWeight = MetroFontWeight.Default;

        public MetroFontWeight FontWeight { get => _fontWeight; set => _fontWeight = value; }
        public MetroFontSize FontSize { get => _fontSize; set => _fontSize = value; }

        public override Font GetThemeFont(string category = null)
        {
            var font = ShouldSerializeFont() ? Font : GetThemeFont(FontSize, FontWeight, category);

            return DpiScaler.ScaleFont(font, this);
        }
    }
}

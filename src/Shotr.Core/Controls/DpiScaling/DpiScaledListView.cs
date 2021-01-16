using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Shotr.Core.Controls.DpiScaling
{
    public class DpiScaledListbox : ListView
    {
        private Size _nsize { get; set; }
        private Point _nlocation { get; set; }

        private Font _original { get; set; }

        public DpiScaledListbox()
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                if (DpiScaler.NotDpiScaling(this))
                {
                    return;
                }

                EventHandler handler = (sender, args) =>
                {
                    if (Size.Width == 256 && Size.Height == 256)
                    {
                        return;
                    }
                    (_nsize, _nlocation) = DpiScaler.ScaleControl(this, _nsize, _nlocation);

                    Console.WriteLine("DPI Scaled Listbox: {0} - {1}x{2} ({3}x{4})", Text, Size.Width, Size.Height, _nsize.Width, _nsize.Height);

                    _original = (_original ?? Font);
                    Font = DpiScaler.ScaleFont(_original, this, 0.5f);

                    var totalColumnWidth = Size.Width;
                    for (var i = 0; i < Columns.Count; i++)
                    {
                        float colPercentage = (Convert.ToInt32(totalColumnWidth / Columns.Count));
                        Columns[i].Width = (int) colPercentage;
                    }
                };

                VisibleChanged += handler;
                SystemEvents.DisplaySettingsChanged += handler;
            }
        }

        public void SetFont(Font font)
        {
            _original = font;
        }
    }
}

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework5.Controls;
using MetroFramework5.Drawing;
using Microsoft.Win32;

namespace Shotr.Core.DpiScaling
{
    public class DpiScaledTabControl : MetroTabControl
    {
        private Size _nsize { get; set; }
        private Point _nlocation { get; set; }
        private Size _itemSize { get; set; }
        public DpiScaledTabControl()
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
                    Console.WriteLine("DPI Scaled Tab Control: {0} - {1}x{2} ({3}x{4})", Text, Size.Width, Size.Height, _nsize.Width, _nsize.Height);
                    var dpiScalingFactor = DpiScaler.GetScalingFactor(this);
                    _itemSize = (_itemSize.IsEmpty ? ItemSize : _itemSize);
                    var size = new Size((int)(_itemSize.Width * dpiScalingFactor), _itemSize.Height + 7);
                    ItemSize = size;
                    SizeMode = TabSizeMode.Fixed;
                };

                VisibleChanged += handler;
                SystemEvents.DisplaySettingsChanged += handler;

                Font = GetThemeFont();
            }
        }
        
        public override Font GetThemeFont(string category = null)
        {
            var font = ShouldSerializeFont() ? Font : GetThemeFont(MetroFontSize.Default, MetroFontWeight.Default, category);
            return DpiScaler.ScaleFont(font, this, .66f);
        }

        public override void DrawTab(int index, Graphics graphics)
        {
            if (DpiScaler.NotDpiScaling(this))
            {
                base.DrawTab(index, graphics);
                return;
            }
            
            TabPage tabPage = TabPages[index];
            var tabRect = GetTabRect(index);

            if (index == 0)
            {
                tabRect.X = DisplayRectangle.X;
            }
            
            var tabTextSize = graphics.MeasureString(tabPage.Text, EffectiveFont);
            tabRect.Y = 0;
            tabRect.Height = (int)tabTextSize.Height;
            
            TextRenderer.DrawText(graphics, tabPage.Text, EffectiveFont, tabRect, EffectiveForeColor, EffectiveBackColor, AsTextFormatFlags(TextAlign) | TextFormatFlags.EndEllipsis);
        }
        
        internal static TextFormatFlags AsTextFormatFlags(ContentAlignment alignment)
        {
            switch (alignment)
            {
                case ContentAlignment.BottomLeft: return TextFormatFlags.Bottom | TextFormatFlags.Left;
                case ContentAlignment.BottomCenter: return TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter;
                case ContentAlignment.BottomRight: return TextFormatFlags.Bottom | TextFormatFlags.Right;
                case ContentAlignment.MiddleLeft: return TextFormatFlags.VerticalCenter | TextFormatFlags.Left;
                case ContentAlignment.MiddleCenter: return TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter;
                case ContentAlignment.MiddleRight: return TextFormatFlags.VerticalCenter | TextFormatFlags.Right;
                case ContentAlignment.TopLeft: return TextFormatFlags.Top | TextFormatFlags.Left;
                case ContentAlignment.TopCenter: return TextFormatFlags.Top | TextFormatFlags.HorizontalCenter;
                case ContentAlignment.TopRight: return TextFormatFlags.Top | TextFormatFlags.Right;
            }
            throw new InvalidEnumArgumentException();
        }
        
        public override void DrawTabSelected(int index, Graphics graphics)
        {
            if (DpiScaler.NotDpiScaling(this))
            {
                base.DrawTabSelected(index, graphics);
                return;
            }

            var dpiScalingFactor = DpiScaler.GetScalingFactor(this);

            using (Brush selectionBrush = new SolidBrush(GetStyleColor()))
            {
                var selectedTabRect = GetTabRect(index);
                var borderRectangle = new Rectangle(
                    selectedTabRect.X + (index == 0 ? 2 : 0),
                    GetTabRect(index).Bottom + 1 - TAB_BOTTOM_BORDER_HEIGHT, 
                    selectedTabRect.Width, 
                    (int)(TAB_BOTTOM_BORDER_HEIGHT * dpiScalingFactor));
                graphics.FillRectangle(selectionBrush, borderRectangle);
            }
        }

        public override void DrawTabBottomBorder(int index, Graphics graphics)
        {
            if (DpiScaler.NotDpiScaling(this))
            {
                base.DrawTabBottomBorder(index, graphics);
                return;
            }

            var dpiScalingFactor = DpiScaler.GetScalingFactor(this);
            
            using (Brush bgBrush = new SolidBrush( GetThemeColor("BorderColor")))
            {
                var borderRectangle = new Rectangle(
                    DisplayRectangle.X, 
                    GetTabRect(index).Bottom + 1 - TAB_BOTTOM_BORDER_HEIGHT, 
                    DisplayRectangle.Width, 
                    (int)(TAB_BOTTOM_BORDER_HEIGHT * dpiScalingFactor));

                graphics.FillRectangle(bgBrush, borderRectangle);
            }
        }
    }
}

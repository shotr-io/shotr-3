using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework5.Controls;
using MetroFramework5.Drawing;
using Microsoft.Win32;

namespace Shotr.Core.DpiScaling
{
    public class DpiScaledToggle : MetroToggle
    {
        private Size _nsize { get; set; }
        private Point _nlocation { get; set; }

        public DpiScaledToggle()
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
                    Console.WriteLine("DPI Scaled Toggle: {0} - {1}x{2} ({3}x{4})", Text, Size.Width, Size.Height, _nsize.Width, _nsize.Height);
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

        public override Size GetPreferredSize(Size proposedSize)
        {
            if (DpiScaler.NotDpiScaling(this))
            {
                return base.GetPreferredSize(proposedSize);
            }

            var scalingFactor = DpiScaler.GetScalingFactor(this);
            var preferredSize = base.GetPreferredSize(proposedSize);
            preferredSize.Width = (int)(scalingFactor * 80);
            //preferredSize.Height = scalingFactor * preferredSize.Height;
            return preferredSize;
        }

        protected override void OnPaintForeground(PaintEventArgs e)
        {
            if (DpiScaler.NotDpiScaling(this))
            {
                base.OnPaintForeground(e);
                return;
            }

            var dpiScalingFactor = DpiScaler.GetScalingFactor(this);
            using (Pen p = new Pen(GetThemeColor("BorderColor")))
            {
                var width = ClientRectangle.Width - (DisplayStatus ? (int)(dpiScalingFactor * 31) : 1);
                var boxRect = new Rectangle((DisplayStatus ? (int)(dpiScalingFactor * 30) : 0), 0, width, ClientRectangle.Height - 1);
                e.Graphics.DrawRectangle(p, boxRect);
            }

            var fillColor = Checked ? GetStyleColor() : GetThemeColor("CheckBox.BorderColor.Normal");
            using (SolidBrush b = new SolidBrush(fillColor))
            {
                var width = ClientRectangle.Width - (DisplayStatus ? (int)(dpiScalingFactor * 34) : 4);
                var boxRect = new Rectangle(DisplayStatus ? (int)(dpiScalingFactor * 32) : 2, 2, width, ClientRectangle.Height - 4);
                e.Graphics.FillRectangle(b, boxRect);
            }

            using (SolidBrush b = new SolidBrush(EffectiveBackColor)) // TODO: ????
            {
                var left = Checked ? Width - 11 : (DisplayStatus ? (int)(dpiScalingFactor * 30) : 0);
                var boxRect = new Rectangle(left, 0, 11, ClientRectangle.Height);
                e.Graphics.FillRectangle(b, boxRect);
            }

            using (SolidBrush b = new SolidBrush(GetThemeColor("CheckBox.BorderColor.Hover")))
            {
                var left = Checked ? Width - 10 : (DisplayStatus ? (int)(dpiScalingFactor * 30) : 0);
                var boxRect = new Rectangle(left, 0, 10, ClientRectangle.Height);
                e.Graphics.FillRectangle(b, boxRect);
            }

            if (DisplayStatus)
            {
                var textRect = new Rectangle(0, 0, (int)(dpiScalingFactor * 30), ClientRectangle.Height);
                TextRenderer.DrawText(e.Graphics, Text, EffectiveFont, textRect, EffectiveForeColor, AsTextFormatFlags(TextAlign) | TextFormatFlags.EndEllipsis);
            }
        }

        public override string Text
        {
            get { return (Checked ? "On" : "Off"); }
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
    }
}

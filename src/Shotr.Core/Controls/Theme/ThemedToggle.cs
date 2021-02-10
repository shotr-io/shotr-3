using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;

namespace Shotr.Core.Controls.Theme
{
    public class ThemedToggle : DpiScaledCheckBox
    {
        private readonly SolidBrush _backColorBrush = new SolidBrush(Theme.ToggleBackColor);
        private readonly SolidBrush _barColorBrush = new SolidBrush(Theme.ToggleBarColor);
        private readonly SolidBrush _onColorBrush = new SolidBrush(Theme.ToggleOnColor);
        private readonly SolidBrush _offColorBrush = new SolidBrush(Theme.ToggleOffColor);

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            e.Graphics.FillRectangle(_backColorBrush, 0, 0, Width, Height);

            if (Checked)
            {
                e.Graphics.FillRectangle(_onColorBrush, 9, 2, Width - 16, Height - 5);
                e.Graphics.FillEllipse(_onColorBrush, new Rectangle(3, 2, Height - 5, Height - 5));
                e.Graphics.FillEllipse(_barColorBrush, Width - 20, 0, 18, 18);
            }
            else
            {
                e.Graphics.FillRectangle(_offColorBrush, 3, 2, Width - 12, Height - 5);
                e.Graphics.FillEllipse(_offColorBrush, new Rectangle(Width - 16, 2, Height - 5, Height - 5));
                e.Graphics.FillEllipse(_barColorBrush, new Rectangle(0, 0, 18, 18));
            }
        }

        protected override void OnClick(EventArgs e)
        {
            Checked = !Checked;
        }
    }
}

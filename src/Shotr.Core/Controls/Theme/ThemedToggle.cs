using System;
using System.Drawing;
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
        private readonly Pen _borderColorPen = new Pen(Theme.ToggleBorderColor);
        private readonly Pen _borderHoverColorPen = new Pen(Theme.ToggleHoverColor);

        private bool _hover;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(_backColorBrush, 0, 0, Width, Height);

            if (Checked)
            {
                e.Graphics.FillRectangle(_onColorBrush, 3, 3, Width - 6, Height - 6);
                e.Graphics.FillRectangle(_barColorBrush, Width - 20, 0, 20, Height);
            }
            else
            {
                e.Graphics.FillRectangle(_offColorBrush, 3, 3, Width - 6, Height - 6);
                e.Graphics.FillRectangle(_barColorBrush, 0, 0, 20, Height);
            }

            e.Graphics.DrawRectangle(_hover ? _borderHoverColorPen : _borderColorPen, 0, 0, Width - 1, Height - 1);
        }

        protected override void OnClick(EventArgs e)
        {
            Checked = !Checked;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            _hover = true;
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            _hover = false;
            base.OnMouseLeave(e);
        }
    }
}

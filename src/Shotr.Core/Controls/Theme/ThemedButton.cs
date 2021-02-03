using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;

namespace Shotr.Core.Controls.Theme
{
    public class ThemedButton : DpiScaledButton
    {
        private Font _font => Theme.Font(Font, this);

        private readonly SolidBrush _backgroundBrush = new SolidBrush(Theme.ButtonBackColor);
        private readonly SolidBrush _disabledBrush = new SolidBrush(Theme.ButtonDisabledColor);
        private readonly Pen _borderPen = new Pen(Theme.ButtonBorderColor);
        private readonly Pen _borderHoverPen = new Pen(Theme.ButtonHoverColor);
        private readonly Pen _buttonClickPen = new Pen(Theme.ButtonClickColor);
        private readonly Pen _buttonHighlightPen = new Pen(Theme.ButtonHighlightColor);

        private bool _hovering;
        private bool _clicking;
        public bool Highlight { get; set; } = false;
        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            e.Graphics.FillRectangle(Enabled ? _backgroundBrush : _disabledBrush, 0, 0, Size.Width, Size.Height);

            var penToUse = _borderPen;

            if (Highlight)
            {
                penToUse = _buttonHighlightPen;
            }
            else if (_clicking)
            {
                penToUse = _buttonClickPen;
            }
            else if (_hovering)
            {
                penToUse = _borderHoverPen;
            }

            e.Graphics.DrawRectangle(penToUse, 0, 0, Size.Width - 1, Size.Height - 1);

            TextRenderer.DrawText(e.Graphics, Text, _font, new Rectangle(0, 0, Width, Height), Theme.ButtonForeColor, TextAlign.AsTextFormatFlags() | TextFormatFlags.EndEllipsis);
        }
        
        protected override void OnMouseEnter(EventArgs e)
        {
            _hovering = true;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _hovering = false;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            _clicking = true;
            base.OnMouseDown(mevent);
            Refresh();
        }
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            _clicking = false;
            base.OnMouseUp(mevent);
            Refresh();
        }
    }
}

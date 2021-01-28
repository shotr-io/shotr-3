using System.Drawing;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;

namespace Shotr.Core.Controls.Theme
{
    public class ThemedLinkLabel : DpiScaledLinkLabel
    {
        private Font _font => Theme.Font(Font, this);

        private readonly SolidBrush _backSolidBrush = new SolidBrush(Theme.LinkLabelBackColor);
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            e.Graphics.FillRectangle(_backSolidBrush, 0, 0, Width, Height);
            TextRenderer.DrawText(e.Graphics, Text, _font, new Rectangle(0, 0, Width, Height), Theme.LinkLabelForeColor, TextAlign.AsTextFormatFlags() | TextFormatFlags.EndEllipsis);
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            using (var g = CreateGraphics())
            {
                proposedSize = new Size(int.MaxValue, int.MaxValue);
                return TextRenderer.MeasureText(g, Text, _font, proposedSize, TextAlign.AsTextFormatFlags() | TextFormatFlags.EndEllipsis);
            }
        }
    }
}

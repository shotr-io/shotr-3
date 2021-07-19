using System.Drawing;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;

namespace Shotr.Core.Controls.Theme
{
    public class ThemedLabel : DpiScaledLabel
    {
        private Font _font => Theme.Font(Font, this);

        public ThemedLabel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            TextRenderer.DrawText(e.Graphics, Text, _font, new Rectangle(0, 0, Width, Height), Theme.LabelForeColor, TextAlign.AsTextFormatFlags() | TextFormatFlags.EndEllipsis);
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

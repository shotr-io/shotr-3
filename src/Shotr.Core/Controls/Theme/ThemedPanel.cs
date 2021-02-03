using System.Drawing;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;

namespace Shotr.Core.Controls.Theme
{
    public class ThemedPanel : DpiScaledPanel
    {
        public override Color BackColor => Theme.PanelBackColor;

        private readonly Pen _borderPen = new Pen(Theme.PanelBorderColor);

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Draw border
            e.Graphics.DrawRectangle(_borderPen, 0, 0, Width - 1, Height - 1);
        }
    }
}

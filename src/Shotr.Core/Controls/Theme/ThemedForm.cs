using System.Drawing;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;

namespace Shotr.Core.Controls.Theme
{
    public partial class ThemedForm : DpiScaledForm
    {
        private Pen _borderPen = new Pen(Theme.FormBorderColor);
        public override Color BackColor => Theme.FormBackColor;

        public override Font Font => Theme.Font(12);

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (FormBorderStyle == FormBorderStyle.None)
            {
                // Paint a nice border.
                e.Graphics.DrawRectangle(_borderPen, 0, 0, Width - 1, Height - 1);
            }
        }
    }
}

using System.Drawing;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;

namespace Shotr.Core.Controls.Theme
{
    public class ThemedBar : DpiScaledControl
    {
        private SolidBrush _backgroundBrush = new SolidBrush(Theme.BarBackColor);
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(_backgroundBrush, ClientRectangle);
        }
    }
}

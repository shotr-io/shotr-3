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

            // Respect backcolor if it's not 19, 19, 48
            if (BackColor.R == 19 && BackColor.G == 19 && BackColor.B == 48)
            {
                e.Graphics.FillRectangle(_backgroundBrush, ClientRectangle);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);
            }
        }
    }
}

using System.Drawing;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;

namespace Shotr.Core.Controls.Theme
{
    public class ThemedTabPage : DpiScaledTabPage
    {
        public override Color BackColor => Theme.TabPageBackColor;

        protected override void OnControlScaled(float scalingFactor)
        {
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}

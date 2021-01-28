using System.Drawing;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;

namespace Shotr.Core.Controls.Theme
{
    public partial class ThemedForm : DpiScaledForm
    {
        public override Color BackColor => Theme.FormBackColor;

        public override Font Font => Theme.Font(12);

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}

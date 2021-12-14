using Shotr.Core.Controls.DpiScaling;
using System;
using System.Windows.Forms;

namespace Shotr.Core.Controls.Theme
{
    public class ThemedListView : DpiScaledListView
    {
        private float? _originalFontSize;
        public ThemedListView()
        {
            DoubleBuffered = true;
        }

        public override bool BasePaint => true;

        protected override void OnControlScaled(float scalingFactor)
        {
            var totalColumnWidth = Width - 4;
            for (int i = 0; i < Columns.Count; i++)
            {
                float colPercentage = (Convert.ToInt32(totalColumnWidth / Columns.Count));
                Columns[i].Width = (int)colPercentage;
            }

            _originalFontSize ??= Font.Size;

            Font = DpiScaler.ScaleFont(Theme.Font(_originalFontSize.Value), this);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x00F)
            {
                using (var graphics = CreateGraphics())
                {
                    OnPaint(new PaintEventArgs(graphics, ClientRectangle));
                }
            }

            base.WndProc(ref m);
        }
    }
}

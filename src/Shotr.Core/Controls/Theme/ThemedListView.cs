using Shotr.Core.Controls.DpiScaling;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Shotr.Core.Controls.Theme
{
    public class ThemedListView : DpiScaledListView
    {
        private Font? _originalFont;
        private Font _font => Theme.Font(Font, this);
        private float _controlScaling = -1f;
        public ThemedListView()
        {
            DoubleBuffered = true;
        }

        public override bool BasePaint => true;

        protected override void OnControlScaled(float scalingFactor)
        {
            if (DpiScaler.NotDpiScaling(this))
            {
                return;
            }

            var totalColumnWidth = Width - 4 - 17;
            for (int i = 0; i < Columns.Count; i++)
            {
                float colPercentage = (Convert.ToInt32(totalColumnWidth / Columns.Count));
                Columns[i].Width = (int)colPercentage;
            }

            _controlScaling = scalingFactor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            _originalFont ??= Font;

            if (!DpiScaler.NotDpiScaling(this))
            {
                Font = DpiScaler.ScaleFont(Theme.Font(Math.Abs(_originalFont.Size - 9) < 0.000001 ? 12 : _originalFont.Size), this);
                var newScalingFactor = DpiScaler.GetScalingFactor(this);
                if (Math.Abs(newScalingFactor - _controlScaling) > 0.00001)
                {
                    OnControlScaled(newScalingFactor);
                }
            }
            
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

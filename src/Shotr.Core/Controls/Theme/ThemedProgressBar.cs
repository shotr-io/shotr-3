using System;
using System.Drawing;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;

namespace Shotr.Core.Controls.Theme
{
    public class ThemedProgressBar : DpiScaledControl
    {
        private int _value;
        public virtual int Value
        {
            get => _value;
            set
            {
                if (value > MaxValue)
                {
                    value = MaxValue;
                }

                _value = value;

                Refresh();
            }
        }

        public int MaxValue { get; set; } = 100;

        private Font _font => Theme.Font(Font, this);

        private readonly SolidBrush _backColorBrush = new SolidBrush(Theme.ProgressBarBackColor);
        private readonly SolidBrush _activeColorBrush = new SolidBrush(Theme.ProgressBarColor);
        private readonly Pen _borderPen = new Pen(Theme.ProgressBarBorderColor);

        public ThemedProgressBar()
        {
            base.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Draw background.
            e.Graphics.FillRectangle(_backColorBrush, 0, 0, Width, Height);
            e.Graphics.DrawRectangle(_borderPen, 0, 0, Width - 1, Height - 1);

            if (Value > 0)
            {
                var valueToDraw = Math.Round((decimal)Width / 100, 0) * Value;
                if (Value >= 100)
                {
                    valueToDraw = Width;
                }
                
                e.Graphics.FillRectangle(_activeColorBrush, 3, 3, (int)valueToDraw - 6, Height - 6);
            }

            TextRenderer.DrawText(e.Graphics, $"{Value}%", _font, new Rectangle(0, 0, Width, Height), Theme.ProgressBarForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }
    }
}

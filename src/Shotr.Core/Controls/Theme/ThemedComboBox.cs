using System.Drawing;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;

namespace Shotr.Core.Controls.Theme
{
    public class ThemedComboBox : DpiScaledComboBox
    {
        private Font _font => Theme.Font(Font, this);

        private readonly SolidBrush _backBrush = new SolidBrush(Theme.ComboBoxBackColor);
        private readonly SolidBrush _foreBrush = new SolidBrush(Theme.ComboBoxForeColor);
        private readonly SolidBrush _focusBrush = new SolidBrush(Theme.ComboBoxFocusedColor);
        private readonly Pen _borderPen = new Pen(Theme.ComboBoxBorderColor);

        public ThemedComboBox()
        {
            SetStyle(ControlStyles.UserPaint, true);

            DrawMode = DrawMode.OwnerDrawFixed;
            DoubleBuffered = true;
        }

        protected override void OnControlScaled(float scalingFactor)
        {
            ItemHeight = (int) (ItemHeight * scalingFactor);
            DropDownHeight = (int)(DropDownHeight * scalingFactor);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            e.Graphics.FillRectangle(_backBrush, 0, 0, Width, Height);
            e.Graphics.DrawRectangle(_borderPen, 0, 0, Width - 1, Height - 1);

            e.Graphics.FillPolygon(_foreBrush, new[]
            {
                new Point(Width - 20, (Height / 2) - 2),
                new Point(Width - 9, (Height / 2) - 2),
                new Point(Width - 15,  (Height / 2) + 4)
            });

            TextRenderer.DrawText(e.Graphics, Text, _font, new Rectangle(2, 2, Width - 20, Height - 4),
                Theme.ComboBoxForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                base.OnDrawItem(e);
                return;
            }

            var normal = e.State == (DrawItemState.NoAccelerator | DrawItemState.NoFocusRect) || e.State == DrawItemState.None;

            var backBrush = normal ? _backBrush : _focusBrush;
            var backColor = normal ? Theme.ComboBoxBackColor : Theme.ComboBoxFocusedColor;


            e.Graphics.FillRectangle(backBrush, e.Bounds);

            TextRenderer.DrawText(e.Graphics, GetItemText(Items[e.Index]), _font, e.Bounds, Theme.ComboBoxForeColor, backColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }
    }
}

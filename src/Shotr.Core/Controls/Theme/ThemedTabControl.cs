using System.Drawing;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;

namespace Shotr.Core.Controls.Theme
{
    public class ThemedTabControl : DpiScaledTabControl
    {
        private Font _font => Theme.Font(Font, this);
        private Size originalItemSize = new Size(96, 23);
        public const int TAB_BOTTOM_BORDER_HEIGHT = 3;

        public ThemedTabControl()
        {
            DrawMode = TabDrawMode.OwnerDrawFixed;
            SizeMode = TabSizeMode.Fixed;
            SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnControlScaled(float scalingFactor)
        {
            if (DpiScaler.NotDpiScaling(this))
            {
                return;
            }

            // measure font.
            var maxWidth = originalItemSize.Width;
            var maxHeight = originalItemSize.Height;
            foreach (TabPage t in TabPages)
            {
                var textMeasuredSize = TextRenderer.MeasureText(t.Text, _font);
                if (textMeasuredSize.Width > maxWidth)
                {
                    maxWidth = textMeasuredSize.Width;
                }

                if (textMeasuredSize.Height > maxHeight)
                {
                    maxHeight = textMeasuredSize.Height;
                }
            }

            ItemSize = new Size(maxWidth + 10, maxHeight + 2);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            if (TabPages.Count < SelectedIndex + 1)
            {
                SelectedIndex = 0;
            }

            if (TabPages.Count == 0 || !(TabPages[SelectedIndex] is ThemedTabPage))
            {
                e.Graphics.Clear(Theme.TabControlBackColor);
                return;
            }

            var tb = (ThemedTabPage)TabPages[SelectedIndex];
            if (tb.BackColor.A < 255 && tb.BackgroundImage == null)
            {
                e.Graphics.Clear(Theme.TabControlBackColor);
                return;
            }

            using (Brush bgBrush = new SolidBrush(Theme.TabControlBackColor))
            {
                var r = new Region(ClientRectangle);
                r.Exclude(DisplayRectangle);
                e.Graphics.FillRegion(bgBrush, r);
            }

            for (var index = 0; index < TabPages.Count; index++)
            {
                if (index == SelectedIndex) continue;

                DrawTab(TabPages[index], index, e.Graphics);
            }

            if (SelectedIndex <= -1) return;

            DrawTabBottomBorder(SelectedIndex, e.Graphics);
            DrawTab(tb, SelectedIndex, e.Graphics);
            DrawTabSelected(SelectedIndex, e.Graphics);

            base.OnPaint(e);
        }
        public virtual void DrawTabBottomBorder(int index, Graphics graphics)
        {
            using (Brush bgBrush = new SolidBrush(Theme.TabControlBorderColor))
            {
                var borderRectangle = new Rectangle(DisplayRectangle.X, GetTabRect(index).Bottom + 2 - TAB_BOTTOM_BORDER_HEIGHT,
                    DisplayRectangle.Width, TAB_BOTTOM_BORDER_HEIGHT);

                graphics.FillRectangle(bgBrush, borderRectangle);
            }
        }

        public virtual void DrawTabSelected(int index, Graphics graphics)
        {
            using (Brush selectionBrush = new SolidBrush(Theme.TabControlHighlightColor))
            {
                var selectedTabRect = GetTabRect(index);
                //Size textAreaRect = MeasureText(TabPages[index].Text);
                var borderRectangle = new Rectangle(
                    selectedTabRect.X + ((index == 0) ? 2 : 0),
                    selectedTabRect.Bottom + 2 - TAB_BOTTOM_BORDER_HEIGHT,
                    selectedTabRect.Width + ((index == 0) ? 0 : 2),
                    TAB_BOTTOM_BORDER_HEIGHT);
                graphics.FillRectangle(selectionBrush, borderRectangle);
            }
        }
        public virtual void DrawTab(TabPage tabPage, int index, Graphics graphics)
        {
            var tabRect = GetTabRect(index);

            if (index == 0)
            {
                tabRect.X = DisplayRectangle.X;
            }

            TextRenderer.DrawText(graphics, tabPage.Text, _font, tabRect, Theme.TabControlForeColor, Theme.TabControlBackColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        private new Rectangle GetTabRect(int index)
        {
            return index < 0 ? new Rectangle() : base.GetTabRect(index);
            var rect = index < 0 ? new Rectangle() : base.GetTabRect(index);
            var scalingFactor = DpiScaler.GetScalingFactor(this);
            rect.Width = (int)(rect.Width * scalingFactor);
            rect.Height = (int)(rect.Height * scalingFactor);

            rect.X = (int)(rect.X * scalingFactor);
            rect.Y = (int)(rect.Y * scalingFactor);

            return rect;
        }
    }
}

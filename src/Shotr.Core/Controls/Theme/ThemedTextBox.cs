using System;
using System.Drawing;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;

namespace Shotr.Core.Controls.Theme
{
    public class ThemedTextBox : DpiScaledControl
    {
        private readonly Pen _borderPen = new Pen(Theme.TextBoxBorderColor);

        public override Color BackColor => Theme.TextBoxBackColor;
        public override Color ForeColor => Theme.TextBoxForeColor;

        private DpiScaledTextBox _baseTextBox;

        public ThemedTextBox()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
            TabStop = false;

            CreateBaseTextBox();
        }

        public string TextBoxText => _baseTextBox.Text;

        protected override void OnControlScaled(float scalingFactor)
        {
            Font = Theme.Font(Font.Size * scalingFactor);
            _baseTextBox.Location = new Point((int)(_baseTextBox.Location.X * scalingFactor), (int)(_baseTextBox.Location.Y * scalingFactor));
            UpdateBaseTextBox();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            e.Graphics.DrawRectangle(_borderPen, 0, 0, Width - 1, Height - 1);
        }

        public bool ReadOnly
        {
            get => _baseTextBox.ReadOnly;
            set => _baseTextBox.ReadOnly = value;
        }

        public bool UseSystemPasswordChar
        {
            get => _baseTextBox.UseSystemPasswordChar;
            set => _baseTextBox.UseSystemPasswordChar = value;
        }
        
        public bool Multiline
        {
            get => _baseTextBox.Multiline;
            set => _baseTextBox.Multiline = value;
        }

        public ScrollBars ScrollBars
        {
            get => _baseTextBox.ScrollBars;
            set => _baseTextBox.ScrollBars = value;
        }

        public override void Refresh()
        {
            base.Refresh();
            UpdateBaseTextBox();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateBaseTextBox();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            _baseTextBox.Text = Text;
        }

        private void UpdateBaseTextBox()
        {
            _baseTextBox.Size = new Size(Width - 6, Height - 6);
            _baseTextBox.Font = Theme.Font(Font.Size);
            //_baseTextBox.Location = new Point(3, 3);
        }

        private void CreateBaseTextBox()
        {
            _baseTextBox = new DpiScaledTextBox
            {
                BorderStyle = BorderStyle.None,
                BackColor = Theme.TextBoxBackColor,
                ForeColor = Theme.TextBoxForeColor,
                Font = Theme.Font(Font.Size),
                Location = new Point(3, 3),
                Size = new Size(Width - 6, Height - 6),
                TabStop = true,
                Text = Text
            };

            Size = new Size(_baseTextBox.Width + 6, _baseTextBox.Height + 6);

            Controls.Add(_baseTextBox);
        }
    }
}

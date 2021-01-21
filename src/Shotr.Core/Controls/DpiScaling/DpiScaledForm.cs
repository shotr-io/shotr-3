using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using MetroFramework5.Drawing;
using MetroFramework5.Forms;

namespace Shotr.Core.Controls.DpiScaling
{
    public class DpiScaledForm : MetroForm
    {
        public virtual bool ScaleForm { get; set; } = true;

        private Size _nsize { get; set; }
        private Point _nlocation { get; set; }

        public DpiScaledForm()
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                if (DpiScaler.NotDpiScaling(this))
                {
                    return;
                }
            
                EventHandler handler = (sender, args) =>
                {
                    if (ScaleForm)
                    {
                        Console.WriteLine("DPI Scaled Form Size: {0} - {1}x{2} ({3}x{4})", Text, Size.Width, Size.Height, _nsize.Width, _nsize.Height);
                        Console.WriteLine("DPI Scaled Form Location: {0} - {1}x{2} ({3}x{4})", Text, Location.X, Location.Y, _nlocation.X, _nlocation.Y);
                        (_nsize, _nlocation) = DpiScaler.ScaleSize(this, _nsize, _nlocation);
                        // get location
                        Location = new Point(_nlocation.X - (int)(_nsize.Width / DpiScaler.GetScalingFactor(this)), 
                            _nlocation.Y - (int)(_nsize.Height / DpiScaler.GetScalingFactor(this)));
                    }
                };

                VisibleChanged += handler;
                DpiChangedAfterParent += handler;
            }
        }

        public void ManualDpiScale()
        {
            (_nsize, _nlocation) = DpiScaler.ScaleSize(this, _nsize, _nlocation);
        }
        
        public override Font GetThemeFont(string category = null)
        {
            if (DpiScaler.NotDpiScaling(this))
            {
                return base.GetThemeFont(category);
            }

            var font = ShouldSerializeFont() ? Font : GetThemeFont(MetroFontSize.Default, MetroFontWeight.Default, category);

            return DpiScaler.ScaleFont(font, this);
        }

        protected override void OnPaintForeground(PaintEventArgs e)
        {
            if (DpiScaler.NotDpiScaling(this))
            {
                base.OnPaintForeground(e);
                return;
            }

            var dpiScalingFactor = DpiScaler.GetScalingFactor(this);
            var BORDER_WIDTH = (int)(5 * dpiScalingFactor);
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            using (var b = new SolidBrush(GetStyleColor()))
                e.Graphics.FillRectangle(b, 0, 0, Width, BORDER_WIDTH);

            if (DisplayHeader)
            {
                // Assuming padding 20px on left/right; 20px from top; max 40px height
                try
                {
                    if (ShowIcon)
                        e.Graphics.DrawImage(Icon.ToBitmap(), new Rectangle((int)(dpiScalingFactor * 15), (int)(dpiScalingFactor * 22), (int)(dpiScalingFactor * 30), (int)(dpiScalingFactor * 30)));
                }
                catch { }
                var bounds = new Rectangle((ShowIcon ? (int)(dpiScalingFactor * (15+30)) : (int)(dpiScalingFactor * 20)), (int)(dpiScalingFactor * 20), (int)(dpiScalingFactor * ((ClientRectangle.Width - 2) * 20)), (int)(dpiScalingFactor * 40));
                
                TextRenderer.DrawText(e.Graphics, Text, GetThemeFont("Form.Title"), bounds, EffectiveForeColor, AsTextFormatFlags(TextAlign) | TextFormatFlags.EndEllipsis);
                
                //e.Graphics.DrawString(Text, GetThemeFont("Form.Title"), new SolidBrush(EffectiveForeColor), bounds);
            }

            var bs = BorderStyle;
            if (bs == MetroBorderStyle.Default && !TryGetThemeProperty("BorderStyle", out bs))
                bs = MetroBorderStyle.None;

            if (bs == MetroBorderStyle.FixedSingle)
            {
                using (var pen = new Pen(GetThemeColor("BorderColor"))) // TODO: Use style color for active window?
                {
                    e.Graphics.DrawLines(pen, new[]
                                {
                                    new Point(0, BORDER_WIDTH),
                                    new Point(0, Height - 1),
                                    new Point(Width - 1, Height - 1),
                                    new Point(Width - 1, BORDER_WIDTH)
                                });
                }
            }

            if (Resizable && (SizeGripStyle == SizeGripStyle.Auto || SizeGripStyle == SizeGripStyle.Show))
            {
                using (var b = new SolidBrush(GetThemeColor("Button.ForeColor.Disabled")) )
                {
                    var resizeHandleSize = new Size(2, 2);
                    e.Graphics.FillRectangles(b, new[] {
                        new Rectangle(new Point(ClientRectangle.Width-14,ClientRectangle.Height-6), resizeHandleSize),
                        new Rectangle(new Point(ClientRectangle.Width-10,ClientRectangle.Height-6), resizeHandleSize),
                        new Rectangle(new Point(ClientRectangle.Width-10,ClientRectangle.Height-10), resizeHandleSize),
                        new Rectangle(new Point(ClientRectangle.Width-6,ClientRectangle.Height-6), resizeHandleSize),
                        new Rectangle(new Point(ClientRectangle.Width-6,ClientRectangle.Height-10), resizeHandleSize),
                        new Rectangle(new Point(ClientRectangle.Width-6,ClientRectangle.Height-14), resizeHandleSize)
                    });
                }
            }
        }

        public override void UpdateWindowButtonPosition()
        {
            if (DpiScaler.NotDpiScaling(this))
            {
                base.UpdateWindowButtonPosition();
                return;
            }

            if (!ControlBox) return;

            var dpiScalingFactor = DpiScaler.GetScalingFactor(this);
            var BORDER_WIDTH = (int)(5 * dpiScalingFactor);

            var location = new Point((int)(ClientRectangle.Width - BORDER_WIDTH - 25 * dpiScalingFactor), BORDER_WIDTH);
            foreach (var metroFormButton in _windowButtons.Where(metroFormButton => metroFormButton != null))
            {
                metroFormButton.Location = location;
                location.Offset((int)(dpiScalingFactor * -25), 0);
            }
        }

        public override void AddWindowButton(WindowButtons button)
        {
            if (_windowButtons[(int)button] != null ) throw new InvalidOperationException();
            var dpiScalingFactor = DpiScaler.GetScalingFactor(this);
            
            var newButton = new MetroFormButton
            {
                Text = GetButtonText(button),
                Tag = button,
                Size = new Size((int)(dpiScalingFactor * 25), (int)(dpiScalingFactor * 20)),
                //Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(Size.Width - (int)(dpiScalingFactor * 25) * (_windowButtons.Select(p => p != null).Count()+1), Size.Height - (int)(dpiScalingFactor * 20)),
            };

            var notNull = _windowButtons.Where(p => p != null);
            var p = new Point(
                Size.Width - (int) (dpiScalingFactor * 25) * notNull.Count() + 1,
                Size.Height - (int) (dpiScalingFactor * 20));
            newButton.ForeColor = Theme switch
            {
                "NewTheme" => MetroColors.FontColor,
                "Dark"     => MetroColors.White,
                "Light"    => MetroColors.Black
            };
            
            newButton.Click += WindowButton_Click;
            Controls.Add(newButton);
            _windowButtons[(int)button] = newButton;
        }

        internal static TextFormatFlags AsTextFormatFlags(HorizontalAlignment alignment)
        {
            switch (alignment)
            {
                case HorizontalAlignment.Left: return TextFormatFlags.Left;
                case HorizontalAlignment.Center: return TextFormatFlags.HorizontalCenter;
                case HorizontalAlignment.Right: return TextFormatFlags.Right;
            }
            throw new InvalidEnumArgumentException();
        }
    }
}

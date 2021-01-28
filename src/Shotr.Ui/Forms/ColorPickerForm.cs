using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;
using Shotr.Core.Controls.Theme;
using Shotr.Core.Settings;
using Shotr.Core.Utils;

namespace Shotr.Ui.Forms
{
    public partial class ColorPickerForm : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var @params = base.CreateParams;
                @params.ExStyle |= 0x80;
                //Params.ExStyle |= 0x20;
                return @params;
            }
        }

        private Bitmap _screenshot;

        private Brush _brush = new SolidBrush(Color.White);
        private TextureBrush _textbrush;

        private Rectangle _x = Rectangle.Empty;
        private bool _drawing = true;

        private readonly BaseSettings _settings;
        public ColorPickerForm(BaseSettings settings, Bitmap bitmap)
        {
            _settings = settings;
            
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            InitializeComponent();
            var scalingFactor = DpiScaler.GetScalingFactor(this);
            Font = Theme.Font((int)(Font.Size * scalingFactor));

            AutoScaleMode = AutoScaleMode.None;
            StartPosition = FormStartPosition.Manual;
            
            _screenshot = bitmap;
            timer1.Interval = 10;
            timer1.Start();

            Paint += ScreenshotForm_Paint;
            FormBorderStyle = FormBorderStyle.None;

            var height = 0;
            var width = 0;
            var left = 0;
            var top = 0;
            foreach (var screen in Screen.AllScreens)
            {
                //take smallest height
                height = (screen.Bounds.Height >= height) ? screen.Bounds.Height : height;
                width += screen.Bounds.Width;
                left = (left >= screen.Bounds.X ? screen.Bounds.X : left);
                top = (top >= screen.Bounds.Y ? screen.Bounds.Y : top);
                if (screen.Bounds.Y + screen.Bounds.Height > height) height = screen.Bounds.Y + screen.Bounds.Height;
                if (top < 0 || screen.Bounds.Y >= height) height += screen.Bounds.Height;
            }
            Size = new Size(width, height);
            //get point of left-most monitor.
            Location = new Point(left, top);

            KeyUp += ScreenshotForm_KeyUp;
            KeyDown += ScreenshotForm_KeyDown;

            Cursor = Cursors.Cross;

            _screenshot = new Bitmap(_screenshot, width, height);

            using (var image = Utils.Apply(Utils.Contrast(0.7f), _screenshot))
            {
                var brush = new TextureBrush(image);
                brush.WrapMode = WrapMode.Clamp;
                _textbrush = brush;
            }

            DoubleBuffered = true;

            ShowInTaskbar = false;

            timer2.Interval = 1000;
            timer2.Start();

            MouseDown += ScreenshotForm_MouseDown;
        }

        void ScreenshotForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y - 1);
                        break;
                    case Keys.Down:
                        Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y + 1);
                        break;
                    case Keys.Left:
                        Cursor.Position = new Point(Cursor.Position.X - 1, Cursor.Position.Y);
                        break;
                    case Keys.Right:
                        Cursor.Position = new Point(Cursor.Position.X + 1, Cursor.Position.Y);
                        break;
                }
            }
        }

        void ScreenshotForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                CloseWindow();
            }
            else if (e.KeyCode == Keys.Z)
            {
                _settings.Capture.ShowZoom = !_settings.Capture.ShowZoom;
            }
            else if (e.KeyCode == Keys.I)
            {
                _settings.Capture.ShowInformation = !_settings.Capture.ShowInformation;
            }
            else if (e.KeyCode == Keys.C)
            {
                _settings.Capture.ShowColor = !_settings.Capture.ShowColor;
            }
        }    
        private void CloseWindow()
        {
            _screenshot.Dispose();
            Dispose();
            Close();
        }

        public static int Between(int num, int min, int max)
        {
            if (num <= min)
            {
                return min;
            }
            if (num >= max)
            {
                return max;
            }
            return num;
        }

        private Bitmap Magnifier(Image img, Point position, int horizontalPixelCount, int verticalPixelCount, int pixelSize)
        {
            horizontalPixelCount = Between(horizontalPixelCount | 1, 1, 0x65);
            verticalPixelCount = Between(verticalPixelCount | 1, 1, 0x65);
            pixelSize = Between(pixelSize, 1, 0x3e8);
            if (((horizontalPixelCount * pixelSize) > Width) || ((verticalPixelCount * pixelSize) > Height))
            {
                horizontalPixelCount = verticalPixelCount = 15;
                pixelSize = 10;
            }
            var width = horizontalPixelCount * pixelSize;
            var height = verticalPixelCount * pixelSize;
            var image = new Bitmap(width - 1, height - 1);
            using (var graphics = Graphics.FromImage(image))
            {
                graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                graphics.PixelOffsetMode = PixelOffsetMode.Half;
                graphics.DrawImage(img, new Rectangle(0, 0, width, height), new Rectangle(position.X - (horizontalPixelCount / 2), position.Y - (verticalPixelCount / 2), horizontalPixelCount, verticalPixelCount), GraphicsUnit.Pixel);
                graphics.PixelOffsetMode = PixelOffsetMode.None;
                using (var pen = new Pen(Color.FromArgb(0x4b, Color.Black)))
                {
                    for (var i = 1; i < horizontalPixelCount; i++)
                    {
                        graphics.DrawLine(pen, new Point((i * pixelSize) - 1, 0), new Point((i * pixelSize) - 1, height - 1));
                    }
                    for (var j = 1; j < verticalPixelCount; j++)
                    {
                        graphics.DrawLine(pen, new Point(0, (j * pixelSize) - 1), new Point(width - 1, (j * pixelSize) - 1));
                    }
                }
                graphics.DrawRectangle(Pens.Black, ((width - pixelSize) / 2) - 1, ((height - pixelSize) / 2) - 1, pixelSize, pixelSize);
                graphics.DrawRectangle(Pens.White, (width - pixelSize) / 2, (height - pixelSize) / 2, pixelSize - 2, pixelSize - 2);
            }
            return image;
        }
        void ScreenshotForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
            e.Graphics.CompositingMode = CompositingMode.SourceOver;
            if (_drawing)
            {
                e.Graphics.FillRectangle(_textbrush, new Rectangle(0, 0, Bounds.Width, Bounds.Height));
                if (_settings.Capture.ShowZoom)
                {
                    //check if screen isn't big enough to fit on right side, if so then fit on left side.
                    var location = new Point(0, 0);
                    var cursorloc = PointToClient(Cursor.Position);
                    using (var magnifier = (Magnifier(_screenshot, new Point(cursorloc.X, cursorloc.Y), 10, 10, 10)))
                    {
                        if ((_x.Width > 80 || _x.Height > Font.Height * 2) && (cursorloc.X - 1 < _x.X && cursorloc.Y - 1 < _x.Y || new Rectangle(new Point(_x.X, _x.Y), new Size(80, (Font.Height * 2))).IntersectsWith(new Rectangle(cursorloc, new Size(80, (Font.Height * 2))))))
                        {
                            //draw it below the text.
                            location = new Point(cursorloc.X + 5, cursorloc.Y + (Font.Height * 2) + 5);
                        }
                        else if (cursorloc.X + magnifier.Width + 5 > Width && cursorloc.Y - magnifier.Height - 5 < Bounds.Y)
                        {
                            //bottom left
                            location = new Point(cursorloc.X - magnifier.Width - 5, cursorloc.Y + 5);
                        }
                        else if (cursorloc.Y + magnifier.Width + 5 > Height && cursorloc.X - magnifier.Height - 5 < Bounds.X)
                        {
                            //top right
                            location = new Point(cursorloc.X + 5, cursorloc.Y - magnifier.Height - 5);
                        }
                        else if (cursorloc.X + magnifier.Width + 5 > Width || cursorloc.Y + magnifier.Height + 5 > Height)
                        {
                            //draw top left.
                            location = new Point(cursorloc.X - magnifier.Width - 5, cursorloc.Y - magnifier.Height - 5);
                        }
                        else
                        {
                            //bottom right
                            location = new Point(cursorloc.X + 5, cursorloc.Y + 5);
                        }
                        //draw magnifier.
                        e.Graphics.DrawImage(magnifier, location);
                        e.Graphics.DrawString(
                            $"{(_settings.Capture.ShowColor ? GetHexCode(_screenshot.GetPixel(PointToClient(Cursor.Position).X, PointToClient(Cursor.Position).Y)) : "")}", Font, _brush, location);
                    }
                }
            }
        }

        private string GetHexCode(Color color)
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}",
                color.R,
                color.G,
                color.B);
        }

        private void ScreenshotForm_Load(object sender, EventArgs e)
        {
            // force window to have focus
            var foreThread = GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero);
            var appThread = GetCurrentThreadId();
            const uint swShow = 5;
            if (foreThread != appThread)
            {
                AttachThreadInput(foreThread, appThread, true);
                BringWindowToTop(Handle);
                ShowWindow(Handle, swShow);
                AttachThreadInput(foreThread, appThread, false);
            }
            else
            {
                BringWindowToTop(Handle);
                ShowWindow(Handle, swShow);
            }
            Activate();
        }
       
        void ScreenshotForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //capture color.
                try
                {
                    Clipboard.SetText(GetHexCode(_screenshot.GetPixel(PointToClient(Cursor.Position).X, PointToClient(Cursor.Position).Y)));
                    CloseWindow();
                }
                catch { }
            }
            else if (e.Button == MouseButtons.Right)
            {
                //cancel this shit.
                CloseWindow();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void ScreenshotForm_Shown(object sender, EventArgs e)
        {
            if (!Visible)
            {
                Show();
            }
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            BringToFront();
            Activate();
        }

        // When you don't want the ProcessId, use this overload and pass IntPtr.Zero for the second parameter
        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr processId);

        [DllImport("kernel32.dll")]
        static extern uint GetCurrentThreadId();

        /// <summary>The GetForegroundWindow function returns a handle to the foreground window.</summary>
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool BringWindowToTop(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
    }
}

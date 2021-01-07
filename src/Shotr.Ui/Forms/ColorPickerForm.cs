using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Shotr.Ui.Forms
{
    public partial class ColorPickerForm : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var Params = base.CreateParams;
                Params.ExStyle |= 0x80;
                //Params.ExStyle |= 0x20;
                return Params;
            }
        }

        private Bitmap screenshot;

        private Pen pen = new Pen(Color.White, 1) { DashPattern = new float[] { 6.0F, 4.0F } };

        private Pen pen1 = new Pen(Color.White, 1);
        private Pen blackpen = new Pen(Color.Black, 1);
        private Brush brush = new SolidBrush(Color.White);
        private SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 0));
        private TextureBrush textbrush;

        private Rectangle x = Rectangle.Empty;

        private Font kfont = new Font(DefaultFont, FontStyle.Bold);
        private Font metroF;
        private bool drawing = true;

        private bool information = (Program.Settings.GetValue("region_capture_information") != null ? (bool)Program.Settings.GetValue("region_capture_information")[0] : true);
        private bool zoom = (Program.Settings.GetValue("region_capture_zoom") != null ? (bool)Program.Settings.GetValue("region_capture_zoom")[0] : true);
        private bool color = (Program.Settings.GetValue("region_capture_color") != null ? (bool)Program.Settings.GetValue("region_capture_color")[0] : true);
        public ColorPickerForm(Bitmap yolo, Font metroFont)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            
            InitializeComponent();

            
            AutoScaleMode = AutoScaleMode.None;

            StartPosition = FormStartPosition.Manual;
            //this.TopMost = true;

            metroF = metroFont;

            timer1.Interval = 10;
            timer1.Start();

            Paint += ScreenshotForm_Paint;
            FormBorderStyle = FormBorderStyle.None;

            int height = 0;
            int width = 0;
            int left = 0;
            int top = 0;
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

            screenshot = yolo;
            screenshot = new Bitmap(screenshot, width, height);

            using (System.Drawing.Image image = Utils.Utils.Apply(Utils.Utils.Contrast(0.7f), screenshot))
            {
                TextureBrush brush = new TextureBrush(image);
                brush.WrapMode = WrapMode.Clamp;
                textbrush = brush;
            }
          
            DoubleBuffered = true;
            ShowInTaskbar = false;
            timer2.Interval = 1000;
            timer2.Start();
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
                //disable the zoom feature.
                zoom = !zoom;
                Program.Settings.ChangeKey("region_capture_zoom", new object[] { zoom });
            }
            else if (e.KeyCode == Keys.I)
            {
                //disable information.
                information = !information;
                Program.Settings.ChangeKey("region_capture_information", new object[] { information });
            }
            else if (e.KeyCode == Keys.C)
            {
                color = !color;
                Program.Settings.ChangeKey("region_capture_color", new object[] { color });
            }
        }    
        private void CloseWindow()
        {
            screenshot.Dispose();
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

        private Bitmap Magnifier(System.Drawing.Image img, Point position, int horizontalPixelCount, int verticalPixelCount, int pixelSize)
        {
            horizontalPixelCount = Between(horizontalPixelCount | 1, 1, 0x65);
            verticalPixelCount = Between(verticalPixelCount | 1, 1, 0x65);
            pixelSize = Between(pixelSize, 1, 0x3e8);
            if (((horizontalPixelCount * pixelSize) > Width) || ((verticalPixelCount * pixelSize) > Height))
            {
                horizontalPixelCount = verticalPixelCount = 15;
                pixelSize = 10;
            }
            int width = horizontalPixelCount * pixelSize;
            int height = verticalPixelCount * pixelSize;
            Bitmap image = new Bitmap(width - 1, height - 1);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                graphics.PixelOffsetMode = PixelOffsetMode.Half;
                graphics.DrawImage(img, new Rectangle(0, 0, width, height), new Rectangle(position.X - (horizontalPixelCount / 2), position.Y - (verticalPixelCount / 2), horizontalPixelCount, verticalPixelCount), GraphicsUnit.Pixel);
                graphics.PixelOffsetMode = PixelOffsetMode.None;
                using (Pen pen = new Pen(Color.FromArgb(0x4b, Color.Black)))
                {
                    for (int i = 1; i < horizontalPixelCount; i++)
                    {
                        graphics.DrawLine(pen, new Point((i * pixelSize) - 1, 0), new Point((i * pixelSize) - 1, height - 1));
                    }
                    for (int j = 1; j < verticalPixelCount; j++)
                    {
                        graphics.DrawLine(pen, new Point(0, (j * pixelSize) - 1), new Point(width - 1, (j * pixelSize) - 1));
                    }
                }
                graphics.DrawRectangle(Pens.Black, ((width - pixelSize) / 2) - 1, ((height - pixelSize) / 2) - 1, pixelSize, pixelSize);
                graphics.DrawRectangle(Pens.White, (int)((width - pixelSize) / 2), (int)((height - pixelSize) / 2), (int)(pixelSize - 2), (int)(pixelSize - 2));
            }
            return image;
        }
        void ScreenshotForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
            e.Graphics.CompositingMode = CompositingMode.SourceOver;
            if (drawing)
            {
                e.Graphics.FillRectangle(textbrush, new Rectangle(0, 0, Bounds.Width, Bounds.Height));
                if (zoom)
                {
                    //PIXEL MASTER SHIT.
                    //check if screen isn't big enough to fit on right side, if so then fit on left side.
                    Point location = new Point(0, 0);
                    Point cursorloc = PointToClient(Cursor.Position);
                    using (Bitmap magnifier = (Magnifier(screenshot, new Point(cursorloc.X, cursorloc.Y), 10, 10, 10)))
                    {
                        if ((x.Width > 80 || x.Height > kfont.Height * 2) && (cursorloc.X - 1 < x.X && cursorloc.Y - 1 < x.Y || new Rectangle(new Point(x.X, x.Y), new Size(80, (kfont.Height * 2))).IntersectsWith(new Rectangle(cursorloc, new Size(80, (kfont.Height * 2))))))
                        {
                            //draw it below the text.
                            location = new Point(cursorloc.X + 5, cursorloc.Y + (kfont.Height * 2) + 5);
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
                        e.Graphics.DrawString(string.Format("{0}", (color ? GetHexCode(screenshot.GetPixel(PointToClient(Cursor.Position).X, PointToClient(Cursor.Position).Y)) : "")), kfont, brush, location);
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
            MouseDown += ScreenshotForm_MouseDown;
            MouseUp += ScreenshotForm_MouseUp;
            // force window to have focus
            uint foreThread = GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero);
            uint appThread = GetCurrentThreadId();
            const uint SW_SHOW = 5;
            if (foreThread != appThread)
            {
                AttachThreadInput(foreThread, appThread, true);
                BringWindowToTop(Handle);
                ShowWindow(Handle, SW_SHOW);
                AttachThreadInput(foreThread, appThread, false);
            }
            else
            {
                BringWindowToTop(Handle);
                ShowWindow(Handle, SW_SHOW);
            }
            Activate();
        }
       
        void ScreenshotForm_MouseUp(object sender, MouseEventArgs e)
        {
        }

        void ScreenshotForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //capture color.
                try
                {
                    Clipboard.SetText(GetHexCode(screenshot.GetPixel(PointToClient(Cursor.Position).X, PointToClient(Cursor.Position).Y)));
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
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        // When you don't want the ProcessId, use this overload and pass IntPtr.Zero for the second parameter
        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

        [DllImport("kernel32.dll")]
        static extern uint GetCurrentThreadId();

        /// <summary>The GetForegroundWindow function returns a handle to the foreground window.</summary>
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool BringWindowToTop(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool BringWindowToTop(HandleRef hWnd);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
    }
}

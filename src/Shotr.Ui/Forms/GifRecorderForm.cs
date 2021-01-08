using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using MetroFramework5.Controls;
using Shotr.Core.Capture;
using Shotr.Core.Hotkey;
using Shotr.Core.Uploader;
using Shotr.Core.Utils;
using ShotrUploaderPlugin;

namespace Shotr.Ui.Forms
{
    public partial class GifRecorderForm : Form
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

        private Point orig;
        private Pen pen = new Pen(Color.White, 1) { DashPattern = new[] { 6.0F, 4.0F } };

        private Pen pen1 = new Pen(Color.White, 1);
        private Pen blackpen = new Pen(Color.Black, 1);
        private Brush brush = new SolidBrush(Color.White);
        private SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 0));
        private TextureBrush textbrush;

        private Rectangle x = Rectangle.Empty;

        private Font kfont = new Font(DefaultFont, FontStyle.Bold);
        private Font metroF;
        private bool activated;
        private bool drawing = true;

        private bool information = (Core.Utils.Settings.Instance.GetValue("region_capture_information") == null || (bool)Core.Utils.Settings.Instance.GetValue("region_capture_information")[0]);
        private bool zoom = (Core.Utils.Settings.Instance.GetValue("region_capture_zoom") == null || (bool)Core.Utils.Settings.Instance.GetValue("region_capture_zoom")[0]);
        private bool color = (Core.Utils.Settings.Instance.GetValue("region_capture_color") == null || (bool)Core.Utils.Settings.Instance.GetValue("region_capture_color")[0]);

        private bool showrecording;

        private SingleInstance Tasks;
        
        public Stopwatch stopwatch = Stopwatch.StartNew();

        public GifRecorderForm(Bitmap yolo, Font metroFont, SingleInstance tasks)
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

            using (Image image = Utils.Apply(Utils.Contrast(0.7f), screenshot))
            {
                TextureBrush brush = new TextureBrush(image);
                brush.WrapMode = WrapMode.Clamp;
                textbrush = brush;
            }
          
            DoubleBuffered = true;
            ShowInTaskbar = false;
            timer2.Interval = 1000;
            timer2.Start();

            Tasks = tasks;
            foreach (Process p in Process.GetProcessesByName("ffmpeg"))
            {
                try
                {
                    p.Kill();
                }
                catch { }
            }
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
                Core.Utils.Settings.Instance.ChangeKey("region_capture_zoom", new object[] { zoom });
            }
            else if (e.KeyCode == Keys.I)
            {
                //disable information.
                information = !information;
                Core.Utils.Settings.Instance.ChangeKey("region_capture_information", new object[] { information });
            }
            else if (e.KeyCode == Keys.C)
            {
                color = !color;
                Core.Utils.Settings.Instance.ChangeKey("region_capture_color", new object[] { color });
            }
        }    
        private void CloseWindow()
        {
            Tasks.Reset();
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
            int width = horizontalPixelCount * pixelSize;
            int height = verticalPixelCount * pixelSize;
            Bitmap image = new Bitmap(width - 1, height - 1);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                graphics.PixelOffsetMode = PixelOffsetMode.Half;
                graphics.DrawImage(img, new Rectangle(0, 0, width, height), new Rectangle(position.X - (horizontalPixelCount / 2), position.Y - (verticalPixelCount / 2), horizontalPixelCount, verticalPixelCount), GraphicsUnit.Pixel);
                graphics.PixelOffsetMode = PixelOffsetMode.None;
                /*using (SolidBrush brush = new SolidBrush(Color.FromArgb(0x7d, Color.LightBlue)))
                {
                    graphics.FillRectangle(brush, new Rectangle(0, (height - pixelSize) / 2, (width - pixelSize) / 2, pixelSize));
                    graphics.FillRectangle(brush, new Rectangle((width + pixelSize) / 2, (height - pixelSize) / 2, (width - pixelSize) / 2, pixelSize));
                    graphics.FillRectangle(brush, new Rectangle((width - pixelSize) / 2, 0, pixelSize, (height - pixelSize) / 2));
                    graphics.FillRectangle(brush, new Rectangle((width - pixelSize) / 2, (height + pixelSize) / 2, pixelSize, (height - pixelSize) / 2));
                }*/
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
                graphics.DrawRectangle(Pens.White, (width - pixelSize) / 2, (height - pixelSize) / 2, pixelSize - 2, pixelSize - 2);
            }
            return image;
        }
        void ScreenshotForm_Paint(object sender, PaintEventArgs e)
        {
            //fade the image.
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
            e.Graphics.CompositingMode = CompositingMode.SourceOver;

            //e.Graphics.DrawImage(screenshot, this.ClientRectangle,
        //new Rectangle(0, 0, screenshot.Width, screenshot.Height),
        //GraphicsUnit.Pixel);
            if (drawing)
            {
                e.Graphics.FillRectangle(textbrush, new Rectangle(0, 0, Bounds.Width, Bounds.Height));//this.Bounds);

                if (activated && x.Height > 1 && x.Width > 1)
                {
                    try
                    {
                        e.Graphics.DrawImage(screenshot, x, x, GraphicsUnit.Pixel);

                        pen.DashOffset = ((int)(stopwatch.Elapsed.TotalMilliseconds / 100.0)) % 10;
                        e.Graphics.DrawRectangle(pen, x);
                        if ((x.Width > 80 || x.Height > kfont.Height * 2) && information)
                        {
                            e.Graphics.DrawString(string.Format("X: {0} / Y: {1}{2}", x.X, x.Y, (color ? " - " + GetHexCode(screenshot.GetPixel(PointToClient(Cursor.Position).X, PointToClient(Cursor.Position).Y)) : "")), kfont, brush, new PointF(x.X, x.Y));
                            e.Graphics.DrawString(string.Format("W: {0} / H: {1}", x.Width, x.Height), kfont, brush, new PointF(x.X, x.Y + kfont.Height));
                        }
                    }
                    catch { }
                }
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
                    }
                }
            }
            else if(IsRecording)
            {
                //transparent yo.
                pen.DashOffset = ((int)(stopwatch.Elapsed.TotalMilliseconds / 100.0)) % 10;
                e.Graphics.DrawRectangle(pen, 0, 0, x.Width - 1, Height - 29);
                //draw circle below stuffs.
                if (showrecording)
                {
                    e.Graphics.FillEllipse(Brushes.Red, Width - 25, Height - 28, 25, 25);
                    e.Graphics.DrawEllipse(Pens.Black, Width - 25, Height - 28, 25, 25);
                }
                //show timer.            
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 32, 33, 37)), 0, Height - 28, 55, 20);
                e.Graphics.DrawRectangle(Pens.Black, 0, Height - 28, 55, 20);
                e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                e.Graphics.DrawString(string.Format("00:{0:#00}:{1:#00}", stopwatch.Elapsed.Minutes, stopwatch.Elapsed.Seconds), metroF, Brushes.White, 0, Height - 28);
            }
        }

        private string GetHexCode(Color color)
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2} / RGB: {4},{5},{6}",
                color.A,
                color.R,
                color.G,
                color.B,
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
        public FFmpegHelper fmp;
        public bool Cancel;
        void ScreenshotForm_MouseUp(object sender, MouseEventArgs e)
        {
            //resize form, set lime to transparent, and yolo swag.
            if (activated)
            {
                if (x.Width < 50 || x.Height < 50) { return; }
                Point newpoint = PointToScreen(new Point(x.X, x.Y));
                x = new Rectangle(newpoint, new Size(x.Width, x.Height));
                activated = false;
                TransparencyKey = Color.LimeGreen;
                //make a minimum size required.
                Size = new Size((x.Width < 216 ? 216 : x.Width), x.Height + 30);
                Location = new Point(x.X, x.Y);
                Panel f = new Panel();
                f.Size = new Size(x.Width - 2, x.Height);
                f.Location = new Point(1, 1);
                f.BackColor = Color.LimeGreen;
                Controls.Add(f);
                //add a stop button.
                //TODO: check to make sure that the shit isn't offscreen, if so then like idk
                MetroButton m = new MetroButton();
                m.Text = "Stop";
                m.Size = new Size(75, 23);
                m.Location = new Point(60, Height - 28);
                m.Click += m_Click;
                m.Theme = "Dark";
                m.Style = "Blue";
                Controls.Add(m);

                MetroButton mb = new MetroButton();
                mb.Text = "Cancel";
                mb.Size = new Size(75, 23);
                mb.Location = new Point(140, Height - 28);
                mb.Click += mb_Click;
                mb.Theme = "Dark";
                mb.Style = "Blue";
                Controls.Add(mb);

                TopMost = true;
                BackColor = Color.LimeGreen;
                Cursor = Cursors.Default;
                //start video recording?

                stopwatch.Restart();
                drawing = false;
                IsRecording = true;

                //new Thread(delegate() { this.CaptureScreen(); }).Start();
                ScreencastOptions sc = new ScreencastOptions();
                sc.ScreenRecordFPS = (int)Core.Utils.Settings.Instance.GetValue("settings.screen_recording")[0];
                sc.Threads = (int)Core.Utils.Settings.Instance.GetValue("settings.screen_recording")[1];
                //sc.Duration = 15;
                int roundedX = ((x.X + 1) % 2 != 0 ? x.X + 2 : x.X + 1);
                int roundedY = ((x.Y + 1) % 2 != 0 ? x.Y + 2 : x.Y + 1);
                int roundedWidth = ((x.Width - 3) % 2 != 0 ? x.Width - 4 : x.Width - 3);
                int roundedHeight = ((x.Height - 1) % 2 != 0 ? x.Height - 2 : x.Height - 1);
                Rectangle w = new Rectangle(roundedX, roundedY, roundedWidth, roundedHeight);
                sc.CaptureArea = w;
                sc.OutputPath = Path.Combine(Core.Utils.Settings.FolderPath, "Cache\\" + Utils.GetRandomString(10) + ".mp4");
                sc.DrawCursor = (bool)Core.Utils.Settings.Instance.GetValue("settings.screen_recording")[2];
                fmp = new FFmpegHelper(sc);
                fmp.Options.FFmpeg.CLIPath = Path.Combine(Core.Utils.Settings.FolderPath, "ffmpeg.exe");
                if ((bool)Core.Utils.Settings.Instance.GetValue("settings.screen_recording")[3])
                {
                    //Fixes audio source if it doesn't exist.
                    DirectShowDevices devices = fmp.GetDirectShowDevices();
                    if (devices.AudioDevices.Contains((string)Core.Utils.Settings.Instance.GetValue("settings.screen_recording")[4].ToString()))
                    {
                        fmp.Options.FFmpeg.AudioSource = (string)Core.Utils.Settings.Instance.GetValue("settings.screen_recording")[4].ToString();
                        fmp.Options.FFmpeg.AudioCodec = FFmpegAudioCodec.libvorbis;
                    }
                }
                fmp.ErrorDataReceived += fmp_ErrorDataReceived;
                fmp.OutputDataReceived += fmp_OutputDataReceived;
                new Thread(delegate()
                {
                    fmp.Record();
                    if (!Cancel)
                    {
                        Tasks.Reset();
                        //check filesize.
                        FileInfo fz = new FileInfo(sc.OutputPath);
                        if (fz.Length >= (99 * (1024 * 1024)))
                        {
                            //let user know that the file is bigger than 100MB.
                            Invoke((MethodInvoker)(() =>
                            {
                                MessageBox.Show("Your recording is over the 100MB limit for Shotr uploads. You'll need to save your recording locally instead.");
                                SaveFileDialog xz = new SaveFileDialog
                                {
                                    Filter = "MPEG4 | *.mp4",
                                    FileName = "*.mp4"
                                };
                                if (xz.ShowDialog() == DialogResult.OK)
                                {
                                    //save file.
                                    File.Copy(sc.OutputPath, xz.FileName);
                                }
                            }));
                        }
                        else
                        {
                            MusicPlayer.PlayCaptured();
                            //process exits here.

                            //TODO: buffer file input into uploader, cause like idk huge file sizes.
                            Uploader.AddToQueue(new ImageShell(File.ReadAllBytes(sc.OutputPath), FileExtensions.mp4));
                        }
                    }
                    //lel die ked
                    try
                    {
                        File.Delete(sc.OutputPath);
                    }
                    catch
                    {
                    }
                    stopwatch.Stop();
                    timer1.Stop();
                    try
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            Close();
                            Dispose();
                        }));
                    }
                    catch { }
                }).Start();
            }
        }

        void mb_Click(object sender, EventArgs e)
        {
            Cancel = true;
            stopwatch.Stop();
            fmp.Close();
            CloseWindow();
        }

        void m_Click(object sender, EventArgs e)
        {
            //stop recording.
            stopwatch.Stop();
            fmp.Close();
        }
        private bool IsRecording;
        void fmp_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }

        void fmp_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }

        void ScreenshotForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (!activated)
                    {
                        activated = true;
                        orig = e.Location;
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    //cancel this shit.
                    CloseWindow();
                }
            }
        }

        public static Rectangle CreateRectangle(int x, int y, int x2, int y2)
        {
            int num;
            int num2;
            if (x <= x2)
            {
                num = (x2 - x) + 1;
            }
            else
            {
                num = (x - x2) + 1;
                x = x2;
            }
            if (y <= y2)
            {
                num2 = (y2 - y) + 1;
            }
            else
            {
                num2 = (y - y2) + 1;
                y = y2;
            }
            return new Rectangle(x, y, num, num2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (activated)
            {
                Point mouselocation = PointToClient(Cursor.Position);
                x = CreateRectangle(orig.X, orig.Y, mouselocation.X, mouselocation.Y);
            }
            //TODO: do we really need a 10 minute limit?
            /*if (this.stopwatch.ElapsedMilliseconds >= (600 * 1000))
            {
                //10 min limit b0ss
                this.stopwatch.Stop();
                fmp.Close();
                this.timer1.Stop();
            }*/
            Refresh();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            showrecording = !showrecording;
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

        private void GifRecorderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (fmp != null)
                    fmp.Close();
            }
            catch { }
        }
    }
}

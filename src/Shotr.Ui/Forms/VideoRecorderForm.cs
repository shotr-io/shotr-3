using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;
using Shotr.Core.Controls.Theme;
using Shotr.Core.Entities.Hotkeys;
using Shotr.Core.Services;
using Shotr.Core.Settings;
using Shotr.Core.Uploader;
using Shotr.Core.Utils;
using ShotrUploaderPlugin;

namespace Shotr.Ui.Forms
{
    public partial class VideoRecorderForm : Form
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

        private Point _orig;
        private Pen _pen = new Pen(Color.White, 1) { DashPattern = new[] { 6.0F, 4.0F } };

        private Brush _brush = new SolidBrush(Color.White);
        private TextureBrush _textbrush;

        private Rectangle _x = Rectangle.Empty;

        private Font _metroF;
        private bool _activated;
        private bool _drawing = true;
        private bool _showrecording;

        private SingleInstance _tasks;
        
        public Stopwatch Stopwatch = Stopwatch.StartNew();

        private readonly BaseSettings _settings;
        private readonly MusicPlayerService _musicPlayerService;
        private readonly Uploader _uploader;

        public VideoRecorderForm(BaseSettings settings, MusicPlayerService musicPlayerService, Uploader uploader, Bitmap bitmap, Font metroFont, SingleInstance tasks)
        {
            _settings = settings;
            _musicPlayerService = musicPlayerService;
            _uploader = uploader;

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            
            InitializeComponent();

            var scalingFactor = DpiScaler.GetScalingFactor(this);
            Font = Theme.Font((int)(Font.Size * scalingFactor));

            AutoScaleMode = AutoScaleMode.None;
            StartPosition = FormStartPosition.Manual;
            TopMost = true;
            ShowInTaskbar = false;

            _screenshot = bitmap;
            _metroF = metroFont;
            _tasks = tasks;

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
            //ShowInTaskbar = false;
            timer2.Interval = 1000;
            timer2.Start();

            foreach (var p in Process.GetProcessesByName("ffmpeg"))
            {
                try
                {
                    p.Kill();
                }
                catch { }
            }
            MouseDown += ScreenshotForm_MouseDown;
            MouseUp += ScreenshotForm_MouseUp;
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
            _tasks.Reset();
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
            var scalingFactor = DpiScaler.GetScalingFactor(this);
            pixelSize = (int)(pixelSize * scalingFactor);
            var width = horizontalPixelCount * pixelSize;
            var height = verticalPixelCount * pixelSize;
            var image = new Bitmap(width - 1, height - 1);
            using (var graphics = Graphics.FromImage(image))
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
            //fade the image.
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
            e.Graphics.CompositingMode = CompositingMode.SourceOver;

            //e.Graphics.DrawImage(screenshot, this.ClientRectangle,
        //new Rectangle(0, 0, screenshot.Width, screenshot.Height),
        //GraphicsUnit.Pixel);
            if (_drawing)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(-1, -1, Bounds.Width + 1, Bounds.Height + 1));
                e.Graphics.FillRectangle(_textbrush, new Rectangle(0, 0, Bounds.Width, Bounds.Height));//this.Bounds);

                if (_activated && _x.Height > 1 && _x.Width > 1)
                {
                    try
                    {
                        e.Graphics.DrawImage(_screenshot, _x, _x, GraphicsUnit.Pixel);

                        _pen.DashOffset = ((int)(Stopwatch.Elapsed.TotalMilliseconds / 100.0)) % 10;
                        e.Graphics.DrawRectangle(_pen, _x);
                        if ((_x.Width > 80 || _x.Height > Font.Height * 2) && _settings.Capture.ShowInformation)
                        {
                            e.Graphics.DrawString(string.Format("X: {0} / Y: {1}{2}", _x.X, _x.Y, _settings.Capture.ShowColor ? " - " + GetHexCode(_screenshot.GetPixel(PointToClient(Cursor.Position).X, PointToClient(Cursor.Position).Y)) : ""), Font, _brush, new PointF(_x.X, _x.Y));
                            e.Graphics.DrawString(string.Format("W: {0} / H: {1}", _x.Width, _x.Height), Font, _brush, new PointF(_x.X, _x.Y + Font.Height));
                        }
                    }
                    catch { }
                }
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
                    }
                }
            }
            else if(_isRecording)
            {
                //transparent yo.
                _pen.DashOffset = ((int)(Stopwatch.Elapsed.TotalMilliseconds / 100.0)) % 10;
                e.Graphics.DrawRectangle(_pen, 0, 0, _x.Width - 1, Height - 29);
                //draw circle below stuffs.
                if (_showrecording)
                {
                    e.Graphics.FillEllipse(Brushes.Red, Width - 25, Height - 28, 25, 25);
                    e.Graphics.DrawEllipse(Pens.Black, Width - 25, Height - 28, 25, 25);
                }
                //show timer.            
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 32, 33, 37)), 0, Height - 28, 55, 20);
                e.Graphics.DrawRectangle(Pens.Black, 0, Height - 28, 55, 20);
                e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                e.Graphics.DrawString(string.Format("00:{0:#00}:{1:#00}", Stopwatch.Elapsed.Minutes, Stopwatch.Elapsed.Seconds), _metroF, Brushes.White, 0, Height - 28);
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
        public FFmpegHelperService Fmp;
        public bool Cancel;
        void ScreenshotForm_MouseUp(object sender, MouseEventArgs e)
        {
            //resize form, set lime to transparent, and yolo swag.
            if (_activated)
            {
                if (_x.Width < 50 || _x.Height < 50) { return; }
                var newpoint = PointToScreen(new Point(_x.X, _x.Y));
                _x = new Rectangle(newpoint, new Size(_x.Width, _x.Height));
                _activated = false;
                TransparencyKey = Color.LimeGreen;
                //make a minimum size required.
                Location = new Point(_x.X, _x.Y);
                var themedPanel = new Panel()
                {
                    Size = new Size(_x.Width - 2, _x.Height),
                    Location = new Point(1, 1),
                    BackColor = Color.LimeGreen,
                };
                    
                Controls.Add(themedPanel);
                //add a stop button.
                //TODO: check to make sure that the shit isn't offscreen, if so then like idk
                var stopButton = new ThemedButton()
                {
                    Scaled = false,
                    Text = "Stop",
                    Size = new Size(75, 23),
                    Location = new Point(60, Height - 28)
                };
                stopButton.Click += m_Click;


                Controls.Add(stopButton);

                var cancelButton = new ThemedButton()
                {
                    Scaled = false,
                    Text = "Cancel",
                    Size = new Size(75, 23),
                    Location = new Point(140, Height - 28),
                };

                cancelButton.Click += mb_Click;


                Controls.Add(cancelButton);

                Size = new Size(_x.Width < 216 ? 216 : _x.Width, _x.Height + 30);

                TopMost = true;
                BackColor = Color.LimeGreen;
                Cursor = Cursors.Default;
                //start video recording?

                Stopwatch.Restart();
                _drawing = false;
                _isRecording = true;

                //new Thread(delegate() { this.CaptureScreen(); }).Start();
                var sc = new ScreencastOptions();
                sc.ScreenRecordFPS = _settings.Record.Framerate;
                sc.Threads = _settings.Record.Threads;
                //sc.Duration = 15;
                var roundedX = ((_x.X + 1) % 2 != 0 ? _x.X + 2 : _x.X + 1);
                var roundedY = ((_x.Y + 1) % 2 != 0 ? _x.Y + 2 : _x.Y + 1);
                var roundedWidth = ((_x.Width - 3) % 2 != 0 ? _x.Width - 4 : _x.Width - 3);
                var roundedHeight = ((_x.Height - 1) % 2 != 0 ? _x.Height - 2 : _x.Height - 1);
                var w = new Rectangle(roundedX, roundedY, roundedWidth, roundedHeight);
                sc.CaptureArea = w;
                sc.OutputPath = Path.Combine(SettingsService.FolderPath, "Cache", Utils.GetRandomString(10) + ".mp4");
                sc.DrawCursor = _settings.Record.RecordCursor;
                Fmp = new FFmpegHelperService(sc);
                Fmp.Options.FFmpeg.CLIPath = Path.Combine(SettingsService.FolderPath, "ffmpeg.exe");
                if (_settings.Record.RecordAudio)
                {
                    //Fixes audio source if it doesn't exist.
                    var devices = Fmp.GetDirectShowDevices();
                    if (_settings.Record.AudioDevice is {} && devices.AudioDevices.Contains(_settings.Record.AudioDevice))
                    {
                        Fmp.Options.FFmpeg.AudioSource = _settings.Record.AudioDevice;
                        Fmp.Options.FFmpeg.AudioCodec = FFmpegAudioCodec.libvorbis;
                    }
                }
                Fmp.ErrorDataReceived += fmp_ErrorDataReceived;
                Fmp.OutputDataReceived += fmp_OutputDataReceived;
                new Thread(delegate()
                {
                    Fmp.Record();
                    if (!Cancel)
                    {
                        _tasks.Reset();
                        //check filesize.
                        var fz = new FileInfo(sc.OutputPath);
                        if (fz.Length >= (99 * (1024 * 1024)))
                        {
                            //let user know that the file is bigger than 100MB.
                            Invoke((MethodInvoker)(() =>
                            {
                                MessageBox.Show("Your recording is over the 100MB limit for Shotr uploads. You'll need to save your recording locally instead.");
                                var xz = new SaveFileDialog
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
                            _musicPlayerService.PlayCaptured();
                            //TODO: buffer file input into uploader, cause like idk huge file sizes.
                            _uploader.AddToQueue(new ImageShell(File.ReadAllBytes(sc.OutputPath), FileExtensions.mp4));
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
                    Stopwatch.Stop();
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
            Stopwatch.Stop();
            Fmp.Close();
            CloseWindow();
        }

        void m_Click(object sender, EventArgs e)
        {
            //stop recording.
            Stopwatch.Stop();
            Fmp.Close();
        }
        private bool _isRecording;
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
            if (_drawing)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (!_activated)
                    {
                        _activated = true;
                        _orig = e.Location;
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
            if (_activated)
            {
                var mouselocation = PointToClient(Cursor.Position);
                _x = CreateRectangle(_orig.X, _orig.Y, mouselocation.X, mouselocation.Y);
            }
            Refresh();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            _showrecording = !_showrecording;
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

        private void GifRecorderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Fmp?.Close();
            }
            catch { }
        }
    }
}

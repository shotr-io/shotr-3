﻿using System;
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

        private bool _activated;
        private bool _drawing = true;
        private bool _showrecording;

        private SingleInstance _tasks;
        
        public Stopwatch Stopwatch = Stopwatch.StartNew();

        private readonly BaseSettings _settings;
        private readonly MusicPlayerService _musicPlayerService;
        private readonly Uploader _uploader;

        public VideoRecorderForm(BaseSettings settings, MusicPlayerService musicPlayerService, Uploader uploader, Bitmap bitmap, SingleInstance tasks)
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
            _tasks = tasks;

            timer1.Interval = 10;
            timer1.Start();

            Paint += ScreenshotForm_Paint;
            FormBorderStyle = FormBorderStyle.None;

            var rect = Utils.GetScreenBoundaries();
            Size = rect.Size;
            //get point of left-most monitor.
            Location = rect.Location;

            KeyUp += ScreenshotForm_KeyUp;
            KeyDown += ScreenshotForm_KeyDown;

            Cursor = Cursors.Cross;

            _screenshot = new Bitmap(_screenshot, rect.Width, rect.Height);

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
                if (Fmp is { })
                {
                    Cancel = true;
                    Fmp.Close();
                }
                else // Pre-recording state
                {
                    CloseWindow();
                }
            }
            else if (e.KeyCode == Keys.Z)
            {
                _settings.Capture.ShowZoom = !_settings.Capture.ShowZoom;
            }
            else if (e.KeyCode == Keys.I)
            {
                _settings.Capture.ShowInformation = !_settings.Capture.ShowInformation;
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
                            e.Graphics.DrawString(string.Format("X: {0} / Y: {1}", _x.X, _x.Y), Font, _brush, new PointF(_x.X, _x.Y));
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
                    var translatedBounds = PointToClient(new Point(Bounds.X, Bounds.Y));
                    using (var magnifier = (Magnifier(_screenshot, new Point(cursorloc.X, cursorloc.Y), 10, 10, 10)))
                    {
                        if (cursorloc.Y + magnifier.Height + 5 > Height && cursorloc.X - magnifier.Width - 5 < translatedBounds.X)
                        {
                            //top right
                            location = new Point(cursorloc.X + 5, cursorloc.Y - magnifier.Height - 5);
                        }
                        else if (cursorloc.X + magnifier.Width + 5 > Width && cursorloc.Y - magnifier.Height - 5 < translatedBounds.Y)
                        {
                            //bottom left
                            location = new Point(cursorloc.X - magnifier.Width - 5, cursorloc.Y + 5);
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
                var elapsed = string.Format("00:{0:#00}:{1:#00}", Stopwatch.Elapsed.Minutes, Stopwatch.Elapsed.Seconds);
                var measurement = e.Graphics.MeasureString(elapsed, Font);

                //transparent yo.
                _pen.DashOffset = ((int)(Stopwatch.Elapsed.TotalMilliseconds / 100.0)) % 10;
                e.Graphics.DrawRectangle(_pen, 0, 0, _x.Width - 1, _x.Height);
                //draw circle below stuffs.
                if (_showrecording)
                {
                    e.Graphics.FillEllipse(Brushes.Red, Width - 20, _x.Height + 2, 20, 20);
                    e.Graphics.DrawEllipse(Pens.Black, Width - 20, _x.Height + 2, 20, 20);
                }

                //show timer.
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 32, 33, 37)), 0, _x.Height + 4, measurement.Width + 4, measurement.Height + 4);
                e.Graphics.DrawRectangle(Pens.Black, 0, _x.Height + 4, measurement.Width + 4, measurement.Height + 4);
                e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                e.Graphics.DrawString(elapsed, Font, Brushes.White, 2, _x.Height + 6);
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
        private ThemedButton _stopButton;
        private ThemedButton _cancelButton;

        public string? OutputPath;

        void ScreenshotForm_MouseUp(object sender, MouseEventArgs e)
        {
            //resize form, set lime to transparent, and yolo swag.
            if (_activated)
            {
                if (_x.Width < 50 || _x.Height < 50)
                {
                    return;
                }

                var newpoint = PointToScreen(new Point(_x.X, _x.Y));
                _x = new Rectangle(newpoint, new Size(_x.Width, _x.Height));
                _activated = false;
                TransparencyKey = Color.LimeGreen;
                //make a minimum size required.
                Location = new Point(_x.X, _x.Y);
                var themedPanel = new Panel()
                {
                    Size = new Size(_x.Width - 2, _x.Height - 1),
                    Location = new Point(1, 1),
                    BackColor = Color.LimeGreen,
                };
                
                Controls.Add(themedPanel);

                var scale = DpiScaler.GetScalingFactor(this);
                var font = Theme.Font(12);

                var stopButtonText = "Stop";
                var stopButtonTextMeasurement = TextRenderer.MeasureText(stopButtonText, font);
                _stopButton = new ThemedButton()
                {
                    Scaled = false,
                    Text = stopButtonText,
                    Size = new Size(stopButtonTextMeasurement.Width, (int)(23 * scale)),
                    Location = new Point((int)(80 * scale), _x.Height + 4),
                    Font = font
                };
                _stopButton.Click += m_Click;
                Controls.Add(_stopButton);

                var cancelButtonText = "Cancel";
                var cancelButtonTextMeasurement = TextRenderer.MeasureText(cancelButtonText, font);
                _cancelButton = new ThemedButton()
                {
                    Scaled = false,
                    Text = cancelButtonText,
                    Size = new Size(cancelButtonTextMeasurement.Width, (int)(23 * scale)),
                    Location = new Point((int)(_stopButton.Location.X + _stopButton.Width + 6 * scale), _x.Height + 4),
                    Font = font
                };

                _cancelButton.Click += mb_Click;
                Controls.Add(_cancelButton);

                Size = new Size(_x.Width < 216 ? 216 : _x.Width, _x.Height + _cancelButton.Height + 4);

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
                Fmp.Options.FFmpeg.Preset = Enum.Parse<FFmpegPreset>(_settings.Record.Quality);
                Fmp.ErrorDataReceived += fmp_ErrorDataReceived;
                Fmp.OutputDataReceived += fmp_OutputDataReceived;
                new Thread(delegate()
                {
                    Fmp.Record();
                    _drawing = false;
                    _tasks.Reset();
                    Stopwatch.Stop();
                    timer1.Stop();
                    
                    if (!Cancel)
                    {
                        // Ask to save.
                        string? filePath = null;
                        Invoke((MethodInvoker)(() =>
                        {
                            var xz = new SaveFileDialog
                            {
                                Filter = "MPEG4 (*.mp4) | *.mp4",
                                FileName = $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.mp4"
                            };
                            if (xz.ShowDialog() == DialogResult.OK)
                            {
                                filePath = xz.FileName;
                                //save file.
                                File.Copy(sc.OutputPath, filePath);
                            }
                        }));

                        _musicPlayerService.PlayCaptured();

                        if (filePath is { })
                        {
                            if (!WineDetectionService.IsWine())
                            {
                                Toast.Send(null, "Video saved to folder!", _settings.Login.Enabled == true ? "Upload" : null, "uploadVideo", $"path={filePath}");
                            }
                            else
                            {
                                var result = MessageBox.Show("Video saved to folder. Would you like to upload it?",
                                    "Upload Video",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                                if (result == DialogResult.Yes)
                                {
                                    _uploader.AddToQueue(new FileShell(filePath));
                                }
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            File.Delete(sc.OutputPath);
                        }
                        catch { }
                    }

                    Invoke((MethodInvoker)(() =>
                    {
                        CloseWindow();
                    }));
                }).Start();
            }
        }

        void mb_Click(object sender, EventArgs e)
        {
            Cancel = true;
            Fmp.Close();
        }

        void m_Click(object sender, EventArgs e)
        {
            //stop recording.
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

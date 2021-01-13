using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Shotr.Core.Hotkey;
using Shotr.Core.Settings;
using Shotr.Core.Uploader;
using Shotr.Core.Utils;

namespace Shotr.Ui.Forms
{
    public partial class ScreenshotForm : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var @params = base.CreateParams;
                @params.ExStyle |= 0x80;
                return @params;
            }
        }

        private Bitmap _screenshot;
        private Bitmap _origscreenshot;

        private Point _orig;
        private Pen _pen = new Pen(Color.White, 1) { DashPattern = new[] { 6.0F, 4.0F } };

        private Brush _brush = new SolidBrush(Color.White);
        private TextureBrush _textbrush;

        private Rectangle _x = Rectangle.Empty;

        private Font _kfont = new Font(DefaultFont, FontStyle.Bold);

        private bool _activated;
        private bool _editing;
        private bool _drawing;
        
        private Stopwatch _stopwatch = Stopwatch.StartNew();

        private SingleInstance _tasks;

        private readonly BaseSettings _settings;
        private readonly Uploader _uploader;

        public ScreenshotForm(BaseSettings settings, Uploader uploader)
        {
            _settings = settings;
            _uploader = uploader;

            _availableColors = new List<Color>();
            var colorsType = typeof(Color);
            var properties = colorsType.GetProperties(BindingFlags.Static | BindingFlags.Public);
            foreach (var prop in properties)
            {
                _availableColors.Add(Color.FromName(prop.Name));
            }

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
        }

        public void SetUpForm(Bitmap bitmap, SingleInstance tasks)
        {
            _screenshot = bitmap;
            _tasks = tasks;
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
                if (_resizing)
                {
                    _resizing = false;
                    _oldResizePosition = Point.Empty;
                    Cursor = Cursors.Cross;
                    return;
                }
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
            else if (e.KeyCode == Keys.E)
            {
                if (!_editing)
                {
                    _editing = true;
                    _activated = false;
                    //remember resizing & activated.
                    _resizing = false;
                }
                else
                {
                    //save current image and get ready to output it on the form.
                    _textbrush.Dispose();
                    using (var image = Utils.Apply(Utils.Contrast(0.7f), _screenshot))
                    {
                        var brush = new TextureBrush(image);
                        brush.WrapMode = WrapMode.Clamp;
                        _textbrush = brush;
                    }
                    //this.textbrush.ScaleTransform((this.Size.Width / (this.Size.Width * Utils.getScalingFactor())), (this.Size.Height / (this.Size.Height * Utils.getScalingFactor())));
                    _editing = false;
                }
                //turn on editing mode.
                
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (!_editing)
                {
                    _activated = false;
                    UploadImage();
                }
            }
        }

        public Bitmap GetProcessedImage()
        {
            return _clonedBitmap;
        }
        private Bitmap _clonedBitmap;
        private void UploadImage()
        {
            //save screenshot at x.
            var format = _screenshot.PixelFormat;
            try
            {
                _clonedBitmap = _screenshot.Clone(new Rectangle(new Point(_x.X, _x.Y), new Size(_x.Width, _x.Height)), format);
            }
            catch
            {
                //attempt to fix and re-clone.

                //check positions relative to the image, make sure they don't overlap.
                if (_x.X + _x.Width > _screenshot.Width)
                {
                    _x.Width = _screenshot.Width - _x.X;
                }
                if (_x.Y + _x.Height > _screenshot.Height)
                {
                    _x.Height = _screenshot.Height - _x.Y;
                }
                if (_x.X < 0)
                {
                    var l = 0 - _x.X;
                    _x.Width -= l;
                    _x.X = 0;
                }
                if (_x.Y < 0)
                {
                    var l = 0 - _x.Y;
                    _x.Height -= l;
                    _x.Y = 0;
                }

                //reclone.
                try
                {
                    _clonedBitmap = _screenshot.Clone(_x, format);
                }
                catch
                {
                    //wot.
                    _screenshot.Dispose();
                    Dispose();
                    Close();
                    //play error msg.
                    return;
                }
            }
            _screenshot.Dispose();

            Hide();
        }
        Graphics _edit;
        private int _prex;
        private int _prey;
        private Color _chosenColor = Color.Red;
        private int _colorIndex;
        private List<Color> _availableColors;
        private Pen _chosenPen;

        private ResizeLocation _resizeLocation;
        private Point _oldResizePosition = Point.Empty;
        void ScreenshotForm_MouseMove(object sender, MouseEventArgs e)
        {
            //change cursor to scalable stuff if we're out of activated.
            var mouse = PointToClient(Cursor.Position);
            if (!_activated && _resizing && !_resizemove)
            {
                //left side.
                if ((mouse.X >= _x.X - 4 && mouse.X <= _x.X + 4) && (mouse.Y >= _x.Y && mouse.Y <= _x.Y + _x.Height))
                {
                    Cursor = Cursors.SizeWE;                  
                }
                //right side.
                else if ((mouse.X >= _x.X + _x.Width - 4 && mouse.X <= _x.X + _x.Width + 4) && (mouse.Y >= _x.Y && mouse.Y <= _x.Y + _x.Height))
                {
                    Cursor = Cursors.SizeWE;
                }
                //top
                else if((mouse.X >= _x.X + 4 && mouse.X <= _x.X + _x.Width - 4) && (mouse.Y >= _x.Y - 4 && mouse.Y <= _x.Y + 4))
                {
                    Cursor = Cursors.SizeNS;
                }
                //bottom 
                else if((mouse.X >= _x.X + 4 && mouse.X <= _x.X + _x.Width - 4) && (mouse.Y >= _x.Y + _x.Height - 4 && mouse.Y <= _x.Y + _x.Height + 4))
                {
                    Cursor = Cursors.SizeNS;
                }
                else if ((mouse.X >= _x.X - 4 && mouse.X <= _x.X + 4) && (mouse.Y >= _x.Y - 4 && mouse.Y <= _x.Y + 4))
                {
                    Cursor = Cursors.SizeNWSE;
                }
                else if ((mouse.X >= _x.X + _x.Width - 4 && mouse.X <= _x.X + _x.Width + 4) && (mouse.Y >= _x.Y - 4 && mouse.Y <= _x.Y + 4))
                {
                    Cursor = Cursors.SizeNESW;
                }
                else if ((mouse.X >= _x.X + _x.Width - 4 && mouse.X <= _x.X + _x.Width + 4) && (mouse.Y >= _x.Y + _x.Height - 4 && mouse.Y <= _x.Y + _x.Height + 4))
                {
                    Cursor = Cursors.SizeNWSE;
                }
                else if ((mouse.X >= _x.X - 4 && mouse.X <= _x.X + 4) && (mouse.Y >= _x.Y + _x.Height - 4 && mouse.Y <= _x.Y + _x.Height + 4))
                {
                    Cursor = Cursors.SizeNESW;
                }
                else if((mouse.X >= _x.X && mouse.X <= _x.X + _x.Width && mouse.Y >= _x.Y && mouse.Y <= _x.Y + _x.Height))
                {
                    Cursor = Cursors.SizeAll;
                }
                else
                {
                    Cursor = Cursors.Cross;
                }
            }
            else if (_resizemove)
            {
                if (_resizeLocation == ResizeLocation.Left)
                {
                    //should work fine hopefully.
                    if (mouse.X > _x.X)
                    {
                        if (_x.Width >= 50)
                        {
                            //move inwards.
                            var output = (mouse.X - _x.X);
                            _x.X += output;
                            _x.Width -= output;
                        }
                    }
                    else
                    {
                        
                        //move inwards.
                        var output = (_x.X - mouse.X);
                        if (_x.Width + output <= 50) { return; }
                        _x.X -= output;
                        _x.Width += output;
                       
                    }
                }
                else if (_resizeLocation == ResizeLocation.Right)
                {
                    //should work fine hopefully.
                    if (mouse.X > _x.X + _x.Width)
                    {
                        //move inwards.
                        var output = (mouse.X - _x.X);
                        //x.X += output;
                        _x.Width = output;
                    }
                    else
                    {
                        if (_x.Width >= 50)
                        {
                            //move inwards.
                            var output = (_x.X + _x.Width - mouse.X);
                            _x.Width -= output;
                        }
                    }
                }
                else if (_resizeLocation == ResizeLocation.Top)
                {
                    //should work fine hopefully.
                    if (mouse.Y > _x.Y)
                    {
                        //move inwards.
                        if (_x.Height >= 50)
                        {
                        var output = (mouse.Y - _x.Y);
                        _x.Y += output;
                        _x.Height -= output;
                        }
                    }
                    else
                    {                  
                        var output = (_x.Y - mouse.Y);
                        _x.Y -= output;
                        _x.Height += output;
                    }
                }
                else if (_resizeLocation == ResizeLocation.Bottom)
                {
                    //should work fine hopefully.
                    if (mouse.Y > _x.Y + _x.Height)
                    {
                        //move inwards.
                        var output = (mouse.Y - _x.Y);
                        _x.Height = output;
                    }
                    else
                    {
                        if (_x.Height >= 50)
                        {
                            //move inwards.
                            var output = (_x.Y + _x.Height - mouse.Y);
                            _x.Height -= output;
                        }
                    }
                }
                else if (_resizeLocation == ResizeLocation.TopLeft)
                {
                    if (mouse.X > _x.X)
                    {
                        if (_x.Width >= 50)
                        {
                            var output = (mouse.X - _x.X);
                            _x.X += output;
                            _x.Width -= output;
                        }
                    }
                    if (mouse.Y > _x.Y)
                    {
                        if (_x.Height >= 50)
                        {
                            //move downwards.
                            var output = (mouse.Y - _x.Y);
                            _x.Y += output;
                            _x.Height -= output;
                        }
                    }
                    if (mouse.X < _x.X)
                    {
                        //move inwards.
                        var output = (_x.X - mouse.X);
                        _x.X -= output;
                        _x.Width += output;
                    }
                    if (mouse.Y < _x.Y)
                    {
                        //move inwards.
                        var output = (_x.Y - mouse.Y);
                        _x.Y -= output;
                        _x.Height += output;
                    }
                }
                else if (_resizeLocation == ResizeLocation.TopRight)
                {
                    if (mouse.X > _x.X + _x.Width)
                    {
                        var output = (mouse.X - _x.X);
                        _x.Width = output;
                    }
                    if (mouse.Y > _x.Y)
                    {
                        if (_x.Height >= 50)
                        {
                            //move downwards.
                            var output = (mouse.Y - _x.Y);
                            _x.Y += output;
                            _x.Height -= output;
                        }
                    }
                    if (mouse.X < _x.X + _x.Width)
                    {
                        if (_x.Width >= 50)
                        {
                            //move inwards.
                            var output = (_x.X + _x.Width - mouse.X);
                            _x.Width -= output;
                        }
                    }
                    if (mouse.Y < _x.Y)
                    {
                        //move inwards.
                        var output = (_x.Y - mouse.Y);
                        _x.Y -= output;
                        _x.Height += output;
                    }
                }
                else if (_resizeLocation == ResizeLocation.BottomRight)
                {
                    if (mouse.X > _x.X + _x.Width)
                    {
                        var output = (mouse.X - _x.X);
                        _x.Width = output;
                    }
                    if (mouse.Y > _x.Y + _x.Height)
                    {
                        //move inwards.
                        var output = (mouse.Y - _x.Y);
                        _x.Height = output;
                    }
                    if (mouse.X < _x.X + _x.Width)
                    {
                        if (_x.Width >= 50)
                        {
                            //move inwards.
                            var output = (_x.X + _x.Width - mouse.X);
                            _x.Width -= output;
                        }
                    }
                    if (mouse.Y < _x.Y + _x.Height)
                    {
                        if (_x.Height >= 50)
                        {
                            //move inwards.
                            var output = (_x.Y + _x.Height - mouse.Y);
                            _x.Height -= output;
                        }
                    }
                }
                else if (_resizeLocation == ResizeLocation.BottomLeft)
                {
                    if (mouse.X > _x.X)
                    {
                        if (_x.Width >= 50)
                        {
                            var output = (mouse.X - _x.X);
                            _x.X += output;
                            _x.Width -= output;
                        }
                    }
                    if (mouse.Y > _x.Y + _x.Height)
                    {
                        //move inwards.
                        var output = (mouse.Y - _x.Y);
                        _x.Height += output;
                    }
                    if (mouse.X < _x.X)
                    {                      
                        //move inwards.
                        var output = (_x.X - mouse.X);
                        _x.X -= output;
                        _x.Width += output;
                    }
                    if (mouse.Y < _x.Y + _x.Height)
                    {
                        if (_x.Height >= 50)
                        {
                            //move inwards.
                            var output = (_x.Y + _x.Height - mouse.Y);
                            _x.Height -= output;
                        }
                    }
                }
                else if (_resizeLocation == ResizeLocation.Any)
                {
                    if(_oldResizePosition == Point.Empty) {
                        _oldResizePosition = mouse;
                        return;
                    }
                    //move relative to mouse.
                    _x.X += (mouse.X - _oldResizePosition.X);
                    _x.Y += (mouse.Y - _oldResizePosition.Y);
                    _oldResizePosition = mouse;
                }
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
            return (num <= min ? min : (num >= max ? max : num));
        }

        private Bitmap ShowSolidColor(Image img, Point position, int width, int height, Color color)
        {
            var image = new Bitmap(width - 1, height - 1);
            using (var graphics = Graphics.FromImage(image))
            {
                graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                graphics.FillRectangle(new SolidBrush(color), new Rectangle(0, 0, width, height));
                graphics.DrawRectangle(Pens.Black, 0, 0, width, height);
            }
            return image;
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
            if (!_editing)
                e.Graphics.FillRectangle(_textbrush, new Rectangle(0, 0, Size.Width, Size.Height));//this.Bounds);
            else
                e.Graphics.DrawImageUnscaled(_screenshot, 0, 0);

            if (_activated && _x.Height > 1 && _x.Width > 1)
            {
                try
                {
                    e.Graphics.DrawImage(_screenshot, _x, _x, GraphicsUnit.Pixel);

                    _pen.DashOffset = ((int)(_stopwatch.Elapsed.TotalMilliseconds / 100.0)) % 10;
                    e.Graphics.DrawRectangle(_pen, _x);
                    if ((_x.Width > 250 && _x.Height > _kfont.Height * 2.2) && _settings.Capture.ShowInformation)
                    {
                        e.Graphics.DrawString(string.Format("X: {0} / Y: {1}{2}", _x.X, _x.Y, (_settings.Capture.ShowColor ? " - " + GetHexCode(_screenshot.GetPixel(PointToClient(Cursor.Position).X, PointToClient(Cursor.Position).Y)) : "")), _kfont, _brush, new PointF(_x.X, _x.Y));
                        e.Graphics.DrawString(string.Format("W: {0} / H: {1}", _x.Width, _x.Height), _kfont, _brush, new PointF(_x.X, _x.Y + _kfont.Height));
                    }
                }
                catch { }
            }
            else if(_resizing)
            {
                try
                {
                    e.Graphics.DrawImage(_screenshot, _x, _x, GraphicsUnit.Pixel);

                    _pen.DashOffset = ((int)(_stopwatch.Elapsed.TotalMilliseconds / 100.0)) % 10;
                    e.Graphics.DrawRectangle(_pen, _x);
                    if ((_x.Width > 250 && _x.Height > _kfont.Height * 2.2) && _settings.Capture.ShowInformation)
                    {
                        e.Graphics.DrawString(string.Format("X: {0} / Y: {1}{2}", _x.X, _x.Y, (_settings.Capture.ShowColor ? " - " + GetHexCode(_screenshot.GetPixel(PointToClient(Cursor.Position).X, PointToClient(Cursor.Position).Y)) : "")), _kfont, _brush, new PointF(_x.X, _x.Y));
                        e.Graphics.DrawString(string.Format("W: {0} / H: {1}", _x.Width, _x.Height), _kfont, _brush, new PointF(_x.X, _x.Y + _kfont.Height));
                    }
                }
                catch { }
            }
            //draw shit on form graphics.            
            if (_editing && _drawing)
            {
                var cursorloc = PointToClient(Cursor.Position);
                //edit.DrawImage(screenshot, new Rectangle(0, 0, this.Bounds.Width, this.Bounds.Height));
                _edit.SmoothingMode = SmoothingMode.HighQuality;
                _edit.DrawLine(_chosenPen, _prex, _prey, cursorloc.X, cursorloc.Y);
                //edit.FillEllipse(Brushes.Red, new Rectangle(e.X, e.Y, 4, 4));
                _prex = cursorloc.X;
                _prey = cursorloc.Y;
            }

            if (_settings.Capture.ShowZoom)
            {
                //check if screen isn't big enough to fit on right side, if so then fit on left side.
                var location = new Point(0, 0);
                var cursorloc = PointToClient(Cursor.Position);
                using (var magnifier = (_editing ? ShowSolidColor(_screenshot, new Point(cursorloc.X, cursorloc.Y), 50, 50, _chosenColor) :  Magnifier(_screenshot, new Point(cursorloc.X, cursorloc.Y), 10, 10, 10)))
                {
                    if ((_x.Width > 80 || _x.Height > _kfont.Height * 2) && (cursorloc.X - 1 < _x.X && cursorloc.Y - 1 < _x.Y || new Rectangle(new Point(_x.X, _x.Y), new Size(80, (_kfont.Height * 2))).IntersectsWith(new Rectangle(cursorloc, new Size(80, (_kfont.Height * 2))))))
                    {
                        //draw it below the text.
                        location = new Point(cursorloc.X + 5, cursorloc.Y + (_kfont.Height * 2) + 5);
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
            
            timer1.Interval = 10;
            timer1.Start();

            Paint += ScreenshotForm_Paint;
            FormBorderStyle = FormBorderStyle.None;
            var height = 0;
            var width = 0;
            var left = 0;
            var top = 0;
            var i = 0;
            foreach (var screen in Screen.AllScreens)
            {
                screen.GetDpi(DpiType.Effective, out var dpiX, out var dpiY);
                //take smallest height
                float scale = 1;//(dpiX / 96f);
                //take smallest height
                height = (int)Math.Round(((screen.Bounds.Height * scale) >= height) ? (screen.Bounds.Height * scale) : height);
                width += (int)Math.Round(screen.Bounds.Width * scale);
                left = (left >= screen.Bounds.X ? screen.Bounds.X : left);
                top = (top >= screen.Bounds.Y ? screen.Bounds.Y : top);
                if (screen.Bounds.Y + screen.Bounds.Height > height) height = screen.Bounds.Y + (int)Math.Round(screen.Bounds.Height * scale);
                if (top < 0 || screen.Bounds.Y >= height) height += (int)Math.Round(screen.Bounds.Height * scale);
                Console.WriteLine("Monitor {4} [ScalingX: {5}, ScalingY: {6}]: - Top: {0}, Left: {1}, Width: {2}, Height: {3}", screen.Bounds.Top, screen.Bounds.Left, screen.Bounds.Width, screen.Bounds.Height, i, dpiX, dpiY);
                i++;
            }

            Size = new Size(width, height);
            //get point of left-most monitor.
            Location = new Point(left, top);

            KeyUp += ScreenshotForm_KeyUp;
            KeyDown += ScreenshotForm_KeyDown;

            Cursor = Cursors.Cross;

            _origscreenshot = (Bitmap)_screenshot.Clone();
            _screenshot = new Bitmap(_screenshot, width, height);
            
            using (var image = Utils.Apply(Utils.Contrast(0.7f), _screenshot))
            {
                var brush = new TextureBrush(image);
                brush.WrapMode = WrapMode.Clamp;
                _textbrush = brush;
            }

            var brush1 = new TextureBrush(_screenshot);
            brush1.WrapMode = WrapMode.Clamp;

            DoubleBuffered = true;
            ShowInTaskbar = false;
            
            _edit = Graphics.FromImage(_screenshot);
            
            MouseMove += ScreenshotForm_MouseMove;
            MouseDown += ScreenshotForm_MouseDown;
            MouseUp += ScreenshotForm_MouseUp;
            MouseWheel += ScreenshotForm_MouseWheel;
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

        void ScreenshotForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (_editing)
            {
                if (e.Delta > 0)
                {
                    _colorIndex++;
                    if (_colorIndex >= _availableColors.Count) _colorIndex = 0;
                    _chosenColor = _availableColors[_colorIndex];
                }
                else
                {
                    _colorIndex--;
                    if (_colorIndex < 0) _colorIndex = _availableColors.Count - 1;
                    _chosenColor = _availableColors[_colorIndex];
                }
            }
        }
        private bool _resizing;
        private bool _resizemove;
        void ScreenshotForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (_resizing)
            {
                _resizemove = false;
                _oldResizePosition = Point.Empty;
                _resizeLocation = ResizeLocation.None;
                return;
            }

            if (!_editing)
            {
                if (!_settings.Capture.UseResizableCanvas)
                {
                    UploadImage();
                    return;
                }
                _activated = false;
                _resizing = true;
            }
            else 
            {
                _drawing = false;
                if (e.Button == MouseButtons.Right)
                {
                    //clear drawings.
                    _screenshot.Dispose();
                    _screenshot = (Bitmap)_origscreenshot.Clone();
                    _edit = Graphics.FromImage(_screenshot);
                }
            }
        }

        void ScreenshotForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (_resizing)
            {
                var mouse = PointToClient(Cursor.Position);
                if ((mouse.X >= _x.X - 4 && mouse.X <= _x.X + 4) && (mouse.Y >= _x.Y + 4 && mouse.Y <= _x.Y + _x.Height - 4))
                {
                    _resizeLocation = ResizeLocation.Left;
                }
                else if ((mouse.X >= _x.X + _x.Width - 4 && mouse.X <= _x.X + _x.Width + 4) && (mouse.Y >= _x.Y + 4 && mouse.Y <= _x.Y + _x.Height - 4))
                {
                    _resizeLocation = ResizeLocation.Right;
                }
                else if ((mouse.X >= _x.X + 4 && mouse.X <= _x.X + _x.Width - 4) && (mouse.Y >= _x.Y - 4 && mouse.Y <= _x.Y + 4))
                {
                    _resizeLocation = ResizeLocation.Top;
                }
                else if ((mouse.X >= _x.X + 4 && mouse.X <= _x.X + _x.Width - 4) && (mouse.Y >= _x.Y + _x.Height - 4 && mouse.Y <= _x.Y + _x.Height + 4))
                {
                    _resizeLocation = ResizeLocation.Bottom;
                }
                else if ((mouse.X >= _x.X - 4 && mouse.X <= _x.X + 4) && (mouse.Y >= _x.Y - 4 && mouse.Y <= _x.Y + 4))
                {
                    _resizeLocation = ResizeLocation.TopLeft;
                }
                else if ((mouse.X >= _x.X + _x.Width - 4 && mouse.X <= _x.X + _x.Width + 4) && (mouse.Y >= _x.Y - 4 && mouse.Y <= _x.Y + 4))
                {
                    _resizeLocation = ResizeLocation.TopRight;                   
                }
                else if ((mouse.X >= _x.X + _x.Width - 4 && mouse.X <= _x.X + _x.Width + 4) && (mouse.Y >= _x.Y + _x.Height - 4 && mouse.Y <= _x.Y + _x.Height + 4))
                {
                    _resizeLocation = ResizeLocation.BottomRight;
                }
                else if ((mouse.X >= _x.X - 4 && mouse.X <= _x.X + 4) && (mouse.Y >= _x.Y + _x.Height - 4 && mouse.Y <= _x.Y + _x.Height + 4))
                {
                    _resizeLocation = ResizeLocation.BottomLeft;
                }
                else if((mouse.X >= _x.X && mouse.X <= _x.X + _x.Width && mouse.Y >= _x.Y && mouse.Y <= _x.Y + _x.Height))
                {
                    _resizeLocation = ResizeLocation.Any;
                }
                _resizemove = true;
                return;
            }

            if (!_editing)
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
            else
            {
                //choose pen.
                _chosenPen = new Pen(_chosenColor, 3);
                //draw shit on theform.
                _prex = e.X;
                _prey = e.Y;
                _drawing = true;
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

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool BringWindowToTop(HandleRef hWnd);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);

        private void ScreenshotForm_MouseHover(object sender, EventArgs e)
        {

        }
    }

    enum ResizeLocation
    {
        Left,
        Top,
        Right,
        Bottom,
        TopLeft,
        TopRight,
        BottomRight,
        BottomLeft,
        Any,
        None
    }
}

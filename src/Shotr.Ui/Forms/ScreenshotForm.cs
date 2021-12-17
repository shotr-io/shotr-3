using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;
using Shotr.Core.Controls.Theme;
using Shotr.Core.Entities;
using Shotr.Core.Entities.Hotkeys;
using Shotr.Core.Services;
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

        public ScreenshotActionEnum ScreenshotAction { get; set; } = ScreenshotActionEnum.SaveToClipboard;

        private Bitmap _screenshot;
        private Bitmap _origscreenshot;

        private Point _orig;
        private Pen _pen = new Pen(Color.White, 1) {DashPattern = new[] {6.0F, 4.0F}};

        private Brush _brush = new SolidBrush(Color.White);
        private TextureBrush _textbrush;

        private Rectangle _x = Rectangle.Empty;

        private bool _activated;
        private bool _editing;
        private bool _drawing;

        private Stopwatch _stopwatch = Stopwatch.StartNew();

        private SingleInstance _tasks;

        private readonly BaseSettings _settings;
        private readonly Uploader _uploader;

        Graphics _edit;
        private int _prex;
        private int _prey;
        private Color _chosenColor; // Should be _availableColors[0] (Red)
        private int _colorIndex;
        private List<Color> _availableColors;
        private Pen _chosenPen;

        private ResizeLocation _resizeLocation;
        private Point _oldResizePosition = Point.Empty;

        private Bitmap _clonedBitmap;

        private bool _resizing;
        private bool _resizemove;
        private bool _quickEscape; // For Active & Fullscreen captures
        private ThemedButton _uploadButton;
        private ThemedButton _saveButton;
        private ThemedButton _clipboardButton;
        private ThemedButton _editButton;

        private readonly int _MinSize = 1;

        private bool wasResizing = false;

        public ScreenshotForm(BaseSettings settings, Uploader uploader, Bitmap bitmap, SingleInstance tasks, Rectangle? coordinates = null)
        {
            _settings = settings;
            _uploader = uploader;

            _availableColors = new List<Color>{
                Color.Red, // Keep 'Red' as the first index
                Color.Black,
                Color.White,
                Color.Orange,
                Color.Yellow,
                Color.Green,
                Color.Blue,
                Color.Indigo,
                Color.Violet
            };
            _chosenColor = _availableColors[0];

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint,
                true);

            InitializeComponent();

            var dpiScale = DpiScaler.GetScalingFactor(this);
            base.Font = Theme.Font((int) (base.Font.Size * dpiScale));
            StartPosition = FormStartPosition.Manual;
            
            TopMost = true;
            ShowInTaskbar = false;

            _tasks = tasks;

            _timer.Interval = 10;
            _timer.Start();

            Paint += ScreenshotForm_Paint;
            FormBorderStyle = FormBorderStyle.None;

            var rect = Utils.GetScreenBoundaries();

            Size = rect.Size;
            //get point of left-most monitor.
            Location = rect.Location;

            KeyPreview = true;
            KeyUp += ScreenshotForm_KeyUp;
            KeyDown += ScreenshotForm_KeyDown;

            base.Cursor = Cursors.Cross;

            _origscreenshot = (Bitmap) bitmap.Clone();
            _screenshot = new Bitmap((Bitmap)bitmap.Clone(), rect.Width, rect.Height);
            bitmap.Dispose();


            using (var image = Utils.Apply(Utils.Contrast(0.7f), _screenshot))
            {
                var brush = new TextureBrush(image);
                brush.WrapMode = WrapMode.Clamp;
                _textbrush = brush;
            }

            var brush1 = new TextureBrush(_screenshot);
            brush1.WrapMode = WrapMode.Clamp;

            DoubleBuffered = true;

            _edit = Graphics.FromImage(_screenshot);

            MouseMove += ScreenshotForm_MouseMove;
            MouseDown += ScreenshotForm_MouseDown;
            MouseUp += ScreenshotForm_MouseUp;
            MouseWheel += ScreenshotForm_MouseWheel;

            if (coordinates is { })
            {
                var fixedCoordinates = coordinates.Value;
                var point = new Point(fixedCoordinates.X, fixedCoordinates.Y);
                var translated = PointToClient(point);
                fixedCoordinates.X = translated.X;
                fixedCoordinates.Y = translated.Y;

                _x = fixedCoordinates;

                SetupButtons();
                _quickEscape = true; // Single escape to exit screenshot form
                _activated = false;
                _editing = false;
                _resizing = true;

                Focus();
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

        private void SetButtonVisibility(bool visible)
        {
            if (_uploadButton is { })
            {
                _uploadButton.Visible = visible;
            }

            if (_saveButton is { })
            {
                _saveButton.Visible = visible;
            }

            if (_clipboardButton is { })
            {
                _clipboardButton.Visible = visible;
            }

            if (_editButton is { })
            {
                _editButton.Visible = visible;
            }
        }

        void ScreenshotForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (_resizing && !_quickEscape)
                {
                    _resizing = false;
                    _oldResizePosition = Point.Empty;
                    Cursor = Cursors.Cross;
                    
                    SetButtonVisibility(false);

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
            else if (e.KeyCode == Keys.E)
            {
                if (!_editing && _settings.Capture.ShowEditNotification)
                {
                    Toast.Send(null,
                        "When you are done editing, press the 'E' key to go back to selecting your screenshot. You can use your scroll wheel to change colors",
                        "Don't Show Again", "dontShowEditNotification", "dontshow=true");
                }

                if (!_editing)
                {
                    wasResizing = _resizing;
                    _editing = true;
                    _activated = false;
                    // Remember resizing & activated.
                    _resizing = false;
                    SetButtonVisibility(false);
                    Cursor = Cursors.Cross;
                }
                else
                {
                    // Save current image and get ready to output it on the form.
                    _textbrush.Dispose();
                    using (var image = Utils.Apply(Utils.Contrast(0.7f), _screenshot))
                    {
                        var brush = new TextureBrush(image);
                        brush.WrapMode = WrapMode.Clamp;
                        _textbrush = brush;
                    }

                    //this.textbrush.ScaleTransform((this.Size.Width / (this.Size.Width * Utils.getScalingFactor())), (this.Size.Height / (this.Size.Height * Utils.getScalingFactor())));
                    _editing = false;
                    if (wasResizing) { 
                        _resizing = true;
                        SetButtonVisibility(true);
                    }
                    Cursor = Cursors.SizeAll;
                }

                // Turn on editing mode.
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (!_editing)
                {
                    _activated = false;
                    ProcessImage();
                }
            }
        }

        public Bitmap GetProcessedImage()
        {
            return _clonedBitmap;
        }

        private void ProcessImage()
        {
            //save screenshot at x.
            var format = _screenshot.PixelFormat;
            try
            {
                _clonedBitmap = _screenshot.Clone(new Rectangle(new Point(_x.X, _x.Y), new Size(_x.Width, _x.Height)),
                    format);
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
                    _edit.Dispose();
                    _origscreenshot.Dispose();
                    Dispose();
                    Close();
                    //play error msg.
                    return;
                }
            }

            _screenshot.Dispose();
            _edit.Dispose();
            _origscreenshot.Dispose();

            Hide();
        }

        void ScreenshotForm_MouseMove(object sender, MouseEventArgs e)
        {
            // Change cursor to scalable stuff if we're out of activated.
            var mouse = PointToClient(Cursor.Position);
            if (!_activated && _resizing && !_resizemove)
            {
                // Left side
                if ((mouse.X >= _x.X - 4 && mouse.X <= _x.X + 4) && (mouse.Y >= _x.Y && mouse.Y <= _x.Y + _x.Height))
                {
                    Cursor = Cursors.SizeWE;
                }
                // Right side
                else if ((mouse.X >= _x.X + _x.Width - 4 && mouse.X <= _x.X + _x.Width + 4) &&
                         (mouse.Y >= _x.Y && mouse.Y <= _x.Y + _x.Height))
                {
                    Cursor = Cursors.SizeWE;
                }
                // Top
                else if ((mouse.X >= _x.X + 4 && mouse.X <= _x.X + _x.Width - 4) &&
                         (mouse.Y >= _x.Y - 4 && mouse.Y <= _x.Y + 4))
                {
                    Cursor = Cursors.SizeNS;
                }
                // Bottom
                else if ((mouse.X >= _x.X + 4 && mouse.X <= _x.X + _x.Width - 4) &&
                         (mouse.Y >= _x.Y + _x.Height - 4 && mouse.Y <= _x.Y + _x.Height + 4))
                {
                    Cursor = Cursors.SizeNS;
                }
                else if ((mouse.X >= _x.X - 4 && mouse.X <= _x.X + 4) && (mouse.Y >= _x.Y - 4 && mouse.Y <= _x.Y + 4))
                {
                    Cursor = Cursors.SizeNWSE;
                }
                else if ((mouse.X >= _x.X + _x.Width - 4 && mouse.X <= _x.X + _x.Width + 4) &&
                         (mouse.Y >= _x.Y - 4 && mouse.Y <= _x.Y + 4))
                {
                    Cursor = Cursors.SizeNESW;
                }
                else if ((mouse.X >= _x.X + _x.Width - 4 && mouse.X <= _x.X + _x.Width + 4) &&
                         (mouse.Y >= _x.Y + _x.Height - 4 && mouse.Y <= _x.Y + _x.Height + 4))
                {
                    Cursor = Cursors.SizeNWSE;
                }
                else if ((mouse.X >= _x.X - 4 && mouse.X <= _x.X + 4) &&
                         (mouse.Y >= _x.Y + _x.Height - 4 && mouse.Y <= _x.Y + _x.Height + 4))
                {
                    Cursor = Cursors.SizeNESW;
                }
                else if ((mouse.X >= _x.X && mouse.X <= _x.X + _x.Width && mouse.Y >= _x.Y &&
                          mouse.Y <= _x.Y + _x.Height))
                {
                    Cursor = Cursors.SizeAll;
                }
                else
                {
                    Cursor = Cursors.Cross;
                }
            }
            else if (_resizemove) // Resize screenshot window
            {
                if (_resizeLocation == ResizeLocation.Left)
                {
                    // X-axis Left
                    if (mouse.X > _x.X)
                    {
                        // Move crop inwards
                        if (_x.Width >= _MinSize) 
                        {
                            var output = (mouse.X - _x.X);
                            var proposedLeftX = _x.X + output;
                            var currentRightX = _x.X + _x.Width;
                            // Prevent left X from replacing right X. This can cause the screenshot area to move.
                            if (proposedLeftX < currentRightX)
                            {
                                _x.X += output;
                            }
                            else
                            {
                                _x.X = currentRightX - _MinSize;
                            }
                            // Prevent width from going into the negatives, this can cause overlap. No smaller than 10px.
                            if ((_x.Width - output) > _MinSize)
                            {
                                _x.Width -= output;
                            }
                            else
                            {
                                _x.Width = _MinSize;
                            }
                        }
                    }
                    else // Move crop outwards
                    {
                        var output = (_x.X - mouse.X);
                        if (_x.Width + output <= _MinSize)
                        {
                            return;
                        }
                        _x.X -= output;
                        _x.Width += output;
                    }
                }
                // X-axis Right
                else if (_resizeLocation == ResizeLocation.Right)
                {
                    // Move crop outwards
                    if (mouse.X > _x.X + _x.Width)
                    {
                        var output = (mouse.X - _x.X);
                        //x.X += output;
                        _x.Width = output;
                    }
                    else
                    {
                        // Move crop inwards
                        if (_x.Width >= _MinSize)
                        {
                            var output = (_x.X + _x.Width - mouse.X);
                            var proposedRightX = _x.Width - output;
                            if (proposedRightX > _MinSize)
                            {
                                _x.Width -= output;
                            }
                            else
                            {
                                _x.Width = _MinSize;
                            }
                        }
                    }
                }
                // Y-axis Top
                else if (_resizeLocation == ResizeLocation.Top)
                {
                    //should work fine hopefully.
                    if (mouse.Y > _x.Y)
                    {
                        // Move inwards
                        if (_x.Height >= _MinSize)
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
                // Y-axis Bottom
                else if (_resizeLocation == ResizeLocation.Bottom)
                {
                    //should work fine hopefully.
                    if (mouse.Y > _x.Y + _x.Height)
                    {
                        // Move inwards
                        var output = (mouse.Y - _x.Y);
                        _x.Height = output;
                    }
                    else
                    {
                        if (_x.Height >= _MinSize)
                        {
                            // Move inwards
                            var output = (_x.Y + _x.Height - mouse.Y);
                            _x.Height -= output;
                        }
                    }
                }
                // Top left corner X/Y
                else if (_resizeLocation == ResizeLocation.TopLeft)
                {
                    if (mouse.X > _x.X)
                    {
                        if (_x.Width >= _MinSize)
                        {
                            var output = (mouse.X - _x.X);
                            _x.X += output;
                            _x.Width -= output;
                        }
                    }

                    if (mouse.Y > _x.Y)
                    {
                        if (_x.Height >= _MinSize)
                        {
                            // Move downwards
                            var output = (mouse.Y - _x.Y);
                            _x.Y += output;
                            _x.Height -= output;
                        }
                    }

                    if (mouse.X < _x.X)
                    {
                        // Move inwards
                        var output = (_x.X - mouse.X);
                        _x.X -= output;
                        _x.Width += output;
                    }

                    if (mouse.Y < _x.Y)
                    {
                        // Move inwards
                        var output = (_x.Y - mouse.Y);
                        _x.Y -= output;
                        _x.Height += output;
                    }
                }
                // Top right corner X/Y
                else if (_resizeLocation == ResizeLocation.TopRight)
                {
                    if (mouse.X > _x.X + _x.Width)
                    {
                        var output = (mouse.X - _x.X);
                        _x.Width = output;
                    }

                    if (mouse.Y > _x.Y)
                    {
                        if (_x.Height >= _MinSize)
                        {
                            // Move downwards
                            var output = (mouse.Y - _x.Y);
                            _x.Y += output;
                            _x.Height -= output;
                        }
                    }

                    if (mouse.X < _x.X + _x.Width)
                    {
                        if (_x.Width >= _MinSize)
                        {
                            // Move inwards
                            var output = (_x.X + _x.Width - mouse.X);
                            _x.Width -= output;
                        }
                    }

                    if (mouse.Y < _x.Y)
                    {
                        // Move inwards
                        var output = (_x.Y - mouse.Y);
                        _x.Y -= output;
                        _x.Height += output;
                    }
                }
                // Bottom right corner X/Y
                else if (_resizeLocation == ResizeLocation.BottomRight)
                {
                    if (mouse.X > _x.X + _x.Width)
                    {
                        var output = (mouse.X - _x.X);
                        _x.Width = output;
                    }

                    if (mouse.Y > _x.Y + _x.Height)
                    {
                        // Move inwards
                        var output = (mouse.Y - _x.Y);
                        _x.Height = output;
                    }

                    if (mouse.X < _x.X + _x.Width)
                    {
                        if (_x.Width >= _MinSize)
                        {
                            // Move inwards
                            var output = (_x.X + _x.Width - mouse.X);
                            _x.Width -= output;
                        }
                    }

                    if (mouse.Y < _x.Y + _x.Height)
                    {
                        if (_x.Height >= _MinSize)
                        {
                            // Move inwards
                            var output = (_x.Y + _x.Height - mouse.Y);
                            _x.Height -= output;
                        }
                    }
                }
                // Bottom left corner X/Y
                else if (_resizeLocation == ResizeLocation.BottomLeft)
                {
                    if (mouse.X > _x.X)
                    {
                        if (_x.Width >= _MinSize)
                        {
                            var output = (mouse.X - _x.X);
                            _x.X += output;
                            _x.Width -= output;
                        }
                    }

                    if (mouse.Y > _x.Y + _x.Height)
                    {
                        // Move inwards
                        var output = (mouse.Y - _x.Y);
                        _x.Height += output;
                    }

                    if (mouse.X < _x.X)
                    {
                        // Move inwards
                        var output = (_x.X - mouse.X);
                        _x.X -= output;
                        _x.Width += output;
                    }

                    if (mouse.Y < _x.Y + _x.Height)
                    {
                        if (_x.Height >= _MinSize)
                        {
                            // Move inwards
                            var output = (_x.Y + _x.Height - mouse.Y);
                            _x.Height -= output;
                        }
                    }
                }
                else if (_resizeLocation == ResizeLocation.Any)
                {
                    if (_oldResizePosition == Point.Empty)
                    {
                        _oldResizePosition = mouse;
                        return;
                    }

                    // Move position relative to mouse
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
            _origscreenshot.Dispose();
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

        private Bitmap Magnifier(Image img, Point position, int horizontalPixelCount, int verticalPixelCount,
            int pixelSize)
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
            pixelSize = (int) (pixelSize * scalingFactor);
            var width = horizontalPixelCount * pixelSize;
            var height = verticalPixelCount * pixelSize;
            var image = new Bitmap(width - 1, height - 1);
            using (var graphics = Graphics.FromImage(image))
            {
                graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                graphics.PixelOffsetMode = PixelOffsetMode.Half;
                graphics.DrawImage(img, new Rectangle(0, 0, width, height),
                    new Rectangle(position.X - (horizontalPixelCount / 2), position.Y - (verticalPixelCount / 2),
                        horizontalPixelCount, verticalPixelCount), GraphicsUnit.Pixel);
                graphics.PixelOffsetMode = PixelOffsetMode.None;
                using (var pen = new Pen(Color.FromArgb(0x4b, Color.Black)))
                {
                    for (var i = 1; i < horizontalPixelCount; i++)
                    {
                        graphics.DrawLine(pen, new Point((i * pixelSize) - 1, 0),
                            new Point((i * pixelSize) - 1, height - 1));
                    }

                    for (var j = 1; j < verticalPixelCount; j++)
                    {
                        graphics.DrawLine(pen, new Point(0, (j * pixelSize) - 1),
                            new Point(width - 1, (j * pixelSize) - 1));
                    }
                }

                graphics.DrawRectangle(Pens.Black, ((width - pixelSize) / 2) - 1, ((height - pixelSize) / 2) - 1,
                    pixelSize, pixelSize);
                graphics.DrawRectangle(Pens.White, (width - pixelSize) / 2, (height - pixelSize) / 2, pixelSize - 2,
                    pixelSize - 2);
            }

            return image;
        }

        void ScreenshotForm_Paint(object sender, PaintEventArgs e)
        {
            if (!_editing)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Black),
                    new Rectangle(-1, -1, Bounds.Width + 1, Bounds.Height + 1));
                e.Graphics.FillRectangle(_textbrush, new Rectangle(0, 0, Size.Width, Size.Height));
            }
            else
            {
                e.Graphics.DrawImageUnscaled(_screenshot, 0, 0);
            }

            var scalingFactor = DpiScaler.GetScalingFactor(this);

            if (_activated && _x.Height > 1 && _x.Width > 1 || _resizing)
            {
                try
                {
                    e.Graphics.DrawImage(_screenshot, _x, _x, GraphicsUnit.Pixel);

                    _pen.DashOffset = ((int) (_stopwatch.Elapsed.TotalMilliseconds / 100.0)) % 10;
                    e.Graphics.DrawRectangle(_pen, _x);
                    if (_settings.Capture.ShowInformation)
                    {
                        TextRenderer.DrawText(e.Graphics, string.Format("X: {0} Y: {1} W: {0} H: {1}", _x.X, _x.Y, _x.Width, _x.Height), Theme.Font(12),new Point(_x.X, _x.Y - Font.Height), Color.White);
                    }

                    // Draw buttons.
                }
                catch
                {
                }
            }

            if (_editing && _drawing)
            {
                var cursorloc = PointToClient(Cursor.Position);
                _edit.SmoothingMode = SmoothingMode.HighQuality;
                _edit.DrawLine(_chosenPen, _prex, _prey, cursorloc.X, cursorloc.Y);
                _prex = cursorloc.X;
                _prey = cursorloc.Y;
            }

            if (_settings.Capture.ShowZoom)
            {
                //check if screen isn't big enough to fit on right side, if so then fit on left side.
                var location = new Point(0, 0);
                var cursorloc = PointToClient(Cursor.Position);
                var translatedBounds = PointToClient(new Point(Bounds.X, Bounds.Y));
                using (var magnifier = (_editing
                    ? ShowSolidColor(_screenshot, new Point(cursorloc.X, cursorloc.Y), (int) (50 * scalingFactor),
                        (int) (50 * scalingFactor), _chosenColor)
                    : Magnifier(_screenshot, new Point(cursorloc.X, cursorloc.Y), 10, 10, 10)))
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
                _activated = false;
                _resizing = true;

                SetupButtons();
            }
            else
            {
                _drawing = false;
                if (e.Button == MouseButtons.Right)
                {
                    //clear drawings.
                    _screenshot.Dispose();
                    _screenshot = (Bitmap) _origscreenshot.Clone();
                    _edit = Graphics.FromImage(_screenshot);
                }
            }
        }

        void ScreenshotForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (_resizing)
            {
                var mouse = PointToClient(Cursor.Position);
                if ((mouse.X >= _x.X - 4 && mouse.X <= _x.X + 4) &&
                    (mouse.Y >= _x.Y + 4 && mouse.Y <= _x.Y + _x.Height - 4))
                {
                    _resizeLocation = ResizeLocation.Left;
                }
                else if ((mouse.X >= _x.X + _x.Width - 4 && mouse.X <= _x.X + _x.Width + 4) &&
                         (mouse.Y >= _x.Y + 4 && mouse.Y <= _x.Y + _x.Height - 4))
                {
                    _resizeLocation = ResizeLocation.Right;
                }
                else if ((mouse.X >= _x.X + 4 && mouse.X <= _x.X + _x.Width - 4) &&
                         (mouse.Y >= _x.Y - 4 && mouse.Y <= _x.Y + 4))
                {
                    _resizeLocation = ResizeLocation.Top;
                }
                else if ((mouse.X >= _x.X + 4 && mouse.X <= _x.X + _x.Width - 4) &&
                         (mouse.Y >= _x.Y + _x.Height - 4 && mouse.Y <= _x.Y + _x.Height + 4))
                {
                    _resizeLocation = ResizeLocation.Bottom;
                }
                else if ((mouse.X >= _x.X - 4 && mouse.X <= _x.X + 4) &&
                         (mouse.Y >= _x.Y - 4 && mouse.Y <= _x.Y + 4))
                {
                    _resizeLocation = ResizeLocation.TopLeft;
                }
                else if ((mouse.X >= _x.X + _x.Width - 4 && mouse.X <= _x.X + _x.Width + 4) &&
                         (mouse.Y >= _x.Y - 4 && mouse.Y <= _x.Y + 4))
                {
                    _resizeLocation = ResizeLocation.TopRight;
                }
                else if ((mouse.X >= _x.X + _x.Width - 4 && mouse.X <= _x.X + _x.Width + 4) &&
                         (mouse.Y >= _x.Y + _x.Height - 4 && mouse.Y <= _x.Y + _x.Height + 4))
                {
                    _resizeLocation = ResizeLocation.BottomRight;
                }
                else if ((mouse.X >= _x.X - 4 && mouse.X <= _x.X + 4) &&
                         (mouse.Y >= _x.Y + _x.Height - 4 && mouse.Y <= _x.Y + _x.Height + 4))
                {
                    _resizeLocation = ResizeLocation.BottomLeft;
                }
                else if ((mouse.X >= _x.X && mouse.X <= _x.X + _x.Width && mouse.Y >= _x.Y &&
                          mouse.Y <= _x.Y + _x.Height))
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
                    CloseWindow();
                }
            }
            else
            {
                // Choose pen
                _chosenPen = new Pen(_chosenColor, 3);
                // Draw on the form
                _prex = e.X;
                _prey = e.Y;
                _drawing = true;
            }
        }

        private void SetupButtons()
        {
            var startX = _x.X;
            var xStart = _x.X;

            var scale = DpiScaler.GetScalingFactor(this);

            if (_settings.Login.Enabled == true)
            {
                if (_uploadButton is null)
                {
                    var uploadText = "Upload";
                    var measurement = TextRenderer.MeasureText(uploadText, Theme.Font(12));

                    _uploadButton = new ThemedButton()
                    {
                        Scaled = false,
                        Text = uploadText,
                        Size = new Size(measurement.Width, (int)(scale * 23)),
                        Location = new Point(startX, _x.Y + _x.Height + 2),
                        Cursor = Cursors.Default,
                        Font = Theme.Font(12)
                    };

                    _uploadButton.MouseClick += (o, args) =>
                    {
                        _activated = false;
                        ScreenshotAction = ScreenshotActionEnum.Upload;
                        ProcessImage();
                    };

                    Controls.Add(_uploadButton);

                    startX += _uploadButton.Width + 6;
                }
                else
                {
                    _uploadButton.Location = new Point(xStart, _x.Y + _x.Height + 2);
                    _uploadButton.Visible = true;
                    xStart += _uploadButton.Width + 6;
                }
            }

            if (_clipboardButton is null)
            {
                var saveToClipboardText = "Save to Clipboard";
                var measurement = TextRenderer.MeasureText(saveToClipboardText, Theme.Font(12));

                _clipboardButton = new ThemedButton()
                {
                    Scaled = false,
                    Text = saveToClipboardText,
                    Size = new Size(measurement.Width, (int)(scale * 23)),
                    Location = new Point(startX, _x.Y + _x.Height + 2),
                    Cursor = Cursors.Default,
                    Font = Theme.Font(12)
                };
                _clipboardButton.MouseClick += (_, _) =>
                {
                    _activated = false;
                    ScreenshotAction = ScreenshotActionEnum.SaveToClipboard;
                    ProcessImage();
                };

                Controls.Add(_clipboardButton);
                startX += _clipboardButton.Width + 6;
            }
            else
            {
                _clipboardButton.Location = new Point(xStart, _x.Y + _x.Height + 2);
                _clipboardButton.Visible = true;
                xStart += _clipboardButton.Width + 6;
            }

            if (_saveButton is null)
            {
                var saveToFileText = "Save to File";
                var measurement = TextRenderer.MeasureText(saveToFileText, Theme.Font(12));

                _saveButton = new ThemedButton()
                {
                    Scaled = false,
                    Text = saveToFileText,
                    Size = new Size(measurement.Width, (int)(scale * 23)),
                    Location = new Point(startX, _x.Y + _x.Height + 2),
                    Cursor = Cursors.Default,
                    Font = Theme.Font(12)
                };
                _saveButton.MouseClick += (_, _) =>
                {
                    _activated = false;
                    ScreenshotAction = ScreenshotActionEnum.SaveToFile;
                    ProcessImage();
                };

                Controls.Add(_saveButton);
                startX += _saveButton.Width + 6;
            }
            else
            {
                _saveButton.Location = new Point(xStart, _x.Y + _x.Height + 2);
                _saveButton.Visible = true;
                xStart += _saveButton.Width + 6;
            }

            if (_editButton is null)
            {
                var editButtonText = "Edit";
                var measurement = TextRenderer.MeasureText(editButtonText, Theme.Font(12));

                _editButton = new ThemedButton()
                {
                    Scaled = false,
                    Text = editButtonText,
                    Size = new Size(measurement.Width, (int)(scale * 23)),
                    Location = new Point(startX, _x.Y + _x.Height + 2),
                    Cursor = Cursors.Default,
                    Font = Theme.Font(12)
                };
                _editButton.MouseClick += (_, _) =>
                {
                    wasResizing = _resizing;

                    _editing = true;
                    _activated = false;
                    _resizing = false;
                    if (!WineDetectionService.IsWine())
                    {
                        if (_settings.Capture.ShowEditNotification)
                        {
                            Toast.Send(null,
                                "When you are done editing, press the 'E' key to go back to selecting your screenshot. You can use your scroll wheel to change colors",
                                "Don't Show Again", "dontShowEditNotification", "dontshow=true");
                        }
                    }

                    SetButtonVisibility(false);
                };

                Controls.Add(_editButton);
                startX += _editButton.Width + 6;
            }
            else
            {
                _editButton.Location = new Point(xStart, _x.Y + _x.Height + 2);
                _editButton.Visible = true;
                xStart += _editButton.Width + 6;
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

            if (_resizing && _x != Rectangle.Empty)
            {
                var startX = _x.X;
                var y = _x.Y + _x.Height + 2;
                if (y > Size.Height - (_uploadButton?.Height ?? _clipboardButton.Height))
                {
                    y = y - (_uploadButton?.Height ?? _clipboardButton.Height) - 2;
                    startX += 2;
                }

                if (_uploadButton is { })
                {
                    _uploadButton.Location = new Point(startX, y);
                    startX += _uploadButton.Width + 6;
                }

                if (_clipboardButton is { })
                {
                    _clipboardButton.Location = new Point(startX, y);
                    startX += _clipboardButton.Width + 6;
                }

                if (_saveButton is { })
                {
                    _saveButton.Location = new Point(startX, y);
                    startX += _saveButton.Width + 6;
                }

                if (_editButton is { })
                {
                    _editButton.Location = new Point(startX, y);
                    startX += _editButton.Width + 6;
                }
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
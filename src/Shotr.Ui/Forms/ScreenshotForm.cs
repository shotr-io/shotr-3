using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Shotr.Ui.Hotkey;
using Shotr.Ui.Utils;

namespace Shotr.Ui.Forms
{
    public partial class ScreenshotForm : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var Params = base.CreateParams;
                Params.ExStyle |= 0x80;
                return Params;
            }
        }

        private Bitmap screenshot;
        private Bitmap origscreenshot;

        private Point orig;
        private Pen pen = new Pen(Color.White, 1) { DashPattern = new float[] { 6.0F, 4.0F } };

        private Pen pen1 = new Pen(Color.White, 1);
        private Pen blackpen = new Pen(Color.Black, 1);
        private Brush brush = new SolidBrush(Color.White);
        private SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 0));
        private TextureBrush textbrush;
        private TextureBrush textbrushorig;

        private Rectangle x = Rectangle.Empty;

        private Font kfont = new Font(DefaultFont, FontStyle.Bold);

        private bool activated = false;
        private bool editing = false;
        private bool drawing = false;

        private bool information = (Program.Settings.GetValue("region_capture_information") != null ? (bool)Program.Settings.GetValue("region_capture_information")[0] : true);
        private bool zoom = (Program.Settings.GetValue("region_capture_zoom") != null ? (bool)Program.Settings.GetValue("region_capture_zoom")[0] : true);
        private bool color = (Program.Settings.GetValue("region_capture_color") != null ? (bool)Program.Settings.GetValue("region_capture_color")[0] : true);

        private Stopwatch stopwatch = Stopwatch.StartNew();

        private SingleInstance Tasks;

        public ScreenshotForm(Bitmap yolo, SingleInstance tasks)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            InitializeComponent();
            //
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;

            StartPosition = FormStartPosition.Manual;
            //this.TopMost = true;

            timer1.Interval = 10;
            timer1.Start();

            Paint += ScreenshotForm_Paint;
            FormBorderStyle = FormBorderStyle.None;
            int height = 0;
            int width = 0;
            int left = 0;
            int top = 0;
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

            screenshot = yolo;
            origscreenshot = (Bitmap)screenshot.Clone();
            screenshot = new Bitmap(screenshot, width, height);
            
            using (System.Drawing.Image image = Utils.Utils.Apply(Utils.Utils.Contrast(0.7f), screenshot))
            {
                TextureBrush brush = new TextureBrush(image);
                brush.WrapMode = WrapMode.Clamp;
                textbrush = brush;
            }

            TextureBrush brush1 = new TextureBrush(screenshot);
            brush1.WrapMode = WrapMode.Clamp;
            textbrushorig = brush1;

            DoubleBuffered = true;
            ShowInTaskbar = false;
            
            edit = Graphics.FromImage(screenshot);
            Tasks = tasks;
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
                if (resizing)
                {
                    resizing = false;
                    oldresizepos = Point.Empty;
                    Cursor = Cursors.Cross;
                    return;
                }
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
            else if (e.KeyCode == Keys.E)
            {
                if (!editing)
                {
                    editing = true;
                    activated = false;
                    //remember resizing & activated.
                    resizing = false;
                }
                else
                {
                    //save current image and get ready to output it on the form.
                    textbrush.Dispose();
                    using (System.Drawing.Image image = Utils.Utils.Apply(Utils.Utils.Contrast(0.7f), screenshot))
                    {
                        TextureBrush brush = new TextureBrush(image);
                        brush.WrapMode = WrapMode.Clamp;
                        textbrush = brush;
                    }
                    //this.textbrush.ScaleTransform((this.Size.Width / (this.Size.Width * Utils.getScalingFactor())), (this.Size.Height / (this.Size.Height * Utils.getScalingFactor())));
                    editing = false;
                }
                //turn on editing mode.
                
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (!editing)
                {
                    activated = false;
                    UploadImage();
                }
            }
        }

        public Bitmap GetProcessedImage()
        {
            return clonedBitmap;
        }
        private Bitmap clonedBitmap;
        private void UploadImage()
        {
            //save screenshot at x.
            System.Drawing.Imaging.PixelFormat format = screenshot.PixelFormat;
            try
            {
                clonedBitmap = screenshot.Clone(new Rectangle(new Point(x.X, x.Y), new Size(x.Width, x.Height)), format);
            }
            catch
            {
                //attempt to fix and re-clone.

                //check positions relative to the image, make sure they don't overlap.
                if (x.X + x.Width > screenshot.Width)
                {
                    x.Width = screenshot.Width - x.X;
                }
                if (x.Y + x.Height > screenshot.Height)
                {
                    x.Height = screenshot.Height - x.Y;
                }
                if (x.X < 0)
                {
                    int l = 0 - x.X;
                    x.Width -= l;
                    x.X = 0;
                }
                if (x.Y < 0)
                {
                    int l = 0 - x.Y;
                    x.Height -= l;
                    x.Y = 0;
                }

                //reclone.
                try
                {
                    clonedBitmap = screenshot.Clone(x, format);
                }
                catch
                {
                    //wot.
                    screenshot.Dispose();
                    Dispose();
                    Close();
                    //play error msg.
                    return;
                }
            }
            screenshot.Dispose();

            Hide();
        }
        Graphics edit;
        private int prex = 0;
        private int prey = 0;
        private Color chosenColor = Color.Red;
        private int colorIndex = 0;
        private List<Color> availableColors = new List<Color>()
        {
            Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Purple, Color.Black
        };
        private Pen chosenPen;

        private ResizeLocation resizelocation;
        private Point oldresizepos = Point.Empty;
        void ScreenshotForm_MouseMove(object sender, MouseEventArgs e)
        {
            //change cursor to scalable stuff if we're out of activated.
            Point mouse = PointToClient(Cursor.Position);
            if (!activated && resizing && !resizemove)
            {
                //left side.
                if ((mouse.X >= x.X - 4 && mouse.X <= x.X + 4) && (mouse.Y >= x.Y && mouse.Y <= x.Y + x.Height))
                {
                    Cursor = Cursors.SizeWE;                  
                }
                //right side.
                else if ((mouse.X >= x.X + x.Width - 4 && mouse.X <= x.X + x.Width + 4) && (mouse.Y >= x.Y && mouse.Y <= x.Y + x.Height))
                {
                    Cursor = Cursors.SizeWE;
                }
                //top
                else if((mouse.X >= x.X + 4 && mouse.X <= x.X + x.Width - 4) && (mouse.Y >= x.Y - 4 && mouse.Y <= x.Y + 4))
                {
                    Cursor = Cursors.SizeNS;
                }
                //bottom 
                else if((mouse.X >= x.X + 4 && mouse.X <= x.X + x.Width - 4) && (mouse.Y >= x.Y + x.Height - 4 && mouse.Y <= x.Y + x.Height + 4))
                {
                    Cursor = Cursors.SizeNS;
                }
                else if ((mouse.X >= x.X - 4 && mouse.X <= x.X + 4) && (mouse.Y >= x.Y - 4 && mouse.Y <= x.Y + 4))
                {
                    Cursor = Cursors.SizeNWSE;
                }
                else if ((mouse.X >= x.X + x.Width - 4 && mouse.X <= x.X + x.Width + 4) && (mouse.Y >= x.Y - 4 && mouse.Y <= x.Y + 4))
                {
                    Cursor = Cursors.SizeNESW;
                }
                else if ((mouse.X >= x.X + x.Width - 4 && mouse.X <= x.X + x.Width + 4) && (mouse.Y >= x.Y + x.Height - 4 && mouse.Y <= x.Y + x.Height + 4))
                {
                    Cursor = Cursors.SizeNWSE;
                }
                else if ((mouse.X >= x.X - 4 && mouse.X <= x.X + 4) && (mouse.Y >= x.Y + x.Height - 4 && mouse.Y <= x.Y + x.Height + 4))
                {
                    Cursor = Cursors.SizeNESW;
                }
                else if((mouse.X >= x.X && mouse.X <= x.X + x.Width && mouse.Y >= x.Y && mouse.Y <= x.Y + x.Height))
                {
                    Cursor = Cursors.SizeAll;
                }
                else
                {
                    Cursor = Cursors.Cross;
                }
            }
            else if (resizemove)
            {
                if (resizelocation == ResizeLocation.Left)
                {
                    //should work fine hopefully.
                    if (mouse.X > x.X)
                    {
                        if (x.Width >= 50)
                        {
                            //move inwards.
                            int output = (mouse.X - x.X);
                            x.X += output;
                            x.Width -= output;
                        }
                    }
                    else
                    {
                        
                        //move inwards.
                        int output = (x.X - mouse.X);
                        if (x.Width + output <= 50) { return; }
                        x.X -= output;
                        x.Width += output;
                       
                    }
                }
                else if (resizelocation == ResizeLocation.Right)
                {
                    //should work fine hopefully.
                    if (mouse.X > x.X + x.Width)
                    {
                        //move inwards.
                        int output = (mouse.X - x.X);
                        //x.X += output;
                        x.Width = output;
                    }
                    else
                    {
                        if (x.Width >= 50)
                        {
                            //move inwards.
                            int output = (x.X + x.Width - mouse.X);
                            x.Width -= output;
                        }
                    }
                }
                else if (resizelocation == ResizeLocation.Top)
                {
                    //should work fine hopefully.
                    if (mouse.Y > x.Y)
                    {
                        //move inwards.
                        if (x.Height >= 50)
                        {
                        int output = (mouse.Y - x.Y);
                        x.Y += output;
                        x.Height -= output;
                        }
                    }
                    else
                    {                  
                        int output = (x.Y - mouse.Y);
                        x.Y -= output;
                        x.Height += output;
                    }
                }
                else if (resizelocation == ResizeLocation.Bottom)
                {
                    //should work fine hopefully.
                    if (mouse.Y > x.Y + x.Height)
                    {
                        //move inwards.
                        int output = (mouse.Y - x.Y);
                        x.Height = output;
                    }
                    else
                    {
                        if (x.Height >= 50)
                        {
                            //move inwards.
                            int output = (x.Y + x.Height - mouse.Y);
                            x.Height -= output;
                        }
                    }
                }
                else if (resizelocation == ResizeLocation.TopLeft)
                {
                    if (mouse.X > x.X)
                    {
                        if (x.Width >= 50)
                        {
                            int output = (mouse.X - x.X);
                            x.X += output;
                            x.Width -= output;
                        }
                    }
                    if (mouse.Y > x.Y)
                    {
                        if (x.Height >= 50)
                        {
                            //move downwards.
                            int output = (mouse.Y - x.Y);
                            x.Y += output;
                            x.Height -= output;
                        }
                    }
                    if (mouse.X < x.X)
                    {
                        //move inwards.
                        int output = (x.X - mouse.X);
                        x.X -= output;
                        x.Width += output;
                    }
                    if (mouse.Y < x.Y)
                    {
                        //move inwards.
                        int output = (x.Y - mouse.Y);
                        x.Y -= output;
                        x.Height += output;
                    }
                }
                else if (resizelocation == ResizeLocation.TopRight)
                {
                    if (mouse.X > x.X + x.Width)
                    {
                        int output = (mouse.X - x.X);
                        x.Width = output;
                    }
                    if (mouse.Y > x.Y)
                    {
                        if (x.Height >= 50)
                        {
                            //move downwards.
                            int output = (mouse.Y - x.Y);
                            x.Y += output;
                            x.Height -= output;
                        }
                    }
                    if (mouse.X < x.X + x.Width)
                    {
                        if (x.Width >= 50)
                        {
                            //move inwards.
                            int output = (x.X + x.Width - mouse.X);
                            x.Width -= output;
                        }
                    }
                    if (mouse.Y < x.Y)
                    {
                        //move inwards.
                        int output = (x.Y - mouse.Y);
                        x.Y -= output;
                        x.Height += output;
                    }
                }
                else if (resizelocation == ResizeLocation.BottomRight)
                {
                    if (mouse.X > x.X + x.Width)
                    {
                        int output = (mouse.X - x.X);
                        x.Width = output;
                    }
                    if (mouse.Y > x.Y + x.Height)
                    {
                        //move inwards.
                        int output = (mouse.Y - x.Y);
                        x.Height = output;
                    }
                    if (mouse.X < x.X + x.Width)
                    {
                        if (x.Width >= 50)
                        {
                            //move inwards.
                            int output = (x.X + x.Width - mouse.X);
                            x.Width -= output;
                        }
                    }
                    if (mouse.Y < x.Y + x.Height)
                    {
                        if (x.Height >= 50)
                        {
                            //move inwards.
                            int output = (x.Y + x.Height - mouse.Y);
                            x.Height -= output;
                        }
                    }
                }
                else if (resizelocation == ResizeLocation.BottomLeft)
                {
                    if (mouse.X > x.X)
                    {
                        if (x.Width >= 50)
                        {
                            int output = (mouse.X - x.X);
                            x.X += output;
                            x.Width -= output;
                        }
                    }
                    if (mouse.Y > x.Y + x.Height)
                    {
                        //move inwards.
                        int output = (mouse.Y - x.Y);
                        x.Height += output;
                    }
                    if (mouse.X < x.X)
                    {                      
                        //move inwards.
                        int output = (x.X - mouse.X);
                        x.X -= output;
                        x.Width += output;
                    }
                    if (mouse.Y < x.Y + x.Height)
                    {
                        if (x.Height >= 50)
                        {
                            //move inwards.
                            int output = (x.Y + x.Height - mouse.Y);
                            x.Height -= output;
                        }
                    }
                }
                else if (resizelocation == ResizeLocation.Any)
                {
                    if(oldresizepos == Point.Empty) {
                        oldresizepos = mouse;
                        return;
                    }
                    //move relative to mouse.
                    x.X += (mouse.X - oldresizepos.X);
                    x.Y += (mouse.Y - oldresizepos.Y);
                    oldresizepos = mouse;
                }
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
            return (num <= min ? min : (num >= max ? max : num));
        }

        private Bitmap ShowSolidColor(System.Drawing.Image img, Point position, int width, int height, Color color)
        {
            Bitmap image = new Bitmap(width - 1, height - 1);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                graphics.FillRectangle(new SolidBrush(color), new Rectangle(0, 0, width, height));
                graphics.DrawRectangle(Pens.Black, 0, 0, width, height);
            }
            return image;
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
            if (!editing)
                e.Graphics.FillRectangle(textbrush, new Rectangle(0, 0, Size.Width, Size.Height));//this.Bounds);
            else
                e.Graphics.DrawImageUnscaled(screenshot, 0, 0);

            if (activated && x.Height > 1 && x.Width > 1)
            {
                try
                {
                    e.Graphics.DrawImage(screenshot, x, x, GraphicsUnit.Pixel);

                    pen.DashOffset = ((int)(stopwatch.Elapsed.TotalMilliseconds / 100.0)) % 10;
                    e.Graphics.DrawRectangle(pen, x);
                    if ((x.Width > 250 && x.Height > kfont.Height * 2.2) && information)
                    {
                        e.Graphics.DrawString(string.Format("X: {0} / Y: {1}{2}", x.X, x.Y, (color ? " - " + GetHexCode(screenshot.GetPixel(PointToClient(Cursor.Position).X, PointToClient(Cursor.Position).Y)) : "")), kfont, brush, new PointF(x.X, x.Y));
                        e.Graphics.DrawString(string.Format("W: {0} / H: {1}", x.Width, x.Height), kfont, brush, new PointF(x.X, x.Y + kfont.Height));
                    }
                }
                catch { }
            }
            else if(resizing)
            {
                try
                {
                    e.Graphics.DrawImage(screenshot, x, x, GraphicsUnit.Pixel);

                    pen.DashOffset = ((int)(stopwatch.Elapsed.TotalMilliseconds / 100.0)) % 10;
                    e.Graphics.DrawRectangle(pen, x);
                    if ((x.Width > 250 && x.Height > kfont.Height * 2.2) && information)
                    {
                        e.Graphics.DrawString(string.Format("X: {0} / Y: {1}{2}", x.X, x.Y, (color ? " - " + GetHexCode(screenshot.GetPixel(PointToClient(Cursor.Position).X, PointToClient(Cursor.Position).Y)) : "")), kfont, brush, new PointF(x.X, x.Y));
                        e.Graphics.DrawString(string.Format("W: {0} / H: {1}", x.Width, x.Height), kfont, brush, new PointF(x.X, x.Y + kfont.Height));
                    }
                }
                catch { }
            }
            //draw shit on form graphics.            
            if (editing && drawing)
            {
                Point cursorloc = PointToClient(Cursor.Position);
                //edit.DrawImage(screenshot, new Rectangle(0, 0, this.Bounds.Width, this.Bounds.Height));
                edit.SmoothingMode = SmoothingMode.HighQuality;
                edit.DrawLine(chosenPen, prex, prey, cursorloc.X, cursorloc.Y);
                //edit.FillEllipse(Brushes.Red, new Rectangle(e.X, e.Y, 4, 4));
                prex = cursorloc.X;
                prey = cursorloc.Y;
            }

            if (zoom)
            {
                //check if screen isn't big enough to fit on right side, if so then fit on left side.
                Point location = new Point(0, 0);
                Point cursorloc = PointToClient(Cursor.Position);
                using (Bitmap magnifier = (editing ? ShowSolidColor(screenshot, new Point(cursorloc.X, cursorloc.Y), 50, 50, chosenColor) :  Magnifier(screenshot, new Point(cursorloc.X, cursorloc.Y), 10, 10, 10)))
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
            MouseMove += ScreenshotForm_MouseMove;
            MouseDown += ScreenshotForm_MouseDown;
            MouseUp += ScreenshotForm_MouseUp;
            MouseWheel += ScreenshotForm_MouseWheel;
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

        void ScreenshotForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (editing)
            {
                if (e.Delta > 0)
                {
                    colorIndex++;
                    if (colorIndex >= availableColors.Count) colorIndex = 0;
                    chosenColor = availableColors[colorIndex];
                }
                else
                {
                    colorIndex--;
                    if (colorIndex < 0) colorIndex = availableColors.Count - 1;
                    chosenColor = availableColors[colorIndex];
                }
            }
        }
        private bool resizing = false;
        private bool resizemove = false;
        void ScreenshotForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (resizing)
            {
                resizemove = false;
                oldresizepos = Point.Empty;
                resizelocation = ResizeLocation.None;
                return;
            }

            if (!editing)
            {
                if (((bool)Program.Settings.GetValue("screenshot.use_resizable_canvas")[0]) == false)
                {
                    UploadImage();
                    return;
                }
                activated = false;
                resizing = true;
            }
            else 
            {
                drawing = false;
                if (e.Button == MouseButtons.Right)
                {
                    //clear drawings.
                    screenshot.Dispose();
                    screenshot = (Bitmap)origscreenshot.Clone();
                    edit = Graphics.FromImage(screenshot);
                }
            }
        }

        void ScreenshotForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (resizing)
            {
                Point mouse = PointToClient(Cursor.Position);
                if ((mouse.X >= x.X - 4 && mouse.X <= x.X + 4) && (mouse.Y >= x.Y + 4 && mouse.Y <= x.Y + x.Height - 4))
                {
                    resizelocation = ResizeLocation.Left;
                }
                else if ((mouse.X >= x.X + x.Width - 4 && mouse.X <= x.X + x.Width + 4) && (mouse.Y >= x.Y + 4 && mouse.Y <= x.Y + x.Height - 4))
                {
                    resizelocation = ResizeLocation.Right;
                }
                else if ((mouse.X >= x.X + 4 && mouse.X <= x.X + x.Width - 4) && (mouse.Y >= x.Y - 4 && mouse.Y <= x.Y + 4))
                {
                    resizelocation = ResizeLocation.Top;
                }
                else if ((mouse.X >= x.X + 4 && mouse.X <= x.X + x.Width - 4) && (mouse.Y >= x.Y + x.Height - 4 && mouse.Y <= x.Y + x.Height + 4))
                {
                    resizelocation = ResizeLocation.Bottom;
                }
                else if ((mouse.X >= x.X - 4 && mouse.X <= x.X + 4) && (mouse.Y >= x.Y - 4 && mouse.Y <= x.Y + 4))
                {
                    resizelocation = ResizeLocation.TopLeft;
                }
                else if ((mouse.X >= x.X + x.Width - 4 && mouse.X <= x.X + x.Width + 4) && (mouse.Y >= x.Y - 4 && mouse.Y <= x.Y + 4))
                {
                    resizelocation = ResizeLocation.TopRight;                   
                }
                else if ((mouse.X >= x.X + x.Width - 4 && mouse.X <= x.X + x.Width + 4) && (mouse.Y >= x.Y + x.Height - 4 && mouse.Y <= x.Y + x.Height + 4))
                {
                    resizelocation = ResizeLocation.BottomRight;
                }
                else if ((mouse.X >= x.X - 4 && mouse.X <= x.X + 4) && (mouse.Y >= x.Y + x.Height - 4 && mouse.Y <= x.Y + x.Height + 4))
                {
                    resizelocation = ResizeLocation.BottomLeft;
                }
                else if((mouse.X >= x.X && mouse.X <= x.X + x.Width && mouse.Y >= x.Y && mouse.Y <= x.Y + x.Height))
                {
                    resizelocation = ResizeLocation.Any;
                }
                resizemove = true;
                return;
            }

            if (!editing)
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
            else
            {
                //choose pen.
                chosenPen = new Pen(chosenColor, 3);
                //draw shit on theform.
                prex = e.X;
                prey = e.Y;
                drawing = true;
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

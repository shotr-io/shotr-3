using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Shotr.Ui.DpiScaling;
using Shotr.Ui.Utils;

namespace Shotr.Ui.Forms
{
    public partial class Notification : DpiScaledForm
    {
        private int time = 5;
        private FormAnimator animator;

        private bool animatingout = false;
        
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        private const int WS_EX_TOPMOST = 0x00000008;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= WS_EX_TOPMOST;
                return createParams;
            }
        } 
        
        public Notification(string url, System.Drawing.Image ico, string mime) : base()
        {
            InitializeComponent();
            ManualDpiScale();
            ScaleForm = false;
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - Width, Screen.PrimaryScreen.WorkingArea.Height - Height);
            ShadowType = MetroFormShadowType.None;
            StartPosition = FormStartPosition.Manual;
            metroLink1.Text = url;
            metroLabel1.Text = (mime.Contains("text") ? "Text Uploaded!" : (mime.Contains("video") ? "Recording Uploaded!" : "Screenshot Uploaded!"));
            Closing += Notification_Closing;
            animator = new FormAnimator(this);
            animator.Direction = FormAnimator.AnimationDirection.Up;
            animator.Method = FormAnimator.AnimationMethod.Slide;
            animator.Duration = 500;
        }

        void Notification_Closing(object sender, CancelEventArgs e)
        {
            if (animatingout == false)
            {
                e.Cancel = true;
                ShadowType = MetroFormShadowType.None;
                animatingout = true;
                Close();
            }
        }
        

        private void Notification_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
            new Thread(delegate()
            {
                Thread.Sleep(500);
                Invoke((MethodInvoker)(() =>
                {
                    ShadowType = MetroFormShadowType.DropShadow;
                }));
                animator.Direction = FormAnimator.AnimationDirection.Down;
            }).Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (time-- < 0)
                Close();
        }

        public new void Show()
        {
            base.Show();
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(metroLink1.Text);
            }
            catch { }
        }
    }
}

using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Shotr.Core.DpiScaling;
using Shotr.Core.Utils;

namespace Shotr.Ui.Forms
{
    public partial class NoUploadNotification : DpiScaledForm
    {
        private int time = 5;
        private FormAnimator animator;
        
        private bool animatingout;
        
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000008; //WS_EX_TOPMOST 
                return cp;
            }
        }

        public NoUploadNotification(Image ico, string mime)
        {
            InitializeComponent();
            ManualDpiScale();
            ScaleForm = false;
            ShadowType = MetroFormShadowType.None;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - Width, Screen.PrimaryScreen.WorkingArea.Height - Height);
            metroLabel1.Text = (mime.Contains("text") ? "Text Saved!" : (mime.Contains("video") ? "Recording Saved!" : "Screenshot Saved!"));
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
            //this.AnimateWindow(false);
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
    }
}

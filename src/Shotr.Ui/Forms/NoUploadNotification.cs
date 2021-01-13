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
        private int _time = 5;
        private FormAnimator _animator;
        
        private bool _animatingout;
        
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
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
            _animator = new FormAnimator(this);
            _animator.Direction = FormAnimator.AnimationDirection.Up;
            _animator.Method = FormAnimator.AnimationMethod.Slide;
            _animator.Duration = 500;
        }

        void Notification_Closing(object sender, CancelEventArgs e)
        {
            if (_animatingout == false)
            {
                e.Cancel = true;
                ShadowType = MetroFormShadowType.None;
                _animatingout = true;
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
                _animator.Direction = FormAnimator.AnimationDirection.Down;
            }).Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_time-- < 0)
                Close();
        }

        public new void Show()
        {
            base.Show();
        }
    }
}

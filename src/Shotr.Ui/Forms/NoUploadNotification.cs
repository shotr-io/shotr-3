using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Shotr.Core.Controls;
using Shotr.Core.Controls.Theme;

namespace Shotr.Ui.Forms
{
    public partial class NoUploadNotification : ThemedForm
    {
        private int _time = 5;
        private FormAnimator _animator;
        
        private bool _animatingout;
        
        protected override bool ShowWithoutActivation => true;

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x00000008; //WS_EX_TOPMOST 
                return cp;
            }
        }

        protected override void OnControlScaled(float scalingFactor)
        {
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - Width, Screen.PrimaryScreen.WorkingArea.Height - Height);
        }

        public NoUploadNotification(string mime)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Closing += Notification_Closing;
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - Width, Screen.PrimaryScreen.WorkingArea.Height - Height);
            _animator = new FormAnimator(this);
            _animator.Direction = FormAnimator.AnimationDirection.Up;
            _animator.Method = FormAnimator.AnimationMethod.Slide;
            _animator.Duration = 500;
            
            metroLabel1.Text = mime.Contains("text") ? "Text Saved!" : mime.Contains("video") ? "Recording Saved!" : "Screenshot Saved!";
        }

        void Notification_Closing(object sender, CancelEventArgs e)
        {
            if (_animatingout == false)
            {
                e.Cancel = true;
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

        private void themedButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

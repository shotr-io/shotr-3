using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Shotr.Core.Controls;
using Shotr.Core.Controls.DpiScaling;
using Shotr.Core.Uploader;
using ShotrUploaderPlugin;

namespace Shotr.Ui.Forms
{
    public partial class ErrorNotification : DpiScaledForm
    {
        private readonly Uploader _uploader;
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
        private ImageShell _failed;
        public ErrorNotification(ImageShell failedImg, UploadedImageJsonResult result)
        {
            InitializeComponent();
            ManualDpiScale();
            ScaleForm = false;
            ShadowType = MetroFormShadowType.None;
            StartPosition = FormStartPosition.Manual;           
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - Width, Screen.PrimaryScreen.WorkingArea.Height - Height);
            Closing += ErrorNotification_Closing;
            _animator = new FormAnimator(this);
            _animator.Direction = FormAnimator.AnimationDirection.Up;
            _animator.Method = FormAnimator.AnimationMethod.Slide;
            _animator.Duration = 500;
            if (_failed != null)
            {
                _failed = failedImg;
                if (result != null)
                {
                    if (!string.IsNullOrEmpty(result.ErrorMessage))
                    {
                        try
                        {
                            metroLabel2.Text = result.ErrorMessage;
                        }
                        catch
                        {
                            metroLabel2.Text = (_failed.Extension == FileExtensions.mp4
                                                    ? "There was an error while uploading your recording."
                                                    : "There was an error while uploading your screenshot.");
                        }
                    }
                    else
                        metroLabel2.Text = (_failed.Extension == FileExtensions.mp4
                                                ? "There was an error while uploading your recording."
                                                : "There was an error while uploading your screenshot.");
                }
                else
                {
                    metroLabel2.Text = "There was an error.";
                }
            }
            else
            {
                metroLabel2.Text = result.ErrorMessage;
                metroButton1.Hide();
            }
        }

        void ErrorNotification_Closing(object sender, CancelEventArgs e)
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
            OnVisibleChanged(e);
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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            _uploader.AddToQueue(_failed);
            Close();
        }
    }
}

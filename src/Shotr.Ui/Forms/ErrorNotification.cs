using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Shotr.Ui.DpiScaling;
using Shotr.Ui.Uploader;
using Shotr.Ui.Utils;
using ShotrUploaderPlugin;

namespace Shotr.Ui.Forms
{
    public partial class ErrorNotification : DpiScaledForm
    {
        private int time = 5;
        private FormAnimator animator;

        private bool animatingout = false;
        
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
        private ImageShell failed;
        public ErrorNotification(System.Drawing.Image ico, ImageShell failedImg, UploadedImageJsonResult result)
        {
            InitializeComponent();
            ManualDpiScale();
            ScaleForm = false;
            ShadowType = MetroFormShadowType.None;
            StartPosition = FormStartPosition.Manual;           
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - Width, Screen.PrimaryScreen.WorkingArea.Height - Height);
            Closing += ErrorNotification_Closing;
            animator = new FormAnimator(this);
            animator.Direction = FormAnimator.AnimationDirection.Up;
            animator.Method = FormAnimator.AnimationMethod.Slide;
            animator.Duration = 500;
            if (failed != null)
            {
                failed = failedImg;
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
                            metroLabel2.Text = (failed.Extension == FileExtensions.mp4
                                ? "There was an error while uploading your recording."
                                : "There was an error while uploading your screenshot.");
                        }
                    }
                    else
                        metroLabel2.Text = (failed.Extension == FileExtensions.mp4
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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Uploader.Uploader.AddToQueue(failed);
            Close();
        }
    }
}

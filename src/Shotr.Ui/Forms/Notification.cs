﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Shotr.Core.DpiScaling;
using Shotr.Core.Utils;

namespace Shotr.Ui.Forms
{
    public partial class Notification : DpiScaledForm
    {
        private int _time = 5;
        private FormAnimator _animator;

        private bool _animatingout;
        
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        private const int WS_EX_TOPMOST = 0x00000008;
        protected override CreateParams CreateParams
        {
            get
            {
                var createParams = base.CreateParams;
                createParams.ExStyle |= WS_EX_TOPMOST;
                return createParams;
            }
        } 
        
        public Notification(string url, Image ico, string mime)
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

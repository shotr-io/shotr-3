using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Shotr.Core.Controls.DpiScaling {
	#region Control
	public class DpiScaledControl : Control
    {
        public virtual bool Scaled { get; set; } = true;
        public virtual bool BasePaint { get; set; } = false;

        private Size _originalSize { get; set; }
        private Point _originalLocation { get; set; }
        private bool _alreadyRan { get; set; }

        public DpiScaledControl() 
        {
            SystemEvents.DisplaySettingsChanged += OnDisplaySettingsChanged;
        }

        private void OnDisplaySettingsChanged(object? sender, EventArgs args) 
        {
            Scale();
        }

        protected virtual void OnControlScaled(float scalingFactor) 
        {
        }

        protected override void OnPaint(PaintEventArgs e) 
        {
            Scale();

            if (BasePaint) 
            {
                base.OnPaint(e);
            }
        }

        private void Scale()
        {
            if (DpiScaler.NotDpiScaling(this))
            {    
                return;
            }

            if (!_alreadyRan)
            {
                _alreadyRan = true;
            }
            else 
            {
                return;
            }

            if (Scaled)
            {
                (_originalSize, _originalLocation) = DpiScaler.ScaleControl(this, _originalSize, _originalLocation, true);
                Console.WriteLine($"DPI Scaled Control: {Text} - Size: {Width}x{Height} (orig {_originalSize.Width}x{_originalSize.Height}), Location: {Location.X}x{Location.Y} (orig: {_originalLocation.X}x{_originalLocation.Y})");
                OnControlScaled(DpiScaler.GetScalingFactor(this));
            }
        }

        public void ManualDpiScale()
        {
            (_originalSize, _originalLocation) = DpiScaler.ScaleSize(this, _originalSize, _originalLocation);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            SystemEvents.DisplaySettingsChanged -= OnDisplaySettingsChanged;
        }
    }
    #endregion

	#region Button
	public class DpiScaledButton : Button
    {
        public virtual bool Scaled { get; set; } = true;
        public virtual bool BasePaint { get; set; } = false;

        private Size _originalSize { get; set; }
        private Point _originalLocation { get; set; }
        private bool _alreadyRan { get; set; }

        public DpiScaledButton() 
        {
            SystemEvents.DisplaySettingsChanged += OnDisplaySettingsChanged;
        }

        private void OnDisplaySettingsChanged(object? sender, EventArgs args) 
        {
            Scale();
        }

        protected virtual void OnControlScaled(float scalingFactor) 
        {
        }

        protected override void OnPaint(PaintEventArgs e) 
        {
            Scale();

            if (BasePaint) 
            {
                base.OnPaint(e);
            }
        }

        private void Scale()
        {
            if (DpiScaler.NotDpiScaling(this))
            {    
                return;
            }

            if (!_alreadyRan)
            {
                _alreadyRan = true;
            }
            else 
            {
                return;
            }

            if (Scaled)
            {
                (_originalSize, _originalLocation) = DpiScaler.ScaleControl(this, _originalSize, _originalLocation, true);
                Console.WriteLine($"DPI Scaled Button: {Text} - Size: {Width}x{Height} (orig {_originalSize.Width}x{_originalSize.Height}), Location: {Location.X}x{Location.Y} (orig: {_originalLocation.X}x{_originalLocation.Y})");
                OnControlScaled(DpiScaler.GetScalingFactor(this));
            }
        }

        public void ManualDpiScale()
        {
            (_originalSize, _originalLocation) = DpiScaler.ScaleSize(this, _originalSize, _originalLocation);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            SystemEvents.DisplaySettingsChanged -= OnDisplaySettingsChanged;
        }
    }
    #endregion

	#region CheckBox
	public class DpiScaledCheckBox : CheckBox
    {
        public virtual bool Scaled { get; set; } = true;
        public virtual bool BasePaint { get; set; } = false;

        private Size _originalSize { get; set; }
        private Point _originalLocation { get; set; }
        private bool _alreadyRan { get; set; }

        public DpiScaledCheckBox() 
        {
            SystemEvents.DisplaySettingsChanged += OnDisplaySettingsChanged;
        }

        private void OnDisplaySettingsChanged(object? sender, EventArgs args) 
        {
            Scale();
        }

        protected virtual void OnControlScaled(float scalingFactor) 
        {
        }

        protected override void OnPaint(PaintEventArgs e) 
        {
            Scale();

            if (BasePaint) 
            {
                base.OnPaint(e);
            }
        }

        private void Scale()
        {
            if (DpiScaler.NotDpiScaling(this))
            {    
                return;
            }

            if (!_alreadyRan)
            {
                _alreadyRan = true;
            }
            else 
            {
                return;
            }

            if (Scaled)
            {
                (_originalSize, _originalLocation) = DpiScaler.ScaleControl(this, _originalSize, _originalLocation, true);
                Console.WriteLine($"DPI Scaled CheckBox: {Text} - Size: {Width}x{Height} (orig {_originalSize.Width}x{_originalSize.Height}), Location: {Location.X}x{Location.Y} (orig: {_originalLocation.X}x{_originalLocation.Y})");
                OnControlScaled(DpiScaler.GetScalingFactor(this));
            }
        }

        public void ManualDpiScale()
        {
            (_originalSize, _originalLocation) = DpiScaler.ScaleSize(this, _originalSize, _originalLocation);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            SystemEvents.DisplaySettingsChanged -= OnDisplaySettingsChanged;
        }
    }
    #endregion

	#region ListView
	public class DpiScaledListView : ListView
    {
        public virtual bool Scaled { get; set; } = true;
        public virtual bool BasePaint { get; set; } = false;

        private Size _originalSize { get; set; }
        private Point _originalLocation { get; set; }
        private bool _alreadyRan { get; set; }

        public DpiScaledListView() 
        {
            SystemEvents.DisplaySettingsChanged += OnDisplaySettingsChanged;
        }

        private void OnDisplaySettingsChanged(object? sender, EventArgs args) 
        {
            Scale();
        }

        protected virtual void OnControlScaled(float scalingFactor) 
        {
        }

        protected override void OnPaint(PaintEventArgs e) 
        {
            Scale();

            if (BasePaint) 
            {
                base.OnPaint(e);
            }
        }

        private void Scale()
        {
            if (DpiScaler.NotDpiScaling(this))
            {    
                return;
            }

            if (!_alreadyRan)
            {
                _alreadyRan = true;
            }
            else 
            {
                return;
            }

            if (Scaled)
            {
                (_originalSize, _originalLocation) = DpiScaler.ScaleControl(this, _originalSize, _originalLocation, true);
                Console.WriteLine($"DPI Scaled ListView: {Text} - Size: {Width}x{Height} (orig {_originalSize.Width}x{_originalSize.Height}), Location: {Location.X}x{Location.Y} (orig: {_originalLocation.X}x{_originalLocation.Y})");
                OnControlScaled(DpiScaler.GetScalingFactor(this));
            }
        }

        public void ManualDpiScale()
        {
            (_originalSize, _originalLocation) = DpiScaler.ScaleSize(this, _originalSize, _originalLocation);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            SystemEvents.DisplaySettingsChanged -= OnDisplaySettingsChanged;
        }
    }
    #endregion

	#region PictureBox
	public class DpiScaledPictureBox : PictureBox
    {
        public virtual bool Scaled { get; set; } = true;
        public virtual bool BasePaint { get; set; } = false;

        private Size _originalSize { get; set; }
        private Point _originalLocation { get; set; }
        private bool _alreadyRan { get; set; }

        public DpiScaledPictureBox() 
        {
            SystemEvents.DisplaySettingsChanged += OnDisplaySettingsChanged;
        }

        private void OnDisplaySettingsChanged(object? sender, EventArgs args) 
        {
            Scale();
        }

        protected virtual void OnControlScaled(float scalingFactor) 
        {
        }

        protected override void OnPaint(PaintEventArgs e) 
        {
            Scale();

            if (BasePaint) 
            {
                base.OnPaint(e);
            }
        }

        private void Scale()
        {
            if (DpiScaler.NotDpiScaling(this))
            {    
                return;
            }

            if (!_alreadyRan)
            {
                _alreadyRan = true;
            }
            else 
            {
                return;
            }

            if (Scaled)
            {
                (_originalSize, _originalLocation) = DpiScaler.ScaleControl(this, _originalSize, _originalLocation, true);
                Console.WriteLine($"DPI Scaled PictureBox: {Text} - Size: {Width}x{Height} (orig {_originalSize.Width}x{_originalSize.Height}), Location: {Location.X}x{Location.Y} (orig: {_originalLocation.X}x{_originalLocation.Y})");
                OnControlScaled(DpiScaler.GetScalingFactor(this));
            }
        }

        public void ManualDpiScale()
        {
            (_originalSize, _originalLocation) = DpiScaler.ScaleSize(this, _originalSize, _originalLocation);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            SystemEvents.DisplaySettingsChanged -= OnDisplaySettingsChanged;
        }
    }
    #endregion

	#region ComboBox
	public class DpiScaledComboBox : ComboBox
    {
        public virtual bool Scaled { get; set; } = true;
        public virtual bool BasePaint { get; set; } = false;

        private Size _originalSize { get; set; }
        private Point _originalLocation { get; set; }
        private bool _alreadyRan { get; set; }

        public DpiScaledComboBox() 
        {
            SystemEvents.DisplaySettingsChanged += OnDisplaySettingsChanged;
        }

        private void OnDisplaySettingsChanged(object? sender, EventArgs args) 
        {
            Scale();
        }

        protected virtual void OnControlScaled(float scalingFactor) 
        {
        }

        protected override void OnPaint(PaintEventArgs e) 
        {
            Scale();

            if (BasePaint) 
            {
                base.OnPaint(e);
            }
        }

        private void Scale()
        {
            if (DpiScaler.NotDpiScaling(this))
            {    
                return;
            }

            if (!_alreadyRan)
            {
                _alreadyRan = true;
            }
            else 
            {
                return;
            }

            if (Scaled)
            {
                (_originalSize, _originalLocation) = DpiScaler.ScaleControl(this, _originalSize, _originalLocation, true);
                Console.WriteLine($"DPI Scaled ComboBox: {Text} - Size: {Width}x{Height} (orig {_originalSize.Width}x{_originalSize.Height}), Location: {Location.X}x{Location.Y} (orig: {_originalLocation.X}x{_originalLocation.Y})");
                OnControlScaled(DpiScaler.GetScalingFactor(this));
            }
        }

        public void ManualDpiScale()
        {
            (_originalSize, _originalLocation) = DpiScaler.ScaleSize(this, _originalSize, _originalLocation);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            SystemEvents.DisplaySettingsChanged -= OnDisplaySettingsChanged;
        }
    }
    #endregion

	#region Form
	public class DpiScaledForm : Form
    {
        public virtual bool Scaled { get; set; } = true;
        public virtual bool BasePaint { get; set; } = false;

        private Size _originalSize { get; set; }
        private Point _originalLocation { get; set; }
        private bool _alreadyRan { get; set; }

        public DpiScaledForm() 
        {
            SystemEvents.DisplaySettingsChanged += OnDisplaySettingsChanged;
        }

        private void OnDisplaySettingsChanged(object? sender, EventArgs args) 
        {
            Scale();
        }

        protected virtual void OnControlScaled(float scalingFactor) 
        {
        }

        protected override void OnPaint(PaintEventArgs e) 
        {
            Scale();

            if (BasePaint) 
            {
                base.OnPaint(e);
            }
        }

        private void Scale()
        {
            if (DpiScaler.NotDpiScaling(this))
            {    
                return;
            }

            if (!_alreadyRan)
            {
                _alreadyRan = true;
            }
            else 
            {
                return;
            }

            if (Scaled)
            {
                (_originalSize, _originalLocation) = DpiScaler.ScaleControl(this, _originalSize, _originalLocation, false);
                Console.WriteLine($"DPI Scaled Form: {Text} - Size: {Width}x{Height} (orig {_originalSize.Width}x{_originalSize.Height}), Location: {Location.X}x{Location.Y} (orig: {_originalLocation.X}x{_originalLocation.Y})");
                OnControlScaled(DpiScaler.GetScalingFactor(this));
            }
        }

        public void ManualDpiScale()
        {
            (_originalSize, _originalLocation) = DpiScaler.ScaleSize(this, _originalSize, _originalLocation);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            SystemEvents.DisplaySettingsChanged -= OnDisplaySettingsChanged;
        }
    }
    #endregion

	#region Label
	public class DpiScaledLabel : Label
    {
        public virtual bool Scaled { get; set; } = true;
        public virtual bool BasePaint { get; set; } = false;

        private Size _originalSize { get; set; }
        private Point _originalLocation { get; set; }
        private bool _alreadyRan { get; set; }

        public DpiScaledLabel() 
        {
            SystemEvents.DisplaySettingsChanged += OnDisplaySettingsChanged;
        }

        private void OnDisplaySettingsChanged(object? sender, EventArgs args) 
        {
            Scale();
        }

        protected virtual void OnControlScaled(float scalingFactor) 
        {
        }

        protected override void OnPaint(PaintEventArgs e) 
        {
            Scale();

            if (BasePaint) 
            {
                base.OnPaint(e);
            }
        }

        private void Scale()
        {
            if (DpiScaler.NotDpiScaling(this))
            {    
                return;
            }

            if (!_alreadyRan)
            {
                _alreadyRan = true;
            }
            else 
            {
                return;
            }

            if (Scaled)
            {
                (_originalSize, _originalLocation) = DpiScaler.ScaleControl(this, _originalSize, _originalLocation, true);
                Console.WriteLine($"DPI Scaled Label: {Text} - Size: {Width}x{Height} (orig {_originalSize.Width}x{_originalSize.Height}), Location: {Location.X}x{Location.Y} (orig: {_originalLocation.X}x{_originalLocation.Y})");
                OnControlScaled(DpiScaler.GetScalingFactor(this));
            }
        }

        public void ManualDpiScale()
        {
            (_originalSize, _originalLocation) = DpiScaler.ScaleSize(this, _originalSize, _originalLocation);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            SystemEvents.DisplaySettingsChanged -= OnDisplaySettingsChanged;
        }
    }
    #endregion

	#region LinkLabel
	public class DpiScaledLinkLabel : LinkLabel
    {
        public virtual bool Scaled { get; set; } = true;
        public virtual bool BasePaint { get; set; } = false;

        private Size _originalSize { get; set; }
        private Point _originalLocation { get; set; }
        private bool _alreadyRan { get; set; }

        public DpiScaledLinkLabel() 
        {
            SystemEvents.DisplaySettingsChanged += OnDisplaySettingsChanged;
        }

        private void OnDisplaySettingsChanged(object? sender, EventArgs args) 
        {
            Scale();
        }

        protected virtual void OnControlScaled(float scalingFactor) 
        {
        }

        protected override void OnPaint(PaintEventArgs e) 
        {
            Scale();

            if (BasePaint) 
            {
                base.OnPaint(e);
            }
        }

        private void Scale()
        {
            if (DpiScaler.NotDpiScaling(this))
            {    
                return;
            }

            if (!_alreadyRan)
            {
                _alreadyRan = true;
            }
            else 
            {
                return;
            }

            if (Scaled)
            {
                (_originalSize, _originalLocation) = DpiScaler.ScaleControl(this, _originalSize, _originalLocation, true);
                Console.WriteLine($"DPI Scaled LinkLabel: {Text} - Size: {Width}x{Height} (orig {_originalSize.Width}x{_originalSize.Height}), Location: {Location.X}x{Location.Y} (orig: {_originalLocation.X}x{_originalLocation.Y})");
                OnControlScaled(DpiScaler.GetScalingFactor(this));
            }
        }

        public void ManualDpiScale()
        {
            (_originalSize, _originalLocation) = DpiScaler.ScaleSize(this, _originalSize, _originalLocation);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            SystemEvents.DisplaySettingsChanged -= OnDisplaySettingsChanged;
        }
    }
    #endregion

	#region Panel
	public class DpiScaledPanel : Panel
    {
        public virtual bool Scaled { get; set; } = true;
        public virtual bool BasePaint { get; set; } = false;

        private Size _originalSize { get; set; }
        private Point _originalLocation { get; set; }
        private bool _alreadyRan { get; set; }

        public DpiScaledPanel() 
        {
            SystemEvents.DisplaySettingsChanged += OnDisplaySettingsChanged;
        }

        private void OnDisplaySettingsChanged(object? sender, EventArgs args) 
        {
            Scale();
        }

        protected virtual void OnControlScaled(float scalingFactor) 
        {
        }

        protected override void OnPaint(PaintEventArgs e) 
        {
            Scale();

            if (BasePaint) 
            {
                base.OnPaint(e);
            }
        }

        private void Scale()
        {
            if (DpiScaler.NotDpiScaling(this))
            {    
                return;
            }

            if (!_alreadyRan)
            {
                _alreadyRan = true;
            }
            else 
            {
                return;
            }

            if (Scaled)
            {
                (_originalSize, _originalLocation) = DpiScaler.ScaleControl(this, _originalSize, _originalLocation, true);
                Console.WriteLine($"DPI Scaled Panel: {Text} - Size: {Width}x{Height} (orig {_originalSize.Width}x{_originalSize.Height}), Location: {Location.X}x{Location.Y} (orig: {_originalLocation.X}x{_originalLocation.Y})");
                OnControlScaled(DpiScaler.GetScalingFactor(this));
            }
        }

        public void ManualDpiScale()
        {
            (_originalSize, _originalLocation) = DpiScaler.ScaleSize(this, _originalSize, _originalLocation);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            SystemEvents.DisplaySettingsChanged -= OnDisplaySettingsChanged;
        }
    }
    #endregion

	#region ProgressBar
	public class DpiScaledProgressBar : ProgressBar
    {
        public virtual bool Scaled { get; set; } = true;
        public virtual bool BasePaint { get; set; } = false;

        private Size _originalSize { get; set; }
        private Point _originalLocation { get; set; }
        private bool _alreadyRan { get; set; }

        public DpiScaledProgressBar() 
        {
            SystemEvents.DisplaySettingsChanged += OnDisplaySettingsChanged;
        }

        private void OnDisplaySettingsChanged(object? sender, EventArgs args) 
        {
            Scale();
        }

        protected virtual void OnControlScaled(float scalingFactor) 
        {
        }

        protected override void OnPaint(PaintEventArgs e) 
        {
            Scale();

            if (BasePaint) 
            {
                base.OnPaint(e);
            }
        }

        private void Scale()
        {
            if (DpiScaler.NotDpiScaling(this))
            {    
                return;
            }

            if (!_alreadyRan)
            {
                _alreadyRan = true;
            }
            else 
            {
                return;
            }

            if (Scaled)
            {
                (_originalSize, _originalLocation) = DpiScaler.ScaleControl(this, _originalSize, _originalLocation, true);
                Console.WriteLine($"DPI Scaled ProgressBar: {Text} - Size: {Width}x{Height} (orig {_originalSize.Width}x{_originalSize.Height}), Location: {Location.X}x{Location.Y} (orig: {_originalLocation.X}x{_originalLocation.Y})");
                OnControlScaled(DpiScaler.GetScalingFactor(this));
            }
        }

        public void ManualDpiScale()
        {
            (_originalSize, _originalLocation) = DpiScaler.ScaleSize(this, _originalSize, _originalLocation);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            SystemEvents.DisplaySettingsChanged -= OnDisplaySettingsChanged;
        }
    }
    #endregion

	#region TabControl
	public class DpiScaledTabControl : TabControl
    {
        public virtual bool Scaled { get; set; } = true;
        public virtual bool BasePaint { get; set; } = false;

        private Size _originalSize { get; set; }
        private Point _originalLocation { get; set; }
        private bool _alreadyRan { get; set; }

        public DpiScaledTabControl() 
        {
            SystemEvents.DisplaySettingsChanged += OnDisplaySettingsChanged;
        }

        private void OnDisplaySettingsChanged(object? sender, EventArgs args) 
        {
            Scale();
        }

        protected virtual void OnControlScaled(float scalingFactor) 
        {
        }

        protected override void OnPaint(PaintEventArgs e) 
        {
            Scale();

            if (BasePaint) 
            {
                base.OnPaint(e);
            }
        }

        private void Scale()
        {
            if (DpiScaler.NotDpiScaling(this))
            {    
                return;
            }

            if (!_alreadyRan)
            {
                _alreadyRan = true;
            }
            else 
            {
                return;
            }

            if (Scaled)
            {
                (_originalSize, _originalLocation) = DpiScaler.ScaleControl(this, _originalSize, _originalLocation, true);
                Console.WriteLine($"DPI Scaled TabControl: {Text} - Size: {Width}x{Height} (orig {_originalSize.Width}x{_originalSize.Height}), Location: {Location.X}x{Location.Y} (orig: {_originalLocation.X}x{_originalLocation.Y})");
                OnControlScaled(DpiScaler.GetScalingFactor(this));
            }
        }

        public void ManualDpiScale()
        {
            (_originalSize, _originalLocation) = DpiScaler.ScaleSize(this, _originalSize, _originalLocation);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            SystemEvents.DisplaySettingsChanged -= OnDisplaySettingsChanged;
        }
    }
    #endregion

	#region TabPage
	public class DpiScaledTabPage : TabPage
    {
        public virtual bool Scaled { get; set; } = true;
        public virtual bool BasePaint { get; set; } = false;

        private Size _originalSize { get; set; }
        private Point _originalLocation { get; set; }
        private bool _alreadyRan { get; set; }

        public DpiScaledTabPage() 
        {
            SystemEvents.DisplaySettingsChanged += OnDisplaySettingsChanged;
        }

        private void OnDisplaySettingsChanged(object? sender, EventArgs args) 
        {
            Scale();
        }

        protected virtual void OnControlScaled(float scalingFactor) 
        {
        }

        protected override void OnPaint(PaintEventArgs e) 
        {
            Scale();

            if (BasePaint) 
            {
                base.OnPaint(e);
            }
        }

        private void Scale()
        {
            if (DpiScaler.NotDpiScaling(this))
            {    
                return;
            }

            if (!_alreadyRan)
            {
                _alreadyRan = true;
            }
            else 
            {
                return;
            }

            if (Scaled)
            {
                (_originalSize, _originalLocation) = DpiScaler.ScaleControl(this, _originalSize, _originalLocation, true);
                Console.WriteLine($"DPI Scaled TabPage: {Text} - Size: {Width}x{Height} (orig {_originalSize.Width}x{_originalSize.Height}), Location: {Location.X}x{Location.Y} (orig: {_originalLocation.X}x{_originalLocation.Y})");
                OnControlScaled(DpiScaler.GetScalingFactor(this));
            }
        }

        public void ManualDpiScale()
        {
            (_originalSize, _originalLocation) = DpiScaler.ScaleSize(this, _originalSize, _originalLocation);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            SystemEvents.DisplaySettingsChanged -= OnDisplaySettingsChanged;
        }
    }
    #endregion

	#region TextBox
	public class DpiScaledTextBox : TextBox
    {
        public virtual bool Scaled { get; set; } = true;
        public virtual bool BasePaint { get; set; } = false;

        private Size _originalSize { get; set; }
        private Point _originalLocation { get; set; }
        private bool _alreadyRan { get; set; }

        public DpiScaledTextBox() 
        {
            SystemEvents.DisplaySettingsChanged += OnDisplaySettingsChanged;
        }

        private void OnDisplaySettingsChanged(object? sender, EventArgs args) 
        {
            Scale();
        }

        protected virtual void OnControlScaled(float scalingFactor) 
        {
        }

        protected override void OnPaint(PaintEventArgs e) 
        {
            Scale();

            if (BasePaint) 
            {
                base.OnPaint(e);
            }
        }

        private void Scale()
        {
            if (DpiScaler.NotDpiScaling(this))
            {    
                return;
            }

            if (!_alreadyRan)
            {
                _alreadyRan = true;
            }
            else 
            {
                return;
            }

            if (Scaled)
            {
                (_originalSize, _originalLocation) = DpiScaler.ScaleControl(this, _originalSize, _originalLocation, true);
                Console.WriteLine($"DPI Scaled TextBox: {Text} - Size: {Width}x{Height} (orig {_originalSize.Width}x{_originalSize.Height}), Location: {Location.X}x{Location.Y} (orig: {_originalLocation.X}x{_originalLocation.Y})");
                OnControlScaled(DpiScaler.GetScalingFactor(this));
            }
        }

        public void ManualDpiScale()
        {
            (_originalSize, _originalLocation) = DpiScaler.ScaleSize(this, _originalSize, _originalLocation);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            SystemEvents.DisplaySettingsChanged -= OnDisplaySettingsChanged;
        }
    }
    #endregion

	}
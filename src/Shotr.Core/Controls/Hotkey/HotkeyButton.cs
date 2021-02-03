using System;
using System.Windows.Forms;
using Shotr.Core.Controls.Theme;
using Shotr.Core.Entities.Hotkeys;

namespace Shotr.Core.Controls.Hotkey
{
    public class HotKeyButton : ThemedButton
    {
        public event EventHandler OnHotKeyChanged = delegate { };
        public event EventHandler OnHotKeyClicked = delegate { };
        public event EventHandler OnHotKeyCanceled = delegate { };
        public bool Editing { get; private set; }
        public Keys Key = Keys.None;

        public HotKeyData? HotKey { get; set; }
        private HotKeyData? PreHk { get; set; }

        public HotKeyButton()
        {
            Text = "None";
            Editing = false;
            Highlight = false;
        }

        private void SetHkText()
        {
            if (HotKey == null)
            {
                Text = "None"; 
                return;
            }
            
            Text = HotKey.ToString();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //here we turn on/off editing mode.
                Editing = !Editing;
                Highlight = Editing;
                if (Editing)
                {
                    PreHk = HotKey;
                    OnHotKeyClicked(this, EventArgs.Empty);
                }
                else
                {
                    OnHotKeyCanceled(this, EventArgs.Empty);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                Editing = false;
                Highlight = false;
                Key = Keys.None;
                HotKey = new HotKeyData(Keys.None);
                SetHkText();
                OnHotKeyChanged(this, EventArgs.Empty);
            }
            

            base.OnMouseUp(e);
        }

        protected override void OnKeyDown(KeyEventArgs kevent)
        {
            kevent.SuppressKeyPress = true;
            if (Editing)
            {
                if (kevent.KeyData == Keys.Escape)
                {
                    Editing = false;
                    Highlight = false;
                    HotKey = PreHk;
                    SetHkText();
                    OnHotKeyCanceled(this, EventArgs.Empty);
                    return;
                }
                Key = kevent.KeyData;
                HotKey = new HotKeyData(Key);
                if (!HotKey.IsValidHotkey) { SetHkText(); return; }
                SetHkText();
                OnHotKeyChanged(this, EventArgs.Empty);
                Editing = false;
                Highlight = false;
            }
            base.OnKeyDown(kevent);
        }

        protected override void OnKeyUp(KeyEventArgs kevent)
        {
            kevent.SuppressKeyPress = true;
            if (Editing)
            {
                //only if printscreen because it's not triggered on keydown.
                if (kevent.KeyCode == Keys.PrintScreen)
                {
                    Key = kevent.KeyData;
                    HotKey = new HotKeyData(Key);
                    if (!HotKey.IsValidHotkey) { SetHkText(); return; }
                    SetHkText();
                    OnHotKeyChanged(this, EventArgs.Empty);
                    Editing = false;
                    Highlight = false;
                }
            }
            base.OnKeyUp(kevent);
        }
    }
}

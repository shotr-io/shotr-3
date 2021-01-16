using System;
using System.Windows.Forms;
using MetroFramework5.Controls;
using Shotr.Core.Entities.Hotkeys;

namespace Shotr.Core.Controls.Hotkey
{
    public class HotkeyButton : MetroButton
    {
        public event EventHandler OnHotKeyChanged = delegate { };
        public bool Editing { get; private set; }
        public Keys Key = Keys.None;

        public HotKeyData? HotKey { get; set; }
        private HotKeyData? PreHk { get; set; }

        public HotkeyButton()
        {
            //override some shits here.
            Text = "None";
            Editing = false;
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

        protected override void OnClick(EventArgs e)
        {
            //here we turn on/off editing mode.
            Editing = !Editing;
            Highlight = Editing;
            if (Editing)
            {
                PreHk = HotKey;
            }
            base.OnClick(e);
        }

        protected override void OnKeyDown(KeyEventArgs kevent)
        {
            kevent.SuppressKeyPress = true;
            if (Editing)
            {
                if (kevent.KeyData == Keys.Escape)
                {
                    Highlight = false;
                    Editing = false;
                    HotKey = PreHk;
                    SetHkText();
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

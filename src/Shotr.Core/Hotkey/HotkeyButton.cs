using System;
using System.Windows.Forms;
using MetroFramework5.Controls;

namespace Shotr.Core.Hotkey
{
    public class HotkeyButton : MetroButton
    {
        public event EventHandler OnHotKeyChanged = delegate { };
        public bool editing { get; private set; }
        public Keys key = Keys.None;

        public HotKeyData HotKey { get; set; }
        private HotKeyData preHK { get; set; }

        public HotkeyButton()
        {
            //override some shits here.
            Text = "None";
            editing = false;
        }

        private void SetHKText()
        {
            if(HotKey == null)
            { Text = "None"; return; }
            Text = HotKey.ToString();
        }

        protected override void OnClick(EventArgs e)
        {
            //here we turn on/off editing mode.
            editing = !editing;
            Highlight = editing;
            if (editing)
            {
                preHK = HotKey;
            }
            base.OnClick(e);
        }

        protected override void OnKeyDown(KeyEventArgs kevent)
        {
            kevent.SuppressKeyPress = true;
            if (editing)
            {
                if (kevent.KeyData == Keys.Escape)
                {
                    Highlight = false;
                    editing = false;
                    HotKey = preHK;
                    SetHKText();
                    return;
                }
                key = kevent.KeyData;
                HotKey = new HotKeyData(key);
                if (!HotKey.IsValidHotkey) { SetHKText(); return; }
                SetHKText();
                OnHotKeyChanged(this, EventArgs.Empty);
                editing = false;
                Highlight = false;
            }
            base.OnKeyDown(kevent);
        }

        protected override void OnKeyUp(KeyEventArgs kevent)
        {
            kevent.SuppressKeyPress = true;
            if (editing)
            {
                //only if printscreen because it's not triggered on keydown.
                if (kevent.KeyCode == Keys.PrintScreen)
                {
                    key = kevent.KeyData;
                    HotKey = new HotKeyData(key);
                    if (!HotKey.IsValidHotkey) { SetHKText(); return; }
                    SetHKText();
                    OnHotKeyChanged(this, EventArgs.Empty);
                    editing = false;
                    Highlight = false;
                }
            }
            base.OnKeyUp(kevent);
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
        }
    }
}

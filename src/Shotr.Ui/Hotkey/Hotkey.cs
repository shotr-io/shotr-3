using System.Text;
using System.Windows.Forms;

namespace Shotr.Ui.Hotkey
{
    public class HotKeyData
    {
        public ushort ID { get; set; }
        public bool Active { get; set; }

        public HotKeyData(Keys hotkey)
        {
            hk = hotkey;
        }

        private Keys hk = Keys.None;
        private KeyTask _task = KeyTask.Empty;

        public KeyTask Task
        {
            get { return _task; }
            set { _task = value; }
        }

        public Keys Hotkey
        {
            get { return hk; }
        }

        public Keys KeyCode
        {
            get
            {
                return Hotkey & Keys.KeyCode;
            }
        }

        public Keys ModifiersKeys
        {
            get
            {
                return Hotkey & Keys.Modifiers;
            }
        }

        public bool Control
        {
            get
            {
                return Hotkey.HasFlag(Keys.Control);
            }
        }

        public bool Shift
        {
            get
            {
                return Hotkey.HasFlag(Keys.Shift);
            }
        }

        public bool Alt
        {
            get
            {
                return Hotkey.HasFlag(Keys.Alt);
            }
        }

        //return modifier keys only.
        public Modifiers ModifiersEnum
        {
            get {
                Modifiers mod = Modifiers.None;
                if (Alt) mod |= Modifiers.Alt;
                if (Control) mod |= Modifiers.Control;
                if (Shift) mod |= Modifiers.Shift;

                return mod;
            }
        }

        public bool IsOnlyModifiers
        {
            get
            {
                return KeyCode == Keys.ControlKey || KeyCode == Keys.ShiftKey || KeyCode == Keys.Menu;
            }
        }

        public bool IsValidHotkey
        {
            get
            {
                return KeyCode != Keys.None && !IsOnlyModifiers;
            }
        }

        public override string ToString()
        {
            string text = string.Empty;

            if (KeyCode != Keys.None)
            {
                if (Control)
                {
                    text += "Ctrl + ";
                }

                if (Shift)
                {
                    text += "Shift + ";
                }

                if (Alt)
                {
                    text += "Alt + ";
                }
            }

            if (IsOnlyModifiers)
            {
                text += "...";
            }
            else if (KeyCode == Keys.Back)
            {
                text += "Backspace";
            }
            else if (KeyCode == Keys.Return)
            {
                text += "Enter";
            }
            else if (KeyCode == Keys.Capital)
            {
                text += "Caps Lock";
            }
            else if (KeyCode == Keys.Next)
            {
                text += "Page Down";
            }
            else if (KeyCode == Keys.Scroll)
            {
                text += "Scroll Lock";
            }
            else if (KeyCode >= Keys.D0 && KeyCode <= Keys.D9)
            {
                text += (KeyCode - Keys.D0).ToString();
            }
            else if (KeyCode >= Keys.NumPad0 && KeyCode <= Keys.NumPad9)
            {
                text += "Numpad " + (KeyCode - Keys.NumPad0).ToString();
            }
            else
            {
                text += ToStringWithSpaces(KeyCode);
            }

            return text;
        }

        private string ToStringWithSpaces(Keys key)
        {
            string name = key.ToString();

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < name.Length; i++)
            {
                if (i > 0 && char.IsUpper(name[i]))
                {
                    result.Append(" " + name[i]);
                }
                else
                {
                    result.Append(name[i]);
                }
            }

            return result.ToString();
        }
    }
}

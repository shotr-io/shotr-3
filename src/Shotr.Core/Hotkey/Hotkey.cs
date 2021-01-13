using System.Text;
using System.Windows.Forms;

namespace Shotr.Core.Hotkey
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
                var mod = Modifiers.None;
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

            text += KeyCode switch
            {
                { } when KeyCode != Keys.None && Control => "Ctrl + ",
                { } when KeyCode != Keys.None && Shift   => "Shift + ",
                { } when KeyCode != Keys.None && Alt     => "Alt + "
            };

            text += KeyCode switch
            {
                {} when IsOnlyModifiers                                    => "...",
                Keys.Back                                                  => "Backspace",
                Keys.Return                                                => "Enter",
                Keys.Capital                                               => "Caps Lock",
                Keys.Next                                                  => "Page Down",
                Keys.Scroll                                                => "Scroll Lock",
                Keys.Oemtilde                                              => "~",
                {} when KeyCode >= Keys.D0 && KeyCode <= Keys.D9           => (KeyCode - Keys.D0).ToString(),
                {} when KeyCode >= Keys.NumPad0 && KeyCode <= Keys.NumPad9 => (KeyCode - Keys.NumPad0).ToString(),
                _                                                          => ToStringWithSpaces(KeyCode)
            };

            return text;
        }

        private string ToStringWithSpaces(Keys key)
        {
            string name = key.ToString();

            StringBuilder result = new StringBuilder();

            for (var i = 0; i < name.Length; i++)
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

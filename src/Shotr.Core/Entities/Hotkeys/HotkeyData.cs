using System.Text;
using System.Windows.Forms;

namespace Shotr.Core.Entities.Hotkeys
{
    public class HotKeyData
    {
        public ushort ID { get; set; }
        public bool Active { get; set; }

        public HotKeyData(Keys hotkey)
        {
            _hk = hotkey;
        }

        private Keys _hk = Keys.None;
        private KeyTask _task = KeyTask.Empty;

        public KeyTask Task
        {
            get => _task;
            set => _task = value;
        }

        public Keys HotKey => _hk;

        public Keys KeyCode => HotKey & Keys.KeyCode;

        public Keys ModifiersKeys => HotKey & Keys.Modifiers;

        public bool Control => HotKey.HasFlag(Keys.Control);

        public bool Shift => HotKey.HasFlag(Keys.Shift);

        public bool Alt => HotKey.HasFlag(Keys.Alt);

        //return modifier keys only.
        public HotKeyModifiers ModifiersEnum
        {
            get {
                var mod = HotKeyModifiers.None;
                if (Alt) mod |= HotKeyModifiers.Alt;
                if (Control) mod |= HotKeyModifiers.Control;
                if (Shift) mod |= HotKeyModifiers.Shift;

                return mod;
            }
        }

        public bool IsOnlyModifiers => KeyCode == Keys.ControlKey || KeyCode == Keys.ShiftKey || KeyCode == Keys.Menu;

        public bool IsValidHotkey => KeyCode != Keys.None && !IsOnlyModifiers;

        public override string ToString()
        {
            var text = string.Empty;

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

            text += KeyCode switch
            {
                {} when IsOnlyModifiers                                    => "...",
                Keys.Back                                                  => "Backspace",
                Keys.Return                                                => "Enter",
                Keys.Capital                                               => "Caps Lock",
                Keys.Next                                                  => "Page Down",
                Keys.Scroll                                                => "Scroll Lock",
                Keys.Oemtilde                                              => "Tilde",
                {} when KeyCode >= Keys.D0 && KeyCode <= Keys.D9           => (KeyCode - Keys.D0).ToString(),
                {} when KeyCode >= Keys.NumPad0 && KeyCode <= Keys.NumPad9 => (KeyCode - Keys.NumPad0).ToString(),
                _                                                          => ToStringWithSpaces(KeyCode)
            };

            return text;
        }

        private string ToStringWithSpaces(Keys key)
        {
            var name = key.ToString();

            var result = new StringBuilder();

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

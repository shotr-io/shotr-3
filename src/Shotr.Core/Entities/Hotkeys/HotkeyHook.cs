using System.Windows.Forms;

namespace Shotr.Core.Entities.Hotkeys
{
    public class HotKeyHook
    {
        private int _id;
        private HotKeyModifiers _mod;
        private Keys _keys;
        private KeyTask _task = KeyTask.Empty;

        public HotKeyHook(int id, HotKeyModifiers modifier, Keys keys)
        {
            _id = id;
            _mod = modifier;
            _keys = keys;
        }

        public KeyTask Task
        {
            get => _task;
            set => _task = value;
        }

        public Keys Keys => _keys;

        public HotKeyModifiers Modifiers => _mod;

        public int Id => _id;

        public HotKeyData Data => new HotKeyData(Keys);
    }
}
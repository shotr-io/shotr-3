using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Shotr.Core.Hotkey
{
    [Flags]
    public enum Modifiers
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        Win = 8
    }
    public sealed class KeyboardHook : IDisposable
    {
        // Registers a hot key with Windows.
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        // Unregisters the hot key with Windows.
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("kernel32.dll")]
        static extern uint GetLastError();

        /// <summary>
        /// Represents the window that is used internally to get the messages.
        /// </summary>
        private class Window : NativeWindow, IDisposable
        {
            private static int WM_HOTKEY = 0x0312;
            private int HotkeyRepeatLimit = 1000;
            private Stopwatch repeatLimitTimer;

            public Window()
            {
                // create the handle for the window.
                repeatLimitTimer = Stopwatch.StartNew();
                CreateHandle(new CreateParams());
            }

            /// <summary>
            /// Overridden to get the notifications.
            /// </summary>
            /// <param name="m"></param>
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);

                // check if we got a hot key pressed.
                if (m.Msg == WM_HOTKEY && CheckRepeatLimitTime())
                {
                    // invoke the event to notify the parent.
                    if (KeyPressed != null)
                        KeyPressed(this, new KeyPressedEventArgs(m.WParam.ToInt32()));
                }
            }

            private bool CheckRepeatLimitTime()
            {
                if (HotkeyRepeatLimit > 0)
                {
                    if (repeatLimitTimer.ElapsedMilliseconds >= HotkeyRepeatLimit)
                    {
                        repeatLimitTimer.Reset();
                        repeatLimitTimer.Start();
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }

            public event EventHandler<KeyPressedEventArgs> KeyPressed;

            #region IDisposable Members

            public void Dispose()
            {
                DestroyHandle();
            }

            #endregion
        }

        private Window _window = new Window();
        private List<int> _ids = new List<int>();

        public KeyboardHook()
        {
            // register the event of the inner native window.
            _window.KeyPressed += delegate(object sender, KeyPressedEventArgs args)
            {
                if (KeyPressed != null)
                    KeyPressed(this, args);
            };
        }

        /// <summary>
        /// Registers a hot key in the system.
        /// </summary>
        /// <param name="modifier">The modifiers that are associated with the hot key.</param>
        /// <param name="key">The key itself that is associated with the hot key.</param>
        public HotKeyHook RegisterHotKey(HotKeyData key)
        {
            // increment the counter.
            int id = 1;
            if (_ids.Count > 0)
                id = _ids[_ids.Count - 1] + 1;
            _ids.Add(id);
            // register the hot key.
            if (!RegisterHotKey(_window.Handle, id, (uint)key.ModifiersEnum, (uint)key.KeyCode))
                throw new InvalidOperationException("Couldn’t register the hotkey.");
            //
            return new HotKeyHook(id, key.ModifiersEnum, key.Hotkey);
        }

        public void UnregisterHotKey(int id)
        {
            if (!_ids.Contains(id))
                return;
            if (!UnregisterHotKey(_window.Handle, id))
                throw new InvalidOperationException(string.Format("Couldn't unregister the hotkey. {0}", GetLastError()));
            _ids.Remove(id);
        }

        /// <summary>
        /// A hot key has been pressed.
        /// </summary>
        public event EventHandler<KeyPressedEventArgs> KeyPressed;

        #region IDisposable Members

        public void Dispose()
        {
            // unregister all the registered hot keys.
            for (int i = 0; i < _ids.Count; i++)
            {
                UnregisterHotKey(_window.Handle, _ids[i]);
            }
            // dispose the inner native window.
            _window.Dispose();
        }

        #endregion
    }

    public class HotKeyHook
    {
        private int _id;
        private Modifiers _mod;
        private Keys _keys;
        private KeyTask _task = KeyTask.Empty;

        public HotKeyHook(int id, Modifiers modifier, Keys keys)
        {
            _id = id;
            _mod = modifier;
            _keys = keys;
        }

        public KeyTask Task
        {
            get { return _task; }
            set { _task = value; }
        }

        public Keys Keys
        {
            get { return _keys; }
        }

        public Modifiers Modifiers
        {
            get { return _mod; }
        }

        public int ID
        {
            get { return _id; }
        }
    }

    /// <summary>
    /// Event Args for the event that is fired after the hot key has been pressed.
    /// </summary>
    public class KeyPressedEventArgs : EventArgs
    {
        public KeyPressedEventArgs(int ida)
        {
            id = ida;
        }
        private int id;

        public int ID
        {
            get { return id; }
        }
    }

    public enum KeyTask
    {
        Empty = -1,
        Region = 1,
        Fullscreen = 2,
        ActiveWindow = 3,
        RecordScreen = 4,
        UploadClipboard = 5,
        RegionNoUpload = 6
    }
}
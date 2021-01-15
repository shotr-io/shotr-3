using System;

namespace Shotr.Core.Entities.Hotkeys
{
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

        public int Id => id;
    }
}
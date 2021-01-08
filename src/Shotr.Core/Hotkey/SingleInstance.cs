namespace Shotr.Core.Hotkey
{
    public class SingleInstance
    {
        private KeyTask currentTask = KeyTask.Empty;

        public KeyTask CurrentTask
        {
            get { return currentTask; }
            set { currentTask = value; }
        }

        public void Reset()
        {
            currentTask = KeyTask.Empty;
        }
    }
}

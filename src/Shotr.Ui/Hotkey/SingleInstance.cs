namespace Shotr.Ui.Hotkey
{
    public class SingleInstance
    {
        private KeyTask currentTask = KeyTask.Empty;
        public SingleInstance()
        {

        }

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

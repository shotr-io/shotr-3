namespace Shotr.Core.Entities.Hotkeys
{
    public class SingleInstance
    {
        private KeyTask _currentTask = KeyTask.Empty;

        public KeyTask CurrentTask
        {
            get => _currentTask;
            set => _currentTask = value;
        }

        public void Reset()
        {
            _currentTask = KeyTask.Empty;
        }
    }
}

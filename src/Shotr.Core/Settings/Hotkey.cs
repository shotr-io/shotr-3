using System.Windows.Forms;
using CustomEnvironmentConfig;

namespace Shotr.Core.Settings
{
    public class Hotkey
    {
        [ConfigurationItem(Required = false, Default = Keys.Control | Keys.Shift | Keys.NumPad4)]
        public Keys Region { get; set; }
        
        [ConfigurationItem(Required = false, Default = Keys.Control | Keys.Shift | Keys.NumPad3)]
        public Keys Fullscreen { get; set; }
        
        [ConfigurationItem(Required = false, Default = Keys.Control | Keys.Shift | Keys.NumPad2)]
        public Keys ActiveWindow { get; set; }
        
        [ConfigurationItem(Required = false, Default = Keys.Control | Keys.Shift | Keys.NumPad1)]
        public Keys RecordScreen { get; set; }
        
        [ConfigurationItem(Required = false, Default = Keys.Control | Keys.Shift | Keys.NumPad5)]
        public Keys Clipboard { get; set; }
        
        [ConfigurationItem(Required = false, Default = Keys.Control | Keys.Shift | Keys.Oemtilde)]
        public Keys NoUpload { get; set; }
    }
}

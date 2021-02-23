using System.Windows.Forms;
using CustomEnvironmentConfig;

namespace Shotr.Core.Settings
{
    public class Hotkey
    {
        [ConfigurationItem(Required = false, Default = Keys.Control | Keys.Shift | Keys.Oemtilde)]
        public Keys Region { get; set; }
        
        [ConfigurationItem(Required = false, Default = Keys.Control | Keys.Shift | Keys.D1)]
        public Keys Fullscreen { get; set; }
        
        [ConfigurationItem(Required = false, Default = Keys.Control | Keys.Shift | Keys.D2)]
        public Keys ActiveWindow { get; set; }
        
        [ConfigurationItem(Required = false, Default = Keys.Control | Keys.Shift | Keys.D3)]
        public Keys RecordScreen { get; set; }
        
        [ConfigurationItem(Required = false, Default = Keys.Control | Keys.Shift | Keys.D4)]
        public Keys Clipboard { get; set; }
        
        [ConfigurationItem(Required = false, Default = Keys.Control | Keys.Shift | Keys.C)]
        public Keys ColorPicker { get; set; }
    }
}

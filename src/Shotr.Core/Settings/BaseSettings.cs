using System.Collections.Generic;
using CustomEnvironmentConfig;
using Shotr.Core.Entities.Web;
using ShotrUploaderPlugin;

namespace Shotr.Core.Settings
{
    public class BaseSettings
    {
        public Capture Capture { get; set; }
        public Record Record { get; set; }
        public Hotkey Hotkey { get; set; }
        public Login Login { get; set; }
        
        [ConfigurationItem(Required = false, Default = true)]
        public bool PlaySounds { get; set; }
        
        [ConfigurationItem(Required = false, Default = true)]
        public bool ShowNotifications { get; set; }
        
        [ConfigurationItem(Required = false, Default = true)]
        public bool StartWithWindows { get; set; }
        
        [ConfigurationItem(Required = false, Default = false)]
        public bool StartMinimized { get; set; }
        
        [ConfigurationItem(Required = false, Default = 0)]
        public int Version { get; set; }
        
        [ConfigurationItem(Required = false, Default = 0)]
        public int UpdatedTo { get; set; }
        
        [ConfigurationItem(Required = false, Default = true)]
        public bool SubscribeToAlphaBeta { get; set; }

        [ConfigurationItem(Ignore = true)]
        public Dictionary<long, UploadResult>? LegacyHistory { get; set; }

        [ConfigurationItem(Ignore = true)]
        public List<UploadItem>? Uploads { get; set; }
    }
}

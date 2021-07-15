using CustomEnvironmentConfig;
using Shotr.Core.Entities;

namespace Shotr.Core.Settings
{
    public class Capture
    {
        [ConfigurationItem(Required = false, Default = false)]
        public bool SaveToDirectory { get; set; }
        
        [ConfigurationItem(Required = false)]
        public string? SaveToDirectoryPath { get; set; }

        [ConfigurationItem(Required = false, Default = true)]
        public bool ShowZoom { get; set; }

        [ConfigurationItem(Required = false, Default = true)]
        public bool ShowEditNotification { get; set; }

        [ConfigurationItem(Required = false, Default = true)]
        public bool ShowInformation { get; set; }

        [ConfigurationItem(Required = false, Default = false)]
        public bool CompressionEnabled { get; set; }
        
        [ConfigurationItem(Required = false, Default = CompressionLevel.Maximum)]
        public CompressionLevel CompressionLevel { get; set; }
        
        [ConfigurationItem(Required = false, Default = "png")]
        public string Extension { get; set; }
        
        [ConfigurationItem(Required = false, Default = true)]
        public bool StitchFullscreen { get; set; }
        
        [ConfigurationItem(Required = false, Default = false)]
        public bool DirectUrl { get; set; }
        
        [ConfigurationItem(Required = false, Default = "Shotr")]
        public string Uploader { get; set; }
    }
}

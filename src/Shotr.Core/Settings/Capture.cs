using CustomEnvironmentConfig;
using Shotr.Core.Entities;
using ShotrUploaderPlugin;

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
        public bool ShowColor { get; set; }
        
        [ConfigurationItem(Required = false, Default = true)]
        public bool ShowInformation { get; set; }
        
        [ConfigurationItem(Required = false, Default = true)]
        public bool UseResizableCanvas { get; set; }

        [ConfigurationItem(Required = false, Default = true)]
        public bool CompressionEnabled { get; set; }
        
        [ConfigurationItem(Required = false, Default = CompressionLevel.Maximum)]
        public CompressionLevel CompressionLevel { get; set; }
        
        [ConfigurationItem(Required = false, Default = FileExtensions.png)]
        public FileExtensions Extension { get; set; }
        
        [ConfigurationItem(Required = false, Default = true)]
        public bool StitchFullscreen { get; set; }
        
        [ConfigurationItem(Required = false, Default = false)]
        public bool DirectUrl { get; set; }
        
        [ConfigurationItem(Required = false, Default = "Shotr")]
        public string Uploader { get; set; }
    }
}

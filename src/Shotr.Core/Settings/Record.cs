using CustomEnvironmentConfig;

namespace Shotr.Core.Settings
{
    public class Record
    {
        [ConfigurationItem(Required = false, Default = 60)]
        public int Framerate { get; set; }
        
        [ConfigurationItem(Required = false, Default = 4)]
        public int Threads { get; set; }
        
        [ConfigurationItem(Required = false, Default = true)]
        public bool RecordCursor { get; set; }
        
        [ConfigurationItem(Required = false, Default = false)]
        public bool RecordAudio { get; set; }
        
        [ConfigurationItem(Required = false)]
        public string? AudioDevice { get; set; }
        
        [ConfigurationItem(Required = false, Default = true)]
        public bool ShowWarning { get; set; }

        [ConfigurationItem(Required = false, Default = "fast")]
        public string? Quality { get; set; }
    }
}

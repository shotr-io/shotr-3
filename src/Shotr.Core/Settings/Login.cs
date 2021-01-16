using CustomEnvironmentConfig;

namespace Shotr.Core.Settings
{
    public class Login
    {
        [ConfigurationItem(Default = false, Required = false)] 
        public bool? Enabled { get; set; }
        
        [ConfigurationItem(Default = false, Required = false)]
        public bool? RememberMe { get; set; }
        
        [ConfigurationItem(Encrypt = true, Required = false)]
        public string? Email { get; set; }
        
        [ConfigurationItem(Encrypt = true, Required = false)]
        public string? Token { get; set; }
        
        [ConfigurationItem(Encrypt = true, Required = false)]
        public string? Password { get; set; }
        
        [ConfigurationItem(Name = "Id", Required = false)]
        public string? DcryptKey { get; set; }
    }
}
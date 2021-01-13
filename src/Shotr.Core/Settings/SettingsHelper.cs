using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CustomEnvironmentConfig;
using Shotr.Core.Hotkey;
using Shotr.Core.Utils;

namespace Shotr.Core.Settings
{
    public class SettingsHelper
    {
        public static string FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Shotr");
        public static string CachePath = Path.Combine(FolderPath, "Cache");
        public static string ErrorPath = Path.Combine(ErrorPath, "error.log");
        
        private string _settingsPath = Path.Combine(FolderPath, "config.cfg");
        
        private List<HotKeyHook> _hotKeys = new List<HotKeyHook>();

        public BaseSettings Load()
        {
            if (!File.Exists(_settingsPath))
            {
                File.WriteAllText(_settingsPath, "");
            }
            
            var config = ConfigurationParser.Parse<BaseSettings>(_settingsPath);

            var dcrypt = new dcrypt();

            if (config.Login.DcryptKey is null)
            {
                config.Login.DcryptKey = Convert.ToBase64String(dcrypt.Key);
            }

            dcrypt = new dcrypt(Convert.FromBase64String(config.Login.DcryptKey));

            var decryptHandler = new Func<string, string, string>((name, value) =>
            {
                return Encoding.UTF8.GetString(dcrypt.Decrypt(Encoding.UTF8.GetBytes(value)));
            });
            
            var decryptedConfig = ConfigurationParser.Parse<BaseSettings>(_settingsPath, ConfigurationTypeEnum.FileOnly, decryptHandler);
            
            return decryptedConfig;
        }

        public void Save(BaseSettings settings)
        {
            var encryptHandler = new Func<string, string, string>((_, value) =>
            {
                // Check dcrypt key.
                if (settings.Login.DcryptKey is { })
                {
                    var dcrypt = new dcrypt(Convert.FromBase64String(settings.Login.DcryptKey));
                    return Convert.ToBase64String(dcrypt.Encrypt(Encoding.UTF8.GetBytes(value)));
                }

                return value;
            });
            
            ConfigurationWriter.WriteToFile(settings, _settingsPath, encryptHandler, true);
        }

        private void InitializeHotkey(Hotkey hotkey)
        {
        }
    }
}

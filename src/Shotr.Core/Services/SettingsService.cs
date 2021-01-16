using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using CustomEnvironmentConfig;
using Shotr.Core.Entities;
using Shotr.Core.Entities.Hotkeys;
using Shotr.Core.Settings;
using Shotr.Core.Utils;
using ShotrUploaderPlugin;

namespace Shotr.Core.Services
{
    public class SettingsService
    {
        public static readonly string FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Shotr");
        public static readonly string CachePath = Path.Combine(FolderPath, "Cache");
        public static readonly string ErrorPath = Path.Combine(FolderPath, "error.log");
        
        private static readonly string _settingsPath = Path.Combine(FolderPath, "config.cfg");
        
        public static BaseSettings Load()
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
                return Encoding.UTF8.GetString(dcrypt.Decrypt(Convert.FromBase64String(value)));
            });
            
            var decryptedConfig = ConfigurationParser.Parse<BaseSettings>(_settingsPath, ConfigurationTypeEnum.FileOnly, decryptHandler);

            if (decryptedConfig.Login.DcryptKey is null)
            {
                decryptedConfig.Login.DcryptKey = config.Login.DcryptKey;
            }

            decryptedConfig.LegacyHistory = LoadLegacyHistory();

            Save(decryptedConfig);
            
            return decryptedConfig;
        }

        public static void Save(BaseSettings settings)
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

        private static Dictionary<long, UploadResult>? LoadLegacyHistory()
        {
            var bin = new BinaryFormatter();
            bin.Binder = new SettingsSerializationBinder();
            if (File.Exists(Path.Combine(FolderPath, "history")))
            {
                var ms = new MemoryStream(File.ReadAllBytes(Path.Combine(FolderPath, "history")));
                try
                {
#pragma warning disable 618
                    return (Dictionary<long, UploadResult>)bin.Deserialize(ms);
#pragma warning restore 618
                }
                catch { /*MessageBox.Show(ex.ToString());*/ }
            }

            return null;
        }
    }
}

using System;
using System.Net;
using System.Threading;
using Newtonsoft.Json;
using Shotr.Core.Settings;

namespace Shotr.Core.UpdateFramework
{
    public class Updater
    {
        public static bool Check = true;
        public static int TimeToCheck = 60 * 60 * 1000;
        public static event EventHandler<UpdaterInfoArgs> OnUpdateCheck = delegate { };
        public static void CheckForUpdates(BaseSettings settings)
        {
            new Thread(delegate()
            {
                //download shotr update url.
                var p = new WebClient { Proxy = null };
                while (Check)
                {
                    try
                    {
                        var updateData = p.DownloadString("https://shotr.dev/api/updates/latest");
                        var deserializedUpdateData = JsonConvert.DeserializeObject<UpdaterResponse>(updateData);
                        OnUpdateCheck.Invoke(null, new UpdaterInfoArgs(deserializedUpdateData, settings));
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Updater Exception: {ex}");
                    }
                    Thread.Sleep(TimeToCheck); //check for updates every hour.
                }
            }).Start();
        }
    }
    public class UpdaterInfoArgs : EventArgs
    {
        public UpdaterInfoArgs(bool error)
        {
            Error = error;
        }
        public UpdaterInfoArgs(UpdaterResponse updaterResponse, BaseSettings settings)
        {
            UpdateInfo = updaterResponse;
            Settings = settings;
        }
        
        public readonly bool Error = false;
        public readonly UpdaterResponse UpdateInfo;
        public readonly BaseSettings Settings;
    }
}

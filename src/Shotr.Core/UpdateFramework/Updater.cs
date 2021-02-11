using System;
using System.Net;
using System.Threading;
using Newtonsoft.Json;
using Shotr.Core.Settings;

namespace Shotr.Core.UpdateFramework
{
    public class Updater
    {
        public static bool FirstRun = true;
        public static int TimeToCheck = 60 * 60 * 1000 * 24;
        public static BaseSettings BaseSettings = null;
        public static event EventHandler<UpdaterInfoArgs> OnUpdateCheck = delegate { };
        public static void CheckForUpdates()
        {
            new Thread(delegate()
            {
                if (!FirstRun)
                {
                    Thread.Sleep(TimeToCheck);
                }
                else
                {
                    // Wait 15 seconds to get the update, as to not just spam the user.
                    Thread.Sleep(15 * 1000);
                }

                //download shotr update url.
                var p = new WebClient { Proxy = null };
                try
                {
                    var updateData = p.DownloadString("https://shotr.dev/api/updates/latest");
                    var deserializedUpdateData = JsonConvert.DeserializeObject<UpdaterResponse>(updateData);
                    OnUpdateCheck.Invoke(null, new UpdaterInfoArgs(deserializedUpdateData, BaseSettings));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Updater Exception: {ex}");
                }

                FirstRun = false;
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

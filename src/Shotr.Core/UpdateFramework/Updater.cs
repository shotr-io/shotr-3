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
                        var updateData = p.DownloadString((settings.SubscribeToAlphaBeta ? "https://shotr.io/beta" : "https://shotr.io/update"));
                        var j = JsonConvert.DeserializeObject<UpdaterResponse>(updateData);
                        if (j.error)
                        {
                            return;
                        }
                        
                        OnUpdateCheck.Invoke(null, new UpdaterInfoArgs(j, settings));
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("EXCEPTION {0}", ex);
                        //error while checking for updates.
                        OnUpdateCheck.Invoke(null, new UpdaterInfoArgs(true));
                    }
                    Thread.Sleep(60 * 60 * 1000); //check for updates every hour.
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

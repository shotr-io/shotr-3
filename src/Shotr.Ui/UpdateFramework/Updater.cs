using System;
using System.Net;
using System.Threading;
using Newtonsoft.Json;

namespace Shotr.Ui.UpdateFramework
{
    class Updater
    {
        public static bool Check = true;
        public static event EventHandler<UpdaterInfoArgs> OnUpdateCheck = delegate { };
        public static void CheckForUpdates(bool beta)
        {
            new Thread(delegate()
            {
                //download shotr update url.
                WebClient p = new WebClient() { Proxy = null };
                while (Check)
                {
                    try
                    {
                        string updateshit = p.DownloadString((beta ? "https://shotr.io/beta" : "https://shotr.io/update"));
                        UpdaterJsonClass j = JsonConvert.DeserializeObject<UpdaterJsonClass>(updateshit);
                        if (j.error) return;
                        OnUpdateCheck.Invoke(null, new UpdaterInfoArgs(j));
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("EXCEPTION {0}", ex.ToString());
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
            error = true;
        }
        public UpdaterInfoArgs(UpdaterJsonClass p)
        {
            updateInfo = p;
        }
        public bool error = false;
        public UpdaterJsonClass updateInfo;
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using Shotr.Ui.Model;
using Shotr.Ui.Plugin;
using Shotr.Ui.Utils;
using ShotrUploaderPlugin;

namespace Shotr.Ui.Uploader
{
    public class Uploader
    {
        public delegate void UploadCompletedEvent(object sender, UploadResult e);
        public delegate void UploadFailedEvent(object sender, ImageShell e);
        public delegate void UploadProgressEvent(object sender, double progress);

        public static event UploadCompletedEvent OnUploaded = delegate { };
        public static event UploadFailedEvent OnError = delegate { };
        public static event UploadProgressEvent OnProgress = delegate { };

        static Queue<ImageShell> w = new Queue<ImageShell>();

        public static void StartQueue()
        {
            FileUploader.OnUploadProgress += FileUploader_OnUploadProgress;
            new Thread(delegate()
                {
                    while (true)
                        if (w.Count > 0)
                        {
                            //enqueue the next item to be uploaded.
                            UploadFile(w.Dequeue());
                        }
                        else Thread.Sleep(100);
                }).Start();
        }
        static bool sound = true;
        public static void RemoveHandlers()
        {
            OnProgress = delegate { };
            OnUploaded = delegate { };
            OnError = delegate { };
            sound = false;
        }

        static void FileUploader_OnUploadProgress(object sender, double progress)
        {
            OnProgress(sender, progress);
        }

        public static void ProcessWithoutUpload(ImageShell f)
        {
            OnUploaded(new object[] { f.ContentType, f.Data, f.Extension }, null);
        }

        public static void AddToQueue(ImageShell f)
        {
            w.Enqueue(f);
        }
        
        public static void UploadFile(ImageShell f)
        {
            //grab uploader from settings.
            ImageUploader x = null;
            if ((string)Program.Settings.GetValue("image_uploader")[0] == "Imgur" && !f.ContentType.Contains("image"))
                x = PluginCore.GetUploader("Shotr");
            else
                x = PluginCore.GetUploader((string)Program.Settings.GetValue("image_uploader")[0]);

            if (x == null) // wot
            {
                //image uploader is non-existent?
                MessageBox.Show("The image uploader you have selected is non-existant.");
                Environment.Exit(0);
            }
                  
            UploadResult m = null;
            UploadedItemResult json = null;

            int retries = 0;
        ok:
            if (x.UseUploadMethod)
            {
                m = x.UploadImage(f);
            }
            else
            {
                var uploadHeaders = x.HeaderValues;

                try
                {
                    string output = FileUploader.UploadFile(x.UploaderURL, f.Data,
                        Utils.Utils.GetRandomString(6) + "." + f.Extension, x.FileValueName, f.ContentType, new NameValueCollection(), 
                        uploadHeaders);
                    json = JsonConvert.DeserializeObject<UploadedItemResult>(output);
                    if (json == null) throw new Exception();
                }
                catch (Exception mx)
                {
                    if (m == null)
                    {
                        json = new UploadedItemResult
                        {
                            Error = true,
                            ErrorMessage = $"There was an error while contacting Shotr. Error: {mx.InnerException}."
                        };
                        m = new UploadResult(json.RawUrl, json.Url, null, Utils.Utils.ToUnixTime(DateTime.Now), x.Title,
                            json.Error);
                    }
                }

                if (json != null)
                {
                    m = new UploadResult(json.RawUrl, json.Url, null, Utils.Utils.ToUnixTime(DateTime.Now), x.Title, json.Error);
                }

                if(m == null)
                {
                    m = new UploadResult("", "", "", 0, x.Title, true);
                    goto ok;
                }               
            }
            if (!m.Error)
            {
                if(sound)
                    MusicPlayer.PlayUploaded();
                OnUploaded(new object[] { f.ContentType, f.Data }, m);
                f.Data = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
                return;
            }
            //first try uploading to shotr.io if it's not shotr already.
            if (retries <= 3 && f.ContentType.Contains("text"))
            {
                retries++;
                if (retries >= 3)
                {
                    //ok default to shotr.
                    if (x.Title != "Shotr")
                    {
                        //re-queue with Shotr instead.
                        x = PluginCore.GetUploader("Shotr");
                        retries = 0;
                    }
                    goto ok;
                }
            }

            OnError(json, f);
        }
    }
}

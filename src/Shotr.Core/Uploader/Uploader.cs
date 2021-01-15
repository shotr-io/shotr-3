using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using Shotr.Core.Model;
using Shotr.Core.Plugin;
using Shotr.Core.Services;
using Shotr.Core.Settings;
using Shotr.Core.Utils;
using ShotrUploaderPlugin;

namespace Shotr.Core.Uploader
{
    public class Uploader
    {
        public delegate void UploadCompletedEvent(object sender, UploadResult e);
        public delegate void UploadFailedEvent(object sender, ImageShell e);
        public delegate void UploadProgressEvent(object sender, double progress);

        public event UploadCompletedEvent OnUploaded = delegate { };
        public event UploadFailedEvent OnError = delegate { };
        public event UploadProgressEvent OnProgress = delegate { };

        private Queue<ImageShell> _uploadQueue = new Queue<ImageShell>();

        private readonly MusicPlayerService _musicPlayerService;
        private readonly BaseSettings _settings;
        private readonly IEnumerable<IImageUploader> _imageUploaders;

        public Uploader(MusicPlayerService musicPlayerService, BaseSettings settings, IEnumerable<IImageUploader> imageUploaders)
        {
            _musicPlayerService = musicPlayerService;
            _settings = settings;
            _imageUploaders = imageUploaders;
        }

        public void StartQueue()
        {
            FileUploaderService.OnUploadProgress += FileUploader_OnUploadProgress;
            new Thread(delegate()
                {
                    while (true)
                        if (_uploadQueue.Count > 0)
                        {
                            //enqueue the next item to be uploaded.
                            UploadFile(_uploadQueue.Dequeue());
                        }
                        else Thread.Sleep(100);
                }).Start();
        }
        
        public void RemoveHandlers()
        {
            OnProgress = delegate { };
            OnUploaded = delegate { };
            OnError = delegate { };
        }

        private void FileUploader_OnUploadProgress(object sender, double progress)
        {
            OnProgress(sender, progress);
        }

        public void ProcessWithoutUpload(ImageShell f)
        {
            OnUploaded(new object[] { f.ContentType, f.Data, f.Extension }, null);
        }

        public void AddToQueue(ImageShell f)
        {
            _uploadQueue.Enqueue(f);
        }
        
        public void UploadFile(ImageShell f)
        {
            var imageUploader = GetUploader(_settings.Capture.Uploader);
            if (imageUploader is null)
            {
                throw new Exception($"Image uploader '{_settings.Capture.Uploader}' does not exist.");
            }

            if (imageUploader.Title == "Imgur" && !f.ContentType.Contains("image"))
            {
                imageUploader = GetUploader("Shotr");
            }
                  
            UploadResult m = null;
            UploadedItemResult json = null;

            var retries = 0;
        ok:
            if (imageUploader.UseUploadMethod)
            {
                m = imageUploader.UploadImage(f);
            }
            else
            {
                var uploadHeaders = imageUploader.HeaderValues;

                try
                {
                    var output = FileUploaderService.UploadFile(imageUploader.UploaderURL, f.Data,
                        Utils.Utils.GetRandomString(6) + "." + f.Extension, imageUploader.FileValueName, f.ContentType, new NameValueCollection(), 
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
                        m = new UploadResult(json.RawUrl, json.Url, null, Utils.Utils.ToUnixTime(DateTime.Now), imageUploader.Title,
                            json.Error);
                    }
                }

                if (json != null)
                {
                    m = new UploadResult(json.RawUrl, json.Url, null, Utils.Utils.ToUnixTime(DateTime.Now), imageUploader.Title, json.Error);
                }

                if(m == null)
                {
                    m = new UploadResult("", "", "", 0, imageUploader.Title, true);
                    goto ok;
                }               
            }
            if (!m.Error)
            {
                _musicPlayerService.PlayUploaded();
                
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
                    if (imageUploader.Title != "Shotr")
                    {
                        //re-queue with Shotr instead.
                        imageUploader = GetUploader("Shotr");
                        retries = 0;
                    }
                    goto ok;
                }
            }

            OnError(json, f);
        }

        private IImageUploader? GetUploader(string name)
        {
            return _imageUploaders.FirstOrDefault(p => p.Title == name);
        }
    }
}

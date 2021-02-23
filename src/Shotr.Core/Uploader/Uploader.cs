using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using Shotr.Core.MimeDetect;
using Shotr.Core.Model;
using Shotr.Core.Services;
using Shotr.Core.Settings;
using Exception = System.Exception;

namespace Shotr.Core.Uploader
{
    public class Uploader
    {
        public delegate void UploadCompletedEvent(FileShell fileShell, UploadResult? result, SaveResult? saveResult, FileTypeEnum fileType, string extension, string? uploader);
        public delegate void UploadFailedEvent(FileShell e, bool allowReUpload, FileTypeEnum fileType, string? uploader, string errorMessage);
        public delegate void UploadProgressEvent(double progress);

        public event UploadCompletedEvent OnUploaded = delegate { };
        public event UploadFailedEvent OnError = delegate { };
        public event UploadProgressEvent OnProgress = delegate { };

        private Queue<FileShell> _uploadQueue = new Queue<FileShell>();
        
        private readonly BaseSettings _settings;
        private readonly IEnumerable<IImageUploader> _imageUploaders;

        public Uploader(BaseSettings settings, IEnumerable<IImageUploader> imageUploaders)
        {
            _settings = settings;
            _imageUploaders = imageUploaders;
        }

        public void StartQueue()
        {
            FileUploaderService.OnUploadProgress += FileUploader_OnUploadProgress;
            new Thread(delegate()
            {
                while (true)
                {
                    if (_uploadQueue.Count > 0)
                    {
                        UploadFile(_uploadQueue.Dequeue());
                    }
                    else
                    {
                        Thread.Sleep(100);
                    }
                }
            }).Start();
        }
        
        public void RemoveHandlers()
        {
            OnProgress = delegate { };
            OnUploaded = delegate { };
            OnError = delegate { };
        }

        private void FileUploader_OnUploadProgress(double progress)
        {
            OnProgress(progress);
        }

        public void ProcessWithoutUpload(FileShell fileShell)
        {
            var mime = new Mime();
            var node = mime.Detect(fileShell.Data);

            var saveResult = new SaveResult
            {
                Time = DateTime.Now.ToUnixTime()
            };
            OnUploaded(fileShell, null, saveResult, node.FileType, node.Extension, null);
        }

        public void AddToQueue(FileShell fileShell)
        {
            _uploadQueue.Enqueue(fileShell);
        }
        
        public void UploadFile(FileShell fileShell)
        {
            var imageUploader = GetUploader(_settings.Capture.Uploader);
            if (imageUploader is null)
            {
                throw new Exception($"Image uploader '{_settings.Capture.Uploader}' does not exist.");
            }

            var mime = new Mime();

            var mimeNode = fileShell.Path is { } ? mime.DetectFile(fileShell.Path) : mime.Detect(fileShell.Data);
            if (mimeNode.FileType == FileTypeEnum.Unknown)
            {
                OnError(fileShell, false, mimeNode.FileType, imageUploader.Title, "Cannot process this file. The file type is not supported.");
                return;
            }

            if (imageUploader.Title == "Imgur" && mimeNode.FileType != FileTypeEnum.Image)
            {
                imageUploader = GetUploader("Shotr");
            }

            string? lastError = null;
            for (var i = 0; i < 3; i++)
            {
                if (imageUploader.UseUploadMethod)
                {
                    var result = imageUploader.UploadImage(fileShell);
                    try
                    {
                        OnUploaded(fileShell, result, null, mimeNode.FileType, mimeNode.Extension, imageUploader.Title);
                        return;
                    }
                    catch (Exception ex)
                    {
                        lastError = ex.Message;
                        continue;
                    }
                }

                var uploadHeaders = imageUploader.HeaderValues;

                try
                {
                    var output = FileUploaderService.UploadFile(imageUploader.UploaderUrl, fileShell, imageUploader.FileValueName, mimeNode.Mime, new NameValueCollection(), uploadHeaders);
                    var json = JsonConvert.DeserializeObject<UploadedItemResult>(output);
                    var result = json.ToUploadResult(imageUploader.Title, DateTime.Now);

                    OnUploaded(fileShell, result, null, mimeNode.FileType, mimeNode.Extension, imageUploader.Title);

                    return;
                }
                catch (Exception mx)
                {
                    Console.WriteLine(mx);
                    lastError = mx.Message;
                }

                Thread.Sleep((int)Math.Pow(i + 1, 2));
            }

            // If they got here, there was an issue.
            if (lastError is { })
            {
                OnError(fileShell, true, mimeNode.FileType, imageUploader.Title, lastError);
            }
        }

        private IImageUploader? GetUploader(string name)
        {
            return _imageUploaders.FirstOrDefault(p => p.Title == name);
        }
    }
}

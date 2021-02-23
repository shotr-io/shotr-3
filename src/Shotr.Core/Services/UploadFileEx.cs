using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using Shotr.Core.Uploader;

namespace Shotr.Core.Services
{
	class FileUploaderService
	{
        public delegate void UploadProgressEvent(double progress);
        public static event UploadProgressEvent OnUploadProgress = delegate { };

        public static string UploadFile(string url, FileShell file, string paramName, string contentType, NameValueCollection nvc, NameValueCollection headers)
        {
            Console.WriteLine("Uploading of size {0} bytes to {1}.", file.Size, new Uri(url).Host);
            var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            var boundarybytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            var wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;           
            wr.Credentials = CredentialCache.DefaultCredentials;
            wr.Headers.Add(new NameValueCollection { { "X-Image-Uploader", "Shotr" } });
            wr.Headers.Add(headers);

            var rs = wr.GetRequestStream();
            var formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in nvc.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                var formitem = string.Format(formdataTemplate, key, nvc[key]);
                var formitembytes = Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }

            rs.Write(boundarybytes, 0, boundarybytes.Length);

            var headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            var header = string.Format(headerTemplate, paramName, file.Name ?? Utils.Utils.GetRandomString(10), contentType);
            var headerbytes = Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            Stream? stream = null;
            if (file.Path is { })
            {
                stream = File.OpenRead(file.Path);
            }
            else if (file.Data is { })
            {
                stream = new MemoryStream(file.Data);
            }

            const int size = 4096;
            var buffer = new byte[size];
            int count = 0, pos = 0, lastProgress = 0;
            while ((count = stream.Read(buffer, 0, size)) > 0)
            {
                rs.Write(buffer, 0, count);
                rs.Flush();
                pos += count;
                //report progress.
                var progress = Convert.ToInt32(Math.Round(pos / (double)file.Size * 100, 0));
                if (lastProgress != progress)
                {
                    Console.WriteLine("Reporting Upload Progress: {0}%", Convert.ToInt32(progress));
                    OnUploadProgress(progress);
                    lastProgress = progress;
                }
            }
            stream.Close();

            var trailer = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            //100%
            try
            {
                var response = wr.GetResponse();
                OnUploadProgress(101d);
                var output = new StreamReader(response.GetResponseStream()).ReadToEnd();
                response.Close();
                Console.WriteLine("File uploaded, server response is: {0}", output);
                return output;
            }
            catch (Exception ex)
            {
                OnUploadProgress(101d);
                Console.WriteLine("Error Uploading File: {0}", ex);
                throw;
            }
        }
	}
}

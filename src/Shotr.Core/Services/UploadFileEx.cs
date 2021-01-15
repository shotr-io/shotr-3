using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace Shotr.Core.Services
{
	class FileUploaderService
	{
        public delegate void UploadProgressEvent(object sender, double progress);
        public static event UploadProgressEvent OnUploadProgress = delegate { };

        public static string UploadFile(string url, byte[] file, string filename, string paramName, string contentType, NameValueCollection nvc, NameValueCollection headers)
        {
            Console.WriteLine("Uploading of size {0} bytes to {1}.", file.Length, new Uri(url).Host);
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
            var header = string.Format(headerTemplate, paramName, filename, contentType);
            var headerbytes = Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);
            try
            {
                using (var ms = new MemoryStream(file))
                {
                    const int size = 4096;
                    var buffer = new byte[size];
                    var count = 0;
                    var pos = 0;
                    var lastprogress = 0;
                    while ((count = ms.Read(buffer, 0, size)) > 0)
                    {
                        rs.Write(buffer, 0, count);
                        rs.Flush();
                        pos += count;
                        //report progress.
                        var progress = Convert.ToInt32(pos / (double)file.Length * 100);
                        if (lastprogress != progress)
                        {
                            Console.WriteLine("Reporting Upload Progress: {0}%", Convert.ToInt32(progress));
                            OnUploadProgress(null, progress);
                            lastprogress = progress;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Failed, error message: {0}", ex);
                return "";
            }
            var trailer = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            WebResponse wresp = null;
            //100%
            try
            {
                wresp = wr.GetResponse();
                OnUploadProgress(null, 101d);
                var stream2 = wresp.GetResponseStream();
                var reader2 = new StreamReader(stream2);
                var p = reader2.ReadToEnd();
                Console.WriteLine("File uploaded, server response is: {0}", p);
                return p;
            }
            catch (Exception ex)
            {
                OnUploadProgress(null, 101d);
                Console.WriteLine("Error Uploading File: {0}", ex);
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }
            return "";
        }
	}
}
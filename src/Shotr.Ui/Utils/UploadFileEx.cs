using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;

namespace Shotr.Ui.Utils
{
	class FileUploader
	{
        public delegate void UploadProgressEvent(object sender, double progress);
        public static event UploadProgressEvent OnUploadProgress = delegate { };

        public static string UploadFile(string url, byte[] file, string filename, string paramName, string contentType, NameValueCollection nvc, NameValueCollection headers)
        {
            Console.WriteLine(string.Format("Uploading of size {0} bytes to {1}.", file.Length, new Uri(url).Host));
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;           
            wr.Credentials = CredentialCache.DefaultCredentials;
            wr.Headers.Add(new NameValueCollection() { { "X-Image-Uploader", "Shotr" } });
            wr.Headers.Add(headers);

            Stream rs = wr.GetRequestStream();
            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in nvc.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, nvc[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }

            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, filename, contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);
            try
            {
                using (MemoryStream ms = new MemoryStream(file))
                {
                    const int size = 4096;
                    byte[] buffer = new byte[size];
                    int count = 0;
                    int pos = 0;
                    int lastprogress = 0;
                    while ((count = ms.Read(buffer, 0, size)) > 0)
                    {
                        rs.Write(buffer, 0, count);
                        rs.Flush();
                        pos += count;
                        //report progress.
                        int progress = Convert.ToInt32((double)((double)pos / (double)file.Length) * 100);
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
                Console.WriteLine("Failed, error message: {0}", ex.ToString());
                return "";
            }
            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            WebResponse wresp = null;
            //100%
            try
            {
                wresp = wr.GetResponse();
                OnUploadProgress(null, 101d);
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                string p = reader2.ReadToEnd();
                Console.WriteLine(string.Format("File uploaded, server response is: {0}", p));
                return p;
            }
            catch (Exception ex)
            {
                OnUploadProgress(null, 101d);
                Console.WriteLine("Error Uploading File: {0}", ex.ToString());
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

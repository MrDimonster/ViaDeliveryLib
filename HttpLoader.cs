using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ViaDeliveryLib
{
    public class HttpLoader : IHttpLoader
    {
        public string GetString(string url, HttpMethod httpMethod, RequestSettings requestSettings, 
            SecurityProtocolType spt = SecurityProtocolType.Tls12)
        {
            string result = string.Empty;
            try
            {
                ServicePointManager.SecurityProtocol = spt;
                var request = CreateRequest(url, httpMethod, requestSettings);
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        result = reader.ReadToEnd();
                    }
                }
            }
            catch { }
            return result;
        }

        public async Task<string> GetStringAsync(string url, HttpMethod httpMethod, 
            RequestSettings requestSettings, SecurityProtocolType spt = SecurityProtocolType.Tls12)
        {
            var result = string.Empty;
            try
            {
                ServicePointManager.SecurityProtocol = spt;
                using (var response = (HttpWebResponse)await CreateRequest(url, httpMethod, requestSettings).GetResponseAsync().ConfigureAwait(false))
                {
                    using (var streamResponse = response.GetResponseStream())
                    {
                        using (var streamReader = new StreamReader(streamResponse))
                        {
                            result = await streamReader.ReadToEndAsync().ConfigureAwait(false);
                        }
                    }
                }
            }
            catch { }
            return result;
        }
 
        private static HttpWebRequest CreateRequest(string url, HttpMethod httpMethod, RequestSettings requestSettings)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = httpMethod.Method;

            if (requestSettings.TimeoutMs > 0)
            {
                request.Timeout = requestSettings.TimeoutMs;
            }

            if (!string.IsNullOrWhiteSpace(requestSettings.UserAgent))
            {
                request.UserAgent = requestSettings.UserAgent;
            }

            if (requestSettings.Headers.Count > 0)
            {
                var contentType = requestSettings.Headers.Where(x => string.Equals(x.Key, "content-type", StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault();

                if (!contentType.Equals(default(KeyValuePair<string, string>)))
                {
                    request.ContentType = contentType.Value;
                }

                foreach (KeyValuePair<string, string> header in requestSettings.Headers
                    .Where(x => !string.Equals(x.Key, "content-type", StringComparison.OrdinalIgnoreCase)))
                {
                    request.Headers[header.Key] = header.Value;
                }
            }

            if (!string.IsNullOrWhiteSpace(requestSettings.Accept))
            {
                request.Accept = requestSettings.Accept;
            }

            request.ContentLength = 0;

            if (!string.IsNullOrWhiteSpace(requestSettings.Body) && !string.Equals(request.Method, "GET",
                 StringComparison.OrdinalIgnoreCase))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(requestSettings.Body);
                request.ContentLength = bytes.Length;
                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                }
            }
            else if (requestSettings.FormData.Count > 0)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(string.Join("&",
                    requestSettings.FormData.Select(x => $"{x.Key}={x.Value}")));
                request.ContentLength = bytes.Length;
                request.ContentType = "application/x-www-form-urlencoded";
                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                }
            }
            return request;
        }

        public bool DownloadFile(string url, HttpMethod httpMethod, string saveToFullPath, 
            RequestSettings requestSettings, SecurityProtocolType spt = SecurityProtocolType.Tls12)
        {
            try
            {
                ServicePointManager.SecurityProtocol = spt;
                const int BUFFER_SIZE = 16 * 1024;
                using (var outputFileStream = File.Create(saveToFullPath, BUFFER_SIZE))
                {
                    var request = CreateRequest(url, httpMethod, requestSettings);
                    using (var response = request.GetResponse())
                    {
                        using (var responseStream = response.GetResponseStream())
                        {
                            var buffer = new byte[BUFFER_SIZE];
                            int bytesRead;
                            do
                            {
                                bytesRead = responseStream.Read(buffer, 0, BUFFER_SIZE);
                                outputFileStream.Write(buffer, 0, bytesRead);
                            }
                            while (bytesRead > 0);
                        }
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DownloadFileAsync(string url, HttpMethod httpMethod, string saveToFullPath,
            RequestSettings requestSettings, SecurityProtocolType spt = SecurityProtocolType.Tls12)
        {
            try
            {
                ServicePointManager.SecurityProtocol = spt;
                const int BUFFER_SIZE = 16 * 1024;
                using (var outputFileStream = File.Create(saveToFullPath, BUFFER_SIZE))
                {
                    var request = CreateRequest(url, httpMethod, requestSettings);
                    using (var response = await request.GetResponseAsync().ConfigureAwait(false))
                    {
                        using (var responseStream = response.GetResponseStream())
                        {
                            var buffer = new byte[BUFFER_SIZE];
                            int bytesRead;
                            do
                            {
                                bytesRead = responseStream.Read(buffer, 0, BUFFER_SIZE);
                                outputFileStream.Write(buffer, 0, bytesRead);
                            }
                            while (bytesRead > 0);
                        }
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}

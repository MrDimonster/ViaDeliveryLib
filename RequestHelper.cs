using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ViaDeliveryLib
{
 

    public class RequestResult
    {
        public string Url { get; set; }
        public bool IsError { get; set; } = false;
        public HttpStatusCode StatusCode { get; set; }
        public string Answer { get; set; }
        public Exception Exception { get; set; }
        public RequestResult(string url)
        {
            Url = url;
        }
        public static RequestResult Create(string url)
        {
            return new RequestResult(url);
        }
    }

    

    
 
    public static class RequestHelper
    {
        public static T GetUrl<T>(string url, HttpMethod httpMethod, 
            ISerializer serializer) where T: class
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("url must be not empty", "url");
            }
            var requestResult = GetResponse(url, httpMethod, new RequestSettings());
            return requestResult.IsError? null: AnswerToObject<T>(requestResult.Answer, serializer);
        }

        public static async Task<T> GetUrlAsync<T>(string url, HttpMethod httpMethod,
            ISerializer serializer) where T : class
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("url must be not empty", "url");
            }
            var requestResult = await GetResponseAsync(url, httpMethod, new RequestSettings());
            return requestResult.IsError ? null : AnswerToObject<T>(requestResult.Answer, serializer);
        }
 
        public static T GetUrl<T>(string url, HttpMethod httpMethod, 
            ISerializer serializer, RequestSettings requestSettings,
            SecurityProtocolType spt = SecurityProtocolType.Tls12) where T : class
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("url must be not empty", "url");
            }
            var requestResult = GetResponse(url, httpMethod, requestSettings, spt);
            return requestResult.IsError ? null : AnswerToObject<T>(requestResult.Answer, serializer);
        }

        public static async Task<T> GetUrlAsync<T>(string url, HttpMethod httpMethod,
            ISerializer serializer, RequestSettings requestSettings,
            SecurityProtocolType spt = SecurityProtocolType.Tls12) where T : class
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("url must be not empty", "url");
            }
            var requestResult = await GetResponseAsync(url, httpMethod, requestSettings, spt);
            return requestResult.IsError ? null : AnswerToObject<T>(requestResult.Answer, serializer);
        }

        public static string GetUrl(string url, HttpMethod httpMethod)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("url must be not empty", "url");
            }
            var requestResult = GetResponse(url, httpMethod, new RequestSettings());
            return requestResult.IsError ? null : requestResult.Answer;
        }

        public static string GetUrl(string url, HttpMethod httpMethod, RequestSettings requestSettings, 
            SecurityProtocolType spt = SecurityProtocolType.Tls12)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("url must be not empty", "url");
            }
            var requestResult = GetResponse(url, httpMethod, requestSettings, spt);
            return requestResult.IsError ? null : requestResult.Answer;
        }

        private static RequestResult GetResponse(string url, HttpMethod httpMethod, RequestSettings requestSettings, 
            SecurityProtocolType spt = SecurityProtocolType.Tls12)
        {
            ServicePointManager.SecurityProtocol = spt;
            var result = RequestResult.Create(url);
            requestSettings = requestSettings ?? new RequestSettings();
            var request = CreateRequest(url, httpMethod, requestSettings);
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    result.StatusCode = response.StatusCode;
                    using (var reader = new StreamReader(response.GetResponseStream(),
                        Encoding.UTF8))
                    {
                        result.Answer = reader.ReadToEnd();
                    }
                }
            }
            catch(WebException e)
            {
                result.Exception = e;
                result.IsError = true;
                if (e.Response != null)
                {
                    result.StatusCode = ((HttpWebResponse)e.Response).StatusCode;
                }
            }
            catch(Exception e)
            {
                result.Exception = e;
                result.IsError = true;
            }
            return result;
        }

        private static async Task<RequestResult> GetResponseAsync(string url, HttpMethod httpMethod, 
            RequestSettings requestSettings, SecurityProtocolType spt = SecurityProtocolType.Tls12)
        {
            var result = RequestResult.Create(url);
            requestSettings = requestSettings ?? new RequestSettings();
            ServicePointManager.SecurityProtocol = spt;
            try
            {
                using (var response = (HttpWebResponse) await CreateRequest(url, httpMethod, requestSettings).GetResponseAsync())
                {
                    using (Stream streamResponse = response.GetResponseStream())
                    {
                        using (StreamReader streamReader = new StreamReader(streamResponse))
                        {
                            result.StatusCode = response.StatusCode;
                            result.Answer = await streamReader.ReadToEndAsync();
                        }
                    }
                }
            }
            catch (WebException e)
            {
                result.Exception = e;
                result.IsError = true;
                if (e.Response != null)
                {
                    result.StatusCode = ((HttpWebResponse)e.Response).StatusCode;
                }
            }
            catch (Exception e)
            {
                result.Exception = e;
                result.IsError = true;
            }
            return result;
        }

        private static HttpWebRequest CreateRequest(string url, HttpMethod httpMethod, 
            RequestSettings requestSettings)
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

        private static T AnswerToObject<T>(string text, ISerializer serializer) where T : class
        {
            var t = typeof(T);
            if(t == typeof(string))
            {
                return text as T;
            }
            else if (t == typeof(XmlDocument))
            {
                var doc = new XmlDocument();
                doc.LoadXml(text);
                return doc as T;
            }
            else
            {
                serializer = serializer ?? new JsonSerializer();
                return serializer.DeserializeObject<T>(text);
            }
        }
    }

     
}

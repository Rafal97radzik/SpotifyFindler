using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
    internal class SpotifyWebClient
    {
        internal async Task<string> GetDataFromRequestAsync(string requestUri, string postData)
        {
            return await GetDataFromRequestAsync(requestUri, null, null, postData);
        }

        internal async Task<string> GetDataFromRequestAsync(string requestUri, HttpRequestHeader headerType, string headerValue)
        {
            return await GetDataFromRequestAsync(requestUri, headerType, headerValue, null);
        }

        internal async Task<string> GetDataFromRequestAsync(string requestUri)
        {
            return await GetDataFromRequestAsync(requestUri, null, null, null);
        }

        internal string GetDataFromRequest(string requestUri, string postData)
        {
            return GetDataFromRequest(requestUri, null, null, postData);
        }

        internal string GetDataFromRequest(string requestUri, HttpRequestHeader headerType, string headerValue)
        {
            return GetDataFromRequest(requestUri, headerType, headerValue, null);
        }

        internal string GetDataFromRequest(string requestUri)
        {
            return GetDataFromRequest(requestUri, null, null, null);
        }

        internal async Task<string> GetDataFromRequestAsync(string requestUri, HttpRequestHeader? headerType, string headerValue, string postData)
        {
            WebResponse response = await GetResponseAsync(requestUri, headerType, headerValue, postData);

            using (var responseReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return await responseReader.ReadToEndAsync();
            }
        }

        internal string GetDataFromRequest(string requestUri, HttpRequestHeader? headerType, string headerValue, string postData)
        {
            WebResponse response =  GetResponse(requestUri, headerType, headerValue, postData);

            using (var responseReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return responseReader.ReadToEnd();
            }
        }

        private async Task<WebResponse> GetResponseAsync(string requestUri, HttpRequestHeader? headerType, string headerValue, string postData)
        {
            HttpWebRequest request = WebRequest.CreateHttp(requestUri);
            request.ContentType = "application/x-www-form-urlencoded";

            if (headerType.HasValue)
                request.Headers.Add(headerType.Value, headerValue);

            if (string.IsNullOrEmpty(postData))
            {
                request.Method = WebRequestMethods.Http.Get;
            }
            else
            {
                request.Method = WebRequestMethods.Http.Post;
                SendPostData(postData, request);
            }

            return await request.GetResponseAsync();
        }

        private WebResponse GetResponse(string requestUri, HttpRequestHeader? headerType, string headerValue, string postData)
        {
            HttpWebRequest request = WebRequest.CreateHttp(requestUri);
            request.ContentType = "application/x-www-form-urlencoded";

            if (headerType.HasValue)
                request.Headers.Add(headerType.Value, headerValue);

            if (string.IsNullOrEmpty(postData))
            {
                request.Method = WebRequestMethods.Http.Get;
            }
            else
            {
                request.Method = WebRequestMethods.Http.Post;
                SendPostData(postData, request);
            }

            return request.GetResponse();
        }

        private static void SendPostData(string postData, HttpWebRequest request)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            request.ContentLength = byteArray.Length;

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
        }
    }
}

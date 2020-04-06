using SpotifyFindler.Web.Enums;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyFindler.Web
{
    public class WebClient:IWebClient
    {
        public string RequestUri { get; set; }
        public RequestHeader? Header { get; set; }
        public string PostData { get; set; }
        public Method Method { get; set; }

        public WebClient()
        {
            Method = Method.GET;
        }

        public async Task<string> GetDataAsync()
        {
            WebResponse response = await GetResponseAsync();

            using (var responseReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return await responseReader.ReadToEndAsync();
            }
        }

        public string GetData()
        {
            WebResponse response = GetResponse();

            using (var responseReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return responseReader.ReadToEnd();
            }
        }

        private async Task<WebResponse> GetResponseAsync()
        {
            HttpWebRequest request = CreateRequest();

            if (request.Method == "POST" && !string.IsNullOrEmpty(PostData))
            {
                SendPostData(request);
            }

            return await request.GetResponseAsync();
        }

        private WebResponse GetResponse()
        {
            HttpWebRequest request = CreateRequest();

            if (request.Method == "POST" && !string.IsNullOrEmpty(PostData))
            {
                SendPostData(request);
            }

            return request.GetResponse();
        }

        private HttpWebRequest CreateRequest()
        {
            HttpWebRequest request = WebRequest.CreateHttp(RequestUri);
            request.ContentType = "application/x-www-form-urlencoded";

            if (Header.HasValue)
            {
                RequestHeader header = Header.Value;
                request.Headers.Add(header.Header, header.Value);
            }

            request.Method = Method.ToString();

            return request;
        }

        private void SendPostData(HttpWebRequest request)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(PostData);

            request.ContentLength = byteArray.Length;

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
        }
    }
}

using System.Net;

namespace SpotifyFindler.Web
{
    public struct RequestHeader
    {
        public HttpRequestHeader Header { get; set; }
        public string Value { get; set; }
    }
}

using SpotifyFindler.Web.Enums;
using System.Threading.Tasks;

namespace SpotifyFindler.Web
{
    public interface IWebClient
    {
        string RequestUri { get; set; }
        RequestHeader? Header { get; set; }
        string PostData { get; set; }
        Method Method { get; set; }


        Task<string> GetDataAsync();

        string GetData();
    }
}

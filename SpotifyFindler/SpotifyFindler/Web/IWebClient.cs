using SpotifyFindler.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

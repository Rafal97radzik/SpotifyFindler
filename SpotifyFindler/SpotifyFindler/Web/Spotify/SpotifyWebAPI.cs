using Newtonsoft.Json;
using SpotifyFindler.Models;
using SpotifyFindler.Web.Spotify.Auth;
using SpotifyFindler.Web.Spotify.Enums;
using System.Net;
using System.Threading.Tasks;

namespace SpotifyFindler.Web.Spotify
{
    public class SpotifyWebAPI : ISpotifyAPI
    {
        private IWebClient webClient;
        private ISpotifyAuth spotifyAuthorization;
        private SpotifyWebBuilder spotifyWebBuilder;

        private Token Token { get => spotifyAuthorization.GetToken(); }

        public SpotifyWebAPI()
        {
            spotifyAuthorization = Depency.GetInstance<ISpotifyAuth>();
            webClient = Depency.GetInstance<IWebClient>();
            spotifyWebBuilder = new SpotifyWebBuilder();
        }

        public async Task<Search> SearchAsync(string queryKeywords, SearchType type, int limit = 20, int offset = 0)
        {
            string uri = spotifyWebBuilder.Search(queryKeywords, limit, offset, type);

            return await GetData<Search>(uri);
        }

        public async Task<Search> GetAlbumTracksAsync(string albumId, int limit = 20, int offset = 0)
        {
            string uri = spotifyWebBuilder.AlbumTracks(albumId, limit, offset);

            return await GetData<Search>(uri);
        }

        public async Task<Search> GetAlbum(string albumId)
        {
            string uri = spotifyWebBuilder.Album(albumId);

            return await GetData<Search>(uri);
        }

        private async Task<T> GetData<T>(string uri)
        {
            string headerValue = spotifyWebBuilder.HeaderValue(Token);

            webClient.RequestUri = uri;
            webClient.Header = new RequestHeader { Header = HttpRequestHeader.Authorization, Value = headerValue };

            string dataString = await webClient.GetDataAsync();

            return JsonConvert.DeserializeObject<T>(dataString);
        }
    }
}

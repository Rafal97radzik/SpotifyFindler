using Newtonsoft.Json;
using SpotifyFindler.Models;
using SpotifyFindler.Web;
using SpotifyFindler.Web.Auth;
using SpotifyFindler.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyFindler
{
    public class SpotifyWebAPI
    {
        private Web.WebClient webClient;
        private ISpotifyAuth spotifyAuthorization;
        private SpotifyWebBuilder spotifyWebBuilder;

        private Token Token { get => spotifyAuthorization.GetToken(); }

        public SpotifyWebAPI(string clientId, string clientSecret)
        {
            spotifyAuthorization = new SpotifyAuthorization(clientId, clientSecret);
            webClient = new Web.WebClient();
            spotifyWebBuilder = new SpotifyWebBuilder();
        }

        public async Task<Search> SearchAsync(string queryKeywords, int limit = 20, int offset = 0, SearchType type)
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
            Token token = spotifyAuthorization.GetToken();
            string headerValue = spotifyWebBuilder.HeaderValue(token);

            webClient.RequestUri = uri;
            webClient.Header = new RequestHeader { Header = HttpRequestHeader.Authorization, Value = headerValue };

            string dataString = await webClient.GetDataAsync();

            return JsonConvert.DeserializeObject<T>(dataString);
        }
    }
}

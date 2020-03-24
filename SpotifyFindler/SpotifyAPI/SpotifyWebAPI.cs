using Newtonsoft.Json;
using SpotifyAPI.Auth;
using SpotifyAPI.Enums;
using SpotifyAPI.Models;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAPI
{
    public class SpotifyWebAPI
    {
        private SpotifyWebClient spotifyWebClient;
        private SpotifyAuthorization spotifyAuthorization;
        private SpotifyWebBuilder spotifyWebBuilder;

        private Token Token { get => spotifyAuthorization.GetToken(); }

        public SpotifyWebAPI(string clientId, string clientSecret)
        {
            spotifyAuthorization = new SpotifyAuthorization(clientId, clientSecret);
            spotifyWebClient = new SpotifyWebClient();
            spotifyWebBuilder = new SpotifyWebBuilder();
        }

        public async Task<Search> SearchAsync(string queryKeywords, int limit = 20, int offset = 0, params SearchType[] type)
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

            string dataString = await spotifyWebClient.GetDataFromRequestAsync(uri, HttpRequestHeader.Authorization, headerValue);

            return JsonConvert.DeserializeObject<T>(dataString);
        }
    }
}

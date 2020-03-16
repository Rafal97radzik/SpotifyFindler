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
        }

        /// <summary>
        ///     Get Spotify catalog information about artists, albums, tracks or playlists that match a keyword string.
        /// </summary>
        /// <param name="queryKeywords">The search query's keywords (and optional field filters and operators), for example q=roadhouse+blues.</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first result to return. Default: 0</param>
        /// <param name="type">A list of item types to search across.</param>
        /// <returns></returns>
        public async Task<Search> SearchAsync(string queryKeywords, int limit = 20, int offset = 0, params SearchType[] type)
        {
            string uri = spotifyWebBuilder.Search(queryKeywords, limit, offset, type);

            Token token = spotifyAuthorization.GetToken();
            string headerValue = spotifyWebBuilder.HeaderValue(token);

            string dataString = await spotifyWebClient.GetDataFromRequestAsync(uri, HttpRequestHeader.Authorization, headerValue);

            return JsonConvert.DeserializeObject<Search>(dataString);
        }

        /// <summary>
        ///     Get Spotify catalog information about artists, albums, tracks or playlists that match a keyword string.
        /// </summary>
        /// <param name="queryKeywords">The search query's keywords (and optional field filters and operators), for example q=roadhouse+blues.</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first result to return. Default: 0</param>
        /// <param name="type">A list of item types to search across.</param>
        /// <returns></returns>
        public Search Search(string queryKeywords, int limit = 20, int offset = 0, params SearchType[] type)
        {
            string uri = spotifyWebBuilder.Search(queryKeywords, limit, offset, type);
            string headerValue = spotifyWebBuilder.HeaderValue(Token);

            string dataString = spotifyWebClient.GetDataFromRequest(uri, HttpRequestHeader.Authorization, headerValue);

            return JsonConvert.DeserializeObject<Search>(dataString);
        }
    }
}

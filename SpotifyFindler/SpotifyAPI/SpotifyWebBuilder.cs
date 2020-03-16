using SpotifyAPI.Enums;
using SpotifyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAPI
{
    internal class SpotifyWebBuilder
    {
        private const string APIBase = "https://api.spotify.com/v1";

        internal string Search(string queryKeywords, int limit = 20, int offset = 0, params SearchType[] type)
        {
            limit = Math.Min(50, limit);
            StringBuilder builder = new StringBuilder(APIBase + "/search");
            builder.Append("?q=" + queryKeywords);
            builder.Append("&type=" + type.ToString());
            builder.Append("&limit=" + limit);
            builder.Append("&offset=" + offset);

            return builder.ToString();
        }

        internal string HeaderValue(Token token)
        {
            StringBuilder builder = new StringBuilder(token.TokenType);
            builder.Append("" + token.AccessToken);

            return builder.ToString();
        }
    }
}

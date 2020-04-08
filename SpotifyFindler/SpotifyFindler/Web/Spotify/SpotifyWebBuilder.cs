using SpotifyFindler.Models;
using SpotifyFindler.Web.Spotify.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyFindler.Web.Spotify
{
    internal class SpotifyWebBuilder
    {
        private const string APIBase = "https://api.spotify.com/v1";

        internal string Search(string queryKeywords, int limit, int offset, SearchType type)
        {
            limit = Math.Min(50, limit);
            StringBuilder builder = new StringBuilder(APIBase + "/search");
            builder.Append("?q=" + queryKeywords);
            builder.Append("&type=" + type.ToString().Replace(" ", ""));
            builder.Append("&limit=" + limit);
            builder.Append("&offset=" + offset);

            return builder.ToString();
        }

        internal string AlbumTracks(string albumId, int limit, int offset)
        {
            limit = Math.Min(50, limit);
            StringBuilder builder = new StringBuilder(APIBase + "/albums/");
            builder.Append(albumId+"/tracks");
            builder.Append("?limit=" + limit);
            builder.Append("&offset=" + offset);

            return builder.ToString();
        }

        internal string Album(string albumId)
        {
            StringBuilder builder = new StringBuilder(APIBase + "/albums/");
            builder.Append(albumId);

            return builder.ToString();
        }

        internal string HeaderValue(Token token)
        {
            StringBuilder builder = new StringBuilder(token.TokenType);
            builder.Append(" " + token.AccessToken);

            return builder.ToString();
        }
    }
}

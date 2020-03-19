using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyAPI;
using SpotifyAPI.Enums;
using SpotifyAPI.Models;
using SpotifyFindler.Properties;
using SpotifyFindler.ViewModels;

namespace SpotifyFindler.API
{
    public class APIClient
    {
        private SpotifyWebAPI spotify;

        public APIClient()
        {
            spotify = new SpotifyWebAPI(Settings.Default.ClientId, Settings.Default.ClientSecret);
        }

        public async Task<Search> SearchAsync(string queryKeywords, int limit = 20, int offset = 0, params SearchType[] type)
        {
            return await spotify.SearchAsync(queryKeywords, limit, offset, type);
        }

        public Search Search(string queryKeywords, int limit = 20, int offset = 0, params SearchType[] type)
        {
            return spotify.Search(queryKeywords, limit, offset, type);
        }
    }
}

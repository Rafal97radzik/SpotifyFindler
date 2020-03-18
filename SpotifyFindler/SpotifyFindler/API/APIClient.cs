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
        private SearchViewModel viewModel;

        public APIClient(SearchViewModel viewModel)
        {
            spotify = new SpotifyWebAPI(Settings.Default.ClientId, Settings.Default.ClientSecret);
            this.viewModel = viewModel;
        }

        public async Task SearchAsync(string queryKeywords, int limit = 20, int offset = 0, params SearchType[] type)
        {
            Search searchResult = await spotify.SearchAsync(queryKeywords, limit, offset, type);

            ClearItems();
            AddItems(searchResult);
        }

        public void Search(string queryKeywords, int limit = 20, int offset = 0, params SearchType[] type)
        {
            var searchResult = spotify.Search(queryKeywords, limit, offset, type);

            ClearItems();
            AddItems(searchResult);
        }

        private void ClearItems()
        {
            viewModel.Albums.ToList().ForEach(a => viewModel.Albums.Remove(a));
            viewModel.Artists.ToList().ForEach(a => viewModel.Artists.Remove(a));
            viewModel.Playlists.ToList().ForEach(p => viewModel.Playlists.Remove(p));
            viewModel.Tracks.ToList().ForEach(t => viewModel.Tracks.Remove(t));
        }

        private void AddItems(Search searchResult)
        {
            searchResult.Albums?.Items.ForEach(a => viewModel.Albums.Add(a));

            searchResult.Artists?.Items.ForEach(a => viewModel.Artists.Add(a));

            searchResult.Playlists?.Items.ForEach(p => viewModel.Playlists.Add(p));

            searchResult.Tracks?.Items.ForEach(t => viewModel.Tracks.Add(t));
        }
    }
}

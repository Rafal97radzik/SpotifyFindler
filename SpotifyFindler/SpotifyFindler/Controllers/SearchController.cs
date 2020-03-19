using SpotifyAPI.Enums;
using SpotifyAPI.Models;
using SpotifyFindler.API;
using SpotifyFindler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyFindler.Controllers
{
    public class SearchController
    {
        private SearchViewModel viewModel;
        private APIClient client;

        public SearchController(SearchViewModel viewModel)
        {
            this.viewModel = viewModel;
            client = new APIClient();
        }

        public async Task Search(string queryKeywords)
        {
            var result = await client.SearchAsync(queryKeywords, 20, 0, SearchType.album, SearchType.artist, SearchType.playlist, SearchType.track);

            ClearViewModel();
            ViewModelAddData(result);
        }

        private void ViewModelAddData(Search result)
        {
            result.Albums.Items.ForEach(a => viewModel.Albums.Add(a));
            result.Artists.Items.ForEach(a => viewModel.Artists.Add(a));
            result.Playlists.Items.ForEach(p => viewModel.Playlists.Add(p));
            result.Tracks.Items.ForEach(t => viewModel.Tracks.Add(t));
        }

        private void ClearViewModel()
        {
            viewModel.Albums.Clear();
            viewModel.Artists.Clear();
            viewModel.Playlists.Clear();
            viewModel.Tracks.Clear();
        }
    }
}

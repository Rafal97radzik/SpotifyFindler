using SpotifyFindler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyFindler.Controllers
{
    class SearchAlbumController
    {
        private SearchAlbumViewModel viewModel;
        private APIClient client;
        private int offset;
        private string queryKeywords;

        public SearchAlbumController(SearchAlbumViewModel viewModel, string queryKeywords)
        {
            this.viewModel = viewModel;
            this.queryKeywords = queryKeywords;
            client = new APIClient();
            offset = 0;
        }

        public async Task GetNextAlbums()
        {
            var result = await client.SearchAsync(queryKeywords, 50, offset, SearchType.album);

            result.Albums.Items.ForEach(a => viewModel.Albums.Add(a));

            offset += 50;
        }
    }
}

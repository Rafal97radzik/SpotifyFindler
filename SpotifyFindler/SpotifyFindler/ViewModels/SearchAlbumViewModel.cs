using SpotifyFindler.Models;
using SpotifyFindler.Web.Spotify;
using SpotifyFindler.Web.Spotify.Enums;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SpotifyFindler.ViewModels
{
    public class SearchAlbumViewModel
    {
        private ISpotifyAPI spotifyAPI;
        private int offset;
        private string queryKeywords;


        public ObservableCollection<Item> Albums { get; set; }


        public SearchAlbumViewModel()
        {
            spotifyAPI = Depency.GetInstance<ISpotifyAPI>();

            Albums = new ObservableCollection<Item>();
        }


        public async Task Search(string queryKeywords)
        {
            this.queryKeywords = queryKeywords;

            var result = await spotifyAPI.SearchAsync(queryKeywords, SearchType.album, 50, 0);

            Albums.Clear();
            result.Albums.Items.ForEach(a => Albums.Add(a));

            offset = 50;
        }

        public async Task GetNextAlbums()
        {
            var result = await spotifyAPI.SearchAsync(queryKeywords, SearchType.album, 50, offset);

            result.Albums.Items.ForEach(a => Albums.Add(a));

            offset += 50;
        }
    }
}

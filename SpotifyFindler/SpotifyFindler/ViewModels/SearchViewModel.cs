using SpotifyFindler.Models;
using SpotifyFindler.Web.Spotify;
using SpotifyFindler.Web.Spotify.Enums;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SpotifyFindler.ViewModels
{
    public class SearchViewModel
    {
        private ISpotifyAPI spotifyAPI;

        public ObservableCollection<Item> Albums { get; set; }
        public ObservableCollection<Item> Tracks { get; set; }
        public ObservableCollection<Item> Playlists { get; set; }
        public ObservableCollection<Item> Artists { get; set; }


        public SearchViewModel()
        {
            spotifyAPI = Depency.GetInstance<ISpotifyAPI>();

            Albums = new ObservableCollection<Item>();
            Tracks = new ObservableCollection<Item>();
            Playlists = new ObservableCollection<Item>();
            Artists = new ObservableCollection<Item>();
        }


        public async Task Search(string queryKeywords)
        {
            Search result = await spotifyAPI.SearchAsync(queryKeywords, SearchType.album | SearchType.artist | SearchType.playlist | SearchType.track, 4, 0);

            ClearViewModel();
            ViewModelAddData(result);
        }

        private void ViewModelAddData(Search result)
        {
            result.Albums.Items.ForEach(a => Albums.Add(a));
            result.Artists.Items.ForEach(a => Artists.Add(a));
            result.Playlists.Items.ForEach(p => Playlists.Add(p));
            result.Tracks.Items.ForEach(t => Tracks.Add(t));
        }

        private void ClearViewModel()
        {
            Albums.Clear();
            Artists.Clear();
            Playlists.Clear();
            Tracks.Clear();
        }
    }
}

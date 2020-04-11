using SpotifyFindler.Models;
using SpotifyFindler.Web.Spotify.Enums;
using System.Threading.Tasks;

namespace SpotifyFindler.Web.Spotify
{
    public interface ISpotifyAPI
    {
        Task<Search> SearchAsync(string queryKeywords, SearchType type, int limit = 20, int offset = 0);

        Task<Search> GetAlbumTracksAsync(string albumId, int limit = 20, int offset = 0);

        Task<Search> GetAlbum(string albumId);
    }
}

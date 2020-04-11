using SpotifyFindler.Models;

namespace SpotifyFindler.Web.Spotify.Auth
{
    public interface ISpotifyAuth
    {
        Token GetToken();
    }
}

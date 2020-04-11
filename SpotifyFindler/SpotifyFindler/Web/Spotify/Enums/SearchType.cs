using System;

namespace SpotifyFindler.Web.Spotify.Enums
{
    [Flags]
    public enum SearchType
    {
        artist=1,
        album=2,
        track=4,
        playlist=8 
    }
}

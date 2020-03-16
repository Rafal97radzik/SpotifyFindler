using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAPI.Enums
{
    [Flags]
    public enum SearchType
    {
        artist,
        album,
        track,
        playlist 
    }
}

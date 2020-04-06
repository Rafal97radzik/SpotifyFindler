using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyFindler.Web.Enums
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

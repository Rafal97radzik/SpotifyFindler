using SpotifyFindler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyFindler.Web.Auth
{
    public interface ISpotifyAuth
    {
        Token GetToken();

        Task<Token> GetTokenAsync();
    }
}

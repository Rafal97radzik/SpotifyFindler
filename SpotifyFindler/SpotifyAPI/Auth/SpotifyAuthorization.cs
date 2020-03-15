using Newtonsoft.Json;
using SpotifyAPI.Models;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAPI.Auth
{
    public class SpotifyAuthorization
    {
        private const string uri = "https://accounts.spotify.com/api/token";
        private const string postData = "grant_type=client_credentials";
        private string headerValue;
        private SpotifyWebClient webClient;
        private Token token;
        private DateTime tokenExpiresIn;

        public SpotifyAuthorization(string clientId, string clientSecret)
        {
            this.headerValue = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(clientId + ":" + clientSecret));
            this.webClient = new SpotifyWebClient();
            this.token = new Token { ExpiresIn = 0 };
            this.tokenExpiresIn = DateTime.Now;
        }

        public Token GetToken()
        {
            if (DateTime.Now > tokenExpiresIn)
            {
                string dateString = webClient.GetDataFromRequest(uri, HttpRequestHeader.Authorization, headerValue, postData);
                token = JsonConvert.DeserializeObject<Token>(dateString);
                tokenExpiresIn = DateTime.Now.AddSeconds(token.ExpiresIn - 30);
            }

            return token;
        }

        public async Task<Token> GetTokenAsync()
        {
            if (DateTime.Now > tokenExpiresIn)
            {
                string dateString = await webClient.GetDataFromRequestAsync(uri, HttpRequestHeader.Authorization, headerValue, postData);
                token = JsonConvert.DeserializeObject<Token>(dateString);
                tokenExpiresIn = DateTime.Now.AddSeconds(token.ExpiresIn - 30);
            }

            return token;
        }
    }
}

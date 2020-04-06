using Newtonsoft.Json;
using SpotifyFindler.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyFindler.Web.Auth
{
    public class SpotifyAuthorization:ISpotifyAuth
    {
        private IWebClient webClient;
        private Token token;
        private DateTime tokenExpiresIn;

        public SpotifyAuthorization(string clientId, string clientSecret)
        {
            string headerValue = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(clientId + ":" + clientSecret));
            
            webClient = Depency.GetInstance<IWebClient>();

            webClient.RequestUri= "https://accounts.spotify.com/api/token";
            webClient.Method = Enums.Method.POST;
            webClient.Header = new RequestHeader { Header = HttpRequestHeader.Authorization, Value = headerValue };
            webClient.PostData = "grant_type=client_credentials";

            tokenExpiresIn = DateTime.Now.AddDays(-1);
        }

        public Token GetToken()
        {
            if (DateTime.Now > tokenExpiresIn)
            {
                string dataString = webClient.GetData();
                token = JsonConvert.DeserializeObject<Token>(dataString);
                tokenExpiresIn = DateTime.Now.AddSeconds(token.ExpiresIn - 30);
            }

            return token;
        }

        public async Task<Token> GetTokenAsync()
        {
            if (DateTime.Now > tokenExpiresIn)
            {
                string dataString = await webClient.GetDataAsync();
                token = JsonConvert.DeserializeObject<Token>(dataString);
                tokenExpiresIn = DateTime.Now.AddSeconds(token.ExpiresIn - 30);
            }

            return token;
        }
    }
}

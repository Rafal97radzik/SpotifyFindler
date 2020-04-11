using Newtonsoft.Json;
using SpotifyFindler.Web.Enums;
using SpotifyFindler.Models;
using System;
using System.Net;
using System.Text;
using SpotifyFindler.Properties;

namespace SpotifyFindler.Web.Spotify.Auth
{
    public class SpotifyAuthorization:ISpotifyAuth
    {
        private IWebClient webClient;
        private Token token;


        public SpotifyAuthorization()
        {
            string clientId = Settings.Default.ClientId;
            string clientSecret = Settings.Default.ClientSecret;

            string headerValue = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(clientId + ":" + clientSecret));
            
            webClient = Depency.GetInstance<IWebClient>();

            webClient.RequestUri= "https://accounts.spotify.com/api/token";
            webClient.Method = Method.POST;
            webClient.Header = new RequestHeader { Header = HttpRequestHeader.Authorization, Value = headerValue };
            webClient.PostData = "grant_type=client_credentials";
        }


        public Token GetToken()
        {
            if (token==null || DateTime.Now > token.Expires)
            {
                string dataString = webClient.GetData();
                token = JsonConvert.DeserializeObject<Token>(dataString);
            }

            return token;
        }
    }
}

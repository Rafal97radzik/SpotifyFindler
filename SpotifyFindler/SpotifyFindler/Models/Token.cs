using Newtonsoft.Json;
using System;

namespace SpotifyFindler.Models
{
    public class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        public DateTime Created { get; } = DateTime.Now;

        public DateTime Expires { get => Created.AddSeconds(ExpiresIn - 30); }
    }
}

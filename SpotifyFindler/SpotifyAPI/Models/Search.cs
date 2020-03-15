using Newtonsoft.Json;

namespace SpotifyAPI.Models
{
    public class Search
    {
        [JsonProperty("albums")]
        public Albums Albums { get; set; }

        [JsonProperty("artists")]
        public Artists Artists { get; set; }

        [JsonProperty("tracks")]
        public Tracks Tracks { get; set; }

        [JsonProperty("playlists")]
        public Playlists Playlists { get; set; }
    }
}

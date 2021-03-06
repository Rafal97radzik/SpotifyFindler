﻿using Newtonsoft.Json;


namespace SpotifyFindler.Models
{
    public class Owner
    {
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}

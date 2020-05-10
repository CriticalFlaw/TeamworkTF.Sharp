using Newtonsoft.Json;
using System;

namespace TeamworkAPI
{
    public class News
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("link")]
        public Uri Link { get; set; }

        [JsonProperty("created_at")]
        public CreatedAt CreatedAt { get; set; }
    }

    public class CreatedAt
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("timezone_type")]
        public long TimeZoneType { get; set; }

        [JsonProperty("timezone")]
        public string TimeZone { get; set; }
    }
}
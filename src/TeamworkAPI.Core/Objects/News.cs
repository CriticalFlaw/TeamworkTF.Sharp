using Newtonsoft.Json;

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
        public string Link { get; set; }

        [JsonProperty("created_at")]
        public CreatedAt CreationDate { get; set; }
    }

    public class CreatedAt
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("timezone_type")]
        public int TimeZoneType { get; set; }

        [JsonProperty("timezone")]
        public string TimeZone { get; set; }
    }
}
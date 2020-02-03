using Newtonsoft.Json;
using System.Collections.Generic;

namespace TeamworkAPI
{
    public class Mode
    {
        [JsonProperty("gamemodes_official")]
        public List<OfficialModes> Official { get; set; }

        [JsonProperty("gamemodes_community")]
        public List<CommunityModes> Community { get; set; }
    }

    public class OfficialModes
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("desc")]
        public string Description { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("playing")]
        public int Playing { get; set; }
    }

    public class CommunityModes
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("desc")]
        public string Description { get; set; }

        [JsonProperty("learn")]
        public string Learn { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("playing")]
        public int Playing { get; set; }
    }
}
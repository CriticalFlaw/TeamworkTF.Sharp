using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamworkTF.Sharp
{
    public class GameMode
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("title")] public string Title { get; set; }

        [JsonProperty("desc")] public string Description { get; set; }

        [JsonProperty("learn", NullValueHandling = NullValueHandling.Ignore)]
        public string Learn { get; set; }

        [JsonProperty("color")] public string Color { get; set; }

        [JsonProperty("playing")] public int Playing { get; set; }
    }

    public class GameModes
    {
        [JsonProperty("gamemodes_official")]
        public List<GameMode> Official { get; set; }

        [JsonProperty("gamemodes_community")]
        public List<GameMode> Community { get; set; }
    }
}
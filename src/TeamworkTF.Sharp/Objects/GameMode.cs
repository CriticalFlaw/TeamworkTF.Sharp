using Newtonsoft.Json;

namespace TeamworkTF.Sharp
{
    public class GameMode
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("desc")]
        public string Description { get; set; }

        [JsonProperty("learn", NullValueHandling = NullValueHandling.Ignore)]
        public string Learn { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("playing")]
        public int Playing { get; set; }
    }
}
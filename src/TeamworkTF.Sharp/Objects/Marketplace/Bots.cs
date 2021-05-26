using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamworkTF.Sharp
{
    public class Bots
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("bots")]
        public List<Bot> BotList { get; set; }
    }

    public class Bot
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("steamid")]
        public string SteamId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
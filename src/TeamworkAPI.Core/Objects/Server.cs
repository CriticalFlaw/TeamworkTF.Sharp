using Newtonsoft.Json;
using System.Collections.Generic;

namespace TeamworkAPI.Objects
{
    public class Server
    {
        [JsonProperty("ip")]
        public string IP { get; set; }

        [JsonProperty("port")]
        public string Port { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("reachable")]
        public bool Reachable { get; set; }

        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("valve_secure")]
        public bool ValveSecured { get; set; }

        [JsonProperty("sourcecbl_secure")]
        public bool SourceSecured { get; set; }

        [JsonProperty("map_name")]
        public string MapName { get; set; }

        [JsonProperty("map_name_thumbnail")]
        public string ThumbnailPath { get; set; }

        [JsonProperty("map_name_next")]
        public string NextMap { get; set; }

        [JsonProperty("players")]
        public int PlayerCount { get; set; }

        [JsonProperty("max_players")]
        public int PlayerCountMax { get; set; }

        [JsonProperty("gamemodes")]
        public List<string> GameModes { get; set; }

        [JsonProperty("gametype")]
        public string GameType { get; set; }

        [JsonProperty("has_password")]
        public bool? HasPassword { get; set; }

        [JsonProperty("has_rtd")]
        public bool HasRollTheDice { get; set; }

        [JsonProperty("has_randomcrits")]
        public bool? HasRandomCrits { get; set; }

        [JsonProperty("has_norespawntime")]
        public bool HasNoSpawnTimer { get; set; }

        [JsonProperty("has_alltalk")]
        public bool HasAllTalk { get; set; }
    }
}
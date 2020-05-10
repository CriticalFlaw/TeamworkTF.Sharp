using Newtonsoft.Json;
using System.Collections.Generic;

namespace TeamworkAPI
{
    public class Server
    {
        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("port")]
        public string Port { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("reachable")]
        public bool Reachable { get; set; }

        [JsonProperty("provider")]
        public Provider Provider { get; set; }

        [JsonProperty("valve_secure")]
        public bool ValveSecure { get; set; }

        [JsonProperty("map_name")]
        public string MapName { get; set; }

        [JsonProperty("map_name_next")]
        public string MapNameNext { get; set; }

        [JsonProperty("players")]
        public long Players { get; set; }

        [JsonProperty("max_players")]
        public long MaxPlayers { get; set; }

        [JsonProperty("gamemodes")]
        public List<string> GameModes { get; set; }

        [JsonProperty("gametype")]
        public string GameType { get; set; }

        [JsonProperty("has_password")]
        public bool HasPassword { get; set; }

        [JsonProperty("has_rtd")]
        public bool HasRtd { get; set; }

        [JsonProperty("has_randomcrits")]
        public bool? HasRandomCrits { get; set; }

        [JsonProperty("has_norespawntime")]
        public bool HasNoRespawnTime { get; set; }

        [JsonProperty("has_alltalk")]
        public bool HasAllTalk { get; set; }
    }
}
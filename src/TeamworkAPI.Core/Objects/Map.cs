using Newtonsoft.Json;
using System.Collections.Generic;

namespace TeamworkAPI
{
    public class Map
    {
        [JsonProperty("map")]
        public string Name { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("first_seen")]
        public object FirstSeen { get; set; }

        [JsonProperty("last_seen")]
        public string LastSeen { get; set; }

        [JsonProperty("all_gamemodes")]
        public List<string> GameModes { get; set; }

        [JsonProperty("all_server_types")]
        public List<string> ServerTypes { get; set; }

        [JsonProperty("highest_players")]
        public int HighestPlayerCount { get; set; }

        [JsonProperty("highest_servers")]
        public int HighestServerCount { get; set; }

        [JsonProperty("alltime_avg_players")]
        public string AvgPlayers { get; set; }

        [JsonProperty("alltime_avg_players_days")]
        public int AvgPlayersDays { get; set; }

        [JsonProperty("official_map")]
        public bool OfficialMap { get; set; }

        [JsonProperty("normalized_map_name")]
        public string NameNormalized { get; set; }

        [JsonProperty("related_maps")]
        public List<string> RelatedMaps { get; set; }

        [JsonProperty("context")]
        public MapContext Context { get; set; }
    }

    public class MapContext
    {
        [JsonProperty("normalized_map_name")]
        public string NameNormalized { get; set; }

        [JsonProperty("file_hash")]
        public string FileHash { get; set; }

        [JsonProperty("map_version_sampled")]
        public int MapVersion { get; set; }

        [JsonProperty("entity_count")]
        public int EntityCount { get; set; }

        [JsonProperty("level_overview")]
        public LevelOverview LevelOverview { get; set; }

        [JsonProperty("screenshots")]
        public List<string> Screenshots { get; set; }

        [JsonProperty("elo_rating_best")]
        public int TopELORating { get; set; }
    }

    public class ImageContext
    {
        [JsonProperty("screenHeight")]
        public int Height { get; set; }

        [JsonProperty("scale")]
        public int Scale { get; set; }

        [JsonProperty("screenWidth")]
        public int Width { get; set; }

        [JsonProperty("y")]
        public int? Y { get; set; }

        [JsonProperty("x")]
        public double? X { get; set; }

        [JsonProperty("z")]
        public double? Z { get; set; }
    }

    public class LevelOverview
    {
        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("context")]
        public List<ImageContext> Context { get; set; }
    }

    public class MapSearch
    {
        [JsonProperty("map_name")]
        public string Name { get; set; }
    }

    public class MapThumbnail
    {
        [JsonProperty("thumbnail")]
        public string Name { get; set; }
    }

    public class ThumbnailContext
    {
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("screenshots")]
        public List<string> Screenshots { get; set; }

        [JsonProperty("leveloverview")]
        public LevelOverview LevelOverview { get; set; }
    }
}
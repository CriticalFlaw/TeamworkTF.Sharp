using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TeamworkTF.Sharp
{
    public class Map
    {
        [JsonProperty("map")]
        public string MapName { get; set; }

        [JsonProperty("thumbnail")]
        public Uri Thumbnail { get; set; }

        [JsonProperty("first_seen")]
        public object FirstSeen { get; set; }

        [JsonProperty("last_seen")]
        public DateTimeOffset LastSeen { get; set; }

        [JsonProperty("all_gamemodes")]
        public List<string> GameModes { get; set; }

        [JsonProperty("all_server_types")]
        public List<string> ServerTypes { get; set; }

        [JsonProperty("highest_players")]
        public long HighestPlayers { get; set; }

        [JsonProperty("highest_servers")]
        public long HighestServers { get; set; }

        [JsonProperty("alltime_avg_players")]
        public string AllTimeAvgPlayers { get; set; }

        [JsonProperty("alltime_avg_players_days")]
        public long AllTimeAvgPlayersDays { get; set; }

        [JsonProperty("official_map")]
        public bool OfficialMap { get; set; }

        [JsonProperty("normalized_map_name")]
        public string NormalizedMapName { get; set; }

        [JsonProperty("related_maps")]
        public List<string> RelatedMaps { get; set; }

        [JsonProperty("extra_info")]
        public ExtraInfo ExtraInfo { get; set; }

        [JsonProperty("context")]
        public MapContext Context { get; set; }
    }

    public class ExtraInfo
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("steam_workshop_link")]
        public Uri SteamWorkshopUrl { get; set; }

        [JsonProperty("tf2maps_link")]
        public Uri TF2MapsUrl { get; set; }

        [JsonProperty("gamebanana_link")]
        public Uri GameBananaUrl { get; set; }

        [JsonProperty("bsp_link")]
        public Uri BspUrl { get; set; }
    }

    public class MapName
    {
        [JsonProperty("map_name")]
        public string Name { get; set; }
    }

    public class MapContext
    {
        [JsonProperty("normalized_map_name")]
        public string NormalizedMapName { get; set; }

        [JsonProperty("file_hash")]
        public string FileHash { get; set; }

        [JsonProperty("map_version_sampled")]
        public long MapVersionSampled { get; set; }

        [JsonProperty("entity_count")]
        public long EntityCount { get; set; }

        [JsonProperty("level_overview")]
        public LevelOverview LevelOverview { get; set; }

        [JsonProperty("screenshots")]
        public Uri[] Screenshots { get; set; }

        [JsonProperty("elo_rating_best")]
        public long EloRatingBest { get; set; }
    }

    public class ImageContext
    {
        [JsonProperty("screenHeight", NullValueHandling = NullValueHandling.Ignore)]
        public long? ScreenHeight { get; set; }

        [JsonProperty("scale", NullValueHandling = NullValueHandling.Ignore)]
        public long? Scale { get; set; }

        [JsonProperty("screenWidth", NullValueHandling = NullValueHandling.Ignore)]
        public long? ScreenWidth { get; set; }

        [JsonProperty("y", NullValueHandling = NullValueHandling.Ignore)]
        public long? Y { get; set; }

        [JsonProperty("x", NullValueHandling = NullValueHandling.Ignore)]
        public long? X { get; set; }

        [JsonProperty("z", NullValueHandling = NullValueHandling.Ignore)]
        public long? Z { get; set; }
    }

    public class LevelOverview
    {
        [JsonProperty("image")]
        public Uri Image { get; set; }

        [JsonProperty("context")]
        public ImageContext[] Context { get; set; }
    }

    public class MapThumbnail
    {
        [JsonProperty("thumbnail")]
        public string Name { get; set; }
    }

    public class ThumbnailContext
    {
        [JsonProperty("thumbnail")]
        public Uri Thumbnail { get; set; }

        [JsonProperty("screenshots")]
        public Uri[] Screenshots { get; set; }

        [JsonProperty("leveloverview")]
        public LevelOverview LevelOverview { get; set; }
    }
}
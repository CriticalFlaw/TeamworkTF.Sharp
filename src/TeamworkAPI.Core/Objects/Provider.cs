using Newtonsoft.Json;
using System.Collections.Generic;

namespace TeamworkAPI.Objects
{
    public class Provider
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("rules_url")]
        public string RulesUrl { get; set; }

        [JsonProperty("steam_group_url")]
        public string SteamGroupUrl { get; set; }

        [JsonProperty("location_focus")]
        public string LocationFocus { get; set; }

        [JsonProperty("statistics")]
        public string StatsUrl { get; set; }

        [JsonProperty("image")]
        public string ImageUrl { get; set; }
    }

    public class ProviderStats
    {
        [JsonProperty("players")]
        public int Players { get; set; }

        [JsonProperty("regions_with_players")]
        public Regions Regions { get; set; }

        [JsonProperty("gamemodes")]
        public List<string> GameModes { get; set; }

        [JsonProperty("servers_online")]
        public int ServersOnline { get; set; }

        [JsonProperty("servers_total")]
        public int ServersTotal { get; set; }
    }

    public struct Regions
    {
        [JsonProperty("Europe")]
        public readonly int Europe;

        [JsonProperty("North America")]
        public readonly int NorthAmerica;

        [JsonProperty("Oceania")]
        public readonly int Oceania;

        [JsonProperty("Asia")]
        public readonly int Asia;
    }

    public class CompProvider
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }
    }

    public class CompProviderStats
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("created_at")]
        public string CreationDate { get; set; }

        [JsonProperty("players")]
        public int PlayerCount { get; set; }

        [JsonProperty("servers_empty")]
        public int ServerCountEmpty { get; set; }

        [JsonProperty("servers_non_empty")]
        public int ServerCountActive { get; set; }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TeamworkAPI
{
    public class Provider
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("website")]
        public Uri Website { get; set; }

        [JsonProperty("rules_url")]
        public Uri RulesUrl { get; set; }

        [JsonProperty("steam_group_url")]
        public Uri SteamGroupUrl { get; set; }

        [JsonProperty("location_focus")]
        public string LocationFocus { get; set; }

        [JsonProperty("statistics")]
        public Uri StatsUrl { get; set; }

        [JsonProperty("image")]
        public Uri ImageUrl { get; set; }
    }

    public class ProviderStats
    {
        [JsonProperty("players")]
        public long Players { get; set; }

        [JsonProperty("regions_with_players")]
        public Regions Regions { get; set; }

        [JsonProperty("gamemodes")]
        public List<string> GameModes { get; set; }

        [JsonProperty("servers_online")]
        public long ServersOnline { get; set; }

        [JsonProperty("servers_total")]
        public long ServersTotal { get; set; }
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
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }
    }

    public class CompProviderStats
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("players")]
        public long Players { get; set; }

        [JsonProperty("servers_empty")]
        public long ServersEmpty { get; set; }

        [JsonProperty("servers_non_empty")]
        public long ServersNonEmpty { get; set; }
    }
}
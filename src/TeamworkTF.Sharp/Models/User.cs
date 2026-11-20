using System;
using Newtonsoft.Json;

namespace TeamworkTF.Sharp.Models
{
    public class User
    {
        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("link")] public Uri? Link { get; set; }

        [JsonProperty("name")] public string? Name { get; set; }

        [JsonProperty("type")] public string? Type { get; set; }

        [JsonProperty("main")] public string? Main { get; set; }

        [JsonProperty("youtube_acc")] public string? Youtube { get; set; }

        [JsonProperty("twitch_acc")] public string? Twitch { get; set; }

        [JsonProperty("twitter_acc")] public string? Twitter { get; set; }

        [JsonProperty("steam_acc")] public string? Steam { get; set; }

        [JsonProperty("discord_group")] public string? DiscordGroup { get; set; }

        [JsonProperty("steam_group")] public string? SteamGroup { get; set; }

        [JsonProperty("thumbnail_url")] public Uri? ThumbnailUrl { get; set; }
    }
}

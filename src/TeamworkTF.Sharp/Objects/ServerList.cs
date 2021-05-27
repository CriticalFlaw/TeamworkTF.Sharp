using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamworkTF.Sharp
{
    public class ServerList
    {
        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("description_large")] public string DescriptionLong { get; set; }

        [JsonProperty("creator")] public User Creator { get; set; }

        [JsonProperty("subscribed")] public long Subscribed { get; set; }

        [JsonProperty("filters")] public Filters Filters { get; set; }
    }

    public class Filters
    {
        [JsonProperty("filter_hostname_whitelist", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> HostnameWhitelist { get; set; }

        [JsonProperty("filter_hostname_blacklist", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> HostnameBlacklist { get; set; }

        [JsonProperty("filter_addr_whitelist", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> AddressWhitelist { get; set; }

        [JsonProperty("filter_addr_blacklist", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> AddressBlacklist { get; set; }

        [JsonProperty("filter_tags_whitelist", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> TagsWhitelist { get; set; }

        [JsonProperty("filter_tags_blacklist", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> TagsBlacklist { get; set; }

        [JsonProperty("filter_gamemode_whitelist", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> GameModeWhitelist { get; set; }

        [JsonProperty("filter_gamemode_blacklist", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> GameModeBlacklist { get; set; }

        [JsonProperty("filter_map_name_whitelist", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> MapWhitelist { get; set; }

        [JsonProperty("filter_map_name_blacklist", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> MapBlacklist { get; set; }

        [JsonProperty("filter_provider_blacklist", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ProviderBlacklist { get; set; }

        [JsonProperty("filter_has_players", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasPlayers { get; set; }

        [JsonProperty("filter_has_rtd", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasRtd { get; set; }

        [JsonProperty("filter_next_map_name_whitelist", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> NextMapWhitelist { get; set; }
    }
}
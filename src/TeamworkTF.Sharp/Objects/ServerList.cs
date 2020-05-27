using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamworkTF.Sharp
{
    public class ServerList
    {
        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("description_large")] public string DescriptionLarge { get; set; }

        [JsonProperty("creator")] public Creator Creator { get; set; }

        [JsonProperty("subscribed")] public long Subscribed { get; set; }

        [JsonProperty("filters")] public Filters Filters { get; set; }
    }

    public class Filters
    {
        [JsonProperty("filter_hostname_whitelist", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> FilterHostnameWhitelist { get; set; }

        [JsonProperty("filter_hostname_blacklist", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> FilterHostnameBlacklist { get; set; }

        [JsonProperty("filter_addr_whitelist", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> FilterAddrWhitelist { get; set; }

        [JsonProperty("filter_tags_whitelist", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> FilterTagsWhitelist { get; set; }

        [JsonProperty("filter_addr_blacklist", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> FilterAddrBlacklist { get; set; }

        [JsonProperty("filter_tags_blacklist", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> FilterTagsBlacklist { get; set; }

        [JsonProperty("filter_gamemode_whitelist", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> FilterGamemodeWhitelist { get; set; }

        [JsonProperty("filter_gamemode_blacklist", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> FilterGamemodeBlacklist { get; set; }

        [JsonProperty("filter_map_name_whitelist", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> FilterMapNameWhitelist { get; set; }

        [JsonProperty("filter_map_name_blacklist", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> FilterMapNameBlacklist { get; set; }

        [JsonProperty("filter_provider_blacklist", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> FilterProviderBlacklist { get; set; }

        [JsonProperty("filter_has_players", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FilterHasPlayers { get; set; }

        [JsonProperty("filter_has_rtd", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FilterHasRtd { get; set; }

        [JsonProperty("filter_next_map_name_whitelist", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> FilterNextMapNameWhitelist { get; set; }
    }
}
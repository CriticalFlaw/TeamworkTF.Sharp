namespace TeamworkTF.Sharp
{
    /// <summary>
    ///     URL templates for the teamwork.tf and Steam APIs.
    /// </summary>
    internal static class Endpoints
    {
        // {0} = endpoint path, {1} = "?" or "&", {2} = API key
        internal const string TeamworkBase = "https://teamwork.tf/api/v1/{0}{1}key={2}";

        // {0} = endpoint path including its query string
        internal const string SteamBase = "https://api.steampowered.com/IEconItems_440/{0}";

        internal const string MapImages = "map-stats/mapimages/{0}";
        internal const string MapSearch = "map-stats/search?search_term={0}";
        internal const string MapStats = "map-stats/map/{0}";
        internal const string MapThumbnail = "map-stats/mapthumbnail/{0}";

        internal const string News = "news";
        internal const string NewsHash = "news/hash/{0}";
        internal const string NewsPage = "news?page={0}";
        internal const string NewsProvider = "news?provider={0}";

        internal const string ServerBanner = "https://teamwork.tf/community/quickplay/{0}:{1}/550x125.png";
        internal const string CommunityProvider = "community/provider/{0}";
        internal const string CommunityServers = "community/provider/{0}/servers";
        internal const string CommunityStats = "community/provider/{0}/stats";
        internal const string CompetitiveProvider = "competitive/provider/{0}";
        internal const string CompetitiveStats = "competitive/provider/{0}/stats";
        internal const string CustomServerLists = "customserverlist";
        internal const string CustomServerList = "customserverlist/{0}";
        internal const string CustomServerListServers = "customserverlist/{0}/servers";
        internal const string ServerByIpAndPort = "quickplay/server?ip={0}&port={1}";
        internal const string ServerByIp = "quickplay/server?ip={0}";
        internal const string GameModes = "quickplay";
        internal const string GameModeServers = "quickplay/{0}/servers";
        internal const string GameMode = "quickplay/{0}";

        internal const string UserCreator = "youtube-creator/steamid/{0}";

        internal const string SteamPlayerItems = "GetPlayerItems/v0001?key={0}&steamid={1}";
        internal const string SteamSchemaItems = "GetSchemaItems/v1?key={0}&language=en";
        internal const string SteamSchemaUrl = "GetSchemaURL/v1?key={0}";
        internal const string SteamStore = "GetStoreMetaData/v1?key={0}&language=en";

        internal const string SteamMarketPrice = "https://steamcommunity.com/market/priceoverview/?currency=1&appid=440&market_hash_name={0}";
    }

    internal static class Messages
    {
        internal const string MissingTeamworkKey = "An API key must be provided. Go to: https://teamwork.tf/settings and look for your API key under 'Show optional settings'.";
        internal const string MissingSteamKey = "An API key must be provided. Go to: https://steamcommunity.com/dev/apikey to get your API key.";
        internal const string InvalidIp = "The server address you have provided is invalid. Please provide a valid address like: 193.221.192.28";
        internal const string TeamworkKeyRejected = "teamwork.tf rejected the API key. Check your key at: https://teamwork.tf/settings";
        internal const string SteamKeyRejected = "Steam rejected the request. Check your API key at: https://steamcommunity.com/dev/apikey";
        internal const string UnexpectedHtml = "Expected a JSON response but received an HTML page. Check that your API key is valid.";
    }
}
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TeamworkTF.Sharp.Properties;

namespace TeamworkTF.Sharp
{
    public class TeamworkAPI
    {
        private readonly string _apiKey;

        public TeamworkAPI(string apiKey)
        {
            _apiKey = string.IsNullOrWhiteSpace(apiKey) ? Resources.ERROR_KEY_TEAMWORK : apiKey;
        }

        private async Task<T> GetRequest<T>(string query)
        {
            using var client = new HttpClient {BaseAddress = new Uri(Resources.API_TEAMWORK)};
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var delimiter = query.Contains("?") ? "&" : "?";
            var response = await client.GetAsync(string.Format(Resources.API_TEAMWORK, query, delimiter, _apiKey))
                .ConfigureAwait(false);
            if (!response.IsSuccessStatusCode) return default;
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync().ConfigureAwait(false),
                new JsonSerializerSettings
                {
                    Error = GetHandleDeserializationError
                });
        }

        public void GetHandleDeserializationError(object sender, ErrorEventArgs errorArgs)
        {
            _ = errorArgs.ErrorContext.Error.Message;
            errorArgs.ErrorContext.Handled = true;
        }

        public string GetNormalizedGameMode(string query)
        {
            return query.ToLowerInvariant().Trim().Replace(' ', '-') switch
            {
                "ad" => "attack-defend",
                "capture-the-flag" => "ctf",
                "cp" => "control-point",
                "king-of-the-hill" => "koth",
                "mann-vs-machine" => "mvm",
                "pl" => "payload",
                "plr" => "payload-race",
                _ => query
            };
        }

        #region BANNER

        /// <summary>
        ///     Generate an image banner, displaying information about a given game server.
        /// </summary>
        /// <param name="address">Game server's IP address.</param>
        /// <returns>A PNG image in form of a URL string.</returns>
        public string GetServerBanner(string address)
        {
            return !IPAddress.TryParse(address, out var ip)
                ? Resources.ERROR_INVALID_IP
                : string.Format(Resources.SERVER_BANNER, ip);
        }

        #endregion BANNER

        #region USER

        /// <summary>
        ///     Get a list of community creators using their SteamID64.
        /// </summary>
        /// <param name="steamId">SteamID64 of a YouTube content creator.</param>
        /// <returns>An array of YouTube creator objects that includes the name and social media links.</returns>
        public async Task<List<User>> GetCommunityUserAsync(string steamId)
        {
            return await GetRequest<List<User>>(string.Format(Resources.USER_CREATOR, steamId))
                .ConfigureAwait(false);
        }

        #endregion USER

        #region NEWS

        /// <summary>
        ///     Get an overview of the last 20 news articles posted on teamwork.tf
        /// </summary>
        /// <returns>An array of news article objects.</returns>
        public async Task<List<News>> GetNewsOverviewAsync()
        {
            return await GetRequest<List<News>>(Resources.NEWS).ConfigureAwait(false);
        }

        /// <summary>
        ///     Get a specific news article. Does not include contents of the article itself.
        /// </summary>
        /// <param name="hash">HASH code of a news article.</param>
        /// <returns>A object containing the news title, source and date posted.</returns>
        public async Task<News> GetNewsPostAsync(string hash)
        {
            return await GetRequest<News>(string.Format(Resources.NEWS_HASH, hash)).ConfigureAwait(false);
        }

        /// <summary>
        ///     Get an overview of news articles posted on a given teamwork.tf page.
        /// </summary>
        /// <param name="page">Page number from which to retrieve news articles.</param>
        /// <returns>An array of news article objects.</returns>
        public async Task<List<News>> GetNewsByPageAsync(int page)
        {
            return await GetRequest<List<News>>(string.Format(Resources.NEWS_PAGE, page)).ConfigureAwait(false);
        }

        /// <summary>
        ///     Get an overview of news articles posted to teamwork.tf by a specific source.
        /// </summary>
        /// <param name="provider">Name of the source that posted the news article.</param>
        /// <returns>An array of news article objects.</returns>
        public async Task<List<News>> GetNewsByProviderAsync(string provider)
        {
            return await GetRequest<List<News>>(string.Format(Resources.NEWS_PROVIDER, provider)).ConfigureAwait(false);
        }

        #endregion NEWS

        #region SERVERS

        /// <summary>
        ///     List all gamemodes that are displayed on community quickplay.
        /// </summary>
        /// <returns>An object containing all game modes recognized by teamwork.tf</returns>
        /// <remarks>https://teamwork.tf/community/quickplay</remarks>
        public async Task<GameModes> GetGameModeListAsync()
        {
            return await GetRequest<GameModes>(Resources.SERVER_MODES).ConfigureAwait(false);
        }

        /// <summary>
        ///     Get an overview of a given game mode.
        /// </summary>
        /// <param name="gamemode">Name of the game mode to search for.</param>
        /// <returns>An object containing the game mode title, description etc.</returns>
        public async Task<GameMode> GetGameModeAsync(string gamemode)
        {
            return await GetRequest<GameMode>(string.Format(Resources.SERVER_MODES_SEARCH,
                GetNormalizedGameMode(gamemode))).ConfigureAwait(false);
        }

        /// <summary>
        ///     Get a list of servers running a given game mode.
        /// </summary>
        /// <param name="gamemode">Name of the game mode to search for.</param>
        /// <returns>An array of server objects that includes the server address, name, map etc.</returns>
        public async Task<List<Server>> GetServerListByGameModeAsync(string gamemode)
        {
            return await GetRequest<List<Server>>(string.Format(Resources.SERVER_MODES_LIST,
                    GetNormalizedGameMode(gamemode)))
                .ConfigureAwait(false);
        }

        /// <summary>
        ///     Get a list of servers based on the server's ip address and port (optional).
        /// </summary>
        /// <param name="ip">IP address to the server.</param>
        /// <param name="port">Server port in case it is other than 27015.</param>
        /// <returns>An array of server objects that includes the server address, name, map etc.</returns>
        public async Task<List<Server>> GetServerByIpAsync(string ip, int port = 27015)
        {
            var endpoint = port > 0
                ? string.Format(Resources.SERVER_IP_FULL, ip, port)
                : string.Format(Resources.SERVER_IP_NOPORT, ip);
            return await GetRequest<List<Server>>(endpoint).ConfigureAwait(false);
        }

        /// <summary>
        ///     Retrieve information about a given community server provider.
        /// </summary>
        /// <param name="provider">Name of the server provider.</param>
        /// <returns>An object containing the server provider's name, site, location etc.</returns>
        /// <remarks>https://teamwork.tf/community/providers</remarks>
        public async Task<Provider> GetCommunityProviderAsync(string provider)
        {
            return await GetRequest<Provider>(string.Format(Resources.SERVER_COMM_SEARCH, provider))
                .ConfigureAwait(false);
        }

        /// <summary>
        ///     Retrieve live player statistics from a given community server provider (updated every 5 minutes).
        /// </summary>
        /// <param name="provider">Name of the server provider.</param>
        /// <returns>An object containing the provider's active player and server counts.</returns>
        public async Task<ProviderStats> GetCommunityStatsAsync(string provider)
        {
            return await GetRequest<ProviderStats>(string.Format(Resources.SERVER_COMM_STATS, provider))
                .ConfigureAwait(false);
        }

        /// <summary>
        ///     Get a list of community provider's servers (updated every 5 minutes).
        /// </summary>
        /// <param name="provider">Name of the server provider.</param>
        /// <returns>An array of server objects that includes the server address, name, map etc.</returns>
        public async Task<List<Server>> GetCommunityServersAsync(string provider)
        {
            return await GetRequest<List<Server>>(string.Format(Resources.SERVER_COMM_SERVERS, provider))
                .ConfigureAwait(false);
        }

        /// <summary>
        ///     Retrieve information about a given competitive server provider.
        /// </summary>
        /// <param name="provider">Name of the server provider.</param>
        /// <returns>An object containing the server provider's name, site and description.</returns>
        public async Task<CompProvider> GetCompetitiveProviderAsync(string provider)
        {
            return await GetRequest<CompProvider>(string.Format(Resources.SERVER_COMP_SEARCH, provider))
                .ConfigureAwait(false);
        }

        /// <summary>
        ///     Retrieve live player statistics from a given competitive server provider (updated every 5 minutes).
        /// </summary>
        /// <param name="provider">Name of the server provider.</param>
        /// <returns>An object containing the provider's active player and server counts.</returns>
        public async Task<CompProviderStats> GetCompetitiveStatsAsync(string provider)
        {
            return await GetRequest<CompProviderStats>(string.Format(Resources.SERVER_COMP_STATS, provider))
                .ConfigureAwait(false);
        }

        /// <summary>
        ///     Get a list of server lists created and curated by the community.
        /// </summary>
        /// <returns>An array of custom server lists that includes the name, description, subscribers etc.</returns>
        /// <remarks>https://teamwork.tf/community/customserverlists</remarks>
        public async Task<List<ServerList>> GetServerListsAsync()
        {
            return await GetRequest<List<ServerList>>(Resources.SERVER_CUSTOM_LIST).ConfigureAwait(false);
        }

        /// <summary>
        ///     Get an overview of a server list created and curated by the community.
        /// </summary>
        /// <param name="id">ID number of a custom server list to search for.</param>
        /// <returns>An object containing the custom server list name, description, subscribers etc.</returns>
        public async Task<ServerList> GetServerListByIdAsync(int id)
        {
            return await GetRequest<ServerList>(string.Format(Resources.SERVER_CUSTOM_SEARCH, id))
                .ConfigureAwait(false);
        }

        /// <summary>
        ///     Get a list of game servers that are on the given server list.
        /// </summary>
        /// <param name="id">ID number of a custom server list to search for.</param>
        /// <returns>An array of server objects that includes the server address, name, map etc.</returns>
        public async Task<List<Server>> GetServersFromServerListAsync(int id)
        {
            return await GetRequest<List<Server>>(string.Format(Resources.SERVER_CUSTOM_SERVERS, id))
                .ConfigureAwait(false);
        }

        #endregion SERVERS

        #region MAPS

        /// <summary>
        ///     Retrieve statistics about a certain map (updated every 5 minutes).
        /// </summary>
        /// <param name="map">Name of the map to search for.</param>
        /// <returns>A map object that includes the name, thumbnail, game mode etc.</returns>
        public async Task<Map> GetMapStatsAsync(string map)
        {
            return await GetRequest<Map>(string.Format(Resources.MAP_STATS, map)).ConfigureAwait(false);
        }

        /// <summary>
        ///     Retrieve the thumbnail URL for a given map.
        /// </summary>
        /// <param name="map">Name of the map to search for.</param>
        /// <returns>A thumbnail object that links to image file.</returns>
        /// <remarks>
        ///     Thumbnail size/format depends on the source, though they'll be at least 512x286 pixels. If you query for an
        ///     unknown map, or a map without a thumbnail the API will respond with a JSON error. The image format is either PNG or
        ///     JPG.
        /// </remarks>
        public async Task<MapThumbnail> GetMapThumbnailAsync(string map)
        {
            return await GetRequest<MapThumbnail>(string.Format(Resources.MAP_THUMBNAIL, map)).ConfigureAwait(false);
        }

        /// <summary>
        ///     Retrieve a list of images for a given map. Depending on the map, images and coordinates may be returned as NULL.
        /// </summary>
        /// <param name="map">Name of the map to search for.</param>
        /// <returns>A thumbnail context object that includes screenshot image links and coordinates.</returns>
        public async Task<ThumbnailContext> GetMapImagesAsync(string map)
        {
            return await GetRequest<ThumbnailContext>(string.Format(Resources.MAP_IMAGES, map)).ConfigureAwait(false);
        }

        /// <summary>
        ///     Search for a specific TF2 map. Lists up to 50 results, so be specific in your search.
        /// </summary>
        /// <param name="map">Name of the map to search for.</param>
        /// <returns>An array of map names.</returns>
        public async Task<List<MapName>> GetMapsBySearchAsync(string map)
        {
            return await GetRequest<List<MapName>>(string.Format(Resources.MAP_SEARCH, map)).ConfigureAwait(false);
        }

        #endregion MAPS
    }
}
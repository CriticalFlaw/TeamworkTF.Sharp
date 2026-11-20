using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using TeamworkTF.Sharp.Models;

namespace TeamworkTF.Sharp
{
    /// <summary>
    ///     Client for the teamwork.tf API. Methods return <c>null</c> when the requested item doesn't exist, and throw
    ///     <see cref="HttpRequestException" /> when the API key is rejected or the API is unavailable.
    /// </summary>
    public class TeamworkAPI
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        /// <param name="apiKey">Your teamwork.tf API key.</param>
        /// <exception cref="ArgumentException"><paramref name="apiKey" /> is empty.</exception>
        public TeamworkAPI(string apiKey) : this(apiKey, null)
        {
        }

        /// <param name="apiKey">Your teamwork.tf API key.</param>
        /// <param name="httpClient">HTTP client to send requests with. When <c>null</c>, a shared client is used.</param>
        /// <exception cref="ArgumentException"><paramref name="apiKey" /> is empty.</exception>
        public TeamworkAPI(string apiKey, HttpClient? httpClient)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException(Messages.MissingTeamworkKey, nameof(apiKey));

            _apiKey = apiKey;
            _httpClient = httpClient ?? ApiClient.Shared;
        }

        private Task<T?> GetRequest<T>(string query, CancellationToken cancellationToken)
        {
            var delimiter = query.Contains('?') ? "&" : "?";
            var url = string.Format(Endpoints.TeamworkBase, query, delimiter, Uri.EscapeDataString(_apiKey));
            return ApiClient.GetAsync<T>(_httpClient, url, Messages.TeamworkKeyRejected, cancellationToken);
        }

        private static string Escape(string value, string paramName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value, paramName);
            return Uri.EscapeDataString(value.Trim());
        }

        /// <summary>
        ///     Convert a game mode name or abbreviation into the ID teamwork.tf uses. For example, "PL" becomes "payload"
        ///     and "King of the Hill" becomes "koth".
        /// </summary>
        /// <param name="query">Game mode name or abbreviation.</param>
        /// <returns>The normalized game mode ID.</returns>
        public string GetNormalizedGameMode(string query)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(query);
            var normalized = query.Trim().ToLowerInvariant().Replace(' ', '-');
            return normalized switch
            {
                "ad" => "attack-defend",
                "capture-the-flag" => "ctf",
                "cp" => "control-point",
                "king-of-the-hill" => "koth",
                "mann-vs-machine" => "mvm",
                "pl" => "payload",
                "plr" => "payload-race",
                _ => normalized
            };
        }

        #region BANNER

        /// <summary>
        ///     Generate an image banner, displaying information about a given game server.
        /// </summary>
        /// <param name="address">Game server's IPv4 address, like 193.221.192.28.</param>
        /// <param name="port">Game server's port.</param>
        /// <returns>A PNG image in form of a URL string.</returns>
        /// <exception cref="ArgumentException"><paramref name="address" /> isn't a valid IPv4 address.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="port" /> isn't between 1 and 65535.</exception>
        public string GetServerBanner(string address, int port = 27015)
        {
            // IPAddress.TryParse also accepts shorthand like "1" (0.0.0.1), so require all four parts.
            if (!IPAddress.TryParse(address, out var ip) || ip.AddressFamily != AddressFamily.InterNetwork ||
                address.Split('.').Length != 4)
                throw new ArgumentException(Messages.InvalidIp, nameof(address));
            ArgumentOutOfRangeException.ThrowIfLessThan(port, IPEndPoint.MinPort + 1);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(port, IPEndPoint.MaxPort);

            return string.Format(Endpoints.ServerBanner, ip, port);
        }

        #endregion BANNER

        #region USER

        /// <summary>
        ///     Get a list of community creators using their SteamID64.
        /// </summary>
        /// <param name="steamId">SteamID64 of a YouTube content creator.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>An array of YouTube creator objects that includes the name and social media links.</returns>
        public Task<List<User>?> GetCommunityUserAsync(string steamId, CancellationToken cancellationToken = default)
        {
            return GetRequest<List<User>>(string.Format(Endpoints.UserCreator, Escape(steamId, nameof(steamId))),
                cancellationToken);
        }

        #endregion USER

        #region NEWS

        /// <summary>
        ///     Get an overview of the last 20 news articles posted on teamwork.tf
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>An array of news article objects.</returns>
        public Task<List<News>?> GetNewsOverviewAsync(CancellationToken cancellationToken = default)
        {
            return GetRequest<List<News>>(Endpoints.News, cancellationToken);
        }

        /// <summary>
        ///     Get a specific news article. Does not include contents of the article itself.
        /// </summary>
        /// <param name="hash">HASH code of a news article.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A object containing the news title, source and date posted.</returns>
        public Task<News?> GetNewsPostAsync(string hash, CancellationToken cancellationToken = default)
        {
            return GetRequest<News>(string.Format(Endpoints.NewsHash, Escape(hash, nameof(hash))), cancellationToken);
        }

        /// <summary>
        ///     Get an overview of news articles posted on a given teamwork.tf page.
        /// </summary>
        /// <param name="page">Page number from which to retrieve news articles.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>An array of news article objects.</returns>
        public Task<List<News>?> GetNewsByPageAsync(int page, CancellationToken cancellationToken = default)
        {
            return GetRequest<List<News>>(string.Format(Endpoints.NewsPage, page), cancellationToken);
        }

        /// <summary>
        ///     Get an overview of news articles posted to teamwork.tf by a specific source.
        /// </summary>
        /// <param name="provider">Name of the source that posted the news article.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>An array of news article objects.</returns>
        public Task<List<News>?> GetNewsByProviderAsync(string provider, CancellationToken cancellationToken = default)
        {
            return GetRequest<List<News>>(string.Format(Endpoints.NewsProvider, Escape(provider, nameof(provider))),
                cancellationToken);
        }

        #endregion NEWS

        #region SERVERS

        /// <summary>
        ///     List all gamemodes that are displayed on community quickplay.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>An object containing all game modes recognized by teamwork.tf</returns>
        /// <remarks>https://teamwork.tf/community/quickplay</remarks>
        public Task<GameModes?> GetGameModeListAsync(CancellationToken cancellationToken = default)
        {
            return GetRequest<GameModes>(Endpoints.GameModes, cancellationToken);
        }

        /// <summary>
        ///     Get an overview of a given game mode.
        /// </summary>
        /// <param name="gamemode">Name of the game mode to search for.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>An object containing the game mode title, description etc.</returns>
        public Task<GameMode?> GetGameModeAsync(string gamemode, CancellationToken cancellationToken = default)
        {
            return GetRequest<GameMode>(string.Format(Endpoints.GameMode,
                Escape(GetNormalizedGameMode(gamemode), nameof(gamemode))), cancellationToken);
        }

        /// <summary>
        ///     Get a list of servers running a given game mode.
        /// </summary>
        /// <param name="gamemode">Name of the game mode to search for.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>An array of server objects that includes the server address, name, map etc.</returns>
        public Task<List<Server>?> GetServerListByGameModeAsync(string gamemode,
            CancellationToken cancellationToken = default)
        {
            return GetRequest<List<Server>>(string.Format(Endpoints.GameModeServers,
                Escape(GetNormalizedGameMode(gamemode), nameof(gamemode))), cancellationToken);
        }

        /// <summary>
        ///     Get a list of servers based on the server's ip address and port (optional).
        /// </summary>
        /// <param name="ip">IP address to the server.</param>
        /// <param name="port">Server port in case it is other than 27015. Pass 0 to match any port.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>An array of server objects that includes the server address, name, map etc.</returns>
        public Task<List<Server>?> GetServerByIpAsync(string ip, int port = 27015,
            CancellationToken cancellationToken = default)
        {
            var address = Escape(ip, nameof(ip));
            var endpoint = port > 0
                ? string.Format(Endpoints.ServerByIpAndPort, address, port)
                : string.Format(Endpoints.ServerByIp, address);
            return GetRequest<List<Server>>(endpoint, cancellationToken);
        }

        /// <summary>
        ///     Retrieve information about a given community server provider.
        /// </summary>
        /// <param name="provider">Name of the server provider.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>An object containing the server provider's name, site, location etc.</returns>
        /// <remarks>https://teamwork.tf/community/providers</remarks>
        public Task<Provider?> GetCommunityProviderAsync(string provider, CancellationToken cancellationToken = default)
        {
            return GetRequest<Provider>(
                string.Format(Endpoints.CommunityProvider, Escape(provider, nameof(provider))), cancellationToken);
        }

        /// <summary>
        ///     Retrieve live player statistics from a given community server provider (updated every 5 minutes).
        /// </summary>
        /// <param name="provider">Name of the server provider.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>An object containing the provider's active player and server counts.</returns>
        public Task<ProviderStats?> GetCommunityStatsAsync(string provider,
            CancellationToken cancellationToken = default)
        {
            return GetRequest<ProviderStats>(
                string.Format(Endpoints.CommunityStats, Escape(provider, nameof(provider))), cancellationToken);
        }

        /// <summary>
        ///     Get a list of community provider's servers (updated every 5 minutes).
        /// </summary>
        /// <param name="provider">Name of the server provider.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>An array of server objects that includes the server address, name, map etc.</returns>
        public Task<List<Server>?> GetCommunityServersAsync(string provider,
            CancellationToken cancellationToken = default)
        {
            return GetRequest<List<Server>>(
                string.Format(Endpoints.CommunityServers, Escape(provider, nameof(provider))), cancellationToken);
        }

        /// <summary>
        ///     Retrieve information about a given competitive server provider.
        /// </summary>
        /// <param name="provider">Name of the server provider.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>An object containing the server provider's name, site and description.</returns>
        public Task<CompProvider?> GetCompetitiveProviderAsync(string provider,
            CancellationToken cancellationToken = default)
        {
            return GetRequest<CompProvider>(
                string.Format(Endpoints.CompetitiveProvider, Escape(provider, nameof(provider))), cancellationToken);
        }

        /// <summary>
        ///     Retrieve live player statistics from a given competitive server provider (updated every 5 minutes).
        /// </summary>
        /// <param name="provider">Name of the server provider.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>An object containing the provider's active player and server counts.</returns>
        public Task<CompProviderStats?> GetCompetitiveStatsAsync(string provider,
            CancellationToken cancellationToken = default)
        {
            return GetRequest<CompProviderStats>(
                string.Format(Endpoints.CompetitiveStats, Escape(provider, nameof(provider))), cancellationToken);
        }

        /// <summary>
        ///     Get a list of server lists created and curated by the community.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>An array of custom server lists that includes the name, description, subscribers etc.</returns>
        /// <remarks>https://teamwork.tf/community/customserverlists</remarks>
        public Task<List<ServerList>?> GetServerListsAsync(CancellationToken cancellationToken = default)
        {
            return GetRequest<List<ServerList>>(Endpoints.CustomServerLists, cancellationToken);
        }

        /// <summary>
        ///     Get an overview of a server list created and curated by the community.
        /// </summary>
        /// <param name="id">ID number of a custom server list to search for.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>An object containing the custom server list name, description, subscribers etc.</returns>
        public Task<ServerList?> GetServerListByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return GetRequest<ServerList>(string.Format(Endpoints.CustomServerList, id), cancellationToken);
        }

        /// <summary>
        ///     Get a list of game servers that are on the given server list.
        /// </summary>
        /// <param name="id">ID number of a custom server list to search for.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>An array of server objects that includes the server address, name, map etc.</returns>
        public Task<List<Server>?> GetServersFromServerListAsync(int id, CancellationToken cancellationToken = default)
        {
            return GetRequest<List<Server>>(string.Format(Endpoints.CustomServerListServers, id), cancellationToken);
        }

        #endregion SERVERS

        #region MAPS

        /// <summary>
        ///     Retrieve statistics about a certain map (updated every 5 minutes).
        /// </summary>
        /// <param name="map">Name of the map to search for.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A map object that includes the name, thumbnail, game mode etc.</returns>
        public Task<Map?> GetMapStatsAsync(string map, CancellationToken cancellationToken = default)
        {
            return GetRequest<Map>(string.Format(Endpoints.MapStats, Escape(map, nameof(map))), cancellationToken);
        }

        /// <summary>
        ///     Retrieve the thumbnail URL for a given map.
        /// </summary>
        /// <param name="map">Name of the map to search for.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A thumbnail object that links to image file.</returns>
        /// <remarks>
        ///     Thumbnail size/format depends on the source, though they'll be at least 512x286 pixels. If you query for an
        ///     unknown map, or a map without a thumbnail the API will respond with a JSON error. The image format is either PNG or
        ///     JPG.
        /// </remarks>
        public Task<MapThumbnail?> GetMapThumbnailAsync(string map, CancellationToken cancellationToken = default)
        {
            return GetRequest<MapThumbnail>(string.Format(Endpoints.MapThumbnail, Escape(map, nameof(map))),
                cancellationToken);
        }

        /// <summary>
        ///     Retrieve a list of images for a given map. Depending on the map, images and coordinates may be returned as NULL.
        /// </summary>
        /// <param name="map">Name of the map to search for.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A thumbnail context object that includes screenshot image links and coordinates.</returns>
        public Task<ThumbnailContext?> GetMapImagesAsync(string map, CancellationToken cancellationToken = default)
        {
            return GetRequest<ThumbnailContext>(string.Format(Endpoints.MapImages, Escape(map, nameof(map))),
                cancellationToken);
        }

        /// <summary>
        ///     Search for a specific TF2 map. Lists up to 50 results, so be specific in your search.
        /// </summary>
        /// <param name="map">Name of the map to search for.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>An array of map names.</returns>
        public Task<List<MapName>?> GetMapsBySearchAsync(string map, CancellationToken cancellationToken = default)
        {
            return GetRequest<List<MapName>>(string.Format(Endpoints.MapSearch, Escape(map, nameof(map))),
                cancellationToken);
        }

        #endregion MAPS
    }
}

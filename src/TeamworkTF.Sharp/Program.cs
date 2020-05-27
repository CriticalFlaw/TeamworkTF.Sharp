using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TeamworkTF.Sharp
{
    public class TeamworkClient
    {
        private const string TeamworkUrl = "https://teamwork.tf/api/v1/";
        private readonly string _apiKey;

        public TeamworkClient(string apiKey)
        {
            this._apiKey = apiKey ?? throw new ArgumentNullException(apiKey,
                "An API key must be provided. See: https://teamwork.tf/api");
        }

        private async Task<T> GetRequest<T>(string query)
        {
            using var client = new HttpClient {BaseAddress = new Uri(TeamworkUrl)};
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var delimiter = query.Contains("?") ? "&" : "?";
            var response = await client.GetAsync($"{TeamworkUrl}{query}{delimiter}key={_apiKey}").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
                {
                    Error = GetHandleDeserializationError
                });
            }

            return default;
        }

        public void GetHandleDeserializationError(object sender, ErrorEventArgs errorArgs)
        {
            _ = errorArgs.ErrorContext.Error.Message;
            errorArgs.ErrorContext.Handled = true;
        }

        public string GetNormalizedGameMode(string query)
        {
            switch (query.ToLowerInvariant().Trim().Replace(' ', '-'))
            {
                case "ad":
                case "attack-defense":
                    return "attack-defend";

                case "capture-the-flag":
                    return "ctf";

                case "cp":
                    return "control-point";

                case "king-of-the-hill":
                    return "koth";

                case "mann-vs-machine":
                    return "mvm";

                case "pl":
                    return "payload";

                case "plr":
                    return "payload-race";

                default:
                    return query;
            }
        }

        #region CREATORS

        public async Task<List<Creator>> GetCreatorByIdAsync(string steamId)
        {
            return await GetRequest<List<Creator>>($"youtube-creator/steamid/{steamId}").ConfigureAwait(false);
        }

        #endregion CREATORS

        #region NEWS

        public async Task<List<News>> GetNewsOverviewAsync()
        {
            return await GetRequest<List<News>>("news").ConfigureAwait(false);
        }

        public async Task<News> GetNewsPostAsync(string hash)
        {
            return await GetRequest<News>($"news/hash/{hash}").ConfigureAwait(false);
        }

        public async Task<List<News>> GetNewsByPageAsync(int hash)
        {
            return await GetRequest<List<News>>($"news?page={hash}").ConfigureAwait(false);
        }

        public async Task<List<News>> GetNewsByProviderAsync(string hash)
        {
            return await GetRequest<List<News>>($"news?provider={hash}").ConfigureAwait(false);
        }

        #endregion NEWS

        #region QUICKPLAY

        public async Task<GameMode> GetGameModeAsync(string gamemode)
        {
            return await GetRequest<GameMode>($"quickplay/{GetNormalizedGameMode(gamemode)}").ConfigureAwait(false);
        }

        public async Task<GameMode> GetGameModeListAsync()
        {
            return await GetRequest<GameMode>("quickplay").ConfigureAwait(false);
        }

        public async Task<List<Server>> GetGameModeServerAsync(string gamemode)
        {
            return await GetRequest<List<Server>>($"quickplay/{GetNormalizedGameMode(gamemode)}/servers")
                .ConfigureAwait(false);
        }

        public async Task<List<Server>> GetGameServerInfoAsync(string ip, int port = 0)
        {
            var endpoint = $"quickplay/server?ip={ip}" + (port > 0 ? $"&port={port}" : "");
            return await GetRequest<List<Server>>(endpoint).ConfigureAwait(false);
        }

        #endregion QUICKPLAY

        #region SERVERS

        public async Task<Provider> GetCommunityProviderAsync(string provider)
        {
            return await GetRequest<Provider>($"community/provider/{provider}").ConfigureAwait(false);
        }

        public async Task<List<Server>> GetCommunityProviderServersAsync(string provider)
        {
            return await GetRequest<List<Server>>($"community/provider/{provider}/servers").ConfigureAwait(false);
        }

        public async Task<ProviderStats> GetCommunityProviderStatsAsync(string provider)
        {
            return await GetRequest<ProviderStats>($"community/provider/{provider}/stats").ConfigureAwait(false);
        }

        public async Task<CompProvider> GetCompetitiveProviderAsync(string provider)
        {
            return await GetRequest<CompProvider>($"competitive/provider/{provider}").ConfigureAwait(false);
        }

        public async Task<CompProviderStats> GetCompetitiveProviderStatsAsync(string provider)
        {
            return await GetRequest<CompProviderStats>($"competitive/provider/{provider}/stats").ConfigureAwait(false);
        }

        public async Task<List<ServerList>> GetCustomServerListsAsync()
        {
            return await GetRequest<List<ServerList>>("customserverlist").ConfigureAwait(false);
        }

        public async Task<ServerList> GetSpecificServerListAsync(int id)
        {
            return await GetRequest<ServerList>($"customserverlist/{id}").ConfigureAwait(false);
        }

        public async Task<List<Server>> GetServersFromServerListAsync(int id)
        {
            return await GetRequest<List<Server>>($"customserverlist/{id}/servers").ConfigureAwait(false);
        }

        #endregion SERVERS

        #region GAMEMAPS

        public async Task<Map> GetMapStatsAsync(string mapName)
        {
            return await GetRequest<Map>($"map-stats/map/{mapName}").ConfigureAwait(false);
        }

        public async Task<MapThumbnail> GetMapThumbnailAsync(string mapName)
        {
            return await GetRequest<MapThumbnail>($"map-stats/mapthumbnail/{mapName}").ConfigureAwait(false);
        }

        public async Task<ThumbnailContext> GetMapThumbnailContextAsync(string mapName)
        {
            return await GetRequest<ThumbnailContext>($"map-stats/mapimages/{mapName}").ConfigureAwait(false);
        }

        public async Task<List<MapName>> GetMapsBySearchAsync(string search)
        {
            return await GetRequest<List<MapName>>($"map-stats/search?search_term={search}").ConfigureAwait(false);
        }

        #endregion GAMEMAPS
    }
}
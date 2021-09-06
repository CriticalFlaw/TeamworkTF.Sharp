using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TeamworkTF.Sharp.Properties;

namespace TeamworkTF.Sharp
{
    public class SteamAPI
    {
        private readonly string _apiKey;

        public SteamAPI(string apiKey)
        {
            _apiKey = string.IsNullOrWhiteSpace(apiKey) ? Resources.ERROR_KEY_STEAM : apiKey;
        }

        private async Task<T> GetRequest<T>(string query)
        {
            using var client = new HttpClient {BaseAddress = new Uri(Resources.API_STEAM)};
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync(query).ConfigureAwait(false);
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

        /// <summary>
        ///     Retrieve TF2 player items from the Steam API.
        /// </summary>
        /// <param name="steamId">User's Steam ID (64-Hex)</param>
        public async Task<InventoryRoot> GetPlayerItemsAsync(string steamId)
        {
            return await GetRequest<InventoryRoot>(string.Format(Resources.STEAM_ITEMS, _apiKey, steamId))
                .ConfigureAwait(false);
        }

        /// <summary>
        ///     Retrieve TF2 schema items from the Steam API.
        /// </summary>
        public async Task<SchemaRoot> GetSchemaItemsAsync()
        {
            return await GetRequest<SchemaRoot>(string.Format(Resources.STEAM_ITEMS_SCHEMA, _apiKey)).ConfigureAwait(false);
        }

        /// <summary>
        ///     Retrieve TF2 schema from the Steam API.
        /// </summary>
        public async Task<SchemaRoot> GetSchemaUrlAsync()
        {
            return await GetRequest<SchemaRoot>(string.Format(Resources.STEAM_SCHEMA_URL, _apiKey)).ConfigureAwait(false);
        }

        /// <summary>
        ///     Retrieve store meta data from the Steam API.
        /// </summary>
        public async Task<Steam> GetStoreDataAsync()
        {
            return await GetRequest<Steam>(string.Format(Resources.STEAM_STORE, _apiKey)).ConfigureAwait(false);
        }

        /// <summary>
        ///     Retrieve the Steam Market price for a given item.
        /// </summary>
        public async Task<Price> GetMarketPriceAsync(string query)
        {
            return await GetRequest<Price>(string.Format(Resources.STEAM_PRICE, query.Replace(" ", "%20"))).ConfigureAwait(false);
        }
    }
}
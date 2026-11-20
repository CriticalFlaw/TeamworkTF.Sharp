using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TeamworkTF.Sharp.Models;

namespace TeamworkTF.Sharp
{
    /// <summary>
    ///     Client for TF2 data from the Steam Web API. Methods throw <see cref="HttpRequestException" /> when the API key
    ///     is rejected or Steam is unavailable.
    /// </summary>
    public class SteamAPI
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        /// <param name="apiKey">Your Steam Web API key.</param>
        /// <exception cref="ArgumentException"><paramref name="apiKey" /> is empty.</exception>
        public SteamAPI(string apiKey) : this(apiKey, null)
        {
        }

        /// <param name="apiKey">Your Steam Web API key.</param>
        /// <param name="httpClient">HTTP client to send requests with. When <c>null</c>, a shared client is used.</param>
        /// <exception cref="ArgumentException"><paramref name="apiKey" /> is empty.</exception>
        public SteamAPI(string apiKey, HttpClient? httpClient)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException(Messages.MissingSteamKey, nameof(apiKey));

            _apiKey = apiKey;
            _httpClient = httpClient ?? ApiClient.Shared;
        }

        private string Key => Uri.EscapeDataString(_apiKey);

        private Task<T?> GetRequest<T>(string url, CancellationToken cancellationToken)
        {
            return ApiClient.GetAsync<T>(_httpClient, url, Messages.SteamKeyRejected, cancellationToken);
        }

        private Task<T?> GetEconRequest<T>(string endpoint, CancellationToken cancellationToken)
        {
            return GetRequest<T>(string.Format(Endpoints.SteamBase, endpoint), cancellationToken);
        }

        /// <summary>
        ///     Retrieve TF2 player items from the Steam API.
        /// </summary>
        /// <param name="steamId">User's SteamID64.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        public Task<InventoryRoot?> GetPlayerItemsAsync(string steamId, CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(steamId);
            return GetEconRequest<InventoryRoot>(
                string.Format(Endpoints.SteamPlayerItems, Key, Uri.EscapeDataString(steamId.Trim())),
                cancellationToken);
        }

        /// <summary>
        ///     Retrieve TF2 schema items from the Steam API.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        public Task<SchemaRoot?> GetSchemaItemsAsync(CancellationToken cancellationToken = default)
        {
            return GetEconRequest<SchemaRoot>(string.Format(Endpoints.SteamSchemaItems, Key), cancellationToken);
        }

        /// <summary>
        ///     Retrieve TF2 schema from the Steam API.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        public Task<SchemaRoot?> GetSchemaUrlAsync(CancellationToken cancellationToken = default)
        {
            return GetEconRequest<SchemaRoot>(string.Format(Endpoints.SteamSchemaUrl, Key), cancellationToken);
        }

        /// <summary>
        ///     Retrieve store meta data from the Steam API.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        public Task<Steam?> GetStoreDataAsync(CancellationToken cancellationToken = default)
        {
            return GetEconRequest<Steam>(string.Format(Endpoints.SteamStore, Key), cancellationToken);
        }

        /// <summary>
        ///     Retrieve the Steam Market price for a given item.
        /// </summary>
        /// <param name="query">The item's market name, like "Mann Co. Supply Crate Key".</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        public Task<Price?> GetMarketPriceAsync(string query, CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(query);
            return GetRequest<Price>(string.Format(Endpoints.SteamMarketPrice, Uri.EscapeDataString(query.Trim())),
                cancellationToken);
        }
    }
}

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TeamworkTF.Sharp.Properties;

namespace TeamworkTF.Sharp
{
    public class MarketplaceTF
    {
        private async Task<T> GetRequest<T>(string query)
        {
            using var client = new HttpClient {BaseAddress = new Uri(Resources.API_MARKETPLACE)};
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync(string.Format(Resources.API_MARKETPLACE, query)).ConfigureAwait(false);
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
        ///     Fetch a list of all API Endpoints accessible to your account.
        /// </summary>
        /// <returns>A list of API endpoint objects.</returns>
        public async Task<EndPoints> GetEndpointsAsync()
        {
            return await GetRequest<EndPoints>(Resources.MARKETPLACE_ENDPOINTS).ConfigureAwait(false);
        }

        /// <summary>
        ///     Fetch a list of all Marketplace.tf bot SteamIDs
        /// </summary>
        /// <returns>A list of Marketplace bot SteamIDs.</returns>
        public async Task<Bots> GetMarketplaceBotsAsync()
        {
            return await GetRequest<Bots>(Resources.MARKETPLACE_BOTS).ConfigureAwait(false);
        }

        /// <summary>
        ///     Fetch all items currently deposited on Marketplace that you can act upon. This does not include items that have
        ///     sold, are still confirming deposit, or are under review.
        /// </summary>
        /// <param name="apiKey">Key for accessing the Marketplace.TF API.</param>
        /// <returns>A list of dashboard items.</returns>
        private async Task<Dashboard> GetDashboardAsync(string apiKey)
        {
            apiKey = string.IsNullOrWhiteSpace(apiKey) ? Resources.ERROR_KEY_MARKETPLACE : apiKey;
            return await GetRequest<Dashboard>(string.Format(Resources.MARKETPLACE_DASHBOARD, apiKey)).ConfigureAwait(false);
        }

        /// <summary>
        ///     Fetch the specified number of sales your account has made. v2 now provides prices in cents, not dollars.
        /// </summary>
        /// <param name="apiKey">Key for accessing the Marketplace.TF API.</param>
        /// <param name="num">The number of sales to fetch. Defaults to 100. Maximum of 500.</param>
        /// <param name="startBefore">A unix timestamp for pagination. Will return all sales that occurred before this timestamp.</param>
        /// <returns>A list of sales.</returns>
        private async Task<Sales> GetSalesAsync(string apiKey, int num = 100, DateTime? startBefore = null)
        {
            apiKey = string.IsNullOrWhiteSpace(apiKey) ? Resources.ERROR_KEY_MARKETPLACE : apiKey;
            startBefore = startBefore ?? DateTime.Now;
            return await GetRequest<Sales>(string.Format(Resources.MARKETPLACE_SALES, _apiKey, num,
                ((DateTimeOffset) startBefore).ToUnixTimeSeconds())).ConfigureAwait(false);
        }
    }
}
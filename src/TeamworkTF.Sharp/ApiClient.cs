using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TeamworkTF.Sharp
{
    /// <summary>
    ///     Shared HTTP client for <see cref="TeamworkAPI" /> and <see cref="SteamAPI" />.
    /// </summary>
    internal static class ApiClient
    {
        // One client for the whole process avoids running out of sockets.
        internal static readonly HttpClient Shared = new(new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(5)
        });

        // If the API changes a field's shape, return what still parses instead of failing the call.
        private static readonly JsonSerializerSettings JsonSettings = new()
        {
            Error = (_, args) => args.ErrorContext.Handled = true
        };

        /// <summary>
        ///     Sends a GET request and deserializes the JSON response.
        /// </summary>
        /// <returns>
        ///     The parsed response, or <c>null</c> when the API says the item doesn't exist (404 and other client errors).
        /// </returns>
        /// <exception cref="HttpRequestException">
        ///     The API key was rejected, the API is rate limiting or failing, or the response wasn't JSON.
        /// </exception>
        internal static async Task<T?> GetAsync<T>(HttpClient client, string url, string keyRejectedMessage,
            CancellationToken cancellationToken)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using var response = await client.SendAsync(request, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode is HttpStatusCode.Unauthorized or HttpStatusCode.Forbidden)
                throw new HttpRequestException(keyRejectedMessage, null, response.StatusCode);

            if (response.StatusCode == HttpStatusCode.TooManyRequests || (int)response.StatusCode >= 500)
                response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode) return default;

            // teamwork.tf answers some bad requests (like a missing key) with a 200 and an HTML login page.
            if (string.Equals(response.Content.Headers.ContentType?.MediaType, "text/html",
                    StringComparison.OrdinalIgnoreCase))
                throw new HttpRequestException(Messages.UnexpectedHtml, null, response.StatusCode);

            var json = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<T>(json, JsonSettings);
        }
    }
}

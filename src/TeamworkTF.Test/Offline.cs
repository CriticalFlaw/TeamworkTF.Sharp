using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using TeamworkTF.Sharp;

namespace TeamworkTF.Test
{
    /// <summary>
    ///     Tests that use canned HTTP responses, so they run without an API key or network access.
    /// </summary>
    public class Offline
    {
        private const string FakeKey = "test-key";

        private static (TeamworkAPI api, FakeHandler handler) Teamwork(HttpStatusCode status = HttpStatusCode.OK,
            string body = "{}", string mediaType = "application/json")
        {
            var handler = new FakeHandler(status, body, mediaType);
            return (new TeamworkAPI(FakeKey, new HttpClient(handler)), handler);
        }

        private static (SteamAPI api, FakeHandler handler) Steam(HttpStatusCode status = HttpStatusCode.OK,
            string body = "{}", string mediaType = "application/json")
        {
            var handler = new FakeHandler(status, body, mediaType);
            return (new SteamAPI(FakeKey, new HttpClient(handler)), handler);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void Constructors_RejectMissingKey(string key)
        {
            Assert.Throws<ArgumentException>(() => new TeamworkAPI(key));
            Assert.Throws<ArgumentException>(() => new SteamAPI(key));
        }

        [TestCase("PL", "payload")]
        [TestCase(" Payload ", "payload")]
        [TestCase("King of the Hill", "koth")]
        [TestCase("Arena", "arena")]
        public void GetNormalizedGameMode_NormalizesInput(string input, string expected)
        {
            Assert.That(new TeamworkAPI(FakeKey).GetNormalizedGameMode(input), Is.EqualTo(expected));
        }

        [Test]
        public void GetServerBanner_BuildsUrlWithPort()
        {
            var api = new TeamworkAPI(FakeKey);
            Assert.That(api.GetServerBanner("193.221.192.28"),
                Is.EqualTo("https://teamwork.tf/community/quickplay/193.221.192.28:27015/550x125.png"));
            Assert.That(api.GetServerBanner("193.221.192.28", 27016), Does.Contain(":27016/"));
        }

        [TestCase("9999.2341.4324.2132")]
        [TestCase("1")]
        [TestCase("::1")]
        [TestCase(null)]
        public void GetServerBanner_RejectsInvalidAddress(string address)
        {
            Assert.Throws<ArgumentException>(() => new TeamworkAPI(FakeKey).GetServerBanner(address));
        }

        [Test]
        public async Task Requests_EscapeUserInputAndKey()
        {
            var (api, handler) = Teamwork(body: "[]");
            await api.GetMapsBySearchAsync("a b&c=d#e");

            Assert.That(handler.LastRequestUri.AbsoluteUri, Is.EqualTo(
                "https://teamwork.tf/api/v1/map-stats/search?search_term=a%20b%26c%3Dd%23e&key=test-key"));
        }

        [Test]
        public async Task GetGameMode_UsesNormalizedName()
        {
            var (api, handler) = Teamwork();
            await api.GetGameModeAsync("PL");
            Assert.That(handler.LastRequestUri.AbsolutePath, Is.EqualTo("/api/v1/quickplay/payload"));
        }

        [Test]
        public void Requests_RejectEmptyInput()
        {
            var (api, _) = Teamwork();
            Assert.Throws<ArgumentException>(() => api.GetMapStatsAsync(" "));
        }

        [Test]
        public async Task NotFound_ReturnsNull()
        {
            var (api, _) = Teamwork(HttpStatusCode.NotFound);
            Assert.That(await api.GetCommunityProviderAsync("nope"), Is.Null);
        }

        [TestCase(HttpStatusCode.Unauthorized)]
        [TestCase(HttpStatusCode.Forbidden)]
        [TestCase(HttpStatusCode.TooManyRequests)]
        [TestCase(HttpStatusCode.InternalServerError)]
        public async Task ErrorStatus_Throws(HttpStatusCode status)
        {
            var (api, _) = Teamwork(status);
            var ex = await Assert.ThrowsAsync<HttpRequestException>(() => api.GetNewsOverviewAsync());
            Assert.That(ex.StatusCode, Is.EqualTo(status));
        }

        [Test]
        public async Task HtmlResponse_Throws()
        {
            var (api, _) = Teamwork(body: "<!DOCTYPE html><html></html>", mediaType: "text/html");
            await Assert.ThrowsAsync<HttpRequestException>(() => api.GetNewsOverviewAsync());
        }

        [Test]
        public async Task Response_IsDeserialized()
        {
            var (api, _) = Teamwork(body: "{\"id\":\"skial\",\"name\":\"Skial\",\"website\":\"https://skial.com\"}");
            var provider = await api.GetCommunityProviderAsync("skial");
            Assert.That(provider.Name, Is.EqualTo("Skial"));
            Assert.That(provider.Website, Is.EqualTo(new Uri("https://skial.com")));
        }

        [Test]
        public async Task Server_PortSentAsStringIsParsed()
        {
            // The API sends ports as strings, e.g. "27015".
            var (api, _) = Teamwork(body: "[{\"ip\":\"151.80.218.92\",\"port\":\"27015\",\"max_players\":32}]");
            var server = (await api.GetServerListByGameModeAsync("payload"))[0];
            Assert.That(server.Port, Is.EqualTo(27015));
            Assert.That(server.MaxPlayers, Is.EqualTo(32));
        }

        [Test]
        public async Task Map_TypedFieldsAreParsed()
        {
            const string json = "{\"map\":\"ctf_2fort\",\"first_seen\":null,\"last_seen\":\"2017-11-27 18:50:00\"," +
                                "\"alltime_avg_players\":\"2328.5486107448\",\"highest_players\":6079}";
            var (api, _) = Teamwork(body: json);
            var map = await api.GetMapStatsAsync("ctf_2fort");
            Assert.That(map.FirstSeen, Is.Null);
            Assert.That(map.LastSeen?.Year, Is.EqualTo(2017));
            Assert.That(map.AllTimeAvgPlayers, Is.EqualTo(2328.5486107448).Within(0.0001));
            Assert.That(map.HighestPlayers, Is.EqualTo(6079));
        }

        [Test]
        public async Task MapThumbnail_IsParsedAsUri()
        {
            var (api, _) = Teamwork(body: "{\"thumbnail\":\"https://teamwork.tf/images/maps/official/ctf_2fort.jpg\"}");
            var thumbnail = await api.GetMapThumbnailAsync("ctf_2fort");
            Assert.That(thumbnail.Thumbnail,
                Is.EqualTo(new Uri("https://teamwork.tf/images/maps/official/ctf_2fort.jpg")));
        }

        [Test]
        public async Task ProviderStats_RegionsAreParsed()
        {
            const string json = "{\"players\":604,\"regions_with_players\":" +
                                "{\"Europe\":516,\"North America\":69,\"Oceania\":10,\"Asia\":9}}";
            var (api, _) = Teamwork(body: json);
            var regions = (await api.GetCommunityStatsAsync("skial")).Regions;
            Assert.That(regions.Europe, Is.EqualTo(516));
            Assert.That(regions.NorthAmerica, Is.EqualTo(69));
            Assert.That(regions.Oceania, Is.EqualTo(10));
            Assert.That(regions.Asia, Is.EqualTo(9));
        }

        [Test]
        public async Task User_SocialFieldsAreStrings()
        {
            const string json = "[{\"id\":816,\"main\":null,\"youtube_acc\":\"UCgRhvJsaM13emRax3rSbRKQ\"," +
                                "\"twitch_acc\":\"sometwitch\",\"discord_group\":null}]";
            var (api, _) = Teamwork(body: json);
            var user = (await api.GetCommunityUserAsync("76561198041892999"))[0];
            Assert.That(user.Id, Is.EqualTo(816));
            Assert.That(user.Main, Is.Null);
            Assert.That(user.Youtube, Is.EqualTo("UCgRhvJsaM13emRax3rSbRKQ"));
            Assert.That(user.Twitch, Is.EqualTo("sometwitch"));
        }

        [Test]
        public async Task Steam_UsesHttpsAndEscapesInput()
        {
            var (api, handler) = Steam();
            await api.GetPlayerItemsAsync("76561198041892999");
            Assert.That(handler.LastRequestUri.Scheme, Is.EqualTo("https"));
            Assert.That(handler.LastRequestUri.AbsoluteUri, Is.EqualTo(
                "https://api.steampowered.com/IEconItems_440/GetPlayerItems/v0001?key=test-key&steamid=76561198041892999"));

            await api.GetMarketPriceAsync("Strange Part: Kills & #1");
            Assert.That(handler.LastRequestUri.Query, Does.EndWith("market_hash_name=Strange%20Part%3A%20Kills%20%26%20%231"));
        }

        [Test]
        public async Task Steam_InventoryAttributesKeepDefindexAndFloatValue()
        {
            const string json = "{\"result\":{\"status\":1,\"items\":[{\"id\":15623785390,\"defindex\":5021," +
                                "\"inventory\":2147483649,\"attributes\":" +
                                "[{\"defindex\":214,\"value\":1103626240,\"float_value\":24.5}]}]}}";
            var (api, _) = Steam(body: json);

            var item = (await api.GetPlayerItemsAsync("1")).Inventory.Items[0];
            Assert.That(item.Id, Is.EqualTo(15623785390UL));
            Assert.That(item.Inventory, Is.EqualTo(2147483649L));

            var attribute = item.Attributes[0];
            Assert.That(attribute.Defindex, Is.EqualTo(214));
            Assert.That(attribute.FloatValue, Is.EqualTo(24.5));
        }

        private sealed class FakeHandler : HttpMessageHandler
        {
            private readonly string _body;
            private readonly string _mediaType;
            private readonly HttpStatusCode _status;

            public FakeHandler(HttpStatusCode status, string body, string mediaType)
            {
                _status = status;
                _body = body;
                _mediaType = mediaType;
            }

            public Uri LastRequestUri { get; private set; }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                CancellationToken cancellationToken)
            {
                LastRequestUri = request.RequestUri;
                return Task.FromResult(new HttpResponseMessage(_status)
                {
                    Content = new StringContent(_body, Encoding.UTF8, _mediaType)
                });
            }
        }
    }
}

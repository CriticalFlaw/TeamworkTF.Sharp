using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TeamworkTF.Test
{
    public class Servers : Setup
    {
        [Test]
        public async Task GetGameModeList()
        {
            var results = await TeamworkTF.GetGameModeListAsync();
            Assert.That(results.Official, Is.Not.Empty);
            Assert.That(results.Community, Is.Not.Empty);
        }

        [Test]
        public async Task GetGameMode()
        {
            Assert.That((await TeamworkTF.GetGameModeAsync("payload")).Id, Is.Not.Null);
        }

        [Test]
        public async Task GetServerListByGameMode()
        {
            Assert.That(await TeamworkTF.GetServerListByGameModeAsync("payload"), Is.Not.Null);
            Assert.That(await TeamworkTF.GetServerListByGameModeAsync("payloader"), Is.Null);
        }

        [Test]
        public async Task GetServerByIp()
        {
            // Look up a server that's online right now, since any hardcoded address eventually goes offline.
            var online = (await TeamworkTF.GetServerListByGameModeAsync("payload"))
                ?.FirstOrDefault(x => !string.IsNullOrEmpty(x.Ip) && x.Port > 0);
            if (online is null) Assert.Inconclusive("No payload servers are online to look up.");

            var results = await TeamworkTF.GetServerByIpAsync(online.Ip, online.Port);
            Assert.That(results, Is.Not.Empty);
        }

        [Test]
        public async Task GetCommunityProvider()
        {
            Assert.That(await TeamworkTF.GetCommunityProviderAsync("skial"), Is.Not.Null);
            Assert.That(await TeamworkTF.GetCommunityProviderAsync("skiil"), Is.Null);
        }

        [Test]
        public async Task GetCommunityServers()
        {
            Assert.That(await TeamworkTF.GetCommunityServersAsync("skial"), Is.Not.Empty);
            Assert.That(await TeamworkTF.GetCommunityServersAsync("skiil"), Is.Empty);
        }

        [Test]
        public async Task GetCommunityStats()
        {
            Assert.That(await TeamworkTF.GetCommunityStatsAsync("skial"), Is.Not.Null);
            Assert.That(await TeamworkTF.GetCommunityStatsAsync("skiil"), Is.Null);
        }

        [Test]
        public async Task GetCompetitiveProvider()
        {
            Assert.That(await TeamworkTF.GetCompetitiveProviderAsync("ugc"), Is.Not.Null);
            Assert.That(await TeamworkTF.GetCompetitiveProviderAsync("ugh"), Is.Null);
        }

        [Test]
        public async Task GetCompetitiveStats()
        {
            Assert.That(await TeamworkTF.GetCompetitiveStatsAsync("ugc"), Is.Not.Null);
            Assert.That(await TeamworkTF.GetCompetitiveStatsAsync("ugh"), Is.Null);
        }

        [Test]
        public async Task GetServerLists()
        {
            Assert.That(await TeamworkTF.GetServerListsAsync(), Is.Not.Empty);
        }

        [Test]
        public async Task GetServerListById()
        {
            Assert.That(await TeamworkTF.GetServerListByIdAsync(1), Is.Not.Null);
        }

        [Test]
        public async Task GetServersFromServerList()
        {
            Assert.That(await TeamworkTF.GetServersFromServerListAsync(1), Is.Not.Empty);
        }
    }
}

using NUnit.Framework;

namespace TeamworkTF.Test
{
    public class Servers : Setup
    {
        [Test]
        public void GetGameModeList()
        {
            Assert.IsNotNull(Client.GetGameModeListAsync().Result);
        }

        [Test]
        public void GetGameMode()
        {
            Assert.IsNotNull(Client.GetGameModeAsync("payload").Result.Title);
        }

        [Test]
        public void GetServerListByGameMode()
        {
            Assert.IsNotNull(Client.GetServerListByGameModeAsync("payload").Result);
            Assert.IsNull(Client.GetServerListByGameModeAsync("payloader").Result);
        }

        [Test]
        public void GetServerByIp()
        {
            Assert.IsNotNull(Client.GetServerByIpAsync("164.132.233.16", 27022).Result);
        }

        [Test]
        public void GetCommunityProvider()
        {
            Assert.IsNotNull(Client.GetCommunityProviderAsync("skial").Result);
            Assert.IsNull(Client.GetCommunityProviderAsync("skiil").Result);
        }

        [Test]
        public void GetCommunityServers()
        {
            Assert.Greater(Client.GetCommunityServersAsync("skial").Result.Count, 0);
            Assert.AreEqual(Client.GetCommunityServersAsync("skiil").Result.Count, 0);
        }

        [Test]
        public void GetCommunityStats()
        {
            Assert.IsNotNull(Client.GetCommunityStatsAsync("skial").Result);
            Assert.IsNull(Client.GetCommunityStatsAsync("skiil").Result);
        }

        [Test]
        public void GetCompetitiveProvider()
        {
            Assert.IsNotNull(Client.GetCompetitiveProviderAsync("ugc").Result);
            Assert.IsNull(Client.GetCompetitiveProviderAsync("ugh").Result);
        }

        [Test]
        public void GetCompetitiveStats()
        {
            Assert.IsNotNull(Client.GetCompetitiveStatsAsync("ugc").Result);
            Assert.IsNull(Client.GetCompetitiveStatsAsync("ugh").Result);
        }

        [Test]
        public void GetServerLists()
        {
            Assert.IsNotNull(Client.GetServerListsAsync().Result);
        }

        [Test]
        public void GetServerListById()
        {
            Assert.IsNotNull(Client.GetServerListByIdAsync(1).Result);
        }

        [Test]
        public void GetServersFromServerList()
        {
            Assert.IsNotNull(Client.GetServersFromServerListAsync(1).Result);
        }
    }
}
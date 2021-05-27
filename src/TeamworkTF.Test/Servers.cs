using NUnit.Framework;

namespace TeamworkTF.Test
{
    public class Servers : Setup
    {
        [Test]
        public void GetServerBanner()
        {
            Assert.IsTrue(TeamworkTF.GetServerBanner("193.221.192.28").Contains("png"));
            Assert.IsFalse(TeamworkTF.GetServerBanner("9999.2341.4324.2132").Contains("png"));
        }

        [Test]
        public void GetGameModeList()
        {
            var results = TeamworkTF.GetGameModeListAsync().Result;
            Assert.Greater(results.Official.Count, 0);
            Assert.Greater(results.Community.Count, 0);
        }

        [Test]
        public void GetGameMode()
        {
            Assert.IsNotNull(TeamworkTF.GetGameModeAsync("payload").Result.Id);
        }

        [Test]
        public void GetServerListByGameMode()
        {
            Assert.IsNotNull(TeamworkTF.GetServerListByGameModeAsync("payload").Result);
            Assert.IsNull(TeamworkTF.GetServerListByGameModeAsync("payloader").Result);
        }

        [Test]
        public void GetServerByIp()
        {
            Assert.Greater(TeamworkTF.GetServerByIpAsync("138.197.133.71").Result.Count, 0);
        }

        [Test]
        public void GetCommunityProvider()
        {
            Assert.IsNotNull(TeamworkTF.GetCommunityProviderAsync("skial").Result);
            Assert.IsNull(TeamworkTF.GetCommunityProviderAsync("skiil").Result);
        }

        [Test]
        public void GetCommunityServers()
        {
            Assert.Greater(TeamworkTF.GetCommunityServersAsync("skial").Result.Count, 0);
            Assert.AreEqual(TeamworkTF.GetCommunityServersAsync("skiil").Result.Count, 0);
        }

        [Test]
        public void GetCommunityStats()
        {
            Assert.IsNotNull(TeamworkTF.GetCommunityStatsAsync("skial").Result);
            Assert.IsNull(TeamworkTF.GetCommunityStatsAsync("skiil").Result);
        }

        [Test]
        public void GetCompetitiveProvider()
        {
            Assert.IsNotNull(TeamworkTF.GetCompetitiveProviderAsync("ugc").Result);
            Assert.IsNull(TeamworkTF.GetCompetitiveProviderAsync("ugh").Result);
        }

        [Test]
        public void GetCompetitiveStats()
        {
            Assert.IsNotNull(TeamworkTF.GetCompetitiveStatsAsync("ugc").Result);
            Assert.IsNull(TeamworkTF.GetCompetitiveStatsAsync("ugh").Result);
        }

        [Test]
        public void GetServerLists()
        {
            Assert.Greater(TeamworkTF.GetServerListsAsync().Result.Count, 0);
        }

        [Test]
        public void GetServerListById()
        {
            Assert.NotNull(TeamworkTF.GetServerListByIdAsync(1).Result);
        }

        [Test]
        public void GetServersFromServerList()
        {
            Assert.Greater(TeamworkTF.GetServersFromServerListAsync(1).Result.Count, 0);
        }
    }
}
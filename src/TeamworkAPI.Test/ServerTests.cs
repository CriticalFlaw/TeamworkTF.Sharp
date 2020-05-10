using NUnit.Framework;

namespace TeamworkAPI.Test
{
    public class ServerTests : BaseTest
    {
        [Test]
        public void GetCommunityProvider()
        {
            Assert.IsNotNull(client.GetCommunityProviderAsync("skial").Result);
            Assert.IsNull(client.GetCommunityProviderAsync("skiil").Result);
        }

        [Test]
        public void GetCommunityProviderServers()
        {
            Assert.Greater(client.GetCommunityProviderServersAsync("skial").Result.Count, 0);
            Assert.AreEqual(client.GetCommunityProviderServersAsync("skiil").Result.Count, 0);
        }

        [Test]
        public void GetCommunityProviderStats()
        {
            Assert.IsNotNull(client.GetCommunityProviderStatsAsync("skial").Result);
            Assert.IsNull(client.GetCommunityProviderStatsAsync("skiil").Result);
        }

        [Test]
        public void GetCompetitiveProvider()
        {
            Assert.IsNotNull(client.GetCompetitiveProviderAsync("ugc").Result);
            Assert.IsNull(client.GetCompetitiveProviderAsync("ugh").Result);
        }

        [Test]
        public void GetCompetitiveProviderStats()
        {
            Assert.IsNotNull(client.GetCompetitiveProviderStatsAsync("ugc").Result);
            Assert.IsNull(client.GetCompetitiveProviderStatsAsync("ugh").Result);
        }

        [Test]
        public void GetCustomServerLists()
        {
            Assert.IsNotNull(client.GetCustomServerListsAsync().Result);
        }

        [Test]
        public void GetSpecificServerList()
        {
            Assert.IsNotNull(client.GetSpecificServerListAsync(1).Result);
        }

        [Test]
        public void GetServersFromServerList()
        {
            Assert.IsNotNull(client.GetServersFromServerListAsync(1).Result);
        }
    }
}
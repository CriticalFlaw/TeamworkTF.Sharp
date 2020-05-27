using NUnit.Framework;

namespace TeamworkTF.Test
{
    public class ServerTests : BaseTest
    {
        [Test]
        public void GetCommunityProvider()
        {
            Assert.IsNotNull(Client.GetCommunityProviderAsync("skial").Result);
            Assert.IsNull(Client.GetCommunityProviderAsync("skiil").Result);
        }

        [Test]
        public void GetCommunityProviderServers()
        {
            Assert.Greater(Client.GetCommunityProviderServersAsync("skial").Result.Count, 0);
            Assert.AreEqual(Client.GetCommunityProviderServersAsync("skiil").Result.Count, 0);
        }

        [Test]
        public void GetCommunityProviderStats()
        {
            Assert.IsNotNull(Client.GetCommunityProviderStatsAsync("skial").Result);
            Assert.IsNull(Client.GetCommunityProviderStatsAsync("skiil").Result);
        }

        [Test]
        public void GetCompetitiveProvider()
        {
            Assert.IsNotNull(Client.GetCompetitiveProviderAsync("ugc").Result);
            Assert.IsNull(Client.GetCompetitiveProviderAsync("ugh").Result);
        }

        [Test]
        public void GetCompetitiveProviderStats()
        {
            Assert.IsNotNull(Client.GetCompetitiveProviderStatsAsync("ugc").Result);
            Assert.IsNull(Client.GetCompetitiveProviderStatsAsync("ugh").Result);
        }

        [Test]
        public void GetCustomServerLists()
        {
            Assert.IsNotNull(Client.GetCustomServerListsAsync().Result);
        }

        [Test]
        public void GetSpecificServerList()
        {
            Assert.IsNotNull(Client.GetSpecificServerListAsync(1).Result);
        }

        [Test]
        public void GetServersFromServerList()
        {
            Assert.IsNotNull(Client.GetServersFromServerListAsync(1).Result);
        }
    }
}
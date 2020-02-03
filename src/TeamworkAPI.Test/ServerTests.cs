using NUnit.Framework;

namespace TeamworkAPI.Test
{
    public class ServerTests
    {
        public TeamworkClient client;

        [SetUp]
        public void Setup()
        {
            client = new TeamworkClient("");
        }

        [Test]
        public void GetCommunityProvider()
        {
            Assert.IsNotNull(client.GetCommunityProviderAsync("vaticancity").Result);
        }

        [Test]
        public void GetCommunityProviderServers()
        {
            Assert.IsNotNull(client.GetCommunityProviderServersAsync("vaticancity").Result);
        }

        [Test]
        public void GetCommunityProviderStats()
        {
            Assert.IsNotNull(client.GetCommunityProviderStatsAsync("vaticancity").Result);
        }

        [Test]
        public void GetCompetitiveProvider()
        {
            Assert.IsNotNull(client.GetCompetitiveProviderAsync("ugc").Result);
        }

        [Test]
        public void GetCompetitiveProviderStats()
        {
            Assert.IsNotNull(client.GetCompetitiveProviderStatsAsync("ugc").Result);
        }
    }
}
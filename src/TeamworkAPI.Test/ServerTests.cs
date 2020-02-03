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
            Assert.IsNull(client.GetCommunityProviderAsync("ottawacity").Result);
        }

        [Test]
        public void GetCommunityProviderServers()
        {
            Assert.Greater(client.GetCommunityProviderServersAsync("vaticancity").Result.Count, 0);
            Assert.AreEqual(client.GetCommunityProviderServersAsync("ottawacity").Result.Count, 0);
        }

        [Test]
        public void GetCommunityProviderStats()
        {
            Assert.IsNotNull(client.GetCommunityProviderStatsAsync("vaticancity").Result);
            Assert.IsNull(client.GetCommunityProviderStatsAsync("ottawacity").Result);
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
    }
}
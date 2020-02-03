using NUnit.Framework;

namespace TeamworkAPI.Test
{
    public class MapTests
    {
        public TeamworkClient client;

        [SetUp]
        public void Setup()
        {
            client = new TeamworkClient("");
        }

        [Test]
        public void GetMapStats()
        {
            Assert.IsNotNull(client.GetMapStatsAsync("pl_upward").Result);
        }

        [Test]
        public void GetMapThumbnail()
        {
            Assert.IsNotNull(client.GetMapThumbnailAsync("pl_upward").Result);
        }

        [Test]
        public void GetMapThumbnailContext()
        {
            Assert.IsNotNull(client.GetMapThumbnailContextAsync("pl_upward").Result);
        }

        [Test]
        public void GetMapsBySearch()
        {
            Assert.IsNotNull(client.GetMapsBySearchAsync("pl_upward").Result);
        }
    }
}
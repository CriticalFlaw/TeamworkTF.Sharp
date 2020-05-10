using NUnit.Framework;

namespace TeamworkAPI.Test
{
    public class MapTests : BaseTest
    {
        [Test]
        public void GetMapStats()
        {
            Assert.IsNotNull(client.GetMapStatsAsync("pl_upward").Result);
            Assert.IsNull(client.GetMapStatsAsync("plr_rupward").Result);
        }

        [Test]
        public void GetMapThumbnail()
        {
            Assert.IsNotNull(client.GetMapThumbnailAsync("pl_upward").Result.Name);
            Assert.IsNull(client.GetMapThumbnailAsync("plr_rupward").Result.Name);
        }

        [Test]
        public void GetMapThumbnailContext()
        {
            Assert.IsNotNull(client.GetMapThumbnailContextAsync("pl_upward").Result.Thumbnail);
            Assert.IsNull(client.GetMapThumbnailContextAsync("plr_rupward").Result.Thumbnail);
        }

        [Test]
        public void GetMapsBySearch()
        {
            Assert.IsNotNull(client.GetMapsBySearchAsync("hightower").Result);
        }
    }
}
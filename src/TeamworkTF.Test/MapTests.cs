using NUnit.Framework;

namespace TeamworkTF.Test
{
    public class MapTests : BaseTest
    {
        [Test]
        public void GetMapStats()
        {
            Assert.IsNotNull(Client.GetMapStatsAsync("pl_upward").Result);
            Assert.IsNull(Client.GetMapStatsAsync("plra_rupward").Result.MapName);
        }

        [Test]
        public void GetMapThumbnail()
        {
            Assert.IsNotNull(Client.GetMapThumbnailAsync("pl_upward").Result.Name);
            Assert.IsNull(Client.GetMapThumbnailAsync("plr_rupward").Result.Name);
        }

        [Test]
        public void GetMapThumbnailContext()
        {
            Assert.IsNotNull(Client.GetMapThumbnailContextAsync("pl_upward").Result.Thumbnail);
            Assert.IsNull(Client.GetMapThumbnailContextAsync("plr_rupward").Result.Thumbnail);
        }

        [Test]
        public void GetMapsBySearch()
        {
            Assert.IsNotNull(Client.GetMapsBySearchAsync("hightower").Result);
        }
    }
}
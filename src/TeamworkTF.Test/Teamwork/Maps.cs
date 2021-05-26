using NUnit.Framework;

namespace TeamworkTF.Test
{
    public class Maps : Setup
    {
        [Test]
        public void GetMapStats()
        {
            Assert.IsNotNull(TeamworkTF.GetMapStatsAsync("pl_upward").Result);
            Assert.IsNull(TeamworkTF.GetMapStatsAsync("plra_rupward").Result.MapName);
        }

        [Test]
        public void GetMapThumbnail()
        {
            Assert.IsNotNull(TeamworkTF.GetMapThumbnailAsync("pl_upward").Result.Name);
            Assert.IsNull(TeamworkTF.GetMapThumbnailAsync("plr_rupward").Result.Name);
        }

        [Test]
        public void GetMapThumbnailContext()
        {
            Assert.IsNotNull(TeamworkTF.GetMapImagesAsync("pl_upward").Result.Thumbnail);
            Assert.IsNull(TeamworkTF.GetMapImagesAsync("plr_rupward").Result.Thumbnail);
        }

        [Test]
        public void GetMapsBySearch()
        {
            Assert.Greater(TeamworkTF.GetMapsBySearchAsync("hightower").Result.Count, 0);
        }
    }
}
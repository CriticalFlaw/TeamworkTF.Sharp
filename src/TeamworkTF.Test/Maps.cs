using System.Threading.Tasks;
using NUnit.Framework;

namespace TeamworkTF.Test
{
    public class Maps : Setup
    {
        [Test]
        public async Task GetMapStats()
        {
            Assert.That(await TeamworkTF.GetMapStatsAsync("pl_upward"), Is.Not.Null);
            Assert.That((await TeamworkTF.GetMapStatsAsync("plra_rupward"))?.MapName, Is.Null);
        }

        [Test]
        public async Task GetMapThumbnail()
        {
            Assert.That((await TeamworkTF.GetMapThumbnailAsync("pl_upward")).Thumbnail, Is.Not.Null);
            Assert.That((await TeamworkTF.GetMapThumbnailAsync("plr_rupward"))?.Thumbnail, Is.Null);
        }

        [Test]
        public async Task GetMapThumbnailContext()
        {
            Assert.That((await TeamworkTF.GetMapImagesAsync("pl_upward")).Thumbnail, Is.Not.Null);
            Assert.That((await TeamworkTF.GetMapImagesAsync("plr_rupward"))?.Thumbnail, Is.Null);
        }

        [Test]
        public async Task GetMapsBySearch()
        {
            Assert.That(await TeamworkTF.GetMapsBySearchAsync("hightower"), Is.Not.Empty);
        }
    }
}

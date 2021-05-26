using NUnit.Framework;

namespace TeamworkTF.Test
{
    public class Schema : Setup
    {
        [Test]
        public void GetPlayerItems()
        {
            Assert.Greater(Steam.GetPlayerItemsAsync("76561198041892999").Result.Result.Items.Count, 0);
        }

        [Test]
        public void GetSchemaItems()
        {
            Assert.Greater(Steam.GetSchemaItemsAsync().Result.Result.Items.Count, 0);
        }

        [Test]
        public void GetSchemaUrl()
        {
            Assert.NotNull(Steam.GetSchemaUrlAsync().Result.Result.ItemsGameUrl);
        }
    }
}
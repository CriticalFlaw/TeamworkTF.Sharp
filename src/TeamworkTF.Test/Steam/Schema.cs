using NUnit.Framework;

namespace TeamworkTF.Test
{
    public class Schema : Setup
    {
        [Test]
        public void GetPlayerItems()
        {
            var results = Steam.GetPlayerItemsAsync("76561198041892999").Result.Inventory.Items;
            Assert.Greater(results.Count, 0);
        }

        [Test]
        public void GetSchemaItems()
        {
            Assert.Greater(Steam.GetSchemaItemsAsync().Result.Schema.Items.Count, 0);
        }

        [Test]
        public void GetSchemaUrl()
        {
            Assert.NotNull(Steam.GetSchemaUrlAsync().Result.Schema.SchemaUrl);
        }
    }
}
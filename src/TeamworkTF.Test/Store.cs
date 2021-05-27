using NUnit.Framework;

namespace TeamworkTF.Test
{
    [Ignore("Steam API endpoints are unreliable")]
    public class Store : Setup
    {
        [Test, Retry(3)]
        public void GetStoreData()
        {
            Assert.IsNotNull(Steam.GetStoreDataAsync().Result);
        }

        [Test, Retry(3)]
        public void GetMarketPrice()
        {
            Assert.IsTrue(Steam.GetMarketPriceAsync("Backpack Expander").Result.Success);
        }
        [Test, Retry(3)]
        public void GetPlayerItems()
        {
            Assert.Greater(Steam.GetPlayerItemsAsync("76561198041892999").Result.Inventory.Items.Count, 0);
        }

        [Test, Retry(3)]
        public void GetSchemaItems()
        {
            Assert.Greater(Steam.GetSchemaItemsAsync().Result.Schema.Items.Count, 0);
        }

        [Test, Retry(3)]
        public void GetSchemaUrl()
        {
            Assert.NotNull(Steam.GetSchemaUrlAsync().Result.Schema.SchemaUrl);
        }
    }
}
using NUnit.Framework;

namespace TeamworkTF.Test
{
    public class Store : Setup
    {
        [Test]
        public void GetStoreData()
        {
            Assert.IsNotNull(Steam.GetStoreDataAsync().Result);
        }

        [Test]
        public void GetMarketPrice()
        {
            Assert.IsTrue(Steam.GetMarketPriceAsync("Backpack Expander").Result.Success);
        }
    }
}
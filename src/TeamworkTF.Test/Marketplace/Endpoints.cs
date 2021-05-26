using NUnit.Framework;

namespace TeamworkTF.Test
{
    public class Endpoints : Setup
    {
        [Test]
        public void GetEndpoints()
        {
            Assert.IsTrue(MarketplaceTF.GetEndpointsAsync().Result.Success);
        }

        [Test]
        public void GetMarketplaceBots()
        {
            Assert.IsTrue(MarketplaceTF.GetMarketplaceBotsAsync().Result.Success);
        }
    }
}
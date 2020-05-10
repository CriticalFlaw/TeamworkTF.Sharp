using NUnit.Framework;

namespace TeamworkTF.Test
{
    public class QuickplayTests : BaseTest
    {
        [Test]
        public void GetGameMode()
        {
            Assert.IsNotNull(client.GetGameModeAsync("payload").Result.Title);
        }

        [Test]
        public void GetGameModeList()
        {
            Assert.IsNotNull(client.GetGameModeListAsync().Result);
        }

        [Test]
        public void GetGameModeServer()
        {
            Assert.IsNotNull(client.GetGameModeServerAsync("payload").Result);
            Assert.IsNull(client.GetGameModeServerAsync("payloader").Result);
        }

        [Test]
        public void GetGameServerInfo()
        {
            Assert.IsNotNull(client.GetGameServerInfoAsync("164.132.233.16", 27022).Result);
        }
    }
}
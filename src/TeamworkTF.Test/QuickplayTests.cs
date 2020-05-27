using NUnit.Framework;

namespace TeamworkTF.Test
{
    public class QuickplayTests : BaseTest
    {
        [Test]
        public void GetGameMode()
        {
            Assert.IsNotNull(Client.GetGameModeAsync("payload").Result.Title);
        }

        [Test]
        public void GetGameModeList()
        {
            Assert.IsNotNull(Client.GetGameModeListAsync().Result);
        }

        [Test]
        public void GetGameModeServer()
        {
            Assert.IsNotNull(Client.GetGameModeServerAsync("payload").Result);
            Assert.IsNull(Client.GetGameModeServerAsync("payloader").Result);
        }

        [Test]
        public void GetGameServerInfo()
        {
            Assert.IsNotNull(Client.GetGameServerInfoAsync("164.132.233.16", 27022).Result);
        }
    }
}
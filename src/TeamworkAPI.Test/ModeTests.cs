using NUnit.Framework;

namespace TeamworkAPI.Test
{
    public class ModeTests
    {
        public TeamworkClient client;

        [SetUp]
        public void Setup()
        {
            client = new TeamworkClient("");
        }

        [Test]
        public void GetGameMode()
        {
            Assert.IsNotNull(client.GetGameModeAsync("payload").Result);
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
        }
    }
}
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
        [Ignore("Skip. Function is deprecated/currently unavailable.")]
        public void GetGameMode()
        {
            //Assert.IsNotNull(client.GetGameModeAsync("ctf").Result.Official);
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
    }
}
using NUnit.Framework;

namespace TeamworkTF.Test
{
    public class Creators : Setup
    {
        [Test]
        public void GetMapCreatorById()
        {
            Assert.IsNotNull(Client.GetMapCreatorAsync("76561198041892999").Result);
        }

        [Test]
        public void GetYouTubeCreatorById()
        {
            Assert.IsNotNull(Client.GetYouTubeCreatorAsync("76561198041892999").Result);
        }
    }
}
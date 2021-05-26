using NUnit.Framework;

namespace TeamworkTF.Test
{
    public class Creators : Setup
    {
        [Test]
        public void GetYouTubeCreatorById()
        {
            Assert.Greater(TeamworkTF.GetYouTubeCreatorAsync("76561198041892999").Result.Count, 0);
        }
    }
}
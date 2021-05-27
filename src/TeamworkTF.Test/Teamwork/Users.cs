using NUnit.Framework;

namespace TeamworkTF.Test
{
    public class Users : Setup
    {
        [Test]
        public void GetCommunityUser()
        {
            Assert.Greater(TeamworkTF.GetCommunityUserAsync("76561198041892999").Result.Count, 0);
        }
    }
}
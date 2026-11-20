using System.Threading.Tasks;
using NUnit.Framework;

namespace TeamworkTF.Test
{
    public class Users : Setup
    {
        [Test]
        public async Task GetCommunityUser()
        {
            Assert.That(await TeamworkTF.GetCommunityUserAsync("76561198041892999"), Is.Not.Empty);
        }
    }
}

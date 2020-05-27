using NUnit.Framework;

namespace TeamworkTF.Test
{
    public class CreatorTests : BaseTest
    {
        [Test]
        public void GetCreatorById()
        {
            Assert.IsNotNull(Client.GetCreatorByIdAsync("76561198041892999").Result);
        }
    }
}
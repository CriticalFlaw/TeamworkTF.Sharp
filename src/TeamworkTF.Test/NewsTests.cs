using NUnit.Framework;

namespace TeamworkTF.Test
{
    public class NewsTests : BaseTest
    {
        [Test]
        public void GetNewsOverview()
        {
            Assert.IsNotNull(client.GetNewsOverviewAsync().Result);
        }

        [Test]
        public void GetNewsPost()
        {
            Assert.IsNotNull(client.GetNewsPostAsync("a20d4d212c82a76c9915dac6b23bd53d").Result.Title);
            Assert.IsNull(client.GetNewsPostAsync("99999999999999999999999999999999").Result.Title);
        }

        [Test]
        public void GetNewsByPage()
        {
            Assert.IsNotNull(client.GetNewsByPageAsync(5).Result);
        }

        [Test]
        public void GetNewsByProvider()
        {
            Assert.IsNotNull(client.GetNewsByProviderAsync("kritzkast").Result);
        }
    }
}
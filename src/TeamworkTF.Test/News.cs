using NUnit.Framework;

namespace TeamworkTF.Test
{
    public class News : Setup
    {
        [Test]
        public void GetNewsOverview()
        {
            Assert.IsNotNull(Client.GetNewsOverviewAsync().Result);
        }

        [Test]
        public void GetNewsPost()
        {
            Assert.IsNotNull(Client.GetNewsPostAsync("a20d4d212c82a76c9915dac6b23bd53d").Result.Title);
            Assert.IsNull(Client.GetNewsPostAsync("99999999999999999999999999999999").Result.Title);
        }

        [Test]
        public void GetNewsByPage()
        {
            Assert.IsNotNull(Client.GetNewsByPageAsync(5).Result);
        }

        [Test]
        public void GetNewsByProvider()
        {
            Assert.IsNotNull(Client.GetNewsByProviderAsync("kritzkast").Result);
        }
    }
}
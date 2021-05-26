using NUnit.Framework;

namespace TeamworkTF.Test
{
    public class News : Setup
    {
        [Test]
        public void GetNewsOverview()
        {
            Assert.Greater(TeamworkTF.GetNewsOverviewAsync().Result.Count, 0);
        }

        [Test]
        public void GetNewsPost()
        {
            Assert.IsNotNull(TeamworkTF.GetNewsPostAsync("a20d4d212c82a76c9915dac6b23bd53d").Result.Title);
            Assert.IsNull(TeamworkTF.GetNewsPostAsync("99999999999999999999999999999999").Result.Title);
        }

        [Test]
        public void GetNewsByPage()
        {
            Assert.IsNotNull(TeamworkTF.GetNewsByPageAsync(5).Result);
        }

        [Test]
        public void GetNewsByProvider()
        {
            Assert.Greater(TeamworkTF.GetNewsByProviderAsync("kritzkast").Result.Count, 0);
        }
    }
}
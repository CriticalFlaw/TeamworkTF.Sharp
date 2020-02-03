using NUnit.Framework;

namespace TeamworkAPI.Test
{
    public class NewsTests
    {
        public TeamworkClient client;

        [SetUp]
        public void Setup()
        {
            client = new TeamworkClient("");
        }

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
    }
}
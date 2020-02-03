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
            Assert.IsNotNull(client.GetNewsPostAsync("0").Result);
        }
    }
}
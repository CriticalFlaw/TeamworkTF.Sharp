using System.Threading.Tasks;
using NUnit.Framework;

namespace TeamworkTF.Test
{
    public class News : Setup
    {
        [Test]
        public async Task GetNewsOverview()
        {
            Assert.That(await TeamworkTF.GetNewsOverviewAsync(), Is.Not.Empty);
        }

        [Test]
        public async Task GetNewsPost()
        {
            Assert.That((await TeamworkTF.GetNewsPostAsync("a20d4d212c82a76c9915dac6b23bd53d")).Title, Is.Not.Null);
            Assert.That((await TeamworkTF.GetNewsPostAsync("99999999999999999999999999999999"))?.Title, Is.Null);
        }

        [Test]
        public async Task GetNewsByPage()
        {
            Assert.That(await TeamworkTF.GetNewsByPageAsync(5), Is.Not.Null);
        }

        [Test]
        public async Task GetNewsByProvider()
        {
            Assert.That(await TeamworkTF.GetNewsByProviderAsync("kritzkast"), Is.Not.Empty);
        }
    }
}

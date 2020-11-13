using NUnit.Framework;

namespace TeamworkTF.Test
{
    public class Banner : Setup
    {
        [Test]
        public void GenerateServerBanner()
        {
            Assert.IsTrue(Client.GetServerBanner("193.221.192.28").Contains("png"));
            Assert.IsFalse(Client.GetServerBanner("9999.2341.4324.2132").Contains("png"));
        }
    }
}
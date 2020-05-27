using NUnit.Framework;
using TeamworkTF.Sharp;

namespace TeamworkTF.Test
{
    public class BaseTest
    {
        public TeamworkClient Client;

        [OneTimeSetUp]
        public void GetSetup()
        {
            Client = new TeamworkClient("");
        }
    }
}
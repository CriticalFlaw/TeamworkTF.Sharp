using NUnit.Framework;
using TeamworkTF.Sharp;

namespace TeamworkTF.Test
{
    public class BaseTest
    {
        public TeamworkClient client;

        [OneTimeSetUp]
        public void Setup()
        {
            client = new TeamworkClient("");
        }
    }
}
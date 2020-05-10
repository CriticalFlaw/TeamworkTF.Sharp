using NUnit.Framework;

namespace TeamworkAPI.Test
{
    public class BaseTest
    {
        public TeamworkClient client;

        [OneTimeSetUp]
        public void Setup()
        {
            client = new TeamworkClient("CAYpIqrbaw4WgZcmBd61htfiePyoVzHJ");
        }
    }
}
using NUnit.Framework;
using TeamworkTF.Sharp;

namespace TeamworkTF.Test
{
    public class Setup
    {
        public TeamworkClient Client;

        [OneTimeSetUp]
        public void GetSetup()
        {
            Client = new TeamworkClient("CAYpIqrbaw4WgZcmBd61htfiePyoVzHJ");
        }
    }
}
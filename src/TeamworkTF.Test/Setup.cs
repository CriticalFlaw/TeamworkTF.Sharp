using NUnit.Framework;
using TeamworkTF.Sharp;

namespace TeamworkTF.Test
{
    public class Setup
    {
        public Sharp.TeamworkTF TeamworkTF;
        public SteamApi Steam;

        [OneTimeSetUp]
        public void GetSetup()
        {
            TeamworkTF = new Sharp.TeamworkTF("");
            Steam = new SteamApi("");
        }
    }
}
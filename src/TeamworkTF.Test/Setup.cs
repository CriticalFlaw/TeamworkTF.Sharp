using NUnit.Framework;
using TeamworkTF.Sharp;

namespace TeamworkTF.Test
{
    public class Setup
    {
        public Sharp.TeamworkTF TeamworkTF;
        public SteamAPI Steam;
        public MarketplaceTF MarketplaceTF;

        [OneTimeSetUp]
        public void GetSetup()
        {
            TeamworkTF = new Sharp.TeamworkTF(null);
            Steam = new SteamAPI(null);
            MarketplaceTF = new MarketplaceTF();
        }
    }
}
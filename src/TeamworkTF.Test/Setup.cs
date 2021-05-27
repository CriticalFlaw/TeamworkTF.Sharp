using System;
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
            var teamworkTf = Environment.GetEnvironmentVariable("teamworkTf") ?? "";
            var steam = Environment.GetEnvironmentVariable("steam") ?? "";
            TeamworkTF = new Sharp.TeamworkTF(teamworkTf);
            Steam = new SteamApi(Environment.GetEnvironmentVariable(steam));
        }
    }
}
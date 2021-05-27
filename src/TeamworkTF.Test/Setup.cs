using System;
using NUnit.Framework;

namespace TeamworkTF.Test
{
    public class Setup
    {
        public Sharp.TeamworkTF TeamworkTF;
        public Sharp.SteamApi Steam;

        [OneTimeSetUp]
        public void GetSetup()
        {
            TeamworkTF = new Sharp.TeamworkTF(Environment.GetEnvironmentVariable("teamworkTf") ?? "");
            Steam = new Sharp.SteamApi(Environment.GetEnvironmentVariable(Environment.GetEnvironmentVariable("steam") ?? ""));
        }
    }
}
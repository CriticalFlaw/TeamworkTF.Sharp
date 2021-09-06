using System;
using NUnit.Framework;
using TeamworkTF.Sharp;

namespace TeamworkTF.Test
{
    public class Setup
    {
        public TeamworkAPI TeamworkTF;

        [OneTimeSetUp]
        public void GetSetup()
        {
            TeamworkTF = new TeamworkAPI(Environment.GetEnvironmentVariable("teamworkTf") ?? "CAYpIqrbaw4WgZcmBd61htfiePyoVzHJ");
        }
    }
}
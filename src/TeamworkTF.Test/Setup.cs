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
            var apiKey = Environment.GetEnvironmentVariable("teamworkTf");
            if (string.IsNullOrWhiteSpace(apiKey))
                Assert.Ignore("Set the 'teamworkTf' environment variable to a teamwork.tf API key to run these tests.");

            TeamworkTF = new TeamworkAPI(apiKey);
        }
    }
}

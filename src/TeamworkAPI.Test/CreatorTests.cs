﻿using NUnit.Framework;

namespace TeamworkAPI.Test
{
    public class CreatorTests : BaseTest
    {
        [Test]
        public void GetCreatorByID()
        {
            Assert.IsNotNull(client.GetCreatorByIDAsync("76561198041892999").Result);
        }
    }
}
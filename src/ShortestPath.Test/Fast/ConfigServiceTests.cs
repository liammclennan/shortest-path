using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ShortestPath.Core.Services;

namespace ShortestPath.Test.Fast
{
    [TestFixture]
    public class ConfigServiceTests : FastTestBase
    {
        private ConfigService service;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            service = container.Create<ConfigService>();
        }

        [Test]
        public void GoogleMapsAPIKey()
        {
            string key = service.GoogleMapsAPIKey();
            Assert.IsFalse(string.IsNullOrEmpty(key));
        }
    }
}

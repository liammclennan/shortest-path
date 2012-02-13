using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ShortestPath.Core.Domain;
using ShortestPath.Test.Creators;

namespace ShortestPath.Test.Fast
{
    [TestFixture]
    public class DirectionsTests
    {
        [Test]
        public void Edges()
        {            
            var directions = new Directions();
            directions.AddRoute(PointMother.ChannelSt, PointMother.DelanceySt);
            directions.AddRoute(PointMother.DelanceySt, PointMother.ChannelSt);

            var edges = directions.Edges(GraphMother.ChannelDelanceyThornlandsBeckwith);
            Assert.AreEqual(2, edges.Count());
        }
    }
}

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
    public class DirectedGraphTests
    {
        [Test]
        public void DistanceBetweenTwoEdges_DelanceyBeckwith_ChannelThornlands()
        {
            var graph = new DirectedGraph(new[]
                                      {
                                          PointMother.DelanceySt, PointMother.ThornlandsRd, PointMother.BeckwithSt,
                                          PointMother.ChannelSt
                                      });
            var delanceyBeckwith = graph.GetEdge(new[] {PointMother.DelanceySt, PointMother.BeckwithSt});
            var channelThornlands = graph.GetEdge(new[] {PointMother.ChannelSt, PointMother.ThornlandsRd});
            
            var result = graph.DistanceBetweenTwoEdges(delanceyBeckwith, channelThornlands);
            Assert.AreEqual(4.0, result, 0.1);
        }
    }
}

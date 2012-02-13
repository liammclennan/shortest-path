using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ShortestPath.Core.Domain;
using ShortestPath.Core.Services;
using ShortestPath.Test.Creators;
using SpecUnit;

namespace ShortestPath.Test.Fast
{
    [Concern("DirectedGraph")]
    public class when_building_a_graph_of_three_points : BaseSpec
    {
        private DirectedGraph result;
        private Point[] points;

        protected override void Given()
        {
            points = new Point[] { PointMother.ChannelSt, PointMother.EthelSt, PointMother.BurchellSt };
        }

        protected override void Do()
        {
            result = new DirectedGraph(points);
        }

        [Observation]
        public void graph_should_have_three_vertices()
        {
            Assert.AreEqual(3, result.Vertices.Count); 
        }

        [Observation]
        public void graph_should_have_one_edge_for_each_connection()
        {
            Assert.AreEqual(3, result.Edges.Count);
            var one = result.GetEdge(new[] {PointMother.ChannelSt, PointMother.EthelSt});
            Assert.AreEqual(8.16747, one.DistanceCost, 0.001);
            Assert.AreEqual(Edge.INFINITE_COST, one.TimeCost);

            var two = result.GetEdge(new[] { PointMother.ChannelSt, PointMother.BurchellSt });
            Assert.AreEqual(19.04, two.DistanceCost, 0.01);
            Assert.AreEqual(Edge.INFINITE_COST, two.TimeCost);

            var three = result.GetEdge(new[] { PointMother.BurchellSt, PointMother.EthelSt });
            Assert.AreEqual(11.556, three.DistanceCost, 0.001);
            Assert.AreEqual(Edge.INFINITE_COST, three.TimeCost);
        }
    }
}
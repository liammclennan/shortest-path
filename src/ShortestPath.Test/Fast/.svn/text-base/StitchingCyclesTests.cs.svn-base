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
    [Concern("StitchingCycles")]
    public class when_finding_closest_sides_for_cyclic_channel_thornlands_delancey_beckwith_channel : BaseSpec
    {
        private IStitchingService stitcher;
        private GraphNavigator nav;
        private Directions result;
        private IList<Directions> cycles;
        private EdgePair edges;

        protected override void Given()
        {
            var graph = GraphMother.ChannelDelanceyThornlandsBeckwith;
            nav = new GraphNavigator(graph,
                PointMother.ChannelSt, PointMother.ChannelSt,
                new ChannelDelanceyBeckwithThornlandsRoadService());
            cycles = nav.GetCycles();
            //foreach (var c in cycles) { Console.WriteLine(c.ToString()); }
            stitcher = new StitchingService(cycles, graph);
        }

        protected override void Do()
        {
            edges = stitcher.FindClosestEdgePair(cycles[0], cycles[1]);
        }

        [Observation]
        public void should_produce_a_result()
        {
            Assert.IsNotNull(edges);
            //Console.WriteLine(edges);
            Assert.IsTrue(edges.FirstCycleEdge.Vertices.Contains(PointMother.ChannelSt) && edges.FirstCycleEdge.Vertices.Contains(PointMother.DelanceySt));
            Assert.IsTrue(edges.SecondCycleEdge.Vertices.Contains(PointMother.ThornlandsRd) && edges.SecondCycleEdge.Vertices.Contains(PointMother.ThornlandsRd));
        }
    }


    [Concern("StitchingCycles")]
    public class when_stitching_cycles_for_cyclic_channel_thornlands_delancey_beckwith_channel : BaseSpec
    {
        private IStitchingService stitcher;
        private GraphNavigator nav;
        private Directions result;

        protected override void Given()
        {
            var graph = GraphMother.ChannelDelanceyThornlandsBeckwith;
            nav = new GraphNavigator(graph,
                PointMother.ChannelSt, PointMother.ChannelSt,
                new ChannelDelanceyBeckwithThornlandsRoadService());
            stitcher = new StitchingService(nav.GetCycles(), graph);
        }

        protected override void Do()
        {
            result = stitcher.Stitch();
        }

        [Observation]
        public void should_produce_a_result()
        {
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Routes.Count);

        }
    }
}

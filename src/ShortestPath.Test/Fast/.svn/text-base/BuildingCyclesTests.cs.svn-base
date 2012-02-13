using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ShortestPath.Core.Domain;
using ShortestPath.Test.Creators;
using SpecUnit;

namespace ShortestPath.Test.Fast
{

    [Concern("BuildingCycles")]
    public class when_building_cycles_for_cyclic_channel_thornlands_delancey_beckwith_channel : BaseSpec
    {
        private GraphNavigator nav;
        private IList<Directions> result;

        protected override void Given()
        {
            nav = new GraphNavigator(GraphMother.ChannelDelanceyThornlandsBeckwith, 
                PointMother.ChannelSt, PointMother.ChannelSt, 
                new ChannelDelanceyBeckwithThornlandsRoadService());
        }

        protected override void Do()
        {
            result = nav.GetCycles();
        }

        [Observation]
        public void should_generate_two_cycles()
        {
            Assert.AreEqual(2, result.Count);
        }

        [Observation]
        public void should_form_a_channel_delancey_beckwith_channel_cycle()
        {
            var cycle = result[0];
            Assert.AreEqual(3, cycle.Routes.Count);
            AssertRoute(cycle.Routes[0], PointMother.ChannelSt, PointMother.DelanceySt);
            AssertRoute(cycle.Routes[1], PointMother.DelanceySt, PointMother.BeckwithSt);
            AssertRoute(cycle.Routes[2], PointMother.BeckwithSt, PointMother.ChannelSt);
        }

        [Observation]
        public void should_form_a_thornlands_thornlands_cycle()
        {
            var cycle = result[1];
            Assert.AreEqual(1, cycle.Routes.Count);
            AssertRoute(cycle.Routes[0], PointMother.ThornlandsRd, PointMother.ThornlandsRd);
        }
    }

    [Concern("BuildingCycles")]
    public class when_building_cycles_for_non_cyclic_channel_delancey_beckwith_thornlands : BaseSpec
    {
        private GraphNavigator nav;
        private IList<Directions> result;

        protected override void Given()
        {
            nav = new GraphNavigator(GraphMother.ChannelDelanceyThornlandsBeckwith,
                PointMother.ChannelSt, PointMother.ThornlandsRd,
                new ChannelDelanceyBeckwithThornlandsRoadService());
        }

        protected override void Do()
        {
            result = nav.GetCycles();
        }

        [Observation]
        public void should_produce_two_cycles()
        {
            Assert.AreEqual(2, result.Count);
        }

        [Observation]
        public void should_form_a_channel_delancey_thornlands_cycle()
        {
            var cycle = result[0];
            Assert.AreEqual(2, cycle.Routes.Count);
            AssertRoute(cycle.Routes[0], PointMother.ChannelSt, PointMother.DelanceySt);
            AssertRoute(cycle.Routes[1], PointMother.DelanceySt, PointMother.ThornlandsRd);
        }

        [Observation]
        public void should_form_a_beckwith_beckwith_cycle()
        {
            var cycle = result[1];
            Assert.AreEqual(1, cycle.Routes.Count);
            AssertRoute(cycle.Routes[0], PointMother.BeckwithSt, PointMother.BeckwithSt);
        }
    }

    [Concern("BuildingCycles")]
    public class when_building_cycles_for_non_cyclic_channel_thornlands_beckwith_delancey : BaseSpec
    {
        private GraphNavigator nav;
        private IList<Directions> result;

        protected override void Given()
        {
            nav = new GraphNavigator(GraphMother.ChannelDelanceyThornlandsBeckwith,
                PointMother.ChannelSt, PointMother.DelanceySt,
                new ChannelDelanceyBeckwithThornlandsRoadService());
        }

        protected override void Do()
        {
            result = nav.GetCycles();
        }

        [Observation]
        public void should_produce_two_cycles()
        {
            Assert.AreEqual(2, result.Count);
        }

        [Observation]
        public void should_form_a_channel_delancy_cycle()
        {
            Assert.AreEqual(1, result[0].Routes.Count);
            AssertRoute(result[0].Routes[0], PointMother.ChannelSt, PointMother.DelanceySt);
        }

        [Observation]
        public void should_form_a_thornlands_beckwith_thornlands_route()
        {
            Assert.AreEqual(2, result[1].Routes.Count);
            AssertRoute(result[1].Routes[0], PointMother.ThornlandsRd, PointMother.BeckwithSt);
            AssertRoute(result[1].Routes[1], PointMother.BeckwithSt, PointMother.ThornlandsRd);
        }
    }

    [Concern("BuildingCycles")]
    public class when_building_cycles_for_non_cyclic_channel_thornlands_delancey_beckwith : BaseSpec
    {
        private GraphNavigator nav;
        private IList<Directions> result;

        protected override void Given()
        {
            nav = new GraphNavigator(GraphMother.ChannelDelanceyThornlandsBeckwith,
                PointMother.ChannelSt, PointMother.BeckwithSt,
                new ChannelDelanceyBeckwithThornlandsRoadService());
        }

        protected override void Do()
        {
            result = nav.GetCycles();
        }

        [Observation]
        public void should_produce_two_cycles()
        {
            Assert.AreEqual(2, result.Count);
        }

        [Observation]
        public void should_form_a_channel_delancey_beckwith_cycle()
        {
            Assert.AreEqual(2, result[0].Routes.Count);
            AssertRoute(result[0].Routes[0], PointMother.ChannelSt, PointMother.DelanceySt);
            AssertRoute(result[0].Routes[1], PointMother.DelanceySt, PointMother.BeckwithSt);
        }

        [Observation]
        public void should_form_a_thornlands_thornlands_cycle()
        {
            Assert.AreEqual(1, result[1].Routes.Count);
            AssertRoute(result[1].Routes[0], PointMother.ThornlandsRd, PointMother.ThornlandsRd);
        }
    }
}

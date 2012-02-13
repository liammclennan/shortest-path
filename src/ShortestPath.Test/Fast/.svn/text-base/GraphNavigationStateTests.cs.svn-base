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
    [Concern("GraphNavigationState")]
    public class when_starting_navigation_channel_ethel_burchell : BaseSpec
    {
        private GraphNavigationState state;

        protected override void Given()
        {
            var graph = new DirectedGraph(new[] { PointMother.ChannelSt, PointMother.BurchellSt, PointMother.EthelSt });
            state = new GraphNavigationState(graph, PointMother.ChannelSt, PointMother.BurchellSt);
        }

        protected override void Do()
        {}

        [Observation]
        public void current_should_be_null()
        {
            Assert.IsNull(state.Current);
        }

        [Observation]
        public void should_not_have_visited_anywhere()
        {
            Assert.IsTrue(state.Visited.Count == 0);
        }

        [Observation]
        public void channel_burchell_and_ethel_should_be_still_to_visit()
        {
            Assert.AreEqual(3, state.StillToVisit.Count());
            Assert.IsTrue(state.StillToVisit.Contains(PointMother.BurchellSt));
            Assert.IsTrue(state.StillToVisit.Contains(PointMother.EthelSt));
            Assert.IsTrue(state.StillToVisit.Contains(PointMother.ChannelSt));
        }

        [Observation]
        public void should_be_nowhere_not_to_visit()
        {
            Assert.IsTrue(state.NotToVisit.Count() == 0);
        }

        [Observation]
        public void should_be_start_of_graph()
        {
            Assert.IsTrue(state.AtStartOfGraph());
        }

        [Observation]
        public void should_not_be_cyclic_graph()
        {
            Assert.IsFalse(state.IsCyclicGraph());
        }

        [Observation]
        public void should_not_be_closed_cycle()
        {
            Assert.IsFalse(state.IsCycleClosed());
        }
    }

    [Concern("GraphNavigationState")]
    public class when_starting_navigation_channel_ethel_burchell_channel : BaseSpec
    {
        private GraphNavigationState state;

        protected override void Given()
        {
            var graph = new DirectedGraph(new[] { PointMother.ChannelSt, PointMother.BurchellSt, PointMother.EthelSt });
            state = new GraphNavigationState(graph, PointMother.ChannelSt, PointMother.ChannelSt);
        }

        protected override void Do()
        {}

        [Observation]
        public void current_should_be_null()
        {
            Assert.IsNull(state.Current);
        }

        [Observation]
        public void should_be_nowhere_visited()
        {
            Assert.IsTrue(state.Visited.Count() == 0);
        }

        [Observation]
        public void burchell_and_ethel_and_channel_should_be_still_to_visit()
        {
            Assert.AreEqual(3, state.StillToVisit.Count());
            Assert.IsTrue(state.StillToVisit.Contains(PointMother.BurchellSt));
            Assert.IsTrue(state.StillToVisit.Contains(PointMother.EthelSt));
            Assert.IsTrue(state.StillToVisit.Contains(PointMother.ChannelSt));
        }

        [Observation]
        public void not_to_visit_should_be_empty()
        {
            Assert.AreEqual(0, state.NotToVisit.Count());
        }

        [Observation]
        public void should_be_start_of_graph()
        {
            Assert.IsTrue(state.AtStartOfGraph());
        }

        [Observation]
        public void should_be_cyclic_graph()
        {
            Assert.IsTrue(state.IsCyclicGraph());
        }

        [Observation]
        public void should_not_be_closed_cycle()
        {
            Assert.IsFalse(state.IsCycleClosed());
        }
    }

    [Concern("GraphNavigationState")]
    public class after_first_cycle_channel_ethel_burchell : BaseSpec
    {
        private GraphNavigator nav;
        private Directions result;

        protected override void Given()
        {
            var graph = new DirectedGraph(new[] { PointMother.ChannelSt, PointMother.BurchellSt, PointMother.EthelSt });
            nav = new GraphNavigator(graph, PointMother.ChannelSt, PointMother.BurchellSt, new ChannelEthelBurchellRoadService());
        }

        protected override void Do()
        {
            result = nav.GetCycle();
        }

        [Observation]
        public void current_should_be_burchell_st()
        {
            Assert.AreEqual(PointMother.BurchellSt, nav.State.Current);
        }

        [Observation]
        public void visited_should_be_channel_burchell()
        {
            Assert.AreEqual(2, nav.State.Visited.Count());
            Assert.IsTrue(nav.State.Visited.Contains(PointMother.ChannelSt));
            Assert.IsTrue(nav.State.Visited.Contains(PointMother.BurchellSt));
        }

        [Observation]
        public void still_to_visit_should_be_ethel()
        {
            Assert.AreEqual(1, nav.State.StillToVisit.Count());
            Assert.IsTrue(nav.State.StillToVisit.Contains(PointMother.EthelSt));
        }

        [Observation]
        public void not_to_visit_should_be_channel_ethel_burchell()
        {
            Assert.AreEqual(2, nav.State.NotToVisit.Count());
            Assert.IsTrue(nav.State.NotToVisit.Contains(PointMother.ChannelSt));
            Assert.IsTrue(nav.State.NotToVisit.Contains(PointMother.BurchellSt));
        }

        [Observation]
        public void should_not_be_start_of_graph()
        {
            Assert.IsFalse(nav.State.AtStartOfGraph());
        }

        [Observation]
        public void should_have_two_routes()
        {
            Assert.AreEqual(1, result.Routes.Count);
        }

        [Observation]
        public void first_route_should_be_channel_burchell()
        {
            Assert.AreEqual(PointMother.ChannelSt, result.Routes[0].From);
            Assert.AreEqual(PointMother.BurchellSt, result.Routes[0].To);
        }

        [Observation]
        public void should_not_be_cyclic_graph()
        {
            Assert.IsFalse(nav.State.IsCyclicGraph());
        }

        [Observation]
        public void should_not_be_closed_cycle()
        {
            Assert.IsFalse(nav.State.IsCycleClosed());
        }
    }

    [Concern("GraphNavigationState")]
    public class after_first_cycle_channel_ethel_burchell_channel : BaseSpec
    {
        private GraphNavigator nav;
        private Directions result;

        protected override void Given()
        {
            var graph = new DirectedGraph(new[] { PointMother.ChannelSt, PointMother.BurchellSt, PointMother.EthelSt });
            nav = new GraphNavigator(graph, PointMother.ChannelSt, PointMother.ChannelSt, new ChannelEthelBurchellRoadService());
        }

        protected override void Do()
        {
            result = nav.GetCycle();
        }

        [Observation]
        public void current_should_be_channel_st()
        {
            Assert.AreEqual(PointMother.ChannelSt, nav.State.Current);
        }

        [Observation]
        public void visited_should_be_channel_ethel()
        {
            Assert.AreEqual(3, nav.State.Visited.Count());
            Assert.IsTrue(nav.State.Visited.Contains(PointMother.ChannelSt));
            Assert.IsTrue(nav.State.Visited.Contains(PointMother.EthelSt));
        }

        [Observation]
        public void should_not_have_visited_burchell()
        {
            Assert.IsFalse(nav.State.Visited.Contains(PointMother.BurchellSt));
            Assert.IsTrue(nav.State.StillToVisit.Contains(PointMother.BurchellSt));
        }

        [Observation]
        public void still_to_visit_should_be_empty()
        {
            Assert.AreEqual(1, nav.State.StillToVisit.Count());
            Assert.IsTrue(nav.State.StillToVisit.Contains(PointMother.BurchellSt));
        }

        [Observation]
        public void not_to_visit_should_be_channel_ethel()
        {
            Assert.AreEqual(2, nav.State.NotToVisit.Count());
            Assert.IsTrue(nav.State.NotToVisit.Contains(PointMother.ChannelSt));
            Assert.IsTrue(nav.State.NotToVisit.Contains(PointMother.EthelSt));
        }

        [Observation]
        public void should_not_be_start_of_graph()
        {
            Assert.IsFalse(nav.State.AtStartOfGraph());
        }

        [Observation]
        public void should_have_two_routes()
        {
            Assert.AreEqual(2, result.Routes.Count);
        }

        [Observation]
        public void first_route_should_be_channel_ethel()
        {
            Assert.AreEqual(PointMother.ChannelSt, result.Routes[0].From);
            Assert.AreEqual(PointMother.EthelSt, result.Routes[0].To);
        }

        [Observation]
        public void second_route_should_be_ethel_channel()
        {
            Assert.AreEqual(PointMother.EthelSt, result.Routes[1].From);
            Assert.AreEqual(PointMother.ChannelSt, result.Routes[1].To);
        }

    }

    [Concern("GraphNavigationState")]
    public class after_second_cycle_channel_ethel_burchell_channel : BaseSpec
    {
        private GraphNavigator nav;
        private Directions firstCycle;
        private Directions secondCycle;

        protected override void Given()
        {
            var graph = new DirectedGraph(new[] { PointMother.ChannelSt, PointMother.BurchellSt, PointMother.EthelSt });
            nav = new GraphNavigator(graph, PointMother.ChannelSt, PointMother.ChannelSt, new ChannelEthelBurchellRoadService());
        }

        protected override void Do()
        {
            firstCycle = nav.GetCycle();
            secondCycle = nav.GetCycle();
        }

        [Observation]
        public void current_should_be_burchell_st()
        {
            Assert.AreEqual(PointMother.BurchellSt, nav.State.Current);
        }

        [Observation]
        public void visited_should_be_channel_ethel_channel_burchell_burchell()
        {
            Assert.AreEqual(5, nav.State.Visited.Count());
            Assert.IsTrue(nav.State.Visited.Contains(PointMother.ChannelSt));
            Assert.IsTrue(nav.State.Visited.Contains(PointMother.EthelSt));
            Assert.IsTrue(nav.State.Visited.Contains(PointMother.BurchellSt));
        }

        [Observation]
        public void still_to_visit_should_be_empty()
        {
            Assert.AreEqual(0, nav.State.StillToVisit.Count());
        }

        [Observation]
        public void not_to_visit_should_be_channel_ethel_burchell()
        {
            Assert.AreEqual(3, nav.State.NotToVisit.Count());
            Assert.IsTrue(nav.State.NotToVisit.Contains(PointMother.ChannelSt));
            Assert.IsTrue(nav.State.NotToVisit.Contains(PointMother.EthelSt));
            Assert.IsTrue(nav.State.NotToVisit.Contains(PointMother.BurchellSt));
        }

        [Observation]
        public void should_not_be_start_of_graph()
        {
            Assert.IsFalse(nav.State.AtStartOfGraph());
        }

        [Observation]
        public void should_have_two_routes()
        {
            Assert.AreEqual(2, firstCycle.Routes.Count);
            Assert.AreEqual(1, secondCycle.Routes.Count);
        }

        [Observation]
        public void first_route_should_be_channel_ethel()
        {
            Assert.AreEqual(PointMother.ChannelSt, firstCycle.Routes[0].From);
            Assert.AreEqual(PointMother.EthelSt, firstCycle.Routes[0].To);
        }

        [Observation]
        public void second_route_should_be_ethel_channel()
        {
            Assert.AreEqual(PointMother.EthelSt, firstCycle.Routes[1].From);
            Assert.AreEqual(PointMother.ChannelSt, firstCycle.Routes[1].To);
        }

        [Observation]
        public void second_cycle_route_burchell_to_burchell()
        {
            Assert.AreEqual(PointMother.BurchellSt, secondCycle.Routes[0].From);
            Assert.AreEqual(PointMother.BurchellSt, secondCycle.Routes[0].To);
        }

    }

    // test non-cyclic graph where not all points are visited by the first cycle.

    
}

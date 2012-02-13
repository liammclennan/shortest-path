using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using ShortestPath.Core.Domain;
using ShortestPath.Core.Services;
using ShortestPath.Test.Creators;
using Moq;

namespace ShortestPath.Test.Slow
{
    [TestFixture]
    public class GraphNavigatorTests
    {
        private AutoMockContainer container;

        [SetUp]
        public void Setup()
        {
            container = new AutoMockContainer(new MockFactory(MockBehavior.Loose));
        }

        private IRouteTimeCacheService GetEmptyRouteCache()
        {
            var routeCache = new Mock<IRouteTimeCacheService>();
            routeCache.Expect(rc => rc.GetTime(It.IsAny<string>(), It.IsAny<string>())).Returns((long?)null);
            return routeCache.Object;
        }

        [Test]
        public void FindNearestPoint()
        {
            var graph = new DirectedGraph(new[] { PointMother.ChannelSt, PointMother.BurchellSt, PointMother.EthelSt });
            var nav = new GraphNavigator(graph, PointMother.ChannelSt, PointMother.ChannelSt, new RoadPathService(GetEmptyRouteCache(), new Mock<ILogService>().Object));

            var nearest = nav.FindNearestPoint(PointMother.ChannelSt);
            Assert.AreEqual(PointMother.EthelSt, nearest);
        }

        [Test]
        public void GetCycles_RealRoadService()
        {
            var graph = new DirectedGraph(new[] { PointMother.ChannelSt, PointMother.BurchellSt, PointMother.EthelSt });
            var nav = new GraphNavigator(graph, PointMother.ChannelSt, PointMother.ChannelSt, new RoadPathService(GetEmptyRouteCache(), new Mock<ILogService>().Object));

            var cycles = nav.GetCycles();
            Assert.AreEqual(2, cycles.Count);
            AssertChannelEthelChannelCycle(cycles[0]);
            AssertBurchellBurchellCycle(cycles[1]);
        }

        private void AssertChannelEthelChannelCycle(Directions cycle)
        {
            Assert.AreEqual(2, cycle.Routes.Count);
            Assert.AreEqual(PointMother.ChannelSt, cycle.Routes[0].From);
            Assert.AreEqual(PointMother.EthelSt, cycle.Routes[0].To);
            Assert.AreEqual(PointMother.EthelSt, cycle.Routes[1].From);
            Assert.AreEqual(PointMother.ChannelSt, cycle.Routes[1].To);
        }

        [Test]
        public void GetCycles_FakeRoadService()
        {
            var graph = new DirectedGraph(new[] { PointMother.ChannelSt, PointMother.BurchellSt, PointMother.EthelSt });
            var nav = new GraphNavigator(graph, PointMother.ChannelSt, PointMother.ChannelSt, new ChannelEthelBurchellRoadService());

            var cycles = nav.GetCycles();
            Assert.AreEqual(2, cycles.Count);
            AssertChannelChannelCycle(cycles[0]);
            AssertBurchellBurchellCycle(cycles[1]);
        }

        private void AssertBurchellBurchellCycle(Directions cycle)
        {
            Assert.AreEqual(1, cycle.Routes.Count);
            Assert.AreEqual(PointMother.BurchellSt, cycle.Routes[0].From);
            Assert.AreEqual(PointMother.BurchellSt, cycle.Routes[0].To);
        }

        private void AssertChannelChannelCycle(Directions cycle)
        {
            Assert.AreEqual(2, cycle.Routes.Count);
            Assert.AreEqual(PointMother.ChannelSt, cycle.Routes[0].From);
            Assert.AreEqual(PointMother.EthelSt, cycle.Routes[0].To);
            Assert.AreEqual(PointMother.EthelSt, cycle.Routes[1].From);
            Assert.AreEqual(PointMother.ChannelSt, cycle.Routes[1].To);
        }

        [Test]
        public void GetCycles_FakeRoadService_NonCyclic()
        {
            var graph = new DirectedGraph(new[] { PointMother.ChannelSt, PointMother.BurchellSt, PointMother.EthelSt });
            var nav = new GraphNavigator(graph, PointMother.ChannelSt, PointMother.BurchellSt, new ChannelEthelBurchellRoadService());

            var cycles = nav.GetCycles();
            Assert.AreEqual(2, cycles.Count);
            Assert.AreEqual(1, cycles[0].Routes.Count);

            Assert.AreEqual(PointMother.ChannelSt, cycles[0].Routes[0].From);
            Assert.AreEqual(PointMother.BurchellSt, cycles[0].Routes[0].To);
            Assert.AreEqual(PointMother.EthelSt, cycles[1].Routes[0].From);
            Assert.AreEqual(PointMother.EthelSt, cycles[1].Routes[0].To);
        }
    }
}

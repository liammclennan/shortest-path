using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ShortestPath.Core.Domain;
using ShortestPath.Core.Services;
using ShortestPath.Test.Creators;
using Moq;

namespace ShortestPath.Test.Slow
{
    [TestFixture]
    public class RoadPathServiceTests
    {
        [Test]
        public void GetRoadDistance_channelst_burchellst()
        {
            var routeCache = new Mock<IRouteTimeCacheService>();
            routeCache.Expect(rc => rc.GetTime(PointMother.ChannelSt.address, PointMother.BurchellSt.address)).Returns((long?)null);

            var logService = new Mock<ILogService>();
            //logService.Expect(ls => ls.Write(ShortestPath.Core.Domain.Persisted.Log.LogType.ROAD_TIME_QUERY, It.IsAny<string>()));

            var service = new RoadPathService(routeCache.Object, logService.Object);
            var result = service.GetRoadTime(new[] { PointMother.ChannelSt, PointMother.BurchellSt });
            var minutes = result/60;
            Assert.IsTrue(20<minutes && minutes<60);
        }

        [Test]
        public void GetRoadDistance_channelst_burchellst_cache()
        {
            var channel = new Point
            {
                address = "38 Channel St, Cleveland qld, 4158",
                lat = -27.530071,
                lon = 153.276939
            };
            var routeCache = new Mock<IRouteTimeCacheService>();
            routeCache.Expect(rc => rc.GetTime(PointMother.EthelSt.address, channel.address)).Returns((long?)null).Verifiable();
            var logService = new Mock<ILogService>();
            var service = new RoadPathService(routeCache.Object, logService.Object);
            var result = service.GetRoadTime(new[] { PointMother.EthelSt, channel });
            var minutes = result / 60;
            Assert.IsTrue(20 < minutes && minutes < 60);
            routeCache.Verify();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ShortestPath.Core.Domain;
using ShortestPath.Core.Services;
using ShortestPath.Test.Creators;
using SpecUnit;

namespace ShortestPath.Test.Slow
{
    [Concern("RouteOptimization")]
    public class when_optimizing_a_one_point_directions : BaseSpec
    {
        private Point[] points;
        private DirectionsService service;
        private Directions result;
        private bool dBCExceptionThrown = false;

        protected override void Given()
        {
            points = new Point[] { PointMother.ChannelSt };
            service = container.Create<DirectionsService>();
        }

        protected override void Do()
        {
            try
            {
                result = service.Optimize(points);
            }
            catch (DBCException)
            {
                dBCExceptionThrown = true;
            }
        }

        [Observation]
        public void should_throw_a_DBCException()
        {
            Assert.IsTrue(dBCExceptionThrown);
        }
    }

    [Concern("RouteOptimization")]
    public class when_optimizing_a_one_route_directions : BaseSpec
    {
        private Point[] points;
        private DirectionsService service;
        private Directions result;

        protected override void Given()
        {
            points = new Point[] { PointMother.ChannelSt, PointMother.EthelSt };
            service = container.Create<DirectionsService>();
        }

        protected override void Do()
        {
            result = service.Optimize(points);
        }

        [Observation]
        public void should_return_one_route()
        {
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Routes.Count);
        }
    }

    [Concern("RouteOptimization")]
    public class when_optimizing_a_two_route_directions : BaseSpec
    {
        private Point[] points;
        private DirectionsService service;
        private Directions result;

        protected override void Given()
        {
            points = new Point[] { PointMother.ChannelSt, PointMother.EthelSt, PointMother.BurchellSt };
            service = container.Create<DirectionsService>();
        }

        protected override void Do()
        {
            result = service.Optimize(points);
        }

        [Observation, Ignore]
        public void should_return_directions()
        {
            Assert.IsNotNull(result);
        }

        [Observation]
        public void should_return_two_routes()
        {
            
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShortestPath.Core.Services;
using ShortestPath.Core.Domain;
using ShortestPath.Test.Creators;
using SpecUnit;
using NUnit.Framework;
using Moq;

namespace ShortestPath.Test.Fast
{
    [Concern("find shortest path USA")]
    public class when_finding_path_for_5_point_cycle_des_moines : BaseSpec
    {
        IDirectionsService service;
        Point[] points = new[] { PointMother.USAPoints.LocustSt, PointMother.USAPoints.AshworthRd, PointMother.USAPoints.UniversityAve, PointMother.USAPoints.RaccoonSt, PointMother.USAPoints.ShawSt, PointMother.USAPoints.LocustSt };
        Directions result;

        protected override void Given()
        {
            service = container.Create<DirectionsService>();
            container.Register<IRoadPathService>(new DesMoinesRoadService());
        }

        protected override void Do()
        {
            result = service.Optimize(points);
        }

        [Observation]
        public void should_return_a_5_route_directions()
        {
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Routes.Count);
        }
    }

    public class when_finding_path_for_5_point_line_des_moines : BaseSpec
    {
        protected override void Given()
        {
            throw new NotImplementedException();
        }

        protected override void Do()
        {
            throw new NotImplementedException();
        }
    }

    [Concern("Ordering routes")]
    public class when_ordering_a_directions : BaseSpec
    {
        private Directions directions;

        protected override void Given()
        {
            directions = new Directions();
            directions.AddRoute(PointMother.USAPoints.UniversityAve, PointMother.USAPoints.LocustSt);
            directions.AddRoute(PointMother.USAPoints.LocustSt, PointMother.USAPoints.ShawSt);
            directions.AddRoute(PointMother.USAPoints.RaccoonSt, PointMother.USAPoints.UniversityAve);
            directions.AddRoute(PointMother.USAPoints.AshworthRd, PointMother.USAPoints.ShawSt);
            directions.AddRoute(PointMother.USAPoints.RaccoonSt, PointMother.USAPoints.AshworthRd);
        }

        protected override void Do()
        {
            directions.Order(PointMother.USAPoints.LocustSt, PointMother.USAPoints.LocustSt);
        }

        [Observation]
        public void first_route_should_be_locust_to_university()
        {
            var route = directions.Routes[0];
            Assert.AreEqual(PointMother.USAPoints.LocustSt, route.From);
            Assert.AreEqual(PointMother.USAPoints.ShawSt, route.To);
        }

    }
}

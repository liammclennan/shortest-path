using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShortestPath.Core.Domain;
using ShortestPath.Core.Services;

namespace ShortestPath.Test.Creators
{
    public class DesMoinesRoadService : IRoadPathService
    {
        public long GetRoadTime(Point[] points)
        {
            DBC.Assert(points.Length == 2, "Can only get the distance between 2 points.");

            if (points.Contains(PointMother.USAPoints.LocustSt) && points.Contains(PointMother.USAPoints.AshworthRd))
                return 660;

            if (points.Contains(PointMother.USAPoints.LocustSt) && points.Contains(PointMother.USAPoints.UniversityAve))
                return 180;

            if (points.Contains(PointMother.USAPoints.LocustSt) && points.Contains(PointMother.USAPoints.RaccoonSt))
                return 480;

            if (points.Contains(PointMother.USAPoints.LocustSt) && points.Contains(PointMother.USAPoints.ShawSt))
                return 360;

            if (points.Contains(PointMother.USAPoints.AshworthRd) && points.Contains(PointMother.USAPoints.UniversityAve))
                return 600;

            if (points.Contains(PointMother.USAPoints.AshworthRd) && points.Contains(PointMother.USAPoints.RaccoonSt))
                return 840;

            if (points.Contains(PointMother.USAPoints.AshworthRd) && points.Contains(PointMother.USAPoints.ShawSt))
                return 780;

            if (points.Contains(PointMother.USAPoints.UniversityAve) && points.Contains(PointMother.USAPoints.RaccoonSt))
                return 480;

            if (points.Contains(PointMother.USAPoints.UniversityAve) && points.Contains(PointMother.USAPoints.ShawSt))
                return 420;

            if (points.Contains(PointMother.USAPoints.RaccoonSt) && points.Contains(PointMother.USAPoints.ShawSt))
                return 120;

            throw new Exception("Unknown points");
        }
    }
}

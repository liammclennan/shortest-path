using System;
using System.Linq;
using ShortestPath.Core.Domain;
using ShortestPath.Core.Services;

namespace ShortestPath.Test.Creators
{
    public class ChannelDelanceyBeckwithThornlandsRoadService : IRoadPathService
    {
        public long GetRoadTime(Point[] points)
        {
            DBC.Assert(points.Length == 2, "Can only get the distance between 2 points.");

            if (points.Contains(PointMother.ChannelSt) && points.Contains(PointMother.DelanceySt))
                return 480;

            if (points.Contains(PointMother.ChannelSt) && points.Contains(PointMother.BeckwithSt))
                return 660;

            if (points.Contains(PointMother.ChannelSt) && points.Contains(PointMother.ThornlandsRd))
                return 600;

            if (points.Contains(PointMother.BeckwithSt) && points.Contains(PointMother.DelanceySt))
                return 300;

            if (points.Contains(PointMother.BeckwithSt) && points.Contains(PointMother.ThornlandsRd))
                return 1020;

            if (points.Contains(PointMother.DelanceySt) && points.Contains(PointMother.ThornlandsRd))
                return 820;
            
            throw new Exception("Unknown points");
        }
    }
}
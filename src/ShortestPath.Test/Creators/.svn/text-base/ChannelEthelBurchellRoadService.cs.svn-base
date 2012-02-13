using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShortestPath.Core.Domain;
using ShortestPath.Core.Services;

namespace ShortestPath.Test.Creators
{
    public class ChannelEthelBurchellRoadService : IRoadPathService 
    {
        public long GetRoadTime(Point[] points)
        {
            DBC.Assert(points.Length == 2, "Can only get the distance between 2 points.");

            if (points.Contains(PointMother.ChannelSt) && points.Contains(PointMother.EthelSt))
                return 840;

            if (points.Contains(PointMother.EthelSt) && points.Contains(PointMother.BurchellSt))
                return 1800;

            if (points.Contains(PointMother.ChannelSt) && points.Contains(PointMother.BurchellSt))
                return 2280;

            throw new Exception("Unknown points");
        }
    }
}

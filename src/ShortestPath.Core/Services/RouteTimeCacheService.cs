using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShortestPath.Core.Domain;
using ShortestPath.Core.Domain.Persisted;
using ShortestPath.Core.Domain.DB;
using ShortestPath.Core.Domain.DB.Queries.RouteTime;

namespace ShortestPath.Core.Services
{
    public interface IRouteTimeCacheService
    {
        long? GetTime(string start, string finish);
        void Add(Point[] points, long seconds);
    }

    public class RouteTimeCacheService : IRouteTimeCacheService
    {
        IRepository repository;

        public RouteTimeCacheService(IRepository repository)
        {
            this.repository = repository;
        }

        public long? GetTime(string start, string finish)
        {
            var times = repository.First(new RouteTimeQuery(start, finish));
            if (times == null) return null;

            return times.Seconds;
        }

        public void Add(Point[] points, long seconds)
        {
            DBC.Assert(points.Length == 2, "Calculating road time requires exactly 2 points. " + points.Length + " were provided.");
            var routeTime = new RouteTime { Start = points[0].address, Finish = points[1].address, Seconds = seconds };
            repository.MakePersistent(routeTime);
        }

    }
}

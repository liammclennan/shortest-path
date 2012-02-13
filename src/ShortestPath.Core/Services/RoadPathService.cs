using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShortestPath.Core.Bing.RouteService;
using ShortestPath.Core.Bing.TokenService;
using ShortestPath.Core.Domain;

namespace ShortestPath.Core.Services
{
    public interface IRoadPathService
    {
        long GetRoadTime(Point[] points);
    }

    public class RoadPathService : IRoadPathService
    {
        IRouteTimeCacheService routeCache;
        ILogService logService;

        public RoadPathService(IRouteTimeCacheService routeCache, ILogService logService)
        {
            this.routeCache = routeCache;
            this.logService = logService;
        }

        private string tokenCache;

        public long GetRoadTime(Point[] points)
        {
            DBC.Assert(points.Length == 2, "Calculating road time requires exactly 2 points. " + points.Length + " were provided.");

            var cacheResult = routeCache.GetTime(points[0].address, points[1].address);
            if (cacheResult != null)
            {
                Log(points, true);
                return cacheResult.Value;
            }
            Log(points, false);

            var router = new RouteServiceClient();
            var request = new RouteRequest();
            request.Credentials = new Credentials();
            request.Credentials.Token = GetToken();
            request.Waypoints = new Waypoint[points.Length];

            for (int i = 0; i < points.Length; i++)
            {
                var p = points[i];
                var waypoint = new Waypoint();
                waypoint.Description = p.address;
                waypoint.Location = new Location();
                waypoint.Location.Latitude = p.lat;
                waypoint.Location.Longitude = p.lon;
                request.Waypoints[i] = waypoint;
            }

            RouteResponse response = router.CalculateRoute(request);
            var seconds = response.Result.Summary.TimeInSeconds;
            routeCache.Add(points, seconds);

            return seconds;
        }

        private void Log(Point[] points, bool cacheHit)
        {
            var template =
            @"Road Time Request
Cache: 
{0}

Points:
{1}
";
            var data = string.Format(template, cacheHit ? "hit" : "miss", string.Join("\n", points.Select(p => p.ToString()).ToArray()));
            logService.Write(ShortestPath.Core.Domain.Persisted.Log.LogType.ROAD_TIME_QUERY, data); 
        }

        private string GetToken()
        {
            if (tokenCache == null)
            {
                // Set Bing Maps Developer Account credentials to access the Token Service
                CommonService commonService = new CommonService();
                commonService.Credentials = new System.Net.NetworkCredential("143600", "R&]0yHu>");

                // Set the token specification properties
                TokenSpecification tokenSpec = new TokenSpecification();
                tokenSpec.ClientIPAddress = "60.226.1.13";
                tokenSpec.TokenValidityDurationMinutes = 60;

                tokenCache = commonService.GetClientToken(tokenSpec);
            }

            return tokenCache;
        }

    }
}

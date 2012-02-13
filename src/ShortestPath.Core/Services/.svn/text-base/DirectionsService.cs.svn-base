using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShortestPath.Core.Domain;
using ShortestPath.Core.Domain.Persisted;
using ShortestPath.Web.Domain;

namespace ShortestPath.Core.Services
{
    public interface IDirectionsService
    {
        Directions Optimize(Point[] points);
    }

    public class DirectionsService : IDirectionsService
    {
        private readonly IRoadPathService roadPathService;
        private IStitchingService stitchingService;
        private ILogService logService;

        public DirectionsService(IRoadPathService roadPathService, ILogService logService)
        {
            this.roadPathService = roadPathService;
            this.logService = logService;
        }

        public Directions Optimize(Point[] points)
        {
            DBC.Assert(points.Length > 1, "Unable to optimize a route with less than 2 points.");

            Log(points);

            if (IsSingleRouteDirections(points)) return BuildSingleRouteDirections(points);

            var graph = new DirectedGraph(points);
            var graphNavigator = new GraphNavigator(graph, points.First(), points.Last(), roadPathService);
            IList<Directions> cycles = graphNavigator.GetCycles();
            stitchingService = new StitchingService(cycles, graph);
            var stitched = stitchingService.Stitch();
            stitched.Order(points.First(), points.Last());
            return stitched;
        }

        private void Log(Point[] points)
        {
            var template = 
@"Shortest Path Request

Points:
{0}
";
            var data = string.Format(template,  string.Join("\n", points.Select(p => p.ToString()).ToArray()));
            logService.Write(ShortestPath.Core.Domain.Persisted.Log.LogType.SEARCH, data);
        }

        private static bool IsSingleRouteDirections(Point[] points)
        {
            return points.Length == 2;
        }

        private static Directions BuildSingleRouteDirections(Point[] points)
        {
            var directions = new Directions();
            directions.Routes.Add(new Route(points[0], points[1]));
            return directions;
        }
    }

    
}

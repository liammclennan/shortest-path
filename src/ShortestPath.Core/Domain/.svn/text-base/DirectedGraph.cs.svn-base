using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShortestPath.Core.Services;

namespace ShortestPath.Core.Domain
{
    /// <summary>
    /// Graph of every point connected to every other with associated distance weights.
    /// </summary>
    public class DirectedGraph
    {
        public List<Point> Vertices { get; set; }
        public List<Edge> Edges { get; set; }
        private readonly GeographyService geographyService;

        public DirectedGraph()
        {
            Vertices = new List<Point>();
            Edges =  new List<Edge>();
            geographyService = new GeographyService();
        }

        public DirectedGraph(Point[] points) : this()
        {
            Vertices = points.ToList();
            BuildEdges();
        }

        private void BuildEdges()
        {
            foreach (Point point in Vertices)
            {
                BuildEdgesForVertex(point);
            }
        }

        private void BuildEdgesForVertex(Point point)
        {
            var otherVertices = NotYetJoinedTo(point);

            foreach (Point vertex in otherVertices)
            {
                Edges.Add(new Edge(new[] { point, vertex }, geographyService.DistanceBetweenTwoPoints(point, vertex), Edge.INFINITE_COST));                
            }
        }

        /// <summary>Returns all of the vertices that are not yet joined by an edge to point.</summary>
        public IEnumerable<Point> NotYetJoinedTo(Point point)
        {
            return Vertices.Where(v => !v.Equals(point)).Where(v => !AreJoinedByAnEdge(point, v));
        }

        public bool AreJoinedByAnEdge(Point one, Point two)
        {
            return Edges.Any(e => e.Vertices.Contains(one) && e.Vertices.Contains(two));
        }

        public Edge GetEdge(Point[] vertices)
        {
            DBC.Assert(vertices.Length == 2, "Cannot bind the path between more or less than two vertices.");
            return Edges.FirstOrDefault(e => e.Vertices.Contains(vertices[0]) && e.Vertices.Contains(vertices[1]));
        }

        public Edge GetEdge(Route route)
        {
            return GetEdge(new[] {route.From, route.To});
        }

        /// <summary>
        /// Within this graph find the points that are within 150% of the geodesic distance between point and its nearest point.
        /// </summary>
        public IEnumerable<Point> FindNearestPoints(Point point, IEnumerable<Point> notToVisit)
        {
            var nearestPoint = FindNearestPoint(point, notToVisit);
            return FindPointsWithin(point, GetEdge(new[] { point, nearestPoint }).DistanceCost * 1.5, notToVisit);
        }
        
        /// <summary>
        /// Find the geodesically nearest point.
        /// </summary>
        public Point FindNearestPoint(Point point, IEnumerable<Point> notToVisit)
        {
            var visitable = Vertices.Except(notToVisit.Union(Enumerable.Repeat(point,1)));
            IEnumerable<Edge> edges = visitable.SelectMany(p => Edges.Where(e => e.Vertices.Contains(p) && e.Vertices.Contains(point)));
            var shortestEdge = edges.First(e => e.DistanceCost == edges.Min(edge => edge.DistanceCost));
            return shortestEdge.Vertices.Single(p => !p.Equals(point));
        }

        private IEnumerable<Point> FindPointsWithin(Point point, double radius, IEnumerable<Point> notToVisit)
        {
            var visitable = Vertices.Except(notToVisit.Union(Enumerable.Repeat(point, 1)));
            IEnumerable<Edge> edges = visitable.SelectMany(p => Edges.Where(e => e.Vertices.Contains(p) && e.Vertices.Contains(point)));
            var shortEdges = edges.Where(e => e.DistanceCost < radius);
            return shortEdges.Select(e => e.Vertices.Single(v => !v.Equals(point)));
        }

        public Point FindNearestPointByRoadTime(Point point, IEnumerable<Point> notToVisit)
        {
            var visitable = Vertices.Except(notToVisit.Union(Enumerable.Repeat(point, 1)));
            IEnumerable<Edge> edges = visitable.SelectMany(p => Edges.Where(e => e.Vertices.Contains(p) && e.Vertices.Contains(point)));
            var shortestEdge = edges.First(e => e.TimeCost == edges.Min(edge => edge.TimeCost));
            return shortestEdge.Vertices.Single(p => !p.Equals(point));
        }

        public Point FindSecondNearestPointByRoadTime(Point point, IEnumerable<Point> notToVisit)
        {
            var visitable = Vertices.Except(notToVisit.Union(Enumerable.Repeat(point, 1)));
            IEnumerable<Edge> edges = visitable.SelectMany(p => Edges.Where(e => e.Vertices.Contains(p) && e.Vertices.Contains(point))).OrderByDescending(e => e.TimeCost);
            var secondShortestEdge = edges.Skip(1).Take(1).First();
            return secondShortestEdge.Vertices.Single(p => !p.Equals(point));
        }

        public void SetTimeCostForEdge(Point[] points, double time)
        {
            GetEdge(points).TimeCost = time;
        }

        public double DistanceBetweenTwoEdges(Edge a, Edge b)
        {
            Point a1 = a.Vertices[0];
            Point b1 = b.Vertices[0];
            Point a2 = a.Vertices[1];
            Point b2 = b.Vertices[1];

            Edge a1b1 = GetEdge(new [] {a1, b1});
            Edge a2b2 = GetEdge(new[] { a2, b2 });
            Edge a1b2 = GetEdge(new[] { a1, b2 });
            Edge a2b1 = GetEdge(new[] { a2, b1 });

            if (a1b1.DistanceCost + a2b2.DistanceCost
                < a1b2.DistanceCost + a2b1.DistanceCost)
            {
                return (a1b1.DistanceCost + a2b2.DistanceCost) / 2;
            }
            else
            {
                return (a1b2.DistanceCost + a2b1.DistanceCost) / 2;
            }
        }

        public Point PickClosestPoint(Point start, Point[] candidates)
        {
            Point closestPoint = candidates[0];
            var shortestDistance = geographyService.DistanceBetweenTwoPoints(start, closestPoint);
            foreach (Point p in candidates)
            {
                var distance = geographyService.DistanceBetweenTwoPoints(start, p);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    closestPoint = p;
                }
            }
            return closestPoint;
        }
    }
}

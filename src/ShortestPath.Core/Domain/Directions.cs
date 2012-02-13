using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShortestPath.Core.Domain
{
    public class Directions
    {
        public IList<Route> Routes { get; private set; }

        public IEnumerable<Edge> Edges(DirectedGraph graph)
        {
            return Routes.Select(r => 
                {
                    return (r.From.Equals(r.To)) 
                        ? new Edge(new[] { r.From, r.To }, 0, 0)
                        : graph.GetEdge(r); 
                });
        }

        public Route GetRoute(Edge edge)
        {
            return Routes.First(r => edge.Vertices.Contains(r.From) && edge.Vertices.Contains(r.To));
        }

        public Directions()
        {
            Routes = new List<Route>();
        }

        public void AddRoute(Point from, Point to)
        {
            Routes.Add(new Route(from, to));
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (Route r in Routes)
            {
                builder.Append(r.ToString());
                builder.Append(" | ");
            }
            return builder.ToString();
        }

        public void Merge(Directions otherDirections)
        {
            foreach (var r in otherDirections.Routes)
            {
                Routes.Add(r);
            }
        }

        public void RemoveRoute(Route toRemove)
        {
            Routes = Routes.Where(r => !(r.From.Equals(toRemove.From) && r.To.Equals(toRemove.To))).ToList();
        }

        /// <summary>Rearrange routes so that the Routes[0].From == from and Routes[max].To == To and each consecutive To equals the next From.</summary>
        public void Order(Point from, Point to)
        {
            var firstRoute = FindFirstRoute(from);
            if (!Routes[0].Equals(firstRoute))
            {
                SwapRoutes(Routes[0], firstRoute);
            }

            if (!Routes[0].From.Equals(from))
            {
                Routes[0].SwapPoints();
            }

            for (var index = 1; index < Routes.Count; index++)
            {
                ProcessNextRoute(index);
            }

        }

        private void ProcessNextRoute(int index)
        {
            var route = Routes[index];
            var lastPoint = Routes[index - 1].To;
            var lastRoute = Routes[index - 1];
            var nextRoute = Routes.Single(r => r.Points.Contains(lastPoint) && !r.Equals(lastRoute));
            if (!route.Equals(nextRoute)) SwapRoutes(route, nextRoute);
            if (!Routes[index].From.Equals(lastPoint))
            {
                Routes[index].SwapPoints();
            }
        }

        private void SwapRoutes(Route first, Route second)
        {
            int indexOfFirst = Routes.IndexOf(first);
            int indexOfSecond = Routes.IndexOf(second);

            Routes[indexOfFirst] = second;
            Routes[indexOfSecond] = first;
        }

        private Route FindFirstRoute(Point from)
        {
            if (Routes[0].From.Equals(from)) return Routes[0];

            Func<Route,bool> routeStartingWith = r => r.From.Equals(from);
            if (Routes.Any(routeStartingWith)) return Routes.First(routeStartingWith);

            Func<Route,bool> routeIncluding = r => r.From.Equals(from) || r.To.Equals(from);
            if (Routes.Any(routeIncluding)) return Routes.First(routeIncluding);

            throw new ArgumentException(from + " is not a part of this directions.");
        }
    }

    public class Route
    {
        private int HASH_MULTIPLIER = 410;

        public Route(Point from, Point to)
        {
            From = from;
            To = to;
        }

        public Point From { get; set; }
        public Point To { get; set; }

        public IEnumerable<Point> Points
        {
            get { return new List<Point> {From, To}; }
        }

        public override string ToString()
        {
            return From.ToString() + " -> " + To.ToString();
        }

        public virtual bool Equals(Route other)
        {
            return From.Equals(other.From)
                   && To.Equals(other.To);
        }

        public override bool Equals(object obj)
        {
            return Equals((Route)obj);
        }

        public override int GetHashCode()
        {
            return From.GetHashCode() + To.GetHashCode() * HASH_MULTIPLIER ^ ToString().GetHashCode();
        }

        public void SwapPoints()
        {
            var temp = From;
            From = To;
            To = temp;
        }

    }
}

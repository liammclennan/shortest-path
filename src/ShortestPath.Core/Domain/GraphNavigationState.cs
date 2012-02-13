using System;
using System.Collections.Generic;
using System.Linq;
using ShortestPath.Core.Services;

namespace ShortestPath.Core.Domain
{
    /// <summary>
    /// Represents the current state of navigating a graph
    /// </summary>
    public class GraphNavigationState
    {
        public Point Start { get; private set;}
        public Point End { get; private set;}
        public Point Current { get; set; }
        public DirectedGraph Graph { get; private set; }
        public IList<Point> Visited { get; private set; }
        public IList<Directions> CompleteCycles = new List<Directions>();
        public Directions CurrentCycle = new Directions();
        
        public GraphNavigationState(DirectedGraph graph, Point start, Point end)
        {
            Graph = graph;
            Start = start;
            End = end;
            Visited = new List<Point>();
        }

        /// <summary>
        /// All - Visited accounting for the possibility that start and end may be the same and therefore visited twice.
        /// </summary>
        public IEnumerable<Point> StillToVisit
        {
            get
            {
                var notVisited = Graph.Vertices.Except(Visited);

                if (IsCyclicGraph() && !IsCycleClosed())
                {
                    notVisited = notVisited.Union(Enumerable.Repeat(Start, 1));
                }
                return notVisited;
            }
        }

        public IEnumerable<Point> NotToVisit
        {
            get
            {
                var notToVisit = Graph.Vertices.Except(StillToVisit);
                return notToVisit;
            }
        }

        public bool IsCycleClosed()
        {
            return Visited.Where(p => p.Equals(Start)).Count() == 2;
        }

        public bool IsCyclicGraph()
        {
            return Start.Equals(End);
        }

        public void Advance(Point next)
        {
            CurrentCycle.AddRoute(Current, next);
            Current = next;
            Visited.Add(next);
        }

        public Directions CompleteCycle()
        {
            var temp = CurrentCycle;
            CompleteCycles.Add(CurrentCycle);
            CurrentCycle = new Directions();
            return temp;
        }

        public bool AtStartOfGraph()
        {
            return Visited.Count() == 0;
        }

        public bool AllPointsHaveBeenVisited()
        {
            return StillToVisit.Count() == 0;
        }

    }
}
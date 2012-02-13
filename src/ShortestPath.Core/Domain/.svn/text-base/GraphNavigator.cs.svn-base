using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShortestPath.Core.Services;

namespace ShortestPath.Core.Domain
{
    /// <summary>
    /// Extracts cycles from a DirectedGraph.
    /// </summary>
    public class GraphNavigator
    {
        public GraphNavigationState State { get; private set; }
        private readonly IRoadPathService roadPathService;

        public GraphNavigator(DirectedGraph graph, Point start, Point end, IRoadPathService roadPathService)
        {
            State = new GraphNavigationState(graph, start, end);
            this.roadPathService = roadPathService;
        }

        /// <summary>
        /// Returns a complete set of cycles for the graph (ie. all points visited).
        /// </summary>
        /// <returns></returns>
        public IList<Directions> GetCycles()
        {
            Directions cycle;
            var result = new List<Directions>();

            do
            {
                cycle = GetCycle();
                if (cycle != null) result.Add(cycle);
            } while (cycle != null);

            return result;
        }

        /// <summary>
        /// Returns a cycle. The first time it is called it will return a cycle from start -> end. 
        /// When no more cycles exist it will return null.
        /// </summary>
        public Directions GetCycle()
        {
            if (State.AtStartOfGraph()) return FindCycle(State.Start, State.End);
            if (State.AllPointsHaveBeenVisited()) return null;
            return FindCycle(State.StillToVisit.First(), State.StillToVisit.First()); 
        }

        private Directions FindCycle(Point from, Point to)
        {
            if (State.AllPointsHaveBeenVisited()) return null;
            State.Current = from;
            State.Visited.Add(from);

            MoveToNearestPoint(from, to);

            while (!State.Current.Equals(to))
            {
                MoveToNearestPoint(from, to);
            }
            return State.CompleteCycle();
        }

        private bool IsFirstCycle(Point from, Point to)
        {
            return from.Equals(State.Start) && to.Equals(State.End);
        }

        /// <summary>
        /// Advances the current pointer to the nearest point that has not been visited, 
        /// unless the nearest point is both the start and the end.
        /// </summary>
        private void MoveToNearestPoint(Point from, Point to)
        {
            // Ensure that there is always more than one cycle when there are more than two points.
            if (IsFirstCycle(from, to) && State.StillToVisit.Count() == 2)
            {
                MoveToEnd();
                return;
            }

            if (State.AllPointsHaveBeenVisited())
            {
                if (to.Equals(State.Current)) 
                    State.Advance(State.Current);
                else
                    State.Advance(to);
                return;
            }
                
            State.Advance(FindNearestPoint(State.Current));            
        }

        /// <summary>
        /// Go directly to the end point.
        /// </summary>
        private void MoveToEnd()
        {
            State.Advance(State.End);
        }

        public Point FindNearestPoint(Point point)
        {
            var nearestGeodesically = State.Graph.FindNearestPoints(point, State.NotToVisit);

            foreach (var p in nearestGeodesically)
            {
                var points = new[] { point, p };
                State.Graph.SetTimeCostForEdge(points, roadPathService.GetRoadTime(points));
            }
            return State.Graph.FindNearestPointByRoadTime(point, State.NotToVisit);
        }

    }
}

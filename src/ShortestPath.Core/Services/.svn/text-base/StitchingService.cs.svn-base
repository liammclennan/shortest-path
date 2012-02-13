using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShortestPath.Core.Domain;

namespace ShortestPath.Core.Services
{
    public interface IStitchingService
    {
        Directions Stitch();
        EdgePair FindClosestEdgePair(Directions firstCycle, Directions secondCycle);
    }

    public class StitchingService : IStitchingService
    {
        private IList<Directions> cycles;
        private readonly DirectedGraph graph;

        public StitchingService(IList<Directions> cycles, DirectedGraph graph)
        {
            this.cycles = cycles;
            this.graph = graph;
        }

        public Directions Stitch()
        {
            while (cycles.Count > 1)
            {
                StitchFirstTwoCycles();
            }
            var stitched = cycles.Single();
            return stitched;
        }

        private void StitchFirstTwoCycles()
        {
            var firstCycle = cycles[0];
            var secondCycle = cycles[1];

            EdgePair edges = FindClosestEdgePair(firstCycle, secondCycle);

            Directions joined = JoinTwoCycles(firstCycle, secondCycle, edges);

            cycles = cycles.Skip(2).Take(cycles.Count - 2).Union(Enumerable.Repeat(joined, 1)).ToList();
        }

        private Directions JoinTwoCycles(Directions firstCycle, Directions secondCycle, EdgePair edges)
        {            
            var firstRoute = firstCycle.GetRoute(edges.FirstCycleEdge);
            var secondRoute = secondCycle.GetRoute(edges.SecondCycleEdge);

            var closest = graph.PickClosestPoint(firstRoute.From, edges.SecondCycleEdge.Vertices);
            firstCycle.AddRoute(firstRoute.From, closest);
            var otherEndOfSecondRoute = secondRoute.From.Equals(secondRoute.To) ? secondRoute.To : secondRoute.Points.Single(p => !p.Equals(closest));
            firstCycle.AddRoute(otherEndOfSecondRoute, firstRoute.To);
            firstCycle.Merge(secondCycle);
            firstCycle.RemoveRoute(firstRoute);
            firstCycle.RemoveRoute(secondRoute);
            return firstCycle;
        }

        public EdgePair FindClosestEdgePair(Directions firstCycle, Directions secondCycle)
        {
            var pairs = BuildEdgePairs(firstCycle, secondCycle);
            var minDistance = pairs.Min(p => p.Distance);
            return pairs.First(p => p.Distance == minDistance);
        }

        private IList<EdgePair> BuildEdgePairs(Directions firstCycle, Directions secondCycle)
        {
            var pairs = new List<EdgePair>();

            foreach (Edge e in firstCycle.Edges(graph))
            {
                pairs.AddRange(BuildEdgePairs(e, secondCycle.Edges(graph)));
            }
            return pairs;
        }

        private IEnumerable<EdgePair> BuildEdgePairs(Edge e, IEnumerable<Edge> toPairWith)
        {
            return toPairWith.Select(
                    pairWith => new EdgePair(e, pairWith, graph.DistanceBetweenTwoEdges(e, pairWith)));
        }
    }

    public class EdgePair
    {
        public Edge FirstCycleEdge { get; set; }
        public Edge SecondCycleEdge { get; set; }
        public double Distance { get; set; }

        public EdgePair(Edge firstCycleEdge, Edge secondCycleEdge, double distance)
        {
            FirstCycleEdge = firstCycleEdge;
            SecondCycleEdge = secondCycleEdge;
            Distance = distance;
        }

        public override string ToString()
        {
            return string.Format("({0} & {1})", FirstCycleEdge, SecondCycleEdge);
        }
    }
}

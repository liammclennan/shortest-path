using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShortestPath.Core.Domain
{
    public class Edge
    {
        public const double INFINITE_COST = 999999999;

        public Point[] Vertices { get; private set; }
        public double DistanceCost { get; private set; }
        public double TimeCost { get; set; }

        public Edge(Point[] vertices, double distanceCost, double timeCost)
        {
            Vertices = vertices;
            DistanceCost = distanceCost;
            TimeCost = timeCost;
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}", Vertices[0].address, Vertices[1].address);
        }
    }
}

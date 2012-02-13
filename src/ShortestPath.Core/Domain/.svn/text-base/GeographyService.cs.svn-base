using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShortestPath.Core.Domain;

namespace ShortestPath.Core.Services
{
    public class GeographyService
    {
        public double DistanceBetweenTwoPoints(Point point1, Point point2)
        {
            var theta = point1.lon - point2.lon;
            var temp = Math.Sin(DegreesToRadians(point1.lat)) * Math.Sin(DegreesToRadians(point2.lat)) +
                       Math.Cos(DegreesToRadians(point1.lat)) * Math.Cos(DegreesToRadians(point2.lat)) *
                       Math.Cos(DegreesToRadians(theta));
            temp = Math.Acos(temp);
            temp = RadiansToDegrees(temp);
            return temp*60*1.852;
        }

        private double DegreesToRadians(double degrees)
        {
            return degrees*(Math.PI/180);
        }

        private double RadiansToDegrees(double radians)
        {
            return 180*radians/Math.PI;
        }

        /// <summary>Calculates the 'distance' between two edges. Defined as the average of the distance between each edges correspoding point.</summary>
        public double DistanceBetweenTwoEdges(Edge a, Edge b)
        {
            Point a1 = a.Vertices[0];
            Point b1 = b.Vertices[0];
            Point a2 = a.Vertices[1];
            Point b2 = b.Vertices[1];

            if (DistanceBetweenTwoPoints(a1,b1) + DistanceBetweenTwoPoints(a2, b2) < DistanceBetweenTwoPoints(a1,b2) + DistanceBetweenTwoPoints(a2, b1))
            {
                // swap
                var temp = a1;
                a1 = a2;
                a2 = temp;
            }

            var firstDistance = DistanceBetweenTwoPoints(a1, b1);
            var secondDistance = DistanceBetweenTwoPoints(a2, b2);
            return (firstDistance + secondDistance)/2;
        }

    }
}
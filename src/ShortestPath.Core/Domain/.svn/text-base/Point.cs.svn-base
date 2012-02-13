using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShortestPath.Core.Domain
{
    // careful changing this class. It must match 
    // MAP.orderedPointConstructor
    public class Point
    {
        private int HASH_MULTIPLIER = 657;
        public string address { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }

        public virtual bool Equals(Point other)
        {
            return address.Equals(other.address)
                   && lat.Equals(other.lat)
                   && lon.Equals(other.lon);
        }

        public override bool Equals(object obj)
        {
            return Equals((Point)obj);
        }

        public override int GetHashCode()
        {
            return lat.GetHashCode() + lon.GetHashCode() * HASH_MULTIPLIER ^ address.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0} ({1},{2})", address, lat, lon);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ShortestPath.Core.Domain;
using ShortestPath.Test.Creators;

namespace ShortestPath.Test.Fast
{
    [TestFixture]
    public class PointTests
    {
        [Test]
        public void equal_points()
        {
            var a = new Point { address = "elephant", lat = 1.0, lon = 3.151598 };
            var b = new Point { address = "elephant", lat = 1.0, lon = 3.151598 };

            Assert.IsTrue(a.Equals(b));
        }

        [Test]
        public void points_with_different_address()
        {
            var a = new Point { address = "elephant", lat = 1.0, lon = 3.151598 };
            var b = new Point { address = "elephAnt", lat = 1.0, lon = 3.151598 };

            Assert.IsFalse(a.Equals(b));
        }

        [Test]
        public void points_with_different_lat()
        {
            var a = new Point { address = "elephant", lat = 1.01, lon = 3.151598 };
            var b = new Point { address = "elephant", lat = 1.0, lon = 3.151598 };

            Assert.IsFalse(a.Equals(b));
        }

        [Test]
        public void points_with_different_lon()
        {
            var a = new Point { address = "elephant", lat = 1.0, lon = 3.151498 };
            var b = new Point { address = "elephant", lat = 1.0, lon = 3.151598 };

            Assert.IsFalse(a.Equals(b));
        }

        [Test]
        public void select_other_point_from_array()
        {
            var point = PointMother.ChannelSt;
            var array = new Point[] {PointMother.ChannelSt, PointMother.EthelSt};
            var other = array.Single(v => !v.Equals(point));
            Assert.IsTrue(other.Equals(PointMother.EthelSt));
        }
    }
}
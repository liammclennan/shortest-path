using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ShortestPath.Core.Domain;
using ShortestPath.Core.Services;
using ShortestPath.Test.Creators;
using SpecUnit;

namespace ShortestPath.Test.Fast
{
    [Concern("GPX")]
    public class when_getting_directions_for_a_cyclic_path : BaseSpec
    {
        private Directions path;
        private IGPXService service;
        private string gpxData;

        protected override void Given()
        {
            path = new Directions();
            path.Routes.Add(new Route(PointMother.EthelSt, PointMother.ChannelSt));
            path.Routes.Add(new Route(PointMother.ChannelSt, PointMother.BeckwithSt));
            path.Routes.Add(new Route(PointMother.BeckwithSt, PointMother.EthelSt));

            service = container.Create<GPXService>();
        }

        protected override void Do()
        {
            gpxData = service.GetGPX(path);
        }

        [Observation]
        public void should_return_data()
        {
            Console.WriteLine(gpxData);
            Assert.IsFalse(string.IsNullOrEmpty(gpxData));
        }

        [Observation]
        public void should_return_expected_gpx_data()
        {
            Assert.AreEqual(EXPECTED_GPX_DATA.Replace(" ", ""), gpxData.Replace(" ", ""));
        }

        private const string EXPECTED_GPX_DATA = @"<?xml version=""1.0"" encoding=""utf-8""?>
<gpx version=""1.1"" creator=""TheFastWay.net"">
  <trk>
    <trkseg>
      <trkpt lat=""-27.488158"" lon=""153.208862"">
        <name>5 Ethel St Thorneside qld</name>        
      </trkpt>
      <trkpt lat=""-27.530071"" lon=""153.276939"">
        <name>49 Channel St Cleveland qld</name>
      </trkpt>
      <trkpt lat=""-27.507856"" lon=""153.261581"">
        <name>1 Beckwith St Ormiston QLD 4160, Australia</name>
      </trkpt>
      <trkpt lat=""-27.488158"" lon=""153.208862"">
        <name>5 Ethel St Thorneside qld</name>        
      </trkpt>
    </trkseg>
  </trk>  
</gpx>";
    }


    [Concern("GPX")]
    public class when_getting_directions : BaseSpec
    {
        private Directions path;
        private IGPXService service;
        private string gpxData;

        protected override void Given()
        {
            path = new Directions();
            path.Routes.Add(new Route(PointMother.EthelSt, PointMother.ChannelSt));
            path.Routes.Add(new Route(PointMother.ChannelSt, PointMother.BeckwithSt));

            service = container.Create<GPXService>();
        }

        protected override void Do()
        {
            gpxData = service.GetGPX(path);
        }

        [Observation]
        public void should_return_data()
        {
            Console.WriteLine(gpxData);
            Assert.IsFalse(string.IsNullOrEmpty(gpxData));
        }

        [Observation]
        public void should_return_expected_gpx_data()
        {
            Assert.AreEqual(EXPECTED_GPX_DATA.Replace(" ", ""), gpxData.Replace(" ", ""));
        }

        private const string EXPECTED_GPX_DATA = @"<?xml version=""1.0"" encoding=""utf-8""?>
<gpx version=""1.1"" creator=""TheFastWay.net"">
  <trk>
    <trkseg>
      <trkpt lat=""-27.488158"" lon=""153.208862"">
        <name>5 Ethel St Thorneside qld</name>        
      </trkpt>
      <trkpt lat=""-27.530071"" lon=""153.276939"">
        <name>49 Channel St Cleveland qld</name>
      </trkpt>
      <trkpt lat=""-27.507856"" lon=""153.261581"">
        <name>1 Beckwith St Ormiston QLD 4160, Australia</name>
      </trkpt>
    </trkseg>
  </trk>  
</gpx>";

    }
}

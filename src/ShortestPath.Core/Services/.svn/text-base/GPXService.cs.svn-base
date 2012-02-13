using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using ShortestPath.Core.Domain;

namespace ShortestPath.Core.Services
{
    public interface IGPXService
    {
        string GetGPX(Directions path);
    }

    public class GPXService : IGPXService
    {
        public string GetGPX(Directions path)
        {
            var sw = new UTF8StringWriter();
            var writer = new XmlTextWriter(sw); //XmlWriter.Create(builder, settings);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("gpx");
            WriteAttribute(writer, "version", "1.1");
            WriteAttribute(writer, "creator", "TheFastWay.net");

            writer.WriteStartElement("trk");
            writer.WriteStartElement("trkseg");

            WriteTrackPoints(writer, path);

            writer.WriteEndElement(); // trkseg
            writer.WriteEndElement(); // trk
            writer.WriteEndElement(); // gpx
            writer.WriteEndDocument();
            
            writer.Flush();
            writer.Close();
            sw.Flush();
            return sw.ToString();
        }

        private void WriteTrackPoints(XmlWriter writer, Directions path)
        {
            var points = path.Routes.Select(r => r.From).ToList();
            points.Add(path.Routes[path.Routes.Count - 1].To);
            points.ForEach(point => WritePoint(writer, point));
        }

        private void WritePoint(XmlWriter writer, Point point)
        {
            //<trkpt lat=""-27.488158"" lon=""153.208862"">
            //    <name>5 Ethel St Thorneside qld</name>        
            //</trkpt>            

            writer.WriteStartElement("trkpt");
            WriteAttribute(writer, "lat", point.lat.ToString());
            WriteAttribute(writer, "lon", point.lon.ToString());
            writer.WriteStartElement("name");
            writer.WriteValue(point.address);
            writer.WriteEndElement(); // name
            writer.WriteEndElement(); // trkpt
        }

        private void WriteAttribute(XmlWriter writer, string name, string value)
        {
            writer.WriteStartAttribute(name);
            writer.WriteValue(value);
            writer.WriteEndAttribute();
        }

    }

    public class UTF8StringWriter : StringWriter
    {
        public override Encoding Encoding
        {
            get
            {
                return Encoding.UTF8;
            }
        }
    }
}

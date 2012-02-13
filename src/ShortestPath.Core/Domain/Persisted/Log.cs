using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShortestPath.Core.Domain.Persisted
{
    public class Log : Entity
    {
        public enum LogType
        {
            SEARCH,ROAD_TIME_QUERY
        }

        public virtual string IP { get; set; }
        public virtual LogType Type { get; set; }
        public virtual string Data { get; set; }
        public virtual DateTime Timestamp { get; set;}

        public Log()
        {
            Timestamp = DateTime.Now;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShortestPath.Core.Domain.Persisted;

namespace ShortestPath.Test.Creators
{
    public class RouteTimeBuilder : IBuilder<RouteTime>
    {
        string Start = "5 Ethel St, Thorneside QLD 4158";
        string Finish = "49 Channel St, Cleveland Queensland 4163";
        int Seconds = 1320;

        public RouteTime Build()
        {
            return new RouteTime { Start = this.Start, Finish = this.Finish, Seconds = this.Seconds };
        }

        public RouteTimeBuilder WithStart(string start)
        {
            this.Start = start;
            return this;
        }

        public RouteTimeBuilder WithFinish(string finish)
        {
            this.Finish = finish;
            return this;
        }

        public RouteTimeBuilder WithSeconds(int seconds)
        {
            this.Seconds = seconds;
            return this;
        }
    }
}

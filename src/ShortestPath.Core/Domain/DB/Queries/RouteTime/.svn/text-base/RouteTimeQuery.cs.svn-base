using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShortestPath.Core.Domain.DB.Queries.RouteTime
{
    public class RouteTimeQuery : ILinqQuery<Domain.Persisted.RouteTime>
    {
        string start;
        string finish;

        public RouteTimeQuery(string start, string finish)
        {
            this.start = start;
            this.finish = finish;
        }

        public System.Linq.Expressions.Expression<Func<Domain.Persisted.RouteTime, bool>> Expression
        {
            get { return (rt) => (rt.Start.Equals(start) && rt.Finish.Equals(finish))
                || (rt.Start.Equals(finish) && rt.Finish.Equals(start));
            }
        }

    }
}

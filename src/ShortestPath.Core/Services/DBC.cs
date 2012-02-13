using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShortestPath.Core.Services
{
    public class DBC
    {
        public static void Assert(bool condition, string failureMessage)
        {
            if (!condition) throw new DBCException(failureMessage);
        }
    }

    public class DBCException : ApplicationException
    {
        public DBCException(string failureMessage) : base(failureMessage)
        {
        }
    }
}

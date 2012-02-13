using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShortestPath.Test.Creators
{
    public static class BuilderExtensions
    {
        public static IEnumerable<T> BuildAll<T>(this IEnumerable<IBuilder<T>> collection)
        {
            return collection.Select(item => item.Build());
        }

        public static IList<T> BuildAsList<T>(this IEnumerable<IBuilder<T>> collection)
        {
            return BuildAll(collection).ToList();
        }
    }

    public interface IBuilder<T>
    {
        T Build();
    }
}

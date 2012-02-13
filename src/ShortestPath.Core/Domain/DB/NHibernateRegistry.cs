using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using StructureMap.Attributes;
using NHibernate;

namespace ShortestPath.Core.Domain.DB
{
    public class NHibernateRegistry : Registry
    {
        public NHibernateRegistry()
        {
            ForRequestedType<ISessionFactory>()
                .CacheBy(InstanceScope.Singleton)
                .TheDefault.Is.ConstructedBy(() => new NHibernateSessionFactory().GetSessionFactory());

            ForRequestedType<ISession>()
                .CacheBy(InstanceScope.Hybrid)
                .TheDefault.Is.ConstructedBy(x => x.GetInstance<ISessionFactory>().OpenSession());
        }
    }
}

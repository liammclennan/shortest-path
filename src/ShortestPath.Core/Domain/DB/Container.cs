using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using StructureMap.Attributes;
using NHibernate;
using System.Configuration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace ShortestPath.Core.Domain.DB
{
    public class Container
    {
        public static void Configure()
        {
            ObjectFactory.Initialize(InitializeStructureMap);
        }

        private static void InitializeStructureMap(IInitializationExpression x)
        {
            x.Scan(y =>
            {
                y.Assembly("ShortestPath.Web");
                y.Assembly("ShortestPath.Core");
                y.With<DefaultConventionScanner>();
            }
            );
            x.AddRegistry<NHibernateRegistry>();
            x.ForRequestedType<IThreadCache>().CacheBy(InstanceScope.Hybrid).TheDefaultIsConcreteType<ThreadCache>();
        }
    }
}

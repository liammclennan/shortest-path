using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using FluentNHibernate;
using System.Configuration;
using FluentNHibernate.AutoMap;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions;
using FluentNHibernate.Mapping;
using ShortestPath.Core.Domain.Persisted;

namespace ShortestPath.Core.Domain.DB
{
    public class NHibernateSessionFactory
    {
        public NHibernate.Cfg.Configuration Configuration { get; private set; }

        public ISessionFactory GetSessionFactory()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SP"].ConnectionString;

            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2005.ConnectionString(x => x.Is(connectionString)))
                .Mappings(m => m.AutoMappings.Add(Automapping()))
                .ExposeConfiguration(c => { 
                    Configuration = c;
                    c.SetProperty("current_session_context_class", "call" );
                    c.SetProperty("show_sql", "true");
                    c.SetProperty("generate_statistics", "true");
                })
                .BuildSessionFactory();
            return sessionFactory;
        }

        private static AutoPersistenceModel Automapping()
        {
            return AutoPersistenceModel.MapEntitiesFromAssemblyOf<Entity>()
                .ConventionDiscovery.Add<OneToManyConvention>()
                .ConventionDiscovery.Add<NotNullPropertyConvention>()
                .ForTypesThatDeriveFrom<Log>(am => {
                    am.Map(l => l.Type);
                    am.Map(l => l.Data).WithLengthOf(7000);
                })                
                .WithSetup(s => s.IsBaseType = type => type == typeof(Entity))
                .Where(t => t.Namespace == "ShortestPath.Core.Domain.Persisted");
        }
    }

    public class ManyToOneConvention : IReferenceConvention
    {
        #region IReferenceConvention Members

        public bool Accept(IManyToOnePart target)
        {
            return true;
        }

        public void Apply(IManyToOnePart target)
        {
        }

        #endregion
    }

    public class OneToManyConvention : IHasManyConvention
    {
        #region IHasManyConvention Members

        public bool Accept(IOneToManyPart target)
        {
            return true;
        }

        public void Apply(IOneToManyPart target)
        {
            target.Cascade.All().WithForeignKeyConstraintName("FK__" + target.Member.DeclaringType.Name + "_" + target.Member.Name);
        }

        #endregion
    }

    public class NotNullPropertyConvention : IPropertyConvention
    {
        #region IPropertyConvention Members

        public bool Accept(IProperty target)
        {
            return true;
        }

        public void Apply(IProperty target)
        {
            target.Not.Nullable();
        }

        #endregion
    }
}

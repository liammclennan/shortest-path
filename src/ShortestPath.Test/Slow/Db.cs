using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ShortestPath.Core.Domain.DB;
using NHibernate;
using NHibernate.Engine;
using System.Data;
using System.IO;

namespace ShortestPath.Test.Slow
{
    [TestFixture]
    public class Db
    {
        ISession session;

        [Test]
        public void RebuildDatabase()
        {
            ITransaction transaction = null;
            try
            {
                var factoryFactory = new NHibernateSessionFactory();
                ISessionFactory sessionFactory = factoryFactory.GetSessionFactory();
                string[] dropScripts = factoryFactory.Configuration.GenerateDropSchemaScript(((ISessionFactoryImplementor)sessionFactory).Dialect);
                string[] createScripts = factoryFactory.Configuration.GenerateSchemaCreationScript(((ISessionFactoryImplementor)sessionFactory).Dialect);
            
                session = sessionFactory.OpenSession();
                ExecuteScripts(dropScripts, session.Connection);
                ExecuteScripts(createScripts, session.Connection);
                SaveScripts(createScripts, "create.sql");

                transaction = session.BeginTransaction();
                var repository = new Repository(session);
                var data = new Data();
                data.Build(repository);
            }
            finally
            {
                if (session != null)
                {
                    if (transaction != null && transaction.IsActive)
                    {
                        transaction.Commit();
                    }
                    session.Close();
                    session.Dispose();
                }
            }
        }

        private static void ExecuteScripts(IEnumerable<string> scripts, IDbConnection connection)
        {
            foreach (string script in scripts)
            {
                IDbCommand command = connection.CreateCommand();
                command.CommandText = script;
                command.ExecuteNonQuery();
            }
        }

        private static void SaveScripts(string[] scripts, string filename)
        {
            var writer = new StreamWriter(@"..\..\..\..\database\" + filename, false);
            foreach (var script in scripts)
            {
                writer.WriteLine(script);
            }
            writer.Close();
            writer.Dispose();
        }
    }
}

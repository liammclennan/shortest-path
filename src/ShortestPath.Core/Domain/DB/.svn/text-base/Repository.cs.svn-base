using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ShortestPath.Core.Domain.Persisted;
using NHibernate;
using NHibernate.Linq;

namespace ShortestPath.Core.Domain.DB
{
    public interface ILinqQuery<TEntity>
    {
        Expression<Func<TEntity, bool>> Expression { get; }
    }

    public interface IRepository
    {
        TEntity Load<TEntity>(int id) where TEntity : Entity;
        IList<TEntity> Query<TEntity>(ILinqQuery<TEntity> where) where TEntity : Entity;
        TEntity First<TEntity>(ILinqQuery<TEntity> query) where TEntity : Entity;
        void Delete<TEntity>(TEntity entity) where TEntity : Entity;
        void MakePersistent<TEntity>(TEntity entity) where TEntity : Entity;
        void RollBack();
    }

    public class Repository : IRepository
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public TEntity Load<TEntity>(int id) where TEntity : Entity
        {
            var entity = _session.Load<TEntity>(id);
            return entity;
        }

        public IList<TEntity> Query<TEntity>(ILinqQuery<TEntity> where) where TEntity : Entity
        {
            return _session.Linq<TEntity>().Where(where.Expression).ToList();
        }

        public TEntity First<TEntity>(ILinqQuery<TEntity> where) where TEntity : Entity
        {
            IList<TEntity> results = Query(where);
            return results.FirstOrDefault();
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : Entity
        {
            _session.Delete(entity);
        }

        public void MakePersistent<TEntity>(TEntity entity) where TEntity : Entity
        {
            _session.SaveOrUpdate(entity);
        }

        public void RollBack()
        {
            if (_session.Transaction.IsActive)
                _session.Transaction.Rollback();
        }
    }
}

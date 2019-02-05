using System;
using System.Linq;
using GraphQL.Data.Entities;

namespace GraphQL.Data
{
    public interface IStorage
    {
        IObservable<TEntity> Insert<TEntity>(TEntity entity) where TEntity : Entity;

        IObservable<TEntity> Update<TEntity>(TEntity entity) where TEntity : Entity;

        IObservable<TEntity> Delete<TEntity>(TEntity entity) where TEntity : Entity;

        IObservable<IQueryable<TEntity>> Get<TEntity>() where TEntity : Entity;
    }
}

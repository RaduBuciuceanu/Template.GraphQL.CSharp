using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using GraphQL.Data.Entities;

namespace GraphQL.Data
{
    public class MemoryStorage : IStorage
    {
        private static readonly ICollection<Entity> Entities;

        static MemoryStorage()
        {
            Entities = new List<Entity>();
        }

        public IObservable<TEntity> Insert<TEntity>(TEntity entity) where TEntity : Entity
        {
            return Observable
                .Return(entity)
                .Do(Entities.Add);
        }

        public IObservable<TEntity> Update<TEntity>(TEntity entity) where TEntity : Entity
        {
            return Observable
                .Return(Delete(entity))
                .Switch()
                .Select(Insert)
                .Switch();
        }

        public IObservable<TEntity> Delete<TEntity>(TEntity entity) where TEntity : Entity
        {
            return Observable
                .Return(Entities.Single(instance => instance.Id == entity.Id))
                .Do(foundEntity => Entities.Remove(foundEntity))
                .Select(_ => entity);
        }

        public IObservable<IQueryable<TEntity>> Get<TEntity>() where TEntity : Entity
        {
            return Observable.Return(Entities.OfType<TEntity>().AsQueryable());
        }
    }
}
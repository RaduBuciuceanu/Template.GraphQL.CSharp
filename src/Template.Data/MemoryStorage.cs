using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using Template.Data.Entities;

namespace Template.Data
{
    public class MemoryStorage : IStorage
    {
        private readonly ICollection<Entity> _entities;

        public MemoryStorage()
        {
            _entities = new List<Entity>();
        }

        public IObservable<TEntity> Insert<TEntity>(TEntity entity) where TEntity : Entity
        {
            return Observable
                .Return(entity)
                .Do(_entities.Add);
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
                .Return(_entities.Single(instance => instance.Id == entity.Id))
                .Do(foundEntity => _entities.Remove(foundEntity))
                .Select(_ => entity);
        }

        public IObservable<IQueryable<TEntity>> Get<TEntity>() where TEntity : Entity
        {
            return Observable.Return(_entities.OfType<TEntity>().AsQueryable());
        }
    }
}

using System.Linq;
using System.Reactive.Linq;
using GraphQL.Data.Entities;
using Moq.AutoMock;

namespace GraphQL.Data.UnitTests.Repositories.Setup
{
    public class StorageSetup : AutoMockerSetup
    {
        public StorageSetup(AutoMocker mocker) : base(mocker)
        {
        }

        public StorageSetup WithInsert<TEntity>(TEntity inputOutput) where TEntity : Entity
        {
            Mocker.GetMock<IStorage>()
                .Setup(storage => storage.Insert(inputOutput))
                .Returns(Observable.Return(inputOutput));

            return this;
        }

        public StorageSetup WithGet<TEntity>(IQueryable<TEntity> output) where TEntity : Entity
        {
            Mocker.GetMock<IStorage>()
                .Setup(storage => storage.Get<TEntity>())
                .Returns(Observable.Return(output));

            return this;
        }
    }
}

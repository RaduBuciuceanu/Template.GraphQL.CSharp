using System.Linq;
using System.Reactive.Linq;
using Moq.AutoMock;
using Template.Data.Entities;

namespace Template.Data.UnitTests.Repositories.Setup
{
    public class StorageSetup : AutoMockerSetup
    {
        public StorageSetup(AutoMocker mocker) : base(mocker)
        {
            Mocker.GetMock<IStorageFactory>()
                .Setup(factory => factory.Make())
                .Returns(Mocker.Get<IStorage>());
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

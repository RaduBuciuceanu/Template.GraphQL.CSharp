using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using GraphQL.Data.Entities;
using Moq;
using Shouldly;
using Xunit;

namespace GraphQL.Data.UnitTests
{
    public class MemoryStorageTests
    {
        private readonly Entity _entityForInsert;
        private readonly Entity _entityForUpdate;
        private readonly IStorage _instance;

        public MemoryStorageTests()
        {
            _entityForInsert = Mock.Of<Entity>();
            _entityForUpdate = Mock.Of<Entity>();
            _entityForUpdate.Id = _entityForInsert.Id;
            _instance = new MemoryStorage();
        }

        [Fact]
        public void Insert_Stores_Entity()
        {
            _instance.Insert(_entityForUpdate).Wait();

            _instance.Get<Entity>().Wait().First().ShouldBe(_entityForUpdate);
        }

        [Fact]
        public void Insert_Returns_StoredEntity()
        {
            Entity actual = _instance.Insert(_entityForUpdate).Wait();

            actual.ShouldBe(_entityForUpdate);
        }

        [Fact]
        public void Update_ReplacesEntity_WhenIdExists()
        {
            _instance.Insert(_entityForInsert).Wait();

            _instance.Update(_entityForUpdate).Wait();

            _instance.Get<Entity>().Wait().First().ShouldBe(_entityForUpdate);
        }

        [Fact]
        public void Update_ReturnsUpdatedEntity_WhenIdExists()
        {
            _instance.Insert(_entityForInsert).Wait();

            Entity actual = _instance.Update(_entityForUpdate).Wait();

            actual.ShouldBe(_entityForUpdate);
        }

        [Fact]
        public void Update_Throws_WhenIdDoesNotExist()
        {
            Action act = () => _instance.Update(_entityForUpdate).Wait();

            act.ShouldThrow<Exception>();
        }

        [Fact]
        public void Update_Throws_WhenIdIsNotUnique()
        {
            _instance.Insert(_entityForInsert).Do(_ => _instance.Insert(_entityForInsert).Wait()).Wait();

            Action act = () => _instance.Update(_entityForUpdate).Wait();

            act.ShouldThrow<Exception>();
        }

        [Fact]
        public void Delete_RemovesEntity_WhenIdExists()
        {
            _instance.Insert(_entityForInsert).Wait();

            _instance.Delete(_entityForInsert).Wait();

            _instance.Get<Entity>().Wait().ShouldBeEmpty();
        }

        [Fact]
        public void Delete_Returns_RemovedEntity()
        {
            _instance.Insert(_entityForInsert).Wait();

            Entity actual = _instance.Delete(_entityForInsert).Wait();

            actual.ShouldBe(_entityForInsert);
        }

        [Fact]
        public void Delete_Throws_WhenIdDoesNotExist()
        {
            Action act = () => _instance.Delete(_entityForInsert).Wait();

            act.ShouldThrow<Exception>();
        }

        [Fact]
        public void Delete_Throws_WhenIdIsNotUnique()
        {
            _instance.Insert(_entityForInsert).Do(_ => _instance.Insert(_entityForInsert).Wait()).Wait();

            Action act = () => _instance.Delete(_entityForInsert).Wait();

            act.ShouldThrow<Exception>();
        }

        [Fact]
        public void Get_ReturnsEmpty_WhenStorageIsEmpty()
        {
            List<Entity> actual = _instance.Get<Entity>().Wait().ToList();

            actual.ShouldBeEmpty();
        }

        [Fact]
        public void Get_ReturnsEverything_WhenStorageIsNotEmpty()
        {
            _instance.Insert(_entityForInsert).Do(_ => _instance.Insert(_entityForInsert).Wait()).Wait();

            List<Entity> actual = _instance.Get<Entity>().Wait().ToList();

            actual.Count().ShouldBe(2);
        }
    }
}

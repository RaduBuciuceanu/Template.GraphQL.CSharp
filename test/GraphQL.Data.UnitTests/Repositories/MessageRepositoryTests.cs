using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using GraphQL.Business.Commands;
using GraphQL.Business.Models.Inputs;
using GraphQL.Business.Models.Parameters;
using GraphQL.Business.Repositories;
using GraphQL.Data.Commands;
using GraphQL.Data.Mapping;
using GraphQL.Data.Repositories;
using Moq;
using Moq.AutoMock;
using Shouldly;
using Xunit;
using MessageEntity = GraphQL.Data.Entities.Message;
using MessageModel = GraphQL.Business.Models.Message;

namespace GraphQL.Data.UnitTests.Repositories
{
    public class MessageRepositoryTests
    {
        private readonly AutoMocker _mocker = new AutoMocker();
        private readonly MessageInput _input = new MessageInput();
        private readonly GetMessagesParameter _parameter = new GetMessagesParameter();
        private readonly MessageEntity _entity = new MessageEntity();
        private readonly MessageModel _model = new MessageModel();
        private readonly IQueryable<MessageEntity> _allEntities;
        private readonly IMessageRepository _instance;

        public MessageRepositoryTests()
        {
            _allEntities = new[] { _entity }.AsQueryable();
            SetupAutomapperInputEntity();
            SetupAutomapperEntityModel();
            SetupAutomapperEntitiesModels();
            SetupStorage();
            SetupFilter();
            SetupMessageCreated();
            _instance = _mocker.CreateInstance<MessageRepository>();
        }

        [Fact]
        public void Insert_InvokesAutomapper_ForEntityMapping()
        {
            _instance.Insert(_input).Wait();

            _mocker.Verify<IAutomapper>(mapper => mapper.Execute<MessageInput, MessageEntity>(_input));
        }

        [Fact]
        public void Insert_InvokesStorage_ForEntityStorage()
        {
            _instance.Insert(_input).Wait();

            _mocker.Verify<IStorage>(storage => storage.Insert(_entity));
        }

        [Fact]
        public void Insert_InvokesAutomapper_ForModelMapping()
        {
            _instance.Insert(_input).Wait();

            _mocker.Verify<IAutomapper>(mapper => mapper.Execute<MessageEntity, MessageModel>(_entity));
        }

        [Fact]
        public void Insert_InvokesMessageCreated_ForSubscription()
        {
            _instance.Insert(_input).Wait();

            _mocker.Verify<IMessageCreated>(messageCreated => messageCreated.Execute(_model));
        }

        [Fact]
        public void Insert_ReturnsModel_MappedByAutomapper()
        {
            MessageModel actual = _instance.Insert(_input).Wait();

            actual.ShouldBe(_model);
        }

        [Fact]
        public void GetMany_InvokesStorage_ForFetchingEntities()
        {
            _instance.GetMany(_parameter).Wait();

            _mocker.Verify<IStorage>(storage => storage.Get<MessageEntity>());
        }

        [Fact]
        public void GetMany_InvokesWith_FromFilterMessages()
        {
            _instance.GetMany(_parameter).Wait();

            _mocker.Verify<IFilterMessages>(filter => filter.With(_parameter), Times.Once);
        }

        [Fact]
        public void GetMany_InvokesExecute_FromFilterMessages()
        {
            _instance.GetMany(_parameter).Wait();

            _mocker.Verify<IFilterMessages>(filter => filter.Execute(_allEntities), Times.Once);
        }

        [Fact]
        public void GetMany_ReturnsModels_MappedByAutomapper()
        {
            IEnumerable<MessageModel> actual = _instance.GetMany(_parameter).Wait();

            actual.ShouldAllBe(model => model == _model);
        }

        private void SetupAutomapperInputEntity()
        {
            _mocker.GetMock<IAutomapper>()
                .Setup(mapper => mapper.Execute<MessageInput, MessageEntity>(_input))
                .Returns(Observable.Return(_entity));
        }

        private void SetupAutomapperEntityModel()
        {
            _mocker.GetMock<IAutomapper>()
                .Setup(mapper => mapper.Execute<MessageEntity, MessageModel>(_entity))
                .Returns(Observable.Return(_model));
        }

        private void SetupAutomapperEntitiesModels()
        {
            _mocker.GetMock<IAutomapper>()
                .Setup(mapper =>
                    mapper.Execute<IEnumerable<MessageEntity>, IEnumerable<MessageModel>>(new[] { _entity }))
                .Returns(Observable.Return(new[] { _model }));
        }

        private void SetupStorage()
        {
            _mocker.GetMock<IStorage>()
                .Setup(storage => storage.Insert(_entity))
                .Returns(Observable.Return(_entity));

            _mocker.GetMock<IStorage>()
                .Setup(storage => storage.Get<MessageEntity>())
                .Returns(Observable.Return(_allEntities));
        }

        private void SetupFilter()
        {
            _mocker.GetMock<IFilterMessages>()
                .Setup(filter => filter.With(_parameter))
                .Returns(_mocker.Get<IFilterMessages>());

            _mocker.GetMock<IFilterMessages>()
                .Setup(filter => filter.Execute(_allEntities))
                .Returns(Observable.Return(_allEntities));
        }

        private void SetupMessageCreated()
        {
            _mocker.GetMock<IMessageCreated>()
                .Setup(messageCreated => messageCreated.Execute(_model))
                .Returns(Observable.Return(_model));
        }
    }
}

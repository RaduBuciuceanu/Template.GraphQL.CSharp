using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using GraphQL.Business.Commands;
using GraphQL.Business.Models.Inputs;
using GraphQL.Business.Repositories;
using GraphQL.Data.Mapping;
using GraphQL.Data.Repositories;
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
        private readonly MessageEntity _entity = new MessageEntity();
        private readonly MessageModel _model = new MessageModel();
        private readonly IMessageRepository _instance;

        public MessageRepositoryTests()
        {
            SetupAutomapper();
            SetupStorage();
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
            _instance.GetMany().Wait();

            _mocker.Verify<IStorage>(storage => storage.Get<MessageEntity>());
        }

        [Fact]
        public void GetMany_ReturnsModels_MappedByAutomapper()
        {
            IEnumerable<MessageModel> actual = _instance.GetMany().Wait();

            actual.ShouldAllBe(model => model == _model);
        }

        private void SetupAutomapper()
        {
            _mocker.GetMock<IAutomapper>()
                .Setup(mapper => mapper.Execute<MessageInput, MessageEntity>(_input))
                .Returns(Observable.Return(_entity));

            _mocker.GetMock<IAutomapper>()
                .Setup(mapper => mapper.Execute<MessageEntity, MessageModel>(_entity))
                .Returns(Observable.Return(_model));

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
                .Returns(Observable.Return(new[] { _entity }.AsQueryable()));
        }

        private void SetupMessageCreated()
        {
            _mocker.GetMock<IMessageCreated>()
                .Setup(messageCreated => messageCreated.Execute(_model))
                .Returns(Observable.Return(_model));
        }
    }
}

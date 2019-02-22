using System.Linq;
using System.Reactive.Linq;
using Moq;
using Shouldly;
using Template.Business.Commands.Messages;
using Template.Business.Models;
using Template.Business.Models.Inputs;
using Template.Business.Models.Parameters;
using Template.Business.Repositories;
using Template.Data.Commands.Messages;
using Template.Data.Commands.Pagination;
using Template.Data.Mapping;
using Template.Data.Repositories;
using Template.Data.UnitTests.Repositories.Setup;
using Xunit;
using MessageEntity = Template.Data.Entities.Message;
using MessageModel = Template.Business.Models.Message;

namespace Template.Data.UnitTests.Repositories
{
    public class MessageRepositoryTests : RepositoryTests
    {
        private readonly MessageInput _input = new MessageInput();
        private readonly GetMessagesParameter _parameter = new GetMessagesParameter();
        private readonly MessageEntity _entity = new MessageEntity();
        private readonly MessageModel _model = new MessageModel();
        private readonly IQueryable<MessageEntity> _allEntities;
        private readonly Pagination<MessageEntity> _entitiesPagination;
        private readonly Pagination<MessageModel> _modelsPagination;
        private readonly IMessageRepository _instance;

        public MessageRepositoryTests()
        {
            _allEntities = new[] { _entity }.AsQueryable();
            _entitiesPagination = new Pagination<MessageEntity> { Items = _allEntities.ToList() };
            _modelsPagination = new Pagination<MessageModel> { Items = new[] { _model } };
            SetupFilter();
            SetupMessageCreated();
            _instance = Mocker.CreateInstance<MessageRepository>();
        }

        [Fact]
        public void Insert_InvokesAutomapper_ForEntityMapping()
        {
            _instance.Insert(_input).Wait();

            Mocker.Verify<IAutomapper>(mapper => mapper.Execute<MessageInput, MessageEntity>(_input));
        }

        [Fact]
        public void Insert_InvokesStorage_ForEntityStorage()
        {
            _instance.Insert(_input).Wait();

            Mocker.Verify<IStorage>(storage => storage.Insert(_entity));
        }

        [Fact]
        public void Insert_InvokesAutomapper_ForModelMapping()
        {
            _instance.Insert(_input).Wait();

            Mocker.Verify<IAutomapper>(mapper => mapper.Execute<MessageEntity, MessageModel>(_entity));
        }

        [Fact]
        public void Insert_InvokesMessageCreated_ForSubscription()
        {
            _instance.Insert(_input).Wait();

            Mocker.Verify<IMessageCreated>(messageCreated => messageCreated.Execute(_model));
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

            Mocker.Verify<IStorage>(storage => storage.Get<MessageEntity>());
        }

        [Fact]
        public void GetMany_InvokesWith_FromFilterMessages()
        {
            _instance.GetMany(_parameter).Wait();

            Mocker.Verify<IFilterMessages>(filter => filter.With(_parameter), Times.Once);
        }

        [Fact]
        public void GetMany_InvokesWith_FromCreatePagination()
        {
            _instance.GetMany(_parameter).Wait();

            Mocker
                .Verify<ICreatePagination<MessageEntity>>(command => command.With(_parameter.Pagination), Times.Once);
        }

        [Fact]
        public void GetMany_InvokesExecute_FromCreatePagination()
        {
            _instance.GetMany(_parameter).Wait();

            Mocker.Verify<ICreatePagination<MessageEntity>>(command => command.Execute(_allEntities), Times.Once);
        }

        [Fact]
        public void GetMany_InvokesExecute_FromFilterMessages()
        {
            _instance.GetMany(_parameter).Wait();

            Mocker.Verify<IFilterMessages>(filter => filter.Execute(_allEntities), Times.Once);
        }

        [Fact]
        public void GetMany_ReturnsModels_MappedByAutomapper()
        {
            Pagination<MessageModel> actual = _instance.GetMany(_parameter).Wait();

            actual.Items.ShouldAllBe(model => model == _model);
        }

        protected override void SetupStorage(StorageSetup setup)
        {
            setup.WithInsert(_entity).WithGet(_allEntities);
        }

        protected override void SetupAutomapper(AutomapperSetup setup)
        {
            setup
                .With(_input, _entity)
                .With(_entity, _model)
                .WithPagination(_entitiesPagination, _modelsPagination);
        }

        protected override void SetupPagination(CreatePaginationSetup setup)
        {
            setup
                .With<MessageEntity>(_parameter.Pagination)
                .With(_allEntities, _entitiesPagination);
        }

        private void SetupFilter()
        {
            Mocker.GetMock<IFilterMessages>()
                .Setup(filter => filter.With(_parameter))
                .Returns(Mocker.Get<IFilterMessages>());

            Mocker.GetMock<IFilterMessages>()
                .Setup(filter => filter.Execute(_allEntities))
                .Returns(Observable.Return(_allEntities));
        }

        private void SetupMessageCreated()
        {
            Mocker.GetMock<IMessageCreated>()
                .Setup(messageCreated => messageCreated.Execute(_model))
                .Returns(Observable.Return(_model));
        }
    }
}

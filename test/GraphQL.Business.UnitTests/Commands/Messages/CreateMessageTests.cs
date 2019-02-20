using System.Reactive.Linq;
using GraphQL.Business.Commands.Messages;
using GraphQL.Business.Models.Inputs;
using GraphQL.Business.Repositories;
using Moq.AutoMock;
using Shouldly;
using Xunit;
using MessageModel = GraphQL.Business.Models.Message;

namespace GraphQL.Business.UnitTests.Commands.Messages
{
    public class CreateMessageTests
    {
        private readonly AutoMocker _mocker = new AutoMocker();
        private readonly MessageInput _input = new MessageInput();
        private readonly MessageModel _model = new MessageModel();
        private readonly ICreateMessage _instance;

        public CreateMessageTests()
        {
            SetupMessageRepository();
            _instance = _mocker.CreateInstance<CreateMessage>();
        }

        [Fact]
        public void Execute_InvokesInsert_FromRepository()
        {
            _instance.Execute(_input).Wait();

            _mocker.Verify<IMessageRepository>(repository => repository.Insert(_input));
        }

        [Fact]
        public void Execute_ReturnsModel_ReturnedByRepository()
        {
            MessageModel actual = _instance.Execute(_input).Wait();

            actual.ShouldBe(_model);
        }

        private void SetupMessageRepository()
        {
            _mocker.GetMock<IMessageRepository>()
                .Setup(repository => repository.Insert(_input))
                .Returns(Observable.Return(_model));
        }
    }
}

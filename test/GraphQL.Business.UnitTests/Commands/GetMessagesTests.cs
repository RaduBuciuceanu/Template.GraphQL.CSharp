using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using GraphQL.Business.Commands;
using GraphQL.Business.Models;
using GraphQL.Business.Repositories;
using Moq.AutoMock;
using Shouldly;
using Xunit;

namespace GraphQL.Business.UnitTests.Commands
{
    public class GetMessagesTests
    {
        private readonly AutoMocker _mocker = new AutoMocker();
        private readonly IEnumerable<Message> _models = new[] { new Message() };
        private readonly IGetMessages _instance;

        public GetMessagesTests()
        {
            SetupMessageRepository();
            _instance = _mocker.CreateInstance<GetMessages>();
        }

        [Fact]
        public void Execute_InvokesGetMany_FromMessageRepository()
        {
            _instance.Execute().Wait();

            _mocker.Verify<IMessageRepository>(repository => repository.GetMany());
        }

        [Fact]
        public void Execute_ReturnsModels_ReturnedByRepository()
        {
            var actual = _instance.Execute().Wait();

            actual.ShouldBe(_models);
        }

        private void SetupMessageRepository()
        {
            _mocker.GetMock<IMessageRepository>()
                .Setup(repository => repository.GetMany())
                .Returns(Observable.Return(_models));
        }
    }
}

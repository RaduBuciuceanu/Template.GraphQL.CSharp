using System.Reactive.Linq;
using GraphQL.Business.Commands.Messages;
using GraphQL.Business.Models;
using GraphQL.Business.Models.Parameters;
using GraphQL.Business.Repositories;
using Moq.AutoMock;
using Shouldly;
using Xunit;

namespace GraphQL.Business.UnitTests.Commands.Messages
{
    public class GetMessagesTests
    {
        private readonly AutoMocker _mocker = new AutoMocker();
        private readonly GetMessagesParameter _parameter = new GetMessagesParameter();
        private readonly Pagination<Message> _expectedResult = new Pagination<Message>();
        private readonly IGetMessages _instance;

        public GetMessagesTests()
        {
            SetupMessageRepository();
            _instance = _mocker.CreateInstance<GetMessages>();
        }

        [Fact]
        public void Execute_InvokesGetMany_FromMessageRepository()
        {
            _instance.Execute(_parameter).Wait();

            _mocker.Verify<IMessageRepository>(repository => repository.GetMany(_parameter));
        }

        [Fact]
        public void Execute_ReturnsModels_ReturnedByRepository()
        {
            var actual = _instance.Execute(_parameter).Wait();

            actual.ShouldBe(_expectedResult);
        }

        private void SetupMessageRepository()
        {
            _mocker.GetMock<IMessageRepository>()
                .Setup(repository => repository.GetMany(_parameter))
                .Returns(Observable.Return(_expectedResult));
        }
    }
}

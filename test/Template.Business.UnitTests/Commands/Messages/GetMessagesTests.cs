using System.Reactive.Linq;
using Moq.AutoMock;
using Shouldly;
using Template.Business.Commands.Messages;
using Template.Business.Models;
using Template.Business.Models.Parameters;
using Template.Business.Repositories;
using Xunit;

namespace Template.Business.UnitTests.Commands.Messages
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

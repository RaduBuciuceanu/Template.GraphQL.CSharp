using System;
using GraphQL.Business.Commands;
using Moq.AutoMock;
using Xunit;

namespace GraphQL.Business.UnitTests.Commands
{
    public class MessageCreatedTests
    {
        private readonly AutoMocker _mocker = new AutoMocker();
        private readonly IMessageCreated _instance;

        public MessageCreatedTests()
        {
            _instance = _mocker.CreateInstance<MessageCreated>();
        }

        [Fact]
        public void Execute_PostsToQueue_When()
        {
            throw new NotImplementedException();
        }
    }
}

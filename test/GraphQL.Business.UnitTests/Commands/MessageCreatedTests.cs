using System;
using System.Reactive;
using System.Reactive.Linq;
using GraphQL.Business.Commands;
using GraphQL.Business.Models.Parameters;
using Shouldly;
using Xunit;
using MessageModel = GraphQL.Business.Models.Message;

namespace GraphQL.Business.UnitTests.Commands
{
    public class MessageCreatedTests
    {
        private readonly MessageModel _message = new MessageModel();
        private readonly IMessageCreated _instance;

        public MessageCreatedTests()
        {
            _instance = new MessageCreated();
        }

        [Fact]
        public void Execute_PostsAndReads_FromQueue()
        {
            MessageModel actual = null;

            using (_instance.Execute(new MessageCreatedParameter()).Subscribe(message => actual = message))
            {
                _instance.Execute(_message).Wait();
            }

            actual.ShouldBe(_message);
        }
    }
}

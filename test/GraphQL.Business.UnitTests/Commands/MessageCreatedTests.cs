using System;
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
        private readonly MessageModel _expectedMessage = new MessageModel();
        private readonly MessageCreatedParameter _parameter = new MessageCreatedParameter();
        private readonly IMessageCreated _instance;

        private MessageModel _actual;

        public MessageCreatedTests()
        {
            _instance = new MessageCreated();
        }

        [Fact]
        public void Execute_PostsAndReads_FromQueue()
        {
            Act();

            _actual.ShouldBe(_expectedMessage);
        }

        [Fact]
        public void Execute_FiltersResultByAuthor_WhenItIsSet()
        {
            _parameter.Author = "Nonexistent author here.";

            Act();

            _actual.ShouldBeNull();
        }

        [Fact]
        public void Execute_DoesNotFilterByAuthor_WhenItIsNotSet()
        {
            Act();

            _actual.ShouldBe(_expectedMessage);
        }

        private void Act()
        {
            using (_instance.Execute(_parameter).Subscribe(message => _actual = message))
            {
                _instance.Execute(_expectedMessage).Wait();
            }
        }
    }
}

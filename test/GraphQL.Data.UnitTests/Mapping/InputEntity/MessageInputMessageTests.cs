using System.Reactive.Linq;
using GraphQL.Business.Models.Inputs;
using Shouldly;
using Xunit;
using MessageEntity = GraphQL.Data.Entities.Message;

namespace GraphQL.Data.UnitTests.Mapping.InputEntity
{
    public class MessageInputMessageTests : AutomapperTests
    {
        private readonly MessageInput _input;
        private readonly MessageEntity _actual;

        public MessageInputMessageTests()
        {
            _input = new MessageInput { Author = "Random author here.", Content = "Random content here." };
            _actual = Instance.Execute<MessageInput, MessageEntity>(_input).Wait();
        }

        [Fact]
        public void Execute_Author_IsMapped()
        {
            _actual.Author.ShouldBe(_input.Author);
        }

        [Fact]
        public void Execute_Content_IsMapped()
        {
            _actual.Content.ShouldBe(_input.Content);
        }
    }
}

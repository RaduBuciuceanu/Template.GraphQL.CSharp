using System.Reactive.Linq;
using Shouldly;
using Xunit;
using MessageEntity = GraphQL.Data.Entities.Message;
using MessageModel = GraphQL.Business.Models.Message;

namespace GraphQL.Data.UnitTests.Mapping.ModelEntity
{
    public class MessageMessageTest : AutomapperTests
    {
        private readonly MessageEntity _entity;
        private readonly MessageModel _actual;

        public MessageMessageTest()
        {
            _entity = BuildEntity();
            _actual = Instance.Execute<MessageEntity, MessageModel>(_entity).Wait();
        }

        [Fact]
        public void Execute_Id_IsMapped()
        {
            _actual.Id.ShouldBe(_entity.Id);
        }

        [Fact]
        public void Execute_Author_IsMapped()
        {
            _actual.Author.ShouldBe(_entity.Author);
        }

        [Fact]
        public void Execute_Content_IsMapped()
        {
            _actual.Content.ShouldBe(_entity.Content);
        }

        private static MessageEntity BuildEntity()
        {
            return new MessageEntity
            {
                Id = "Random id here.",
                Author = "Random author here.",
                Content = "Random content here."
            };
        }
    }
}

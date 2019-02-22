using System.Reactive.Linq;
using Shouldly;
using Xunit;
using MessageEntity = Template.Data.Entities.Message;
using MessageModel = Template.Business.Models.Message;

namespace Template.Data.UnitTests.Mapping.EntityModel
{
    public class MessageMessageTests : AutomapperTests
    {
        private readonly MessageEntity _entity;
        private readonly MessageModel _actual;

        public MessageMessageTests()
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
                Id = "Random id here.", Author = "Random author here.", Content = "Random content here."
            };
        }
    }
}

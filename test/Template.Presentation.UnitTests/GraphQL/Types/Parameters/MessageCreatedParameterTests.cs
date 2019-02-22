using GraphQL.Types;
using Shouldly;
using Template.Presentation.GraphQL.Types.Parameters;
using Xunit;

namespace Template.Presentation.UnitTests.GraphQL.Types.Parameters
{
    public class MessageCreatedParameterTests
    {
        private readonly MessageCreatedParameter _instance;

        public MessageCreatedParameterTests()
        {
            _instance = new MessageCreatedParameter();
        }

        [Fact]
        public void Constructor_Name_IsSet()
        {
            _instance.Name.ShouldBe("MessageCreatedParameter");
        }

        [Fact]
        public void Constructor_Description_IsSet()
        {
            _instance.Description.ShouldBe("Parameter passed to messageCreated graph node.");
        }

        [Fact]
        public void Constructor_AuthorField_HasRightName()
        {
            _instance.GetField("Author").ShouldNotBeNull();
        }

        [Fact]
        public void Constructor_AuthorField_HasRightDescription()
        {
            _instance.GetField("Author").Description.ShouldBe("The author of the message.");
        }

        [Fact]
        public void Constructor_AuthorField_HasRightType()
        {
            _instance.GetField("Author").Type.ShouldBe(typeof(NonNullGraphType<StringGraphType>));
        }
    }
}

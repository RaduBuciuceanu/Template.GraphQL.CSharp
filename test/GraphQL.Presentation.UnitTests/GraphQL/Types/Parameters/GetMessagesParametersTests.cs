using GraphQL.Presentation.GraphQL.Types.Parameters;
using GraphQL.Types;
using Shouldly;
using Xunit;

namespace GraphQL.Presentation.UnitTests.GraphQL.Types.Parameters
{
    public class GetMessagesParametersTests
    {
        private readonly GetMessagesParameter _instance;

        public GetMessagesParametersTests()
        {
            _instance = new GetMessagesParameter();
        }

        [Fact]
        public void Constructor_Name_IsSet()
        {
            _instance.Name.ShouldBe("getMessagesParameter");
        }

        [Fact]
        public void Constructor_Description_IsSet()
        {
            _instance.Description.ShouldBe("Parameter passed to getMessages graph node.");
        }

        [Fact]
        public void Constructor_AuthorField_HasRightName()
        {
            _instance.GetField("Id").ShouldNotBeNull();
        }

        [Fact]
        public void Constructor_AuthorField_HasRightDescription()
        {
            _instance.GetField("Id").Description.ShouldBe("The id of the message.");
        }

        [Fact]
        public void Constructor_AuthorField_HasRightType()
        {
            _instance.GetField("Id").Type.ShouldBe(typeof(NonNullGraphType<StringGraphType>));
        }
    }
}

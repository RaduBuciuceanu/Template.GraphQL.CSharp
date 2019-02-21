using GraphQL.Presentation.GraphQL.Types.Parameters;
using GraphQL.Types;
using Shouldly;
using Xunit;

namespace GraphQL.Presentation.UnitTests.GraphQL.Types.Parameters
{
    public class GetMessagesParameterTests
    {
        private readonly GetMessagesParameter _instance;

        public GetMessagesParameterTests()
        {
            _instance = new GetMessagesParameter();
        }

        [Fact]
        public void Constructor_Name_IsSet()
        {
            _instance.Name.ShouldBe("GetMessagesParameter");
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
            _instance.GetField("Id").Type.ShouldBe(typeof(StringGraphType));
        }

        [Fact]
        public void Constructor_PaginationField_HasRightName()
        {
            _instance.GetField("Pagination").ShouldNotBeNull();
        }

        [Fact]
        public void Constructor_PaginationField_HasRightDescription()
        {
            _instance.GetField("Pagination").Description.ShouldBe("The pagination info.");
        }

        [Fact]
        public void Constructor_PaginationField_HasRightType()
        {
            _instance.GetField("Pagination").Type.ShouldBe(typeof(NonNullGraphType<PaginationParameter>));
        }
    }
}

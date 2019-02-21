using GraphQL.Presentation.GraphQL.Types.Parameters;
using GraphQL.Types;
using Shouldly;
using Xunit;

namespace GraphQL.Presentation.UnitTests.GraphQL.Types.Parameters
{
    public class PaginationParameterTests
    {
        private readonly PaginationParameter _instance;

        public PaginationParameterTests()
        {
            _instance = new PaginationParameter();
        }

        [Fact]
        public void Constructor_Name_IsSet()
        {
            _instance.Name.ShouldBe("PaginationParameter");
        }

        [Fact]
        public void Constructor_Description_IsSet()
        {
            _instance.Description.ShouldBe("The parameter used to specify the pagination info.");
        }

        [Fact]
        public void Constructor_PageIndexField_HasRightName()
        {
            _instance.GetField("PageIndex").ShouldNotBeNull();
        }

        [Fact]
        public void Constructor_PageIndexField_HasRightDescription()
        {
            _instance.GetField("PageIndex").Description.ShouldBe("The index of the page (starts from 0).");
        }

        [Fact]
        public void Constructor_PageIndexField_HasRightType()
        {
            _instance.GetField("PageIndex").Type.ShouldBe(typeof(NonNullGraphType<IntGraphType>));
        }

        [Fact]
        public void Constructor_PageSizeField_HasRightName()
        {
            _instance.GetField("PageSize").ShouldNotBeNull();
        }

        [Fact]
        public void Constructor_PageSizeField_HasRightDescription()
        {
            _instance.GetField("PageSize").Description.ShouldBe("The size of the page (starts from 1).");
        }

        [Fact]
        public void Constructor_PageSizeField_HasRightType()
        {
            _instance.GetField("PageSize").Type.ShouldBe(typeof(NonNullGraphType<IntGraphType>));
        }
    }
}

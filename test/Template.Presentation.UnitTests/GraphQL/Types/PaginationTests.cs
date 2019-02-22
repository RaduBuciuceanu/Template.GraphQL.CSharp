using GraphQL.Types;
using Shouldly;
using Template.Presentation.GraphQL.Types;
using Xunit;

namespace Template.Presentation.UnitTests.GraphQL.Types
{
    public class PaginationTests
    {
        private readonly Pagination<ObjectGraphType> _instance;

        public PaginationTests()
        {
            _instance = new Pagination<ObjectGraphType>();
        }

        [Fact]
        public void Constructor_Name_IsSet()
        {
            _instance.Name.ShouldBe($"{nameof(ObjectGraphType)}Pagination");
        }

        [Fact]
        public void Constructor_Description_IsSet()
        {
            _instance.Description.ShouldBe("A pagination used to extract a paged collection of items from server.");
        }

        [Fact]
        public void Constructor_PageIndexField_HasRightName()
        {
            _instance.GetField("pageIndex").ShouldNotBeNull();
        }

        [Fact]
        public void Constructor_PageIndexField_HasRightDescription()
        {
            _instance.GetField("pageIndex").Description.ShouldBe("The index of the page (starts from 0).");
        }

        [Fact]
        public void Constructor_PageIndexField_HasRightType()
        {
            _instance.GetField("pageIndex").Type.ShouldBe(typeof(NonNullGraphType<IntGraphType>));
        }

        [Fact]
        public void Constructor_PageSizeField_HasRightName()
        {
            _instance.GetField("pageSize").ShouldNotBeNull();
        }

        [Fact]
        public void Constructor_PageSizeField_HasRightDescription()
        {
            _instance.GetField("pageSize").Description.ShouldBe("The size of the page (starts from 1).");
        }

        [Fact]
        public void Constructor_PageSizeField_HasRightType()
        {
            _instance.GetField("pageSize").Type.ShouldBe(typeof(NonNullGraphType<IntGraphType>));
        }

        [Fact]
        public void Constructor_TotalCountField_HasRightName()
        {
            _instance.GetField("totalCount").ShouldNotBeNull();
        }

        [Fact]
        public void Constructor_TotalCountField_HasRightDescription()
        {
            _instance.GetField("totalCount").Description.ShouldBe("The total count of the items.");
        }

        [Fact]
        public void Constructor_TotalCountField_HasRightType()
        {
            _instance.GetField("totalCount").Type.ShouldBe(typeof(NonNullGraphType<IntGraphType>));
        }

        [Fact]
        public void Constructor_ItemsField_HasRightName()
        {
            _instance.GetField("items").ShouldNotBeNull();
        }

        [Fact]
        public void Constructor_ItemsField_HasRightDescription()
        {
            _instance.GetField("items").Description.ShouldBe("The items.");
        }

        [Fact]
        public void Constructor_ItemsField_HasRightType()
        {
            _instance.GetField("items").Type.ShouldBe(typeof(NonNullGraphType<ListGraphType<ObjectGraphType>>));
        }
    }
}

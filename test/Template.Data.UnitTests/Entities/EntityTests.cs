using Moq;
using Shouldly;
using Template.Data.Entities;
using Xunit;

namespace Template.Data.UnitTests.Entities
{
    public class EntityTests
    {
        private readonly Entity _instance;

        public EntityTests()
        {
            _instance = Mock.Of<Entity>();
        }

        [Fact]
        public void Id_IsNot_NullOrEmpty()
        {
            _instance.Id.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public void Id_IsAlways_Unique()
        {
            var other = Mock.Of<Entity>();

            other.Id.ShouldNotBe(_instance.Id);
        }
    }
}

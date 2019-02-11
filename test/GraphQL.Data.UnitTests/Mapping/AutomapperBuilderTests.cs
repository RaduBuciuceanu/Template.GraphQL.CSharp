using GraphQL.Data.Mapping;
using Shouldly;
using Xunit;

namespace GraphQL.Data.UnitTests.Mapping
{
    public class AutomapperBuilderTests
    {
        private readonly IAutomapperBuilder _instance;

        public AutomapperBuilderTests()
        {
            _instance = new AutomapperBuilder();
        }

        [Fact]
        public void WithMaps_Returns_Itself()
        {
            IAutomapperBuilder actual = _instance.WithMaps();

            actual.ShouldBe(_instance);
        }

        [Fact]
        public void Build_DoesNot_ReturnNull()
        {
            IAutomapper actual = _instance.Build();

            actual.ShouldNotBeNull();
        }
    }
}

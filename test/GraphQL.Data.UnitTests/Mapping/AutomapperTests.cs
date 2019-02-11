using GraphQL.Data.Mapping;

namespace GraphQL.Data.UnitTests.Mapping
{
    public abstract class AutomapperTests
    {
        protected static readonly IAutomapper Instance;

        static AutomapperTests()
        {
            var builder = new AutomapperBuilder();
            Instance = builder.WithMaps().Build();
        }
    }
}

using Shouldly;
using Xunit;

namespace GraphQL.Data.UnitTests
{
    public class MemoryStorageFactoryTests
    {
        private readonly IStorageFactory _instance;

        public MemoryStorageFactoryTests()
        {
            _instance = new MemoryStorageFactory();
        }

        [Fact]
        public void Make_DoesNot_ReturnNull()
        {
            IStorage actual = _instance.Make();

            actual.ShouldNotBeNull();
        }

        [Fact]
        public void Make_Result_IsMemoryStorage()
        {
            IStorage actual = _instance.Make();

            actual.ShouldBeOfType<MemoryStorage>();
        }

        [Fact]
        public void Make_AlwaysReturns_SameInstances()
        {
            IStorage one = _instance.Make();

            one.ShouldBe(_instance.Make());
        }
    }
}

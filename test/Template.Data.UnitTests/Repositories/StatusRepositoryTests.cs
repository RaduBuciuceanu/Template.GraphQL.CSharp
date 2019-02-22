using System.Reactive;
using System.Reactive.Linq;
using Shouldly;
using Template.Data.Repositories;
using Xunit;

namespace Template.Data.UnitTests.Repositories
{
    public class StatusRepositoryTests : RepositoryTests
    {
        private readonly IStatusRepository _instance;

        public StatusRepositoryTests()
        {
            _instance = new StatusRepository();
        }

        [Fact]
        public void Ping_Returns_DefaultUnit()
        {
            Unit actual = _instance.Ping().Wait();

            actual.ShouldBe(Unit.Default);
        }
    }
}

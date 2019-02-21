using System;
using GraphQL.Data;
using GraphQL.Presentation.Startup;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace GraphQL.Presentation.UnitTests.Startup
{
    public class StartupMockTests : StartupTests
    {
        protected override Action<IServiceCollection> Act => StartupMock.ConfigureServices;

        [Fact]
        public void ConfigureServices_MemoryStorageFactory_IsRegistered()
        {
            Get<IStorageFactory>().ShouldBeOfType<MemoryStorageFactory>();
        }
    }
}

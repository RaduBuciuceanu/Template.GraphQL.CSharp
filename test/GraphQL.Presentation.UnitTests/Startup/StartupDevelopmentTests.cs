using System;
using GraphQL.Data;
using GraphQL.Presentation.Startup;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace GraphQL.Presentation.UnitTests.Startup
{
    public class StartupDevelopmentTests : StartupTests
    {
        protected override Action<IServiceCollection> Act => StartupDevelopment.ConfigureServices;

        [Fact]
        public void ConfigureServices_MemoryStorage_IsRegistered()
        {
            Get<IStorage>().ShouldBeOfType<MemoryStorage>();
        }
    }
}

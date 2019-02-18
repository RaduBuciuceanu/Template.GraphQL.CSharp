using System;
using System.Collections.ObjectModel;
using GraphQL.Data;
using GraphQL.Presentation.Startup;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace GraphQL.Presentation.UnitTests.Startup
{
    public class StartupProductionTests : StartupTests
    {
        protected override Action<IServiceCollection> Act => StartupMock.ConfigureServices;

        [Fact]
        public void ConfigureServices_MemoryStorage_IsRegistered()
        {
            Get<IStorage>().ShouldBeOfType<MemoryStorage>();
        }
    }
}

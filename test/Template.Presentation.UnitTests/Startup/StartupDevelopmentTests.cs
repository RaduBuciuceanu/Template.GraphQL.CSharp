using System;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Template.Data;
using Template.Presentation.Startup;
using Xunit;

namespace Template.Presentation.UnitTests.Startup
{
    public class StartupDevelopmentTests : StartupTests
    {
        protected override Action<IServiceCollection> Act => StartupDevelopment.ConfigureServices;

        [Fact]
        public void ConfigureServices_MemoryStorageFactory_IsRegistered()
        {
            Get<IStorageFactory>().ShouldBeOfType<MemoryStorageFactory>();
        }
    }
}

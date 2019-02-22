using System;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Template.Data;
using Template.Presentation.Startup;
using Xunit;

namespace Template.Presentation.UnitTests.Startup
{
    public class StartupStagingTests : StartupTests
    {
        protected override Action<IServiceCollection> Act => StartupMock.ConfigureServices;

        [Fact]
        public void ConfigureServices_MemoryStorageFactory_IsRegistered()
        {
            Get<IStorageFactory>().ShouldBeOfType<MemoryStorageFactory>();
        }
    }
}

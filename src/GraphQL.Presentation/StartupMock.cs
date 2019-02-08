using System.Reactive.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ConfigureServicesMock = GraphQL.Presentation.Ioc.ConfigureServicesMock;
using IConfigureMock = GraphQL.Presentation.Configurations.IConfigureMock;

namespace GraphQL.Presentation
{
    public class StartupMock
    {
        public static void ConfigureServices(IServiceCollection collection)
        {
            var modules = new ConfigureServicesMock();
            modules.Execute(collection).Wait();
        }

        public static void Configure(IApplicationBuilder builder, IConfigureMock configure)
        {
            configure.Execute(builder).Wait();
        }
    }
}

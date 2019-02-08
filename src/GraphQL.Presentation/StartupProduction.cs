using System.Reactive.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ConfigureServicesProduction = GraphQL.Presentation.Ioc.ConfigureServicesProduction;
using IConfigureProduction = GraphQL.Presentation.Configurations.IConfigureProduction;

namespace GraphQL.Presentation
{
    public class StartupProduction
    {
        public static void ConfigureServices(IServiceCollection collection)
        {
            var modules = new ConfigureServicesProduction();
            modules.Execute(collection).Wait();
        }

        public static void Configure(IApplicationBuilder builder, IConfigureProduction configure)
        {
            configure.Execute(builder).Wait();
        }
    }
}

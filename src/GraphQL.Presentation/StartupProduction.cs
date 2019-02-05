using System.Reactive.Linq;
using GraphQL.Presentation.Configurations;
using GraphQL.Presentation.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

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

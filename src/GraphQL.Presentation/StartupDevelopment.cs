using System.Reactive.Linq;
using GraphQL.Presentation.Configurations;
using GraphQL.Presentation.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation
{
    public class StartupDevelopment
    {
        public static void ConfigureServices(IServiceCollection collection)
        {
            var modules = new ConfigureServicesDevelopment();
            modules.Execute(collection).Wait();
        }

        public static void Configure(IApplicationBuilder builder, IConfigureDevelopment configure)
        {
            configure.Execute(builder).Wait();
        }
    }
}

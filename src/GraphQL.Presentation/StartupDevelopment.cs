using System.Reactive.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ConfigureServicesDevelopment = GraphQL.Presentation.Ioc.ConfigureServicesDevelopment;
using IConfigureDevelopment = GraphQL.Presentation.Configurations.IConfigureDevelopment;

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

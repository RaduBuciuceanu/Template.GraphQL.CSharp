using System.Reactive.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ConfigureServicesStaging = GraphQL.Presentation.Ioc.ConfigureServicesStaging;
using IConfigureStaging = GraphQL.Presentation.Configurations.IConfigureStaging;

namespace GraphQL.Presentation
{
    public class StartupStaging
    {
        public static void ConfigureServices(IServiceCollection collection)
        {
            var modules = new ConfigureServicesStaging();
            modules.Execute(collection).Wait();
        }

        public static void Configure(IApplicationBuilder builder, IConfigureStaging configure)
        {
            configure.Execute(builder).Wait();
        }
    }
}

using System.Reactive.Linq;
using GraphiQl;
using GraphQL.Presentation.Configurations;
using GraphQL.Presentation.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

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

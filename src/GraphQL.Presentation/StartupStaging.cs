using System.Reactive.Linq;
using GraphQL.Presentation.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation
{
    public class StartupStaging
    {
        public static void ConfigureServices(IServiceCollection collection)
        {
            new ConfigureSettings().Execute(collection).Wait();
            new ConfigureMemoryStorages().Execute(collection).Wait();
            new ConfigureRepositories().Execute(collection).Wait();
            new ConfigureBusinessCommands().Execute(collection).Wait();
            new ConfigureGraph().Execute(collection).Wait();
        }

        public static void Configure(IApplicationBuilder builder)
        {
            builder.UseMvc();
        }
    }
}

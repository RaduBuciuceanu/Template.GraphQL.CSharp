using System.Reactive.Linq;
using GraphiQl;
using GraphQL.Presentation.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation
{
    public class StartupMock
    {
        public static void ConfigureServices(IServiceCollection collection)
        {
            collection.AddMvc();

            new ConfigureSettings().Execute(collection).Wait();
            new ConfigureMemoryStorages().Execute(collection).Wait();
            new ConfigureDataMapping().Execute(collection).Wait();
            new ConfigureBusinessRepositories().Execute(collection).Wait();
            new ConfigureBusinessCommands().Execute(collection).Wait();
            new ConfigureGraph().Execute(collection).Wait();
        }

        public static void Configure(IApplicationBuilder builder)
        {
            builder.UseMvc();
            builder.UseGraphiQl();
            builder.UseDeveloperExceptionPage();
        }
    }
}

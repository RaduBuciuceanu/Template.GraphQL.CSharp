using GraphQL.Data;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Ioc
{
    public class StorageModule : IModule
    {
        public void Configure(IServiceCollection collection)
        {
            collection.AddScoped<IStorage, MemoryStorage>();
        }
    }
}

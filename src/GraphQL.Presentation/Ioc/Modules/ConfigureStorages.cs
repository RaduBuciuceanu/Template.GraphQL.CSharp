using System;
using System.Reactive.Linq;
using GraphQL.Data;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Ioc.Modules
{
    internal class ConfigureStorages : IConfigureServices
    {
        public void Configure(IServiceCollection collection)
        {
            collection.AddScoped<IStorage, MemoryStorage>();
        }

        public IObservable<IServiceCollection> Execute(IServiceCollection input)
        {
            return Observable.Return(input)
                .Do(_ => _.AddScoped<IStorage, MemoryStorage>());
        }
    }
}

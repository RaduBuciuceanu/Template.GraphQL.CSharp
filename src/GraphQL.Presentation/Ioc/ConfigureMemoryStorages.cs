using System;
using System.Reactive.Linq;
using GraphQL.Data;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Ioc
{
    internal class ConfigureMemoryStorages : IConfigureServices
    {
        public IObservable<IServiceCollection> Execute(IServiceCollection input)
        {
            return Observable.Return(input)
                .Do(services => services.AddScoped<IStorage, MemoryStorage>());
        }
    }
}

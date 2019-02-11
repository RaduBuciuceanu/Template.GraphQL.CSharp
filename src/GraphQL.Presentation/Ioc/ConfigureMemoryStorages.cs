using System;
using System.Reactive.Linq;
using GraphQL.Business;
using GraphQL.Data;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Ioc
{
    internal class ConfigureMemoryStorages : Command<IServiceCollection, IServiceCollection>, IConfigureServices
    {
        public override IObservable<IServiceCollection> Execute(IServiceCollection input)
        {
            return Observable.Return(input)
                .Do(services => services.AddScoped<IStorage, MemoryStorage>());
        }
    }
}

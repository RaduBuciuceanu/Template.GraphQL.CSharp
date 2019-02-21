using System;
using System.Reactive.Linq;
using GraphQL.Business;
using GraphQL.Data;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Startup.Ioc
{
    internal class DataMemoryStorages : Command<IServiceCollection, IServiceCollection>, ISetup
    {
        public override IObservable<IServiceCollection> Execute(IServiceCollection input)
        {
            return Observable.Return(input)
                .Do(services => services.AddSingleton<IStorageFactory, MemoryStorageFactory>());
        }
    }
}

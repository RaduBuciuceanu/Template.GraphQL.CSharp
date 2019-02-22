using System;
using System.Reactive.Linq;
using Microsoft.Extensions.DependencyInjection;
using Template.Data;

namespace Template.Presentation.Startup.Ioc
{
    internal class DataMemoryStorages : ISetup
    {
        public IObservable<IServiceCollection> Execute(IServiceCollection input)
        {
            return Observable.Return(input)
                .Do(services => services.AddSingleton<IStorageFactory, MemoryStorageFactory>());
        }
    }
}

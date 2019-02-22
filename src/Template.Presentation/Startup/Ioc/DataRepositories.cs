using System;
using System.Reactive.Linq;
using Microsoft.Extensions.DependencyInjection;
using Template.Data.Repositories;

namespace Template.Presentation.Startup.Ioc
{
    internal class DataRepositories : ISetup
    {
        public IObservable<IServiceCollection> Execute(IServiceCollection input = default(IServiceCollection))
        {
            return Observable.Return(input)
                .Do(services => services.AddScoped<IStatusRepository, StatusRepository>());
        }
    }
}

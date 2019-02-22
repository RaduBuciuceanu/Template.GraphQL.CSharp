using System;
using System.Reactive.Linq;
using Microsoft.Extensions.DependencyInjection;
using Template.Data.Commands;

namespace Template.Presentation.Startup.Ioc
{
    internal class DataCommands : ISetup
    {
        public IObservable<IServiceCollection> Execute(IServiceCollection input)
        {
            return Observable.Return(input)
                .Do(services => services.AddTransient<IFilterMessages, FilterMessages>())
                .Do(services => services.AddTransient(typeof(ICreatePagination<>), typeof(CreatePagination<>)));
        }
    }
}

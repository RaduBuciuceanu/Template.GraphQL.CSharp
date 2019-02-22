using System;
using System.Reactive.Linq;
using Microsoft.Extensions.DependencyInjection;
using Template.Business.Commands.Status;
using Template.Data.Commands.Messages;
using Template.Data.Commands.Pagination;
using Template.Data.Commands.Status;

namespace Template.Presentation.Startup.Ioc
{
    internal class DataCommands : ISetup
    {
        public IObservable<IServiceCollection> Execute(IServiceCollection input)
        {
            return Observable.Return(input)
                .Do(services => services.AddTransient<IGetComponentHealth, GetComponentHealth>())
                .Do(services => services.AddTransient<IFilterMessages, FilterMessages>())
                .Do(services => services.AddTransient(typeof(ICreatePagination<>), typeof(CreatePagination<>)));
        }
    }
}

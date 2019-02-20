using System;
using System.Reactive.Linq;
using GraphQL.Business;
using GraphQL.Data.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Startup.Ioc
{
    internal class DataCommands : Command<IServiceCollection, IServiceCollection>, ISetup
    {
        public override IObservable<IServiceCollection> Execute(IServiceCollection input)
        {
            return Observable.Return(input)
                .Do(services => services.AddTransient<IFilterMessages, FilterMessages>());
        }
    }
}

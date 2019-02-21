using System;
using System.Reactive.Linq;
using GraphQL.Business;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Startup.Ioc
{
    internal class Settings : ISetup
    {
        public IObservable<IServiceCollection> Execute(IServiceCollection input)
        {
            return Observable.Return(input);
        }
    }
}

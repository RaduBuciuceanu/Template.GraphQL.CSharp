using System;
using System.Reactive.Linq;
using GraphQL.Business.Commands.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Startup.Ioc
{
    public class BusinessLogger : ISetup
    {
        public IObservable<IServiceCollection> Execute(IServiceCollection input = default(IServiceCollection))
        {
            return Observable.Return(input)
                .Do(services => services.AddScoped<ILogger, Logger>());
        }
    }
}

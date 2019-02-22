using System;
using System.Reactive.Linq;
using Microsoft.Extensions.DependencyInjection;
using Template.Business.Commands.Logging;

namespace Template.Presentation.Startup.Ioc
{
    internal class BusinessLogger : ISetup
    {
        public IObservable<IServiceCollection> Execute(IServiceCollection input = default(IServiceCollection))
        {
            return Observable.Return(input)
                .Do(services => services.AddScoped<ILogger, Logger>());
        }
    }
}

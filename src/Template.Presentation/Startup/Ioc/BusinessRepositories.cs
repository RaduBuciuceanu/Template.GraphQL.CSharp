using System;
using System.Reactive.Linq;
using Microsoft.Extensions.DependencyInjection;
using Template.Business.Repositories;
using Template.Data.Repositories;

namespace Template.Presentation.Startup.Ioc
{
    internal class BusinessRepositories : ISetup
    {
        public IObservable<IServiceCollection> Execute(IServiceCollection input)
        {
            return Observable.Return(input)
                .Do(services => services.AddScoped<ILogRepository, LogRepository>())
                .Do(services => services.AddTransient<IMessageRepository, MessageRepository>());
        }
    }
}

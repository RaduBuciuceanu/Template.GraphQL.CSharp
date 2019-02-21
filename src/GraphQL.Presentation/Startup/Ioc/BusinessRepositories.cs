using System;
using System.Reactive.Linq;
using GraphQL.Business;
using GraphQL.Business.Repositories;
using GraphQL.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Startup.Ioc
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

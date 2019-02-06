using System;
using System.Reactive.Linq;
using GraphQL.Business.Repositories;
using GraphQL.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Main.Ioc.Modules
{
    internal class ConfigureRepositories : IConfigureServices
    {
        public IObservable<IServiceCollection> Execute(IServiceCollection input)
        {
            return Observable.Return(input)
                .Do(_ => _.AddScoped<IMessageRepository, MessageRepository>());
        }
    }
}

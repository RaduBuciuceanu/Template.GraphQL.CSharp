using System;
using System.Reactive.Linq;
using GraphQL.Business.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Main.Ioc.Modules
{
    internal class ConfigureBusinessCommands : IConfigureServices
    {
        public IObservable<IServiceCollection> Execute(IServiceCollection input)
        {
            return Observable.Return(input)
                .Do(services => services.AddSingleton<IMessageCreated, MessageCreated>())
                .Do(services => services.AddTransient<ICreateMessage, CreateMessage>());
        }
    }
}

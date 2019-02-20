using System;
using System.Reactive.Linq;
using GraphQL.Business;
using GraphQL.Business.Commands.Messages;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Startup.Ioc
{
    internal class BusinessCommands : Command<IServiceCollection, IServiceCollection>, ISetup
    {
        public override IObservable<IServiceCollection> Execute(IServiceCollection input)
        {
            return Observable.Return(input)
                .Do(services => services.AddSingleton<IMessageCreated, MessageCreated>())
                .Do(services => services.AddTransient<ICreateMessage, CreateMessage>())
                .Do(services => services.AddTransient<IGetMessages, GetMessages>());
        }
    }
}

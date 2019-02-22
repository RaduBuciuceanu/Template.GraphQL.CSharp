using System;
using System.Reactive.Linq;
using Microsoft.Extensions.DependencyInjection;
using Template.Business.Commands.Messages;

namespace Template.Presentation.Startup.Ioc
{
    internal class BusinessCommands : ISetup
    {
        public IObservable<IServiceCollection> Execute(IServiceCollection input)
        {
            return Observable.Return(input)
                .Do(services => services.AddSingleton<IMessageCreated, MessageCreated>())
                .Do(services => services.AddTransient<ICreateMessage, CreateMessage>())
                .Do(services => services.AddTransient<IGetMessages, GetMessages>());
        }
    }
}

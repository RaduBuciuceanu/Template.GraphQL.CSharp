using GraphQL.Business.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Ioc
{
    public class CommandsModule : IModule
    {
        public void Configure(IServiceCollection collection)
        {
            collection.AddSingleton<IMessageCreated, MessageCreated>();
            collection.AddScoped<ICreateMessage, CreateMessage>();
        }
    }
}

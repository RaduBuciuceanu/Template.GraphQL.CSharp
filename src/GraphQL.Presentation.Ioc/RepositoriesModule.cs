using GraphQL.Business.Repositories;
using GraphQL.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Ioc
{
    public class RepositoriesModule : IModule
    {
        public void Configure(IServiceCollection collection)
        {
            collection.AddScoped<IMessageRepository, MessageRepository>();
        }
    }
}
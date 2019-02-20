using GraphQL.Business;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Startup.Ioc
{
    internal interface ISetup : ICommand<IServiceCollection, IServiceCollection>
    {
    }
}

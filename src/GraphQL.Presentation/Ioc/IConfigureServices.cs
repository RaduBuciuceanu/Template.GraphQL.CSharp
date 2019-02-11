using GraphQL.Business;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Ioc
{
    internal interface IConfigureServices : ICommand<IServiceCollection, IServiceCollection>
    {
    }
}

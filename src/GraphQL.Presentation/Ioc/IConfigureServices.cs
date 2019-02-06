using GraphQL.Business;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Main.Ioc
{
    internal interface IConfigureServices : ICommand<IServiceCollection, IServiceCollection>
    {
    }
}

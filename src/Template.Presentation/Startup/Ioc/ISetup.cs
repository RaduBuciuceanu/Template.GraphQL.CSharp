using Microsoft.Extensions.DependencyInjection;
using Template.Business;

namespace Template.Presentation.Startup.Ioc
{
    internal interface ISetup : ICommand<IServiceCollection, IServiceCollection>
    {
    }
}

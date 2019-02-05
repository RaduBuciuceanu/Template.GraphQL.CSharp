using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Ioc
{
    public interface IModule
    {
        void Configure(IServiceCollection collection);
    }
}

using GraphQL.Business;
using Microsoft.AspNetCore.Builder;

namespace GraphQL.Presentation.Main.Configurations
{
    public interface IConfigureMock : ICommand<IApplicationBuilder, IApplicationBuilder>
    {
    }
}

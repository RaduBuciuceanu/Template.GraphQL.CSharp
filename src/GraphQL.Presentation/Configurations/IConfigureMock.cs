using GraphQL.Business;
using Microsoft.AspNetCore.Builder;

namespace GraphQL.Presentation.Configurations
{
    public interface IConfigureMock : ICommand<IApplicationBuilder, IApplicationBuilder>
    {
    }
}

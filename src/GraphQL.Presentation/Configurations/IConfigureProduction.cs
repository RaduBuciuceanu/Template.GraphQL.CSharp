using GraphQL.Business;
using Microsoft.AspNetCore.Builder;

namespace GraphQL.Presentation.Configurations
{
    public interface IConfigureProduction : ICommand<IApplicationBuilder, IApplicationBuilder>
    {
    }
}

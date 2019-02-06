using GraphQL.Business;
using Microsoft.AspNetCore.Builder;

namespace GraphQL.Presentation.Main.Configurations
{
    public interface IConfigureProduction : ICommand<IApplicationBuilder, IApplicationBuilder>
    {
    }
}

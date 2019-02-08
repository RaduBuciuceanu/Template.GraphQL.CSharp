using System;
using System.Reactive.Linq;
using Microsoft.Extensions.DependencyInjection;
using ConfigureDevelopment = GraphQL.Presentation.Configurations.ConfigureDevelopment;
using ConfigureMock = GraphQL.Presentation.Configurations.ConfigureMock;
using ConfigureProduction = GraphQL.Presentation.Configurations.ConfigureProduction;
using ConfigureStaging = GraphQL.Presentation.Configurations.ConfigureStaging;
using IConfigureDevelopment = GraphQL.Presentation.Configurations.IConfigureDevelopment;
using IConfigureMock = GraphQL.Presentation.Configurations.IConfigureMock;
using IConfigureProduction = GraphQL.Presentation.Configurations.IConfigureProduction;
using IConfigureStaging = GraphQL.Presentation.Configurations.IConfigureStaging;

namespace GraphQL.Presentation.Ioc.Modules
{
    public class ConfigureConfigurations : IConfigureServices
    {
        public IObservable<IServiceCollection> Execute(IServiceCollection input)
        {
            return Observable.Return(input)
                .Do(_ => _.AddSingleton<IConfigureMock, ConfigureMock>())
                .Do(_ => _.AddSingleton<IConfigureDevelopment, ConfigureDevelopment>())
                .Do(_ => _.AddSingleton<IConfigureStaging, ConfigureStaging>())
                .Do(_ => _.AddSingleton<IConfigureProduction, ConfigureProduction>());
        }
    }
}

using System;
using System.Reactive.Linq;
using Microsoft.Extensions.DependencyInjection;
using ConfigureDevelopment = GraphQL.Presentation.Main.Configurations.ConfigureDevelopment;
using ConfigureMock = GraphQL.Presentation.Main.Configurations.ConfigureMock;
using ConfigureProduction = GraphQL.Presentation.Main.Configurations.ConfigureProduction;
using ConfigureStaging = GraphQL.Presentation.Main.Configurations.ConfigureStaging;
using IConfigureDevelopment = GraphQL.Presentation.Main.Configurations.IConfigureDevelopment;
using IConfigureMock = GraphQL.Presentation.Main.Configurations.IConfigureMock;
using IConfigureProduction = GraphQL.Presentation.Main.Configurations.IConfigureProduction;
using IConfigureStaging = GraphQL.Presentation.Main.Configurations.IConfigureStaging;

namespace GraphQL.Presentation.Main.Ioc.Modules
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

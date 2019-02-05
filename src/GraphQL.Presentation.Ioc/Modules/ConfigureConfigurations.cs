using System;
using System.Reactive.Linq;
using GraphQL.Presentation.Configurations;
using Microsoft.Extensions.DependencyInjection;

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

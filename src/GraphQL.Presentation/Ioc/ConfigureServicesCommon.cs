using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using GraphQL.Presentation.Ioc.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Ioc
{
    internal class ConfigureServicesCommon : IConfigureServices
    {
        private readonly IEnumerable<IConfigureServices> _configurations;

        public ConfigureServicesCommon()
        {
            _configurations = new IConfigureServices[]
            {
                new ConfigureGraph(),
                new ConfigureStorages(),
                new ConfigureBusinessCommands(),
                new ConfigureRepositories(),
            };
        }

        public IObservable<IServiceCollection> Execute(IServiceCollection input)
        {
            return Observable.Return(input)
                .Do(_ => _.AddMvc())
                .Do(_ => _.AddCors())
                .Do(Configure);
        }

        private void Configure(IServiceCollection collection)
        {
            foreach (IConfigureServices module in _configurations)
            {
                module.Execute(collection).Wait();
            }
        }
    }
}

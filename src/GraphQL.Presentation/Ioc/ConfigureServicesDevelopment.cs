using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using GraphQL.Presentation.Main.Ioc.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Main.Ioc
{
    public class ConfigureServicesDevelopment : IConfigureServices
    {
        private readonly IEnumerable<IConfigureServices> _configurstions;

        public ConfigureServicesDevelopment()
        {
            _configurstions = new IConfigureServices[]
            {
                new ConfigureServicesCommon(),
                new ConfigureConfigurations(),
            };
        }

        public IObservable<IServiceCollection> Execute(IServiceCollection input)
        {
            return Observable.Return(input)
                .Do(Configure);
        }

        private void Configure(IServiceCollection collection)
        {
            foreach (IConfigureServices module in _configurstions)
            {
                module.Execute(collection).Wait();
            }
        }
    }
}

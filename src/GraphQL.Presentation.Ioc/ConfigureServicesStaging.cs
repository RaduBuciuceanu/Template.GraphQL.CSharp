using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Ioc
{
    public class ConfigureServicesStaging : IConfigureServices
    {
        private readonly IEnumerable<IConfigureServices> _configurstions;

        public ConfigureServicesStaging()
        {
            _configurstions = new IConfigureServices[]
            {
                new ConfigureServicesCommon()
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

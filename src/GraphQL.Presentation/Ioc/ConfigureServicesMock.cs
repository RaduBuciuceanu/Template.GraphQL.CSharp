using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Main.Ioc
{
    public class ConfigureServicesMock : IConfigureServices
    {
        private readonly IEnumerable<IConfigureServices> _configurations;

        public ConfigureServicesMock()
        {
            _configurations = new IConfigureServices[]
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
            foreach (IConfigureServices module in _configurations)
            {
                module.Execute(collection).Wait();
            }
        }
    }
}

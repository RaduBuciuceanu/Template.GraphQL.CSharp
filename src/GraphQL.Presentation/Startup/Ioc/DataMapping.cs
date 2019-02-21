using System;
using System.Reactive.Linq;
using GraphQL.Business;
using GraphQL.Data.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Startup.Ioc
{
    internal class DataMapping : ISetup
    {
        public IObservable<IServiceCollection> Execute(IServiceCollection input)
        {
            return Observable.Return(input)
                .Do(services => services.AddScoped(BuildAutomapper));
        }

        private static IAutomapper BuildAutomapper(IServiceProvider provider)
        {
            var builder = new AutomapperBuilder();
            return builder.WithMaps().Build();
        }
    }
}

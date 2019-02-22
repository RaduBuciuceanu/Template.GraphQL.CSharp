using System;
using System.Reactive.Linq;
using Microsoft.Extensions.DependencyInjection;
using Template.Data.Mapping;

namespace Template.Presentation.Startup.Ioc
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

using System;
using System.Reactive.Linq;
using GraphQL.Business;
using GraphQL.Data.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Ioc
{
    public class ConfigureDataMapping : Command<IServiceCollection, IServiceCollection>, IConfigureServices
    {
        public override IObservable<IServiceCollection> Execute(IServiceCollection input)
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

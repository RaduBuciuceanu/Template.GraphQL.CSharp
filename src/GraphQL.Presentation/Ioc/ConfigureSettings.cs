using System;
using System.Reactive.Linq;
using GraphQL.Business;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Ioc
{
    internal class ConfigureSettings : Command<IServiceCollection, IServiceCollection>, IConfigureServices
    {
        public override IObservable<IServiceCollection> Execute(IServiceCollection input)
        {
            return Observable.Return(input);
        }
    }
}

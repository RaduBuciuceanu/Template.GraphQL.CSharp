using System;
using System.Reactive.Linq;
using GraphiQl;
using GraphQL.Business;
using Microsoft.AspNetCore.Builder;

namespace GraphQL.Presentation.Main.Configurations
{
    internal class ConfigureCommon : ICommand<IApplicationBuilder, IApplicationBuilder>
    {
        public IObservable<IApplicationBuilder> Execute(IApplicationBuilder input)
        {
            return Observable.Return(input)
                .Do(_ => _.UseGraphiQl())
                .Do(_ => _.UseMvc());
        }
    }
}

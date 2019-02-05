using System;
using System.Reactive.Linq;
using Microsoft.AspNetCore.Builder;

namespace GraphQL.Presentation.Configurations
{
    public class ConfigureMock : IConfigureMock
    {
        private readonly ConfigureCommon _common;

        public ConfigureMock()
        {
            _common = new ConfigureCommon();
        }

        public IObservable<IApplicationBuilder> Execute(IApplicationBuilder input)
        {
            return Observable.Return(input)
                .Select(_common.Execute)
                .Switch()
                .Do(_ => _.UseDeveloperExceptionPage());
        }
    }
}

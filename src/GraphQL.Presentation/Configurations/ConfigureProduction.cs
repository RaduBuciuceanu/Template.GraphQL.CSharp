using System;
using Microsoft.AspNetCore.Builder;

namespace GraphQL.Presentation.Configurations
{
    public class ConfigureProduction : IConfigureProduction
    {
        private readonly ConfigureCommon _common;

        public ConfigureProduction()
        {
            _common = new ConfigureCommon();
        }

        public IObservable<IApplicationBuilder> Execute(IApplicationBuilder input)
        {
            return _common.Execute(input);
        }
    }
}

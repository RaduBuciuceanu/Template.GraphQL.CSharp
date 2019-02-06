using System;
using Microsoft.AspNetCore.Builder;

namespace GraphQL.Presentation.Main.Configurations
{
    public class ConfigureStaging : IConfigureStaging
    {
        private readonly ConfigureCommon _common;

        public ConfigureStaging()
        {
            _common = new ConfigureCommon();
        }

        public IObservable<IApplicationBuilder> Execute(IApplicationBuilder input)
        {
            return _common.Execute(input);
        }
    }
}

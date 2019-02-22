using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using AutoMapper;

namespace Template.Data.Mapping
{
    public class AutomapperBuilder : IAutomapperBuilder
    {
        private IConfigurationProvider _provider;

        public AutomapperBuilder()
        {
            _provider = new MapperConfiguration(configuration => { });
        }

        public IAutomapperBuilder WithMaps()
        {
            _provider = BuildProvider();
            return this;
        }

        public IAutomapper Build()
        {
            var mapper = new Mapper(_provider);
            return new Automapper(mapper);
        }

        private MapperConfiguration BuildProvider()
        {
            return new MapperConfiguration(expression =>
            {
                foreach (IMapping mapping in DiscoverConfigurations())
                {
                    mapping.Execute(expression).Wait();
                }
            });
        }

        private IEnumerable<IMapping> DiscoverConfigurations()
        {
            return GetType()
                .Assembly
                .GetTypes()
                .Where(typeof(IMapping).IsAssignableFrom)
                .Where(type => !type.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IMapping>();
        }
    }
}

using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Ioc
{
    public class Modules : IModule
    {
        private readonly IEnumerable<IModule> _modules;

        public Modules()
        {
            _modules = new IModule[]
            {
                new GraphModule(),
                new StorageModule(),
                new CommandsModule(),
                new RepositoriesModule(),
            };
        }

        public void Configure(IServiceCollection collection)
        {
            foreach (IModule module in _modules)
            {
                module.Configure(collection);
            }
        }
    }
}

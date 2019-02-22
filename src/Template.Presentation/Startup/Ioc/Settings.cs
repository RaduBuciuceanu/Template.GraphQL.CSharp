using System;
using System.Reactive.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Template.Presentation.Startup.Ioc
{
    internal class Settings : ISetup
    {
        public IObservable<IServiceCollection> Execute(IServiceCollection input)
        {
            return Observable.Return(input);
        }
    }
}

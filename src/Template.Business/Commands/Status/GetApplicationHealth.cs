using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using Template.Business.Models;

namespace Template.Business.Commands.Status
{
    public class GetApplicationHealth : IGetApplicationHealth
    {
        private readonly IEnumerable<IGetComponentHealth> _commands;

        public GetApplicationHealth(IEnumerable<IGetComponentHealth> commands)
        {
            _commands = commands;
        }

        public IObservable<IEnumerable<ComponentHealth>> Execute(Unit input = default(Unit))
        {
            return Observable.Return(_commands)
                .SelectMany(commands => commands)
                .Select(command => command.Execute())
                .Switch()
                .Buffer(int.MaxValue);
        }
    }
}

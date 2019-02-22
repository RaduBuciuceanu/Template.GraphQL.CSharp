using System.Collections.Generic;
using System.Reactive;
using Template.Business.Models;

namespace Template.Business.Commands.Status
{
    public interface IGetApplicationHealth : ICommand<Unit, IEnumerable<ComponentHealth>>
    {
    }
}

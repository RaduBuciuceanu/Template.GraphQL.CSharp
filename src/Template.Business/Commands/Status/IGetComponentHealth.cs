using System.Reactive;
using Template.Business.Models;

namespace Template.Business.Commands.Status
{
    public interface IGetComponentHealth : ICommand<Unit, ComponentHealth>
    {
    }
}

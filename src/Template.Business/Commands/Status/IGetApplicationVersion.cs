using System.Reactive;
using Template.Business.Models;

namespace Template.Business.Commands.Status
{
    public interface IGetApplicationVersion : ICommand<Unit, ApplicationVersion>
    {
    }
}

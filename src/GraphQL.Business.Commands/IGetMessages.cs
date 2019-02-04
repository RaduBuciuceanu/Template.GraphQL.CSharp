using System.Collections.Generic;
using System.Reactive;
using GraphQL.Business.Models;

namespace GraphQL.Business.Commands
{
    public interface IGetMessages : ICommand<Unit, IEnumerable<Message>>
    {
    }
}

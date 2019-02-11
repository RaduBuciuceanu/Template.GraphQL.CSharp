using System.Reactive;
using GraphQL.Business.Models;

namespace GraphQL.Business.Commands
{
    public interface IMessageCreated : ICommand<Unit, Message>, ICommand<Message, Message>
    {
    }
}

using GraphQL.Business.Models;
using GraphQL.Business.Models.Parameters;

namespace GraphQL.Business.Commands
{
    public interface IMessageCreated : ICommand<MessageCreatedParameter, Message>, ICommand<Message, Message>
    {
    }
}

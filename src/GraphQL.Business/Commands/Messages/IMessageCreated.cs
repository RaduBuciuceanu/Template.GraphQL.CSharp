using GraphQL.Business.Models;
using GraphQL.Business.Models.Parameters;

namespace GraphQL.Business.Commands.Messages
{
    public interface IMessageCreated : ICommand<MessageCreatedParameter, Message>, ICommand<Message, Message>
    {
    }
}

using Template.Business.Models;
using Template.Business.Models.Parameters;

namespace Template.Business.Commands.Messages
{
    public interface IMessageCreated : ICommand<MessageCreatedParameter, Message>, ICommand<Message, Message>
    {
    }
}

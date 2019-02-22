using Template.Business.Models;
using Template.Business.Models.Inputs;

namespace Template.Business.Commands.Messages
{
    public interface ICreateMessage : ICommand<MessageInput, Message>
    {
    }
}

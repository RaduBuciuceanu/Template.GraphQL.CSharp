using GraphQL.Business.Models;
using GraphQL.Business.Models.Inputs;

namespace GraphQL.Business.Commands.Messages
{
    public interface ICreateMessage : ICommand<MessageInput, Message>
    {
    }
}

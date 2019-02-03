using GraphQL.Business.Models;
using GraphQL.Business.Models.Inputs;

namespace GraphQL.Business.Commands
{
    public interface ICreateMessage : ICommand<MessageInput, Message>
    {
    }
}
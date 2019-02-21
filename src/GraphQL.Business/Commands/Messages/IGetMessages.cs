using GraphQL.Business.Models;
using GraphQL.Business.Models.Parameters;

namespace GraphQL.Business.Commands.Messages
{
    public interface IGetMessages : ICommand<GetMessagesParameter, Pagination<Message>>
    {
    }
}

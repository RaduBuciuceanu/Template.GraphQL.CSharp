using Template.Business.Models;
using Template.Business.Models.Parameters;

namespace Template.Business.Commands.Messages
{
    public interface IGetMessages : ICommand<GetMessagesParameter, Pagination<Message>>
    {
    }
}

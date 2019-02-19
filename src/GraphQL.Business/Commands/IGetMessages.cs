using System.Collections.Generic;
using GraphQL.Business.Models;
using GraphQL.Business.Models.Parameters;

namespace GraphQL.Business.Commands
{
    public interface IGetMessages : ICommand<GetMessagesParameter, IEnumerable<Message>>
    {
    }
}

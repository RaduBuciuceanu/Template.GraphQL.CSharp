using System.Linq;
using GraphQL.Business;
using GraphQL.Business.Models.Parameters;
using GraphQL.Data.Entities;

namespace GraphQL.Data.Commands
{
    public interface IFilterMessages : ICommand<IQueryable<Message>, IQueryable<Message>>
    {
        IFilterMessages With(GetMessagesParameter parameter);
    }
}

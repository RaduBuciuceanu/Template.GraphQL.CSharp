using System.Linq;
using Template.Business;
using Template.Business.Models.Parameters;
using Template.Data.Entities;

namespace Template.Data.Commands.Messages
{
    public interface IFilterMessages : ICommand<IQueryable<Message>, IQueryable<Message>>
    {
        IFilterMessages With(GetMessagesParameter parameter);
    }
}

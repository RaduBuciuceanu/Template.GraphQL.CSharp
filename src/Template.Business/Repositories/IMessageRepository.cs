using System;
using Template.Business.Models;
using Template.Business.Models.Inputs;
using Template.Business.Models.Parameters;

namespace Template.Business.Repositories
{
    public interface IMessageRepository
    {
        IObservable<Message> Insert(MessageInput message);

        IObservable<Pagination<Message>> GetMany(GetMessagesParameter parameter);
    }
}

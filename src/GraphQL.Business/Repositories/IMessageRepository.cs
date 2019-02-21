using System;
using System.Collections.Generic;
using GraphQL.Business.Models;
using GraphQL.Business.Models.Inputs;
using GraphQL.Business.Models.Parameters;

namespace GraphQL.Business.Repositories
{
    public interface IMessageRepository
    {
        IObservable<Message> Insert(MessageInput message);

        IObservable<Pagination<Message>> GetMany(GetMessagesParameter parameter);
    }
}

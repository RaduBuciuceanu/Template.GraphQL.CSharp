using System;
using System.Collections.Generic;
using GraphQL.Business.Models;
using GraphQL.Business.Models.Inputs;

namespace GraphQL.Business.Repositories
{
    public interface IMessageRepository
    {
        IObservable<Message> Insert(MessageInput message);
        IObservable<IEnumerable<Message>> GetMany();
    }
}


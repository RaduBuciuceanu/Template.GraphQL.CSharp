using System;
using GraphQL.Business.Models;
using GraphQL.Business.Models.Inputs;

namespace GraphQL.Business.Repositories
{
    public interface IMessageRepository
    {
        IObservable<Message> Insert(MessageInput message);
    }
}
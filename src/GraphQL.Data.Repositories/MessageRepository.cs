using System;
using GraphQL.Business.Models;
using GraphQL.Business.Models.Inputs;
using GraphQL.Business.Repositories;

namespace GraphQL.Data.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IStorage _storage;

        public MessageRepository(IStorage storage)
        {
            _storage = storage;
        }

        public IObservable<Message> Insert(MessageInput message)
        {
//            return _storage.Insert(message);
            return null;
        }
    }
}
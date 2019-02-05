using System;
using System.Collections.Generic;
using GraphQL.Business.Commands;
using GraphQL.Business.Models;
using GraphQL.Business.Models.Inputs;
using GraphQL.Business.Repositories;

namespace GraphQL.Data.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IStorage _storage;
        private readonly IMessageCreated _messageCreated;

        public MessageRepository(IStorage storage, IMessageCreated messageCreated)
        {
            _storage = storage;
            _messageCreated = messageCreated;
        }

        public IObservable<Message> Insert(MessageInput message)
        {
            return _messageCreated.Execute(new Message { Author = "Blah" });
        }

        public IObservable<IEnumerable<Message>> GetMany()
        {
            throw new NotImplementedException();
        }
    }
}


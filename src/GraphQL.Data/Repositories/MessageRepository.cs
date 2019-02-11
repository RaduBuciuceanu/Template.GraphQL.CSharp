using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using GraphQL.Business.Commands;
using GraphQL.Business.Models;
using GraphQL.Business.Models.Inputs;
using GraphQL.Business.Repositories;
using GraphQL.Data.Mapping;
using MessageEntity = GraphQL.Data.Entities.Message;
using MessageModel = GraphQL.Business.Models.Message;

namespace GraphQL.Data.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IStorage _storage;
        private readonly IMessageCreated _messageCreated;
        private readonly IAutomapper _mapper;

        public MessageRepository(IStorage storage, IMessageCreated messageCreated, IAutomapper mapper)
        {
            _storage = storage;
            _messageCreated = messageCreated;
            _mapper = mapper;
        }

        public IObservable<MessageModel> Insert(MessageInput message)
        {
            return Observable.Return(message)
                .Select(_mapper.Execute<MessageInput, MessageEntity>)
                .Switch()
                .Select(_storage.Insert)
                .Switch()
                .Select(_mapper.Execute<MessageEntity, MessageModel>)
                .Switch()
                .Select(_messageCreated.Execute)
                .Switch();
        }

        public IObservable<IEnumerable<Message>> GetMany()
        {
            return _storage.Get<MessageEntity>()
                .Select(_mapper.Execute<IEnumerable<MessageEntity>, IEnumerable<MessageModel>>)
                .Switch();
        }
    }
}

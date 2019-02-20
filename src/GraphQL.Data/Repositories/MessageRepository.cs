using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using GraphQL.Business.Commands.Messages;
using GraphQL.Business.Models;
using GraphQL.Business.Models.Inputs;
using GraphQL.Business.Models.Parameters;
using GraphQL.Business.Repositories;
using GraphQL.Data.Commands;
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
        private readonly IFilterMessages _filterMessages;

        public MessageRepository(IStorage storage, IMessageCreated messageCreated, IAutomapper mapper,
            IFilterMessages filterMessages)
        {
            _storage = storage;
            _messageCreated = messageCreated;
            _mapper = mapper;
            _filterMessages = filterMessages;
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

        public IObservable<IEnumerable<Message>> GetMany(GetMessagesParameter parameter)
        {
            return _storage.Get<MessageEntity>()
                .Select(_filterMessages.With(parameter).Execute)
                .Switch()
                .Select(_mapper.Execute<IEnumerable<MessageEntity>, IEnumerable<MessageModel>>)
                .Switch();
        }
    }
}

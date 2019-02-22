using System;
using System.Reactive.Linq;
using Template.Business.Commands.Messages;
using Template.Business.Models;
using Template.Business.Models.Inputs;
using Template.Business.Models.Parameters;
using Template.Business.Repositories;
using Template.Data.Commands.Messages;
using Template.Data.Commands.Pagination;
using Template.Data.Mapping;
using MessageEntity = Template.Data.Entities.Message;
using MessageModel = Template.Business.Models.Message;

namespace Template.Data.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IStorage _storage;
        private readonly IMessageCreated _messageCreated;
        private readonly IAutomapper _mapper;
        private readonly IFilterMessages _filterMessages;
        private readonly ICreatePagination<MessageEntity> _createPagination;

        public MessageRepository(IStorageFactory storageFactory, IMessageCreated messageCreated, IAutomapper mapper,
            IFilterMessages filterMessages, ICreatePagination<MessageEntity> createPagination)
        {
            _storage = storageFactory.Make();
            _messageCreated = messageCreated;
            _mapper = mapper;
            _filterMessages = filterMessages;
            _createPagination = createPagination;
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

        public IObservable<Pagination<MessageModel>> GetMany(GetMessagesParameter parameter)
        {
            return _storage.Get<MessageEntity>()
                .Select(_filterMessages.With(parameter).Execute)
                .Switch()
                .Select(_createPagination.With(parameter.Pagination).Execute)
                .Switch()
                .Select(_mapper.Execute<Pagination<MessageEntity>, Pagination<MessageModel>>)
                .Switch();
        }
    }
}

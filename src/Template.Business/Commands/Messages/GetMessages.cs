using System;
using Template.Business.Models;
using Template.Business.Models.Parameters;
using Template.Business.Repositories;

namespace Template.Business.Commands.Messages
{
    public class GetMessages : IGetMessages
    {
        private readonly IMessageRepository _messageRepository;

        public GetMessages(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public IObservable<Pagination<Message>> Execute(GetMessagesParameter input)
        {
            return _messageRepository.GetMany(input);
        }
    }
}

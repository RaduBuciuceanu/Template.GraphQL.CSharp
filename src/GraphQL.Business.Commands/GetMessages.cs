using System;
using System.Collections.Generic;
using System.Reactive;
using GraphQL.Business.Models;
using GraphQL.Business.Repositories;

namespace GraphQL.Business.Commands
{
    public class GetMessages : IGetMessages
    {
        private readonly IMessageRepository _messageRepository;

        public GetMessages(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public IObservable<IEnumerable<Message>> Execute(Unit input)
        {
            return _messageRepository.GetMany();
        }
    }
}

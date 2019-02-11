using System;
using System.Collections.Generic;
using System.Reactive;
using GraphQL.Business.Models;
using GraphQL.Business.Repositories;

namespace GraphQL.Business.Commands
{
    public class GetMessages : Command<Unit, IEnumerable<Message>>, IGetMessages
    {
        private readonly IMessageRepository _messageRepository;

        public GetMessages(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public override IObservable<IEnumerable<Message>> Execute(Unit input)
        {
            return _messageRepository.GetMany();
        }
    }
}

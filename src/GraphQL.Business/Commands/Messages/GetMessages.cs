using System;
using GraphQL.Business.Models;
using GraphQL.Business.Models.Parameters;
using GraphQL.Business.Repositories;

namespace GraphQL.Business.Commands.Messages
{
    public class GetMessages : Command<GetMessagesParameter, Pagination<Message>>, IGetMessages
    {
        private readonly IMessageRepository _messageRepository;

        public GetMessages(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public override IObservable<Pagination<Message>> Execute(GetMessagesParameter input)
        {
            return _messageRepository.GetMany(input);
        }
    }
}

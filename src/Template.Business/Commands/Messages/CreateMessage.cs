using System;
using Template.Business.Models;
using Template.Business.Models.Inputs;
using Template.Business.Repositories;

namespace Template.Business.Commands.Messages
{
    public class CreateMessage : ICreateMessage
    {
        private readonly IMessageRepository _repository;

        public CreateMessage(IMessageRepository repository)
        {
            _repository = repository;
        }

        public IObservable<Message> Execute(MessageInput input)
        {
            return _repository.Insert(input);
        }
    }
}

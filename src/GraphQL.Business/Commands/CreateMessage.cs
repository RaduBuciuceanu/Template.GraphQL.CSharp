using System;
using GraphQL.Business.Models;
using GraphQL.Business.Models.Inputs;
using GraphQL.Business.Repositories;

namespace GraphQL.Business.Commands
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

using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using GraphQL.Business.Models;
using GraphQL.Business.Models.Parameters;

namespace GraphQL.Business.Commands
{
    public class MessageCreated : Command<MessageCreatedParameter, Message>, IMessageCreated
    {
        private ISubject<Message> _subject;

        public MessageCreated()
        {
            _subject = new ReplaySubject<Message>(50);
        }

        public override IObservable<Message> Execute(MessageCreatedParameter input)
        {
            return _subject;
        }

        public IObservable<Message> Execute(Message input)
        {
            return Observable
                .Return(input)
                .Do(_ => _subject.OnNext(input));
        }
    }
}

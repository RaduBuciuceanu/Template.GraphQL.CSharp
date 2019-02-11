using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using GraphQL.Business.Models;

namespace GraphQL.Business.Commands
{
    public class MessageCreated : Command<Unit, Message>, IMessageCreated
    {
        private ISubject<Message> _subject;

        public MessageCreated()
        {
            _subject = new ReplaySubject<Message>(50);
        }

        public override IObservable<Message> Execute(Unit input)
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

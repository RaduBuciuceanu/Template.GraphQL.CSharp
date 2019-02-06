using System;
using System.Reactive;
using GraphQL.Business.Commands;
using GraphQL.Presentation.Main.GraphQL.Contract;
using GraphQL.Presentation.Main.GraphQL.Types;
using GraphQL.Subscription;
using GraphQL.Types;

namespace GraphQL.Presentation.Main.GraphQL.Subscriptions
{
    public class MessageCreated : ISubscription
    {
        private readonly IMessageCreated _messageCreated;

        public string Name => "messageCreated";

        public string Description => "Returns the created event when any is created.";

        public Type Type => typeof(Message);

        public MessageCreated(IMessageCreated messageCreated)
        {
            _messageCreated = messageCreated;
        }

        public object Resolve(ResolveFieldContext context)
        {
            return context.Source as Message;
        }

        public IObservable<object> Subscribe(ResolveEventStreamContext context)
        {
            return _messageCreated.Execute(Unit.Default);
        }
    }
}

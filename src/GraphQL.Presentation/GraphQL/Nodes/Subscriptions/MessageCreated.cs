using System;
using GraphQL.Business.Commands.Messages;
using GraphQL.Presentation.GraphQL.Nodes.Types;
using GraphQL.Presentation.GraphQL.Nodes.Types.Base;
using GraphQL.Presentation.GraphQL.Types;
using GraphQL.Presentation.GraphQL.Types.Parameters;
using GraphQL.Subscription;
using GraphQL.Types;
using MessageCreatedParameterModel = GraphQL.Business.Models.Parameters.MessageCreatedParameter;
using MessageModel = GraphQL.Business.Models.Message;

namespace GraphQL.Presentation.GraphQL.Nodes.Subscriptions
{
    public class MessageCreated : ISubscription, IHasArgument
    {
        private readonly IMessageCreated _messageCreated;

        public string Name => "messageCreated";

        public string Description => "Returns the created event when any is created.";

        public Type Type => typeof(Message);

        public string ArgumentName => "parameter";

        public string ArgumentDescription => "The parameter used to filter messages.";

        public Type ArgumentType => typeof(MessageCreatedParameter);

        public MessageCreated(IMessageCreated messageCreated)
        {
            _messageCreated = messageCreated;
        }

        public object Resolve(ResolveFieldContext context)
        {
            return context.Source as MessageModel;
        }

        public IObservable<object> Subscribe(ResolveEventStreamContext context)
        {
            var input = context.GetArgument<MessageCreatedParameterModel>("parameter");
            return _messageCreated.Execute(input);
        }
    }
}

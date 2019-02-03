using System;
using System.Reactive.Threading.Tasks;
using GraphQL.Business.Commands;
using GraphQL.Presentation.GraphQL.Contract;
using GraphQL.Presentation.GraphQL.Types;
using GraphQL.Types;
using MessageInputModel = GraphQL.Business.Models.Inputs.MessageInput;
using MessageInput = GraphQL.Presentation.GraphQL.Types.Inputs.MessageInput;

namespace GraphQL.Presentation.GraphQL.Mutations
{
    public class CreateMessage : IMutation
    {
        private readonly ICreateMessage _createMessage;

        public Type Type => typeof(Message);

        public string Name => "message";

        public string Description => "Creates a message and returns the created one.";

        public string ArgumentName => "input";

        public string ArgumentDescription => "The description of the argument.";

        public Type ArgumentType => typeof(MessageInput);

        public CreateMessage(ICreateMessage createMessage)
        {
            _createMessage = createMessage;
        }

        public object Resolve(ResolveFieldContext context)
        {
            var input = context.GetArgument<MessageInputModel>("input");
            return _createMessage.Execute(input).ToTask();
        }
    }
}
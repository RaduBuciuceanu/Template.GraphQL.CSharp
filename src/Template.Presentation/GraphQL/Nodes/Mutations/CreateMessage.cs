using System;
using System.Reactive.Threading.Tasks;
using GraphQL.Types;
using Template.Business.Commands.Messages;
using Template.Presentation.GraphQL.Nodes.Types;
using Template.Presentation.GraphQL.Types;
using MessageInput = Template.Presentation.GraphQL.Types.Inputs.MessageInput;
using MessageInputModel = Template.Business.Models.Inputs.MessageInput;

namespace Template.Presentation.GraphQL.Nodes.Mutations
{
    public class CreateMessage : IMutation
    {
        private readonly ICreateMessage _createMessage;

        public Type Type => typeof(Message);

        public string Name => "createMessage";

        public string Description => "Creates a message and returns the created one.";

        public string ArgumentName => "input";

        public string ArgumentDescription => "The message to be created.";

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

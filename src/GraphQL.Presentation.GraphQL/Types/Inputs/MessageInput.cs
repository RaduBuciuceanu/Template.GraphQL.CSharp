using GraphQL.Types;
using MessageInputModel = GraphQL.Business.Models.Inputs.MessageInput;

namespace GraphQL.Presentation.GraphQL.Types.Inputs
{
    public class MessageInput : InputObjectGraphType<MessageInputModel>
    {
        public MessageInput()
        {
            Name = "messageInput";
            Description = string.Empty;

            Field(instance => instance.Author).Description(string.Empty);
            Field(instance => instance.Content).Description(string.Empty);
        }
    }
}


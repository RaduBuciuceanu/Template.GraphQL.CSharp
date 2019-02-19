using GraphQL.Types;
using MessageInputModel = GraphQL.Business.Models.Inputs.MessageInput;

namespace GraphQL.Presentation.GraphQL.Types.Inputs
{
    public class MessageInput : InputObjectGraphType<MessageInputModel>
    {
        public MessageInput()
        {
            Name = "messageInput";
            Description = "A message that contains an author and a content.";

            Field(instance => instance.Author).Description("The author of the message.");
            Field(instance => instance.Content).Description("The content of the message.");
        }
    }
}

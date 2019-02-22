using GraphQL.Types;

namespace Template.Presentation.GraphQL.Types.Inputs
{
    public class MessageInput : InputObjectGraphType<Business.Models.Inputs.MessageInput>
    {
        public MessageInput()
        {
            Name = "MessageInput";
            Description = "A message that contains an author and a content.";

            Field(instance => instance.Author).Description("The author of the message.");
            Field(instance => instance.Content).Description("The content of the message.");
        }
    }
}

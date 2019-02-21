using GraphQL.Types;
using MessageModel = GraphQL.Business.Models.Message;

namespace GraphQL.Presentation.GraphQL.Types
{
    public class Message : ObjectGraphType<MessageModel>
    {
        public Message()
        {
            Name = "Message";
            Description = "A message that contains an author and a content.";

            Field(instance => instance.Author).Description("The author of the message.");
            Field(instance => instance.Content).Description("The content of the message.");
        }
    }
}

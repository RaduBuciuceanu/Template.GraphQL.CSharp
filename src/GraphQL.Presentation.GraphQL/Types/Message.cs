using GraphQL.Types;
using MessageModel = GraphQL.Business.Models.Message;

namespace GraphQL.Presentation.GraphQL.Types
{
    public class Message : ObjectGraphType<MessageModel>
    {
        public Message()
        {
            Name = "message";
            Description = string.Empty;

            Field(instance => instance.Author).Description(string.Empty);
            Field(instance => instance.Content).Description(string.Empty);
        }
    }
}

using GraphQL.Types;
using MessageModel = GraphQL.Business.Models.Message;

namespace GraphQL.Presentation.GraphQL.Types
{
    public class Message : ObjectGraphType<MessageModel>
    {
        public Message()
        {
            Name = "";
            Description = "";
        }
    }
}
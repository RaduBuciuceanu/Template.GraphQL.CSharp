using GraphQL.Types;
using MessageInputModel = GraphQL.Business.Models.Inputs.MessageInput;

namespace GraphQL.Presentation.GraphQL.Types.Inputs
{
    public class MessageInput : InputObjectGraphType<MessageInputModel>
    {
    }
}
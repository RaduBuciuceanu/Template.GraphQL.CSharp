using GraphQL.Types;
using MessageCreatedParameterModel = GraphQL.Business.Models.Parameters.MessageCreatedParameter;

namespace GraphQL.Presentation.GraphQL.Types.Parameters
{
    public class MessageCreatedParameter : InputObjectGraphType<MessageCreatedParameterModel>
    {
        public MessageCreatedParameter()
        {
            Name = "MessageCreatedParameter";
            Description = "Parameter passed to messageCreated graph node.";

            Field(model => model.Author).Description("The author of the message.");
        }
    }
}

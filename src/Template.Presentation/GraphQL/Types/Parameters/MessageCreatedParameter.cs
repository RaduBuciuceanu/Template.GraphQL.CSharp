using GraphQL.Types;

namespace Template.Presentation.GraphQL.Types.Parameters
{
    public class MessageCreatedParameter : InputObjectGraphType<Business.Models.Parameters.MessageCreatedParameter>
    {
        public MessageCreatedParameter()
        {
            Name = "MessageCreatedParameter";
            Description = "Parameter passed to messageCreated graph node.";

            Field(model => model.Author).Description("The author of the message.");
        }
    }
}

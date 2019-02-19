using GraphQL.Types;
using GetMessagesParameterModel = GraphQL.Business.Models.Parameters.GetMessagesParameter;

namespace GraphQL.Presentation.GraphQL.Types.Parameters
{
    public class GetMessagesParameter : InputObjectGraphType<GetMessagesParameterModel>
    {
        public GetMessagesParameter()
        {
            Name = "getMessagesParameter";
            Description = "Parameter passed to getMessages graph node.";

            Field(model => model.Id).Description("The id of the message.");
        }
    }
}

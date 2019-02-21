using GraphQL.Types;
using GetMessagesParameterModel = GraphQL.Business.Models.Parameters.GetMessagesParameter;

namespace GraphQL.Presentation.GraphQL.Types.Parameters
{
    public class GetMessagesParameter : InputObjectGraphType<GetMessagesParameterModel>
    {
        public GetMessagesParameter()
        {
            Name = "GetMessagesParameter";
            Description = "Parameter passed to getMessages graph node.";

            Field(model => model.Id, true).Description("The id of the message.");

            Field(model => model.Pagination, false, typeof(NonNullGraphType<PaginationParameter>))
                .Description("The pagination info.");
        }
    }
}

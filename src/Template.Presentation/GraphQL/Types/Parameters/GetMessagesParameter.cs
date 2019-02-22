using GraphQL.Types;

namespace Template.Presentation.GraphQL.Types.Parameters
{
    public class GetMessagesParameter : InputObjectGraphType<Business.Models.Parameters.GetMessagesParameter>
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

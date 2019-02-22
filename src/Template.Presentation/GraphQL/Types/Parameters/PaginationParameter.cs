using GraphQL.Types;

namespace Template.Presentation.GraphQL.Types.Parameters
{
    public class PaginationParameter : InputObjectGraphType<Business.Models.Parameters.PaginationParameter>
    {
        public PaginationParameter()
        {
            Name = nameof(PaginationParameter);
            Description = "The parameter used to specify the pagination info.";

            Field(model => model.PageIndex).Description("The index of the page (starts from 0).");
            Field(model => model.PageSize).Description("The size of the page (starts from 1).");
        }
    }
}

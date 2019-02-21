using GraphQL.Types;

namespace GraphQL.Presentation.GraphQL.Types
{
    public class Pagination<TGraphType> : ObjectGraphType<object> where TGraphType : IGraphType
    {
        public Pagination()
        {
            Name = $"{typeof(TGraphType).Name}Pagination";
            Description = "A pagination used to extract a paged collection of items from server.";

            Field<NonNullGraphType<IntGraphType>>("pageIndex", "The index of the page (starts from 0).");
            Field<NonNullGraphType<IntGraphType>>("pageSize", "The size of the page (starts from 1).");
            Field<NonNullGraphType<IntGraphType>>("totalCount", "The total count of the items.");
            Field<NonNullGraphType<ListGraphType<TGraphType>>>("items", "The items.");
        }
    }
}

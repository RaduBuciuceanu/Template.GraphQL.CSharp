using System.Collections.Generic;
using GraphQL.Presentation.GraphQL.Builders;
using GraphQL.Presentation.GraphQL.Contract;
using GraphQL.Types;

namespace GraphQL.Presentation.GraphQL.Main
{
    public sealed class Query : ObjectGraphType<object>
    {
        public Query(IEnumerable<IQuery> queries)
        {
            var builder = new GraphFieldBuilder();

            foreach (IQuery query in queries)
            {
                AddField(builder.WithNode(query).Build());
            }
        }
    }
}


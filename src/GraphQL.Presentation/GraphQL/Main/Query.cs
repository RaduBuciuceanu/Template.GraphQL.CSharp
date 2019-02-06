using System.Collections.Generic;
using GraphQL.Presentation.Main.GraphQL.Builders;
using GraphQL.Presentation.Main.GraphQL.Contract;
using GraphQL.Types;

namespace GraphQL.Presentation.Main.GraphQL.Main
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

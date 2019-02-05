using System.Collections.Generic;
using GraphQL.Presentation.GraphQL.Builders;
using GraphQL.Presentation.GraphQL.Contract;
using GraphQL.Types;

namespace GraphQL.Presentation.GraphQL.Main
{
    public sealed class Mutation : ObjectGraphType<object>
    {
        public Mutation(IEnumerable<IMutation> mutations)
        {
            var builder = new GraphFieldBuilder();

            foreach (IMutation mutation in mutations)
            {
                AddField(builder.WithNode(mutation).Build());
            }
        }
    }
}


using System.Collections.Generic;
using GraphQL.Presentation.Main.GraphQL.Builders;
using GraphQL.Presentation.Main.GraphQL.Contract;
using GraphQL.Types;

namespace GraphQL.Presentation.Main.GraphQL.Main
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

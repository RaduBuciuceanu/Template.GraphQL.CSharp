using GraphQL.Types;
using MutationNode = GraphQL.Presentation.Main.GraphQL.Main.Mutation;
using QueryNode = GraphQL.Presentation.Main.GraphQL.Main.Query;
using SubscriptionNode = GraphQL.Presentation.Main.GraphQL.Main.Subscription;

namespace GraphQL.Presentation.Main.GraphQL
{
    public class GraphSchema : Schema
    {
        public GraphSchema(MutationNode mutation, QueryNode query, SubscriptionNode subscription)
        {
            Mutation = mutation;
            Query = query;
            Subscription = subscription;
        }
    }
}

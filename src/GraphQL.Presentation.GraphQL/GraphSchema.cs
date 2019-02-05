using GraphQL.Types;
using MutationNode = GraphQL.Presentation.GraphQL.Main.Mutation;
using QueryNode = GraphQL.Presentation.GraphQL.Main.Query;
using SubscriptionNode = GraphQL.Presentation.GraphQL.Main.Subscription;

namespace GraphQL.Presentation.GraphQL
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


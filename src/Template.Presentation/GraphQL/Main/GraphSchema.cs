using GraphQL.Types;
using Template.Presentation.GraphQL.Nodes.Types;

namespace Template.Presentation.GraphQL.Main
{
    public class GraphSchema : Schema
    {
        public GraphSchema(Node<IMutation> mutation, Node<IQuery> query, Node<ISubscription> subscription)
        {
            Mutation = mutation;
            Mutation.Name = "mutation";

            Query = query;
            Query.Name = "query";

            Subscription = subscription;
            Subscription.Name = "subscription";
        }
    }
}

using System.Collections.Generic;
using GraphQL.Presentation.GraphQL.Builders;
using GraphQL.Presentation.GraphQL.Contract;
using GraphQL.Types;

namespace GraphQL.Presentation.GraphQL.Main
{
    public sealed class Subscription : ObjectGraphType<object>
    {
        public Subscription(IEnumerable<ISubscription> subscriptions)
        {
            var builder = new GraphFieldBuilder();

            foreach (ISubscription subscription in subscriptions)
            {
                AddField(builder.WithNode(subscription).Build());
            }
        }
    }
}

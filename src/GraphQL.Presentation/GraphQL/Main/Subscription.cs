using System.Collections.Generic;
using GraphQL.Presentation.Main.GraphQL.Builders;
using GraphQL.Presentation.Main.GraphQL.Contract;
using GraphQL.Types;

namespace GraphQL.Presentation.Main.GraphQL.Main
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

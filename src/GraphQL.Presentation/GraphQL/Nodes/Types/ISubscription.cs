using System;
using GraphQL.Presentation.GraphQL.Nodes.Types.Base;
using GraphQL.Subscription;

namespace GraphQL.Presentation.GraphQL.Nodes.Types
{
    public interface ISubscription : IHasBasics
    {
        IObservable<object> Subscribe(ResolveEventStreamContext context);
    }
}

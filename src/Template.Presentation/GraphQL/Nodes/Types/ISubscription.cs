using System;
using GraphQL.Subscription;
using Template.Presentation.GraphQL.Nodes.Types.Base;

namespace Template.Presentation.GraphQL.Nodes.Types
{
    public interface ISubscription : IHasBasics
    {
        IObservable<object> Subscribe(ResolveEventStreamContext context);
    }
}

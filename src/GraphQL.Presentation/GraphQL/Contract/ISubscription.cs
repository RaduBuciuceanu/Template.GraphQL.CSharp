using System;
using GraphQL.Subscription;

namespace GraphQL.Presentation.Main.GraphQL.Contract
{
    public interface ISubscription : INode
    {
        IObservable<object> Subscribe(ResolveEventStreamContext context);
    }
}

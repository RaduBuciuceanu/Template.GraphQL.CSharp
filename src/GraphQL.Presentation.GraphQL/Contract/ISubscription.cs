using System;
using GraphQL.Subscription;

namespace GraphQL.Presentation.GraphQL.Contract
{
    public interface ISubscription : INode
    {
        IObservable<object> Subscribe(ResolveEventStreamContext context);
    }
}


using System;
using GraphQL.Subscription;

namespace GraphQL.Presentation.GraphQL.Contract
{
    public interface ISubscription : IHasBasics
    {
        IObservable<object> Subscribe(ResolveEventStreamContext context);
    }
}

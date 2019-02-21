using System;

namespace GraphQL.Data.Mapping
{
    public interface IAutomapper
    {
        IObservable<TDestination> Execute<TSource, TDestination>(TSource source);
    }
}

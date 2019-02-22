using System;

namespace Template.Data.Mapping
{
    public interface IAutomapper
    {
        IObservable<TDestination> Execute<TSource, TDestination>(TSource source);
    }
}

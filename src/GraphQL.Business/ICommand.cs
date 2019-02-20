using System;

namespace GraphQL.Business
{
    public interface ICommand
    {
        IObservable<TOutput> Execute<TInput, TOutput>(TInput input);
    }

    public interface ICommand<in TInput, out TOutput> : ICommand
    {
        IObservable<TOutput> Execute(TInput input = default(TInput));
    }
}

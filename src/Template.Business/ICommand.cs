using System;

namespace Template.Business
{
    public interface ICommand<in TInput, out TOutput>
    {
        IObservable<TOutput> Execute(TInput input = default(TInput));
    }
}

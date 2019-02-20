using System;
using System.Reactive.Linq;

namespace GraphQL.Business
{
    public abstract class Command<TInput, TOutput> : ICommand<TInput, TOutput>
    {
        public abstract IObservable<TOutput> Execute(TInput input);

        public IObservable<TBaseOutput> Execute<TBaseInput, TBaseOutput>(TBaseInput input)
        {
            return Execute((TInput)(object)input).Select(_ => (TBaseOutput)(object)_);
        }
    }
}

using System;

namespace GraphQL.Business.Commands.Logging
{
    public interface ILogger
    {
        IObservable<string> Info(string message, object context = null);

        IObservable<string> Error(string message, object context = null);

        IObservable<string> Warning(string message, object context = null);
    }
}

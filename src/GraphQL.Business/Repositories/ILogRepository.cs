using System;

namespace GraphQL.Business.Repositories
{
    public interface ILogRepository
    {
        IObservable<string> InsertInfo(string message, object context = null);

        IObservable<string> InsertWarning(string message, object context = null);

        IObservable<string> InsertError(string message, object context = null);
    }
}

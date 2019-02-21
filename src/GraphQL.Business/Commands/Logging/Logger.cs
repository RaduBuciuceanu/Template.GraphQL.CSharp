using System;
using GraphQL.Business.Repositories;

namespace GraphQL.Business.Commands.Logging
{
    public class Logger : ILogger
    {
        private readonly ILogRepository _repository;

        public Logger(ILogRepository repository)
        {
            _repository = repository;
        }

        public IObservable<string> Info(string message, object context = null)
        {
            return _repository.InsertInfo(message, context);
        }

        public IObservable<string> Error(string message, object context = null)
        {
            return _repository.InsertError(message, context);
        }

        public IObservable<string> Warning(string message, object context = null)
        {
            return _repository.InsertWarning(message, context);
        }
    }
}

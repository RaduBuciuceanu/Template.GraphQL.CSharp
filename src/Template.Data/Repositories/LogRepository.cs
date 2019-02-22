using System;
using System.Reactive.Linq;
using Template.Business.Repositories;

namespace Template.Data.Repositories
{
    public class LogRepository : ILogRepository
    {
        private const string Info = "[Info]: ";
        private const string Warning = "[Warning]: ";
        private const string Error = "[Error]: ";

        public IObservable<string> InsertInfo(string message, object context = null)
        {
            return LogToConsole($"{Info}{message}");
        }

        public IObservable<string> InsertWarning(string message, object context = null)
        {
            return LogToConsole($"{Warning}{message}");
        }

        public IObservable<string> InsertError(string message, object context = null)
        {
            return LogToConsole($"{Error}{message}");
        }

        private static IObservable<string> LogToConsole(string message)
        {
            return Observable.Return(message).Do(Console.WriteLine);
        }
    }
}

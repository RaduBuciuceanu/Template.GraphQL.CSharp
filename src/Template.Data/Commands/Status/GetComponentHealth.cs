using System;
using System.Reactive;
using System.Reactive.Linq;
using Template.Business.Commands.Status;
using Template.Business.Models;
using Template.Data.Repositories;

namespace Template.Data.Commands.Status
{
    public class GetComponentHealth : IGetComponentHealth
    {
        private const string Name = "Data layer health";
        private const string SuccessMessage = "Data layer health check succeeded.";
        private const string FailMessage = "Data layer health check failed.";

        private readonly IStatusRepository _repository;

        public GetComponentHealth(IStatusRepository repository)
        {
            _repository = repository;
        }

        public IObservable<ComponentHealth> Execute(Unit input = default(Unit))
        {
            var start = default(DateTime);

            return Observable.Return(DateTime.UtcNow)
                .Do(time => start = time)
                .Do(_ => _repository.Ping().Wait())
                .Select(_ => BuildSucceededStatus(start))
                .Switch()
                .Catch<ComponentHealth, Exception>(exception => BuildFailedStatus(start, exception));
        }

        private static IObservable<ComponentHealth> BuildSucceededStatus(DateTime start)
        {
            return Observable.Return(new ComponentHealth
            {
                Name = Name,
                Message = SuccessMessage,
                Passed = true,
                Duration = BuildDuration(start).Wait()
            });
        }

        private static IObservable<ComponentHealth> BuildFailedStatus(DateTime start, Exception exception)
        {
            return Observable.Return(new ComponentHealth
            {
                Name = Name,
                Message = $"{FailMessage} {exception}",
                Passed = false,
                Duration = BuildDuration(start).Wait()
            });
        }

        private static IObservable<string> BuildDuration(DateTime start)
        {
            return Observable
                .Return(DateTime.UtcNow - start)
                .Select(duration => $"{duration.TotalSeconds} seconds");
        }
    }
}

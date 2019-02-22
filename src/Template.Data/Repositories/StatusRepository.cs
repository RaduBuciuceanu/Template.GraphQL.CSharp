using System;
using System.Reactive;
using System.Reactive.Linq;

namespace Template.Data.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        public IObservable<Unit> Ping()
        {
            return Observable.Return(Unit.Default);
        }
    }
}

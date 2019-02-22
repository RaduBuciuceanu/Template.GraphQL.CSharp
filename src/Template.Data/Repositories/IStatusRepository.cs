using System;
using System.Reactive;

namespace Template.Data.Repositories
{
    public interface IStatusRepository
    {
        IObservable<Unit> Ping();
    }
}

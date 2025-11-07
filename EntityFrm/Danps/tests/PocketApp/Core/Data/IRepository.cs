using PocketApp.Core.DomainObjects;
using System;

namespace PocketApp.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
using {SOLUCAO}.Core.DomainObjects;

namespace {SOLUCAO}.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
namespace {SOLUCAO}.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
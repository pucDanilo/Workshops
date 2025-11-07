using PocketApp.Core.Data;
using PocketApp.Core.DomainObjects;

namespace PocketApp.Data.Repository
{
    public abstract class PocketContextRepository<T> : BaseRepository<T> where T : Entity, IAggregateRoot
    {
        //        protected readonly PocketContext _context;

        //public IUnitOfWork UnitOfWork => _context;

        public PocketContextRepository(PocketContext context) : base(context)
        {
        }

        /*
        public async Task<IEnumerable<T>> ObterTodos()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> ObterPorId(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Adicionar(T fluxoCaixa)
        {
            dbSet.Add(fluxoCaixa);
        }

        public void Atualizar(T fluxoCaixa)
        {
            dbSet.Update(fluxoCaixa);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }*/
    }
}
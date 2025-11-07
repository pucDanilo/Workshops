using Microsoft.EntityFrameworkCore;
using PocketApp.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocketApp.Core.Data
{
    public abstract class BaseRepository<T> : IRepository<T> where T : Entity, IAggregateRoot
    {
        protected readonly BaseContext _context;

        public IUnitOfWork UnitOfWork => _context;

        protected DbSet<T> aggregateRootDbSet;

        public BaseRepository(BaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> ObterTodos()
        {
            return await aggregateRootDbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> ObterPorId(Guid id)
        {
            return await aggregateRootDbSet.FindAsync(id);
        }

        public void Adicionar(T item)
        {
            aggregateRootDbSet.Add(item);
        }

        public void Atualizar(T item)
        {
            aggregateRootDbSet.Update(item);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
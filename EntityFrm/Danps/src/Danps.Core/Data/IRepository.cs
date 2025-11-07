using Danps.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Danps.Core.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : EntityAudit
    {
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> pred);

        Task<TEntity> ObterPorId(int id);

        Task<List<TEntity>> ObterTodos();

        Task Adicionar(TEntity entity);

        Task Atualizar(TEntity entity);

        Task Remover(int id);

        Task<int> SaveChanges();
    }
}
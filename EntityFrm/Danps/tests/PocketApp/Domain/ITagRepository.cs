using PocketApp.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocketApp.Domain
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<IEnumerable<Tag>> ObterTodos();

        void Adicionar(Tag obj);

        void Atualizar(Tag obj);
    }
}
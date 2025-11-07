using Microsoft.EntityFrameworkCore;
using PocketApp.Core.Data;
using PocketApp.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocketApp.Data.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly PocketContext _context;

        public TagRepository(PocketContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Tag>> ObterTodos()
        {
            return await _context.Tags.AsNoTracking().ToListAsync();
        }

        public void Adicionar(Tag tag)
        {
            _context.Tags.Add(tag);
        }

        public void Atualizar(Tag tag)
        {
            _context.Tags.Update(tag);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
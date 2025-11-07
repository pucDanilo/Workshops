using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace PocketApp.Core.Data
{
    public abstract class BaseContext : DbContext, IUnitOfWork
    {
        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = System.DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return await base.SaveChangesAsync() > 0;
        }
    }
}
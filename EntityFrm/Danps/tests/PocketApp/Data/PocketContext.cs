using Microsoft.EntityFrameworkCore;
using PocketApp.Core.Data;
using PocketApp.Domain;

namespace PocketApp.Data
{
    public class PocketContext : BaseContext
    {
        public DbSet<FluxoCaixa> CashFlows { get; set; }
        public DbSet<Movimentacao> Transactions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Locatario> Tenants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PocketApp;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PocketContext).Assembly);
        }

        /*

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
        }*/
    }
}
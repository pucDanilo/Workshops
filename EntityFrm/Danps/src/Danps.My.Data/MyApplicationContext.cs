using Danps.Core;
using Danps.My.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Danps.My.Data
{
    public class MyApplicationContext : DefaultDbContext
    {
        public DbSet<MyClass> MyClasses { get; set; }
        public DbSet<MyReplace> MyReplaces { get; set; }
        public DbSet<MyClassField> MyClassFields { get; set; }
        public DbSet<MyClassForeignKey> MyClassForeignKeys { get; set; }
        public DbSet<MyAggregate> MyAggregates { get; set; }
        public DbSet<MyAggregateClass> MyAggregateClasses { get; set; }
        public DbSet<MySqlObject> MySqlObject { get; set; }
        public DbSet<MyModelo> Modelos { get; set; }
        public DbSet<MyTag> Tags { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyApplicationContext).Assembly);
            //modelBuilder.Entity<MyClass>().HasQueryFilter(p => !p.NomeTabela.Contains("my_class"));
        }
    }
}
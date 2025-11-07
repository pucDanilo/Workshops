using Danps.Catalogo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace Danps.Catalogo.Domain
{
    public class CatalogoContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Teste002;Trusted_Connection=True;MultipleActiveResultSets=true")
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().OwnsOne(p => p.Dimensoes);
        }
    }
}
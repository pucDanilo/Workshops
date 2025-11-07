using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace Danps.Core
{
    public abstract class DefaultDbContext : DbContext
    {
        public static string LOCAL_DB = "Server=(localdb)\\mssqllocaldb;Database=Teste002;Trusted_Connection=True;MultipleActiveResultSets=true";
        public const string HOM = @"Data Source=GTIDBSQLHOM01\PROD;Integrated Security=True;Initial Catalog=";
        public static string SGE => $"{HOM}SGE2";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(LOCAL_DB)
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
        }
    }
}
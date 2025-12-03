using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Workshops.Domain.Models;
using WorkShops.Core.Data;

namespace Workshops.Infrastructure.Context;

public class WorkshopsDbContext : DbContext, IUnitOfWork
{
    public WorkshopsDbContext(DbContextOptions<WorkshopsDbContext> options) : base(options)
    {
    }

    public DbSet<Workshop> Workshops => Set<Workshop>();

    public async Task<bool> Commit()
    {
        var sucess = await base.SaveChangesAsync() > 0;
        //if (sucess) await _mediatorHandler.PublishEvents(this);

        return sucess;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorkshopsDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}

public class DbContextFactory : IDesignTimeDbContextFactory<WorkshopsDbContext>
{
    public WorkshopsDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var dbContextBuilder = new DbContextOptionsBuilder<WorkshopsDbContext>();
        dbContextBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=dps;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        return new WorkshopsDbContext(dbContextBuilder.Options);
    }
}

using Microsoft.EntityFrameworkCore;
using Workshop10_API.Api.Models;

namespace Workshop10_API.Api.Infrastructure.Data;

public class WorkshopsDbContext : DbContext
{
    public WorkshopsDbContext(DbContextOptions<WorkshopsDbContext> options) : base(options)
    {
    }

    public DbSet<Workshop> Workshops => Set<Workshop>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new WorkshopMap());
        modelBuilder.ApplyConfiguration(new UserMap());
    }
}
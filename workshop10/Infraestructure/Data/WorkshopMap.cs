using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop10_API.Api.Models;

namespace Workshop10_API.Api.Infrastructure.Data;

public class WorkshopMap : IEntityTypeConfiguration<Workshop>
{
    public void Configure(EntityTypeBuilder<Workshop> builder)
    {
        builder.ToTable("Workshops");
        builder.HasKey(w => w.Id);
        builder.Property(w => w.Title).IsRequired().HasMaxLength(120);
        builder.Property(w => w.Description).HasMaxLength(2000);
        builder.Property(w => w.Location).HasMaxLength(200);
        builder.Property(w => w.Capacity).HasDefaultValue(1);
        builder.HasIndex(w => w.StartAt);
    }
}
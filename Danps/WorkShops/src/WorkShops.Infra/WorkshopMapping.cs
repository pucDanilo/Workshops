using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshops.Domain.Models;

namespace Workshops.Infrastructure.Context;

public class WorkshopMapping : IEntityTypeConfiguration<Workshop>
{
    public void Configure(EntityTypeBuilder<Workshop> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(w => w.Title).IsRequired().HasMaxLength(120);
        builder.Property(w => w.Description).HasMaxLength(2000);
        builder.Property(w => w.Location).HasMaxLength(200);
        builder.Property(w => w.Capacity).HasDefaultValue(1);
        builder.HasIndex(w => w.StartAt);

        builder.ToTable("Workshops");
    }
}
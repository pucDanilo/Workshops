using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop10_API.Api.Models;

namespace Workshop10_API.Api.Infrastructure.Data;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");
        builder.HasKey(w => w.Id);
        builder.Property(w => w.Name).IsRequired().HasMaxLength(120);
        builder.Property(w => w.Password).IsRequired().HasMaxLength(120);
    }
}

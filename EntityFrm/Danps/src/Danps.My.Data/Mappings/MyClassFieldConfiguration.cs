using Danps.Core.Data;
using Danps.My.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Danps.My.Data.Mappings
{
    public class MyClassFieldConfiguration : IEntityTypeConfiguration<MyClassField>
    {
        public void Configure(EntityTypeBuilder<MyClassField> builder)
        {
            builder.ToTable("my_class_field");
            builder.HasKey(c => c.Id);
            builder.Property(t => t.Id).HasColumnName("seq_my_class_field");
            builder.Property(t => t.column_id).IsRequired().HasColumnName("column_id");
            builder.Property(t => t.column_name).HasColumnName("column_name").IsRequired().HasMaxLength(255);
            builder.Property(t => t.object_name).HasColumnName("object_name").IsRequired().HasMaxLength(500);
            builder.Property(t => t.clr_type).HasColumnName("clr_type").IsRequired().HasMaxLength(255);
            builder.Property(t => t.column_type).HasColumnName("column_type").IsRequired().HasMaxLength(255);
            builder.Property(t => t.max_length).HasColumnName("max_length");
            builder.Property(t => t.is_primary_key).IsRequired().HasColumnName("is_primary_key");
            builder.Property(t => t.OwnsOne).HasColumnName("nom_ownsOne").HasMaxLength(255);
            builder.Property(t => t.MyClassId).HasColumnName("seq_my_class");
            builder.ConfigureAudit();
        }
    }
}
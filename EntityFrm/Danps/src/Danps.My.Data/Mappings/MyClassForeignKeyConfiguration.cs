using Danps.Core.Data;
using Danps.My.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Danps.My.Data.Mappings
{
    public class MyClassForeignKeyConfiguration : IEntityTypeConfiguration<MyClassForeignKey>
    {
        public void Configure(EntityTypeBuilder<MyClassForeignKey> builder)
        {
            builder.ToTable("my_class_foreign_key");
            builder.HasKey(c => c.Id);
            builder.Property(t => t.Id).HasColumnName("seq_my_class_foreign_key");
            builder.Property(t => t.column_name).HasColumnName("column_name").IsRequired().HasMaxLength(255);
            builder.Property(t => t.table_name).HasColumnName("table_name").IsRequired().HasMaxLength(255);
            builder.Property(t => t.reference_name).HasColumnName("reference_name").IsRequired().HasMaxLength(255);
            builder.Property(t => t.MyClassId).HasColumnName("seq_my_class");
            builder.ConfigureAudit();
        }
    }
}
using Danps.Core.Data;
using Danps.My.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Danps.My.Data.Mappings
{
    public class MyClassConfiguration : IEntityTypeConfiguration<MyClass>
    {
        public void Configure(EntityTypeBuilder<MyClass> builder)
        {
            builder.ToTable("my_class");
            builder.HasKey(c => c.Id);
            builder.Property(t => t.Id).HasColumnName("seq_my_class");
            builder.Property(t => t.NomeTabela).HasColumnName("table_name").IsRequired().HasMaxLength(255);
            builder.Property(t => t.Nome).HasColumnName("class_name").IsRequired().HasMaxLength(255);
            builder.Property(t => t.NomeColuna).HasColumnName("pk_column_name").IsRequired().HasMaxLength(255);
            builder.Property(t => t.NomeChavePrimaria).HasColumnName("pk_name").IsRequired().HasMaxLength(255);
            builder.ConfigureAudit();
        }
    }
}
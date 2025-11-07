using Danps.Core.Data;
using Danps.My.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Danps.My.Data.Mappings
{
    public class MyReplaceConfiguration : IEntityTypeConfiguration<MyReplace>
    {
        public void Configure(EntityTypeBuilder<MyReplace> builder)
        {
            builder.ToTable("my_replace");
            builder.HasKey(c => c.Id);
            builder.Property(t => t.Id).HasColumnName("seq_my_replace");
            builder.Property(t => t.Entrada).HasColumnName("dsc_entrada").IsRequired().HasMaxLength(255);
            builder.Property(t => t.Saida).HasColumnName("dsc_saida").IsRequired().HasMaxLength(255);
            builder.ConfigureAudit();
        }
    }
}
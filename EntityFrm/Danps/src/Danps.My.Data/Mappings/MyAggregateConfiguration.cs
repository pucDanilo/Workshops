using Danps.Core.Data;
using Danps.My.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Danps.My.Data.Mappings
{
    public class MyAggregateConfiguration : IEntityTypeConfiguration<MyAggregate>
    {
        public void Configure(EntityTypeBuilder<MyAggregate> builder)
        {
            builder.ToTable("my_aggregate");
            builder.HasKey(c => c.Id);
            builder.Property(t => t.Id).HasColumnName("seq_my_aggregate_root");

            builder.Property(t => t.Area).HasColumnName("nom_aggregate").IsRequired().HasMaxLength(255);
            builder.Property(t => t.Projeto).HasColumnName("nom_projeto").IsRequired().HasMaxLength(255);
            builder.Property(t => t.CoreDomain).HasColumnName("nom_core_domain").IsRequired().HasMaxLength(255);
            builder.Property(t => t.NomeInterface).HasColumnName("nom_interface").HasMaxLength(255);
            builder.ConfigureAudit();
        }
    }
}
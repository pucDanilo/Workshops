
using Danps.Core.Data;
using Danps.My.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Danps.My.Data.Mappings
{
    public class MyAggregateClassConfiguration : IEntityTypeConfiguration<MyAggregateClass>
    {
        public void Configure(EntityTypeBuilder<MyAggregateClass> builder)
        {
            builder.ToTable("my_aggregate_class");
            builder.HasKey(c => c.Id);
            builder.Property(t => t.Id).HasColumnName("seq_my_aggregate_class");
            builder.Property(t => t.Principal).HasColumnName("idt_aggregate_root").IsRequired();
            builder.Property(t => t.MyAggregateId).HasColumnName("seq_my_aggregate");
            builder.Property(t => t.MyClassId).HasColumnName("seq_my_class");
            builder.ConfigureAudit();
        }
    }
}
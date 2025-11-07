using Danps.Core.Data;
using Danps.My.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Danps.My.Data.Mappings
{
    public class MyTagConfiguration : IEntityTypeConfiguration<MyTag>
    {
        public void Configure(EntityTypeBuilder<MyTag> builder)
        {
            builder.ToTable("my_tag");
            builder.HasKey(c => c.Id);
            builder.Property(t => t.Id).HasColumnName("seq_my_tag");
            builder.Property(t => t.Token).HasColumnName("dsc_my_tag").IsRequired().HasMaxLength(50);
            builder.OwnsOne(c => c.Objeto, cm =>
            {
                cm.Property(c => c.Nome).HasColumnName("nom_objeto_origem").HasMaxLength(100);
                cm.Property(c => c.Propriedade).HasColumnName("nom_propriedade_origem").HasMaxLength(255);
            });

            builder.Property(t => t.ModeloId).HasColumnName("seq_my_modelo").IsRequired();

            builder.Property(t => t.ModeloSecundarioId).HasColumnName("seq_my_modelo_2");

            builder.ConfigureAudit();
        }
    }
}
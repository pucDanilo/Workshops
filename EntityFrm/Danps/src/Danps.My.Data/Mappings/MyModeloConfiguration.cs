using Danps.Core.Data;
using Danps.My.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Danps.My.Data.Mappings
{
    public class MyModeloConfiguration : IEntityTypeConfiguration<MyModelo>
    {
        public void Configure(EntityTypeBuilder<MyModelo> builder)
        {
            builder.ToTable("my_modelo");
            builder.HasKey(c => c.Id);
            builder.Property(t => t.Id).HasColumnName("seq_my_modelo");
            builder.Property(t => t.Nome).HasColumnName("dsc_my_modelo").HasColumnType("varchar").IsRequired().HasMaxLength(255);
            builder.Property(t => t.Mensagem).HasColumnName("dsc_mensagem").IsRequired();
            builder.Property(t => t.Concatenador).HasColumnName("val_concatenador").HasMaxLength(15);
            builder.OwnsOne(c => c.Remetente, cm =>
            {
                cm.Property(c => c.Assunto).HasColumnName("dsc_assunto").HasMaxLength(255);
                cm.Property(c => c.Nome).HasColumnName("nom_remetente").HasMaxLength(255);
                cm.Property(c => c.Email).HasColumnName("dsc_email_remetente").HasMaxLength(255);
            });

            builder.ConfigureAudit();
        }
    }
}
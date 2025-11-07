using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PocketApp.Domain;

namespace PocketApp.Mappings
{
    public class MovimentacaoMapping : IEntityTypeConfiguration<Movimentacao>
    {
        public void Configure(EntityTypeBuilder<Movimentacao> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(t => t.Id).HasColumnName("seq_transaction");
            builder.Property(t => t.Data).HasColumnName("dat_transaction");
            builder.Property(c => c.Descricao).HasColumnName("dsc_transaction").IsRequired().HasColumnType("varchar(255)");
            builder.Property(c => c.Valor).HasColumnName("val_transaction").IsRequired().HasColumnType("decimal(9,2)");
            builder.Property(c => c.Tag).HasColumnName("dsc_tag");
            builder.Property(c => c.FluxoCaixaId).HasColumnName("seq_cash_flow");
            builder.ToTable("transaction");
        }
    }
}
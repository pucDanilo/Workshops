using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PocketApp.Domain;

namespace PocketApp.Mappings
{
    public class FluxoCaixaMapping : IEntityTypeConfiguration<FluxoCaixa>
    {
        public void Configure(EntityTypeBuilder<FluxoCaixa> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(t => t.Id).HasColumnName("seq_cash_flow");
            builder.Property(t => t.LocatarioId).HasColumnName("seq_tenant");
            builder.Property(c => c.Nome).HasColumnName("nom_cash_flow").IsRequired().HasColumnType("varchar(255)");
            builder.Property(c => c.Saldo).HasColumnName("val_cash_flow").IsRequired().HasColumnType("decimal(9,2)");
            builder.Property(c => c.SaldoAnterior).HasColumnName("val_init_cash_flow").IsRequired().HasColumnType("decimal(9,2)");
            builder.Property(c => c.TipoCategoria).HasColumnName("idt_category");

            builder.HasMany(f => f.Movimentacoes).WithOne(p => p.FluxoCaixa).HasForeignKey(p => p.FluxoCaixaId);

            builder.ToTable("cash_flow");
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Mappings
{
    public class CertificadoMapping : IEntityTypeConfiguration<Certificado>
    {
        public void Configure(EntityTypeBuilder<Certificado> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(t => t.seq_certificadora).HasColumnName("seq_certificadora");
            builder.Property(t => t.seq_participante).HasColumnName("seq_participante");
            builder.Property(t => t.dat_inicio).HasColumnName("dat_inicio");
            builder.Property(t => t.dat_fim).HasColumnName("dat_fim");
            builder.Property(t => t.dat_inclusao).HasColumnName("dat_inclusao");
            builder.Property(t => t.usu_inclusao).HasColumnName("usu_inclusao");
            builder.Property(t => t.dat_alteracao).HasColumnName("dat_alteracao");
            builder.Property(t => t.usu_alteracao).HasColumnName("usu_alteracao");
            builder.Property(t => t.cod_emissao_1).HasColumnName("cod_emissao_1");
            builder.Property(t => t.cod_emissao_2).HasColumnName("cod_emissao_2");
            builder.Property(t => t.num_pedido).HasColumnName("num_pedido");
            builder.Property(t => t.dsc_email).HasColumnName("dsc_email");
            builder.Property(t => t.seq_unidade).HasColumnName("seq_unidade");
            builder.Property(t => t.cod_ccusto_ems).HasColumnName("cod_ccusto_ems");
            builder.Property(t => t.cod_lote).HasColumnName("cod_lote");
            builder.Property(t => t.seq_certificado).HasColumnName("seq_certificado");
            builder.ToTable("Certificado");
        }
    }
}
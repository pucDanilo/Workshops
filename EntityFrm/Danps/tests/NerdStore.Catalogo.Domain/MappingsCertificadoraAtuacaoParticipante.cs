using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Mappings
{
    public class CertificadoraAtuacaoParticipanteMapping : IEntityTypeConfiguration<CertificadoraAtuacaoParticipante>
    {
        public void Configure(EntityTypeBuilder<CertificadoraAtuacaoParticipante> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(t => t.seq_certificadora).HasColumnName("seq_certificadora");
            builder.Property(t => t.dsc_token_atuacao).HasColumnName("dsc_token_atuacao");
            builder.Property(t => t.dsc_atuacao_participante).HasColumnName("dsc_atuacao_participante");
            builder.Property(t => t.dat_inclusao).HasColumnName("dat_inclusao");
            builder.Property(t => t.usu_inclusao).HasColumnName("usu_inclusao");
            builder.Property(t => t.dat_alteracao).HasColumnName("dat_alteracao");
            builder.Property(t => t.usu_alteracao).HasColumnName("usu_alteracao");
            builder.Property(t => t.seq_certificadora_atuacao_participante).HasColumnName("seq_certificadora_atuacao_participante");
            builder.ToTable("CertificadoraAtuacaoParticipante");
        }
    }
}
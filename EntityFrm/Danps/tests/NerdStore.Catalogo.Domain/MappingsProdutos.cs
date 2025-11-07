using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Mappings
{
    public class ProdutosMapping : IEntityTypeConfiguration<Produtos>
    {
        public void Configure(EntityTypeBuilder<Produtos> builder)
        {
            builder.Property(t => t.CategoriaId).HasColumnName("CategoriaId");
            builder.Property(t => t.Nome).HasColumnName("Nome");
            builder.Property(t => t.Descricao).HasColumnName("Descricao");
            builder.Property(t => t.Ativo).HasColumnName("Ativo");
            builder.Property(t => t.Valor).HasColumnName("Valor");
            builder.Property(t => t.DataCadastro).HasColumnName("DataCadastro");
            builder.Property(t => t.Imagem).HasColumnName("Imagem");
            builder.Property(t => t.QuantidadeEstoque).HasColumnName("QuantidadeEstoque");
            builder.Property(t => t.Altura).HasColumnName("Altura");
            builder.Property(t => t.Largura).HasColumnName("Largura");
            builder.Property(t => t.Profundidade).HasColumnName("Profundidade");
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.ToTable("Produtos");
        }
    }
}
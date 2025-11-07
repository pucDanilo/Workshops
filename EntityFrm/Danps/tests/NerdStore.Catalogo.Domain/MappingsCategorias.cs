using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Mappings
{
    public class CategoriasMapping : IEntityTypeConfiguration<Categorias>
    {
        public void Configure(EntityTypeBuilder<Categorias> builder)
        {
            builder.Property(t => t.Nome).HasColumnName("Nome");
            builder.Property(t => t.Codigo).HasColumnName("Codigo");
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.ToTable("Categorias");
        }
    }
}
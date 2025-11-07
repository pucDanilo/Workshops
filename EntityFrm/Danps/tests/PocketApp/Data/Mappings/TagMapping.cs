using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PocketApp.Domain;

namespace PocketApp.Mappings
{
    /*
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(t => t.Id).HasColumnName("seq_category");
            builder.Property(t => t.Codigo).HasColumnName("idt_tipo_categoria");
            builder.Property(c => c.Nome).HasColumnName("nom_category").IsRequired().HasColumnType("varchar(255)");

            builder.HasMany(f => f.Caixas).WithOne(p => p.Categoria).HasForeignKey(p => p.CategoriaId);

            builder.ToTable("category");
        }
    }
    */

    public class TagMapping : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(t => t.Id).HasColumnName("seq_tag");
            builder.Property(t => t.Codigo).HasColumnName("idt_tag");
            builder.Property(c => c.Nome).HasColumnName("nom_tag").IsRequired().HasColumnType("varchar(255)");
            builder.ToTable("tag");
        }
    }
}
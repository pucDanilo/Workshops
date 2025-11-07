using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PocketApp.Domain;

namespace PocketApp.Mappings
{
    public class LocatarioMapping : IEntityTypeConfiguration<Locatario>
    {
        public void Configure(EntityTypeBuilder<Locatario> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(t => t.Id).HasColumnName("seq_tenant"); 
            builder.Property(c => c.Nome).HasColumnName("nom_tenant").IsRequired().HasColumnType("varchar(255)");
            builder.Property(c => c.Token).HasColumnName("dsc_token_tenant").IsRequired();
            builder.ToTable("tenant");
        }
    }
}
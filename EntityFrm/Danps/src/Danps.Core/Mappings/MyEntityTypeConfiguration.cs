using Danps.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Danps.Core.Data
{
    public static class MyEntityTypeConfiguration
    {
        public static void ConfigureAudit<T>(this EntityTypeBuilder<T> builder) where T : EntityAudit
        {
            builder.Property(t => t.DataInclusao).HasColumnName("dat_inclusao").HasColumnType("datetime");
            builder.Property(t => t.UsuarioInclusao).IsRequired().HasMaxLength(60).HasColumnName("usu_inclusao").HasColumnType("varchar");
            builder.Property(t => t.DataAlteracao).HasColumnName("dat_alteracao").HasColumnType("datetime");
            builder.Property(t => t.UsuarioAlteracao).HasMaxLength(60).HasColumnName("usu_alteracao").HasColumnType("varchar");
        }
    }
}
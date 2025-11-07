using Danps.My.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Danps.My.Data.Mappings
{
    public class MySqlObjectConfiguration : IEntityTypeConfiguration<MySqlObject>
    {
        public void Configure(EntityTypeBuilder<MySqlObject> builder)
        {
            builder.ToView("my_sql_object").HasNoKey();
            builder.Property(t => t.ObjectName).HasColumnName("ObjectName");
            builder.Property(t => t.Definition).HasColumnName("definition");
            builder.Property(t => t.ObjectType).HasColumnName("ObjectType");
            builder.Property(t => t.ObjectDrop).HasColumnName("ObjectDrop");
        }
    }


}
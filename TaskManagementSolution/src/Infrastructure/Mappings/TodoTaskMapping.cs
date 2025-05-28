using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class TodoTaskMapping : IEntityTypeConfiguration<TodoTask>
    {
        public void Configure(EntityTypeBuilder<TodoTask> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(c => c.Title).IsRequired().HasColumnType("varchar(200)");

            builder.Property(c => c.DueDate).IsRequired();

            builder.Property(c => c.IsCompleted).IsRequired();

            builder.ToTable("TodoTasks");
        }
    }
}
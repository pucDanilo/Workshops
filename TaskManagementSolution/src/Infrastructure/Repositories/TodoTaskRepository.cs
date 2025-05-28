using Domain;
using Domain.Entities;
using Infrastructure.Core;

namespace Infrastructure.Repositories;

public class TodoTaskRepository : Repository<TodoTask>, ITodoTaskRepository
{
    public TodoTaskRepository(MeuDbContext db) : base(db)
    {
    }

    public Task<IEnumerable<TodoTask>> GetOverdueTasks() => Find(a => a.DueDate <= DateTime.Now);
}
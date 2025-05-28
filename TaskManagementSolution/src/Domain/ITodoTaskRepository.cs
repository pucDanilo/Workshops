using Domain.Core;
using Domain.Entities;

namespace Domain;

public interface ITodoTaskRepository : IRepository<TodoTask>
{
    Task<IEnumerable<TodoTask>> GetOverdueTasks();
}